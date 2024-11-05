using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControls;

namespace ChatApplication
{

    public partial class Form1 : Form
    {
        private Dictionary<string, string> messageSaver;
        private Socket serverSocket,ClientSocket;
        private Dictionary<string, IpHolder> messagePairs;
        private Timer DateTimer;
        private byte[] buffer;
        private List<string> list;
        private bool move = false;
        private Point preLoc;
        private string messageSend ="";

        public Form1()
        {
            InitializeComponent();
            Icon = new Icon("signal-app-icon.ico");
            messageSaver = new Dictionary<string, string>();
            messagePairs = new Dictionary<string, IpHolder>();
            list = new List<string>();
            buffer = new byte[1024];
            TimeLabel();
            ListOfIps();
            StartServer();
            Intro();
        }
        
        private void IpHolder_Click(object sender, EventArgs e)
        {
            IpHolder ipHolder = sender as IpHolder;
            label1.Text = ipHolder.HolderText;
            LoadData(label1.Text);
        }
        
        private void DateTimer_Tick(object sender, EventArgs e)
        {
            Date.Text = DateTime.Now.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hide();
            ShowInTaskbar = false;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            preLoc = e.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                Location = new Point(this.Location.X + e.Location.X - preLoc.X, this.Location.Y + e.Location.Y - preLoc.Y);
            }
        }

        private void messageBar1_SendClicked(object sender, EventArgs e)
        {
            messageSend = messageBar1.MsgText;
            BroadcastMessage(messageSend);
            
        }

        private void AddIps()
        {
            int x = 0;
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is IpHolder)
                {
                    var temp = control as IpHolder;
                    try
                    {
                        temp.Show();
                        temp.HolderText = list[x];
                    }
                    catch
                    {
                        temp.Hide();
                    }
                    if (!messageSaver.ContainsKey(list[x]))
                        messageSaver.Add(list[x], "");
                    if (!messagePairs.ContainsKey(list[x]))
                        messagePairs.Add(list[x], control as IpHolder);
                    x++;

                }
            }
        }

        private async void ListOfIps()
        {
            //ProcessStartInfo processInfo = new ProcessStartInfo
            //{
            //    FileName = "cmd.exe",
            //    Arguments = "/c arp -a",
            //    RedirectStandardOutput = true,
            //    RedirectStandardError = true,
            //    UseShellExecute = false,
            //    CreateNoWindow = false,
            //    WorkingDirectory = @"D:\\"
            //};

            //using (Process process = new Process { StartInfo = processInfo })
            //{
            //    process.Start();

            //    process.WaitForExit();
            //    string output = process.StandardOutput.ReadToEnd();
            //    Regex regex = new Regex(@"(\d{1,3}\.){3}\d{1,3}");


            //    foreach (Match match in regex.Matches(output))
            //    {
            //        list.Add(match.Value);
            //    }
            //    list.RemoveAt(0);
            //}

            string baseIP = "192.168.3";
            int startRange = 1;
            int endRange = 254;

            list= await GetIPAddressesFromPingAsync(baseIP, startRange, endRange);
            list = list.OrderBy(x => Convert.ToInt32(x.Split('.')[3])).ToList();
            label1.Text = list[0];
            AddPanels();
            AddIps();
        }
        
        private void TimeLabel()
        {
            DateTimer = new Timer();
            DateTimer.Interval = 10;
            DateTimer.Tick += DateTimer_Tick;
            DateTimer.Start();
        }

        private void Intro()
        {
            this.Hide();
            TransparencyForm loadingPage = new TransparencyForm(true);
            loadingPage.ShowDialog();
            this.Show();
        }

        private void AddPanels()
        {
            for (int i = 0; i < list.Count; i++)
            {
                IpHolder ipHolder = new IpHolder("");
                ipHolder.Name = "Control" + (1 + i);
                flowLayoutPanel1.Controls.Add(ipHolder);
                ipHolder.Dock = DockStyle.Top;
                ipHolder.Click += IpHolder_Click;
            }
        }
        
        private void StartServer()
        {
            try
            {
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                string localIP = GetLocalIPAddress();
                serverSocket.Bind(new IPEndPoint(IPAddress.Parse(localIP), 22334));
                serverSocket.Listen(10);
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            try
            {
                Socket clientSocket = serverSocket.EndAccept(ar);

                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), clientSocket);
                
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallBack), null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            Socket currentClient = (Socket)ar.AsyncState;
            try
            {
                int received = currentClient.EndReceive(ar);
                if (received == 0)
                {
                    currentClient.Disconnect(false);
                    return;
                }
                IPEndPoint ip = currentClient.RemoteEndPoint as IPEndPoint;
                byte[] dataBuffer = new byte[received];
                Array.Copy(buffer, dataBuffer, received);
                string text = Encoding.ASCII.GetString(dataBuffer);
                BeginInvoke((MethodInvoker)delegate
                {
                    if(ip.Address.ToString()!=label1.Text)
                        messagePairs[ip.Address.ToString()].HasMessage = true;
                });
                valueSetter(text,ip.Address.ToString());
                currentClient.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), currentClient);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool BroadcastMessage(string text)
        {
            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.BeginConnect(new IPEndPoint(IPAddress.Parse(label1.Text), 22334), new AsyncCallback(ConnectCallBack), null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
            
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                ClientSocket.EndConnect(ar);

                byte[] buffer = Encoding.ASCII.GetBytes(messageSend);
                ClientSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(SendCallBack), null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SendCallBack(IAsyncResult ar)
        {
            try
            {
                ClientSocket.EndSend(ar);
                Notification notification = new Notification();
                notification.showAlert("192.168.3.32", "", Notification.enmType.Info);
                notification.Show();

                if (ClientSocket != null && ClientSocket.Connected)
                {
                    try
                    {
                        ClientSocket.Shutdown(SocketShutdown.Both); 
                        ClientSocket.Disconnect(false); 
                    }
                    catch (SocketException ex)
                    {
                        
                    }
                    finally
                    {
                        ClientSocket.Close(); 
                        ClientSocket.Dispose();
                    }
                }
                BeginInvoke((MethodInvoker)delegate
                {
                    messageSaver[label1.Text] += "Me : " + messageSend + "\n";
                    LoadData(label1.Text);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void valueSetter(string text,string ip)
        {
            MethodInvoker methodInvoker = new MethodInvoker(() =>
              {
                  messageSaver[ip] += "Client : " + text + "\n";
                  if (label1.Text == ip && this.Visible)
                      LoadData(ip);
                  else
                  {
                      Notification notification = new Notification();
                      notification.showAlert(ip, text, Notification.enmType.Info);
                      notification.Show();
                  }
                  DataManager.SetData(ip, text, MessageType.Receive);
              });
            Invoke(methodInvoker);
        }
        
        private void messageBar1_Load(object sender, EventArgs e)
        {

        }

        public static string GetLocalIPAddress()
        {
            var x = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            ShowIcon = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Signal_DoubleClick(object sender, EventArgs e)
        {
            Show();
            ShowIcon = true;
        }

        public static async Task<List<string>> GetIPAddressesFromPingAsync(string baseIP, int startRange, int endRange)
        {
            List<string> activeIPs = new List<string>();
            List<Task> pingTasks = new List<Task>();
            string localIP = GetLocalIPAddress();
            for (int i = startRange; i <= endRange; i++)
            {
                string ip = $"{baseIP}.{i}";
                pingTasks.Add(Task.Run(async () =>
                {
                    Ping ping = new Ping();
                    try
                    {
                        PingReply reply = await ping.SendPingAsync(ip, 100);
                        if (reply.Status == IPStatus.Success)
                        {
                            lock (activeIPs)
                            {
                                activeIPs.Add(ip);
                            }
                        }
                    }
                    catch { }
                }));
            }

            await Task.WhenAll(pingTasks);
            return activeIPs;
        }




        private void LoadData(string ip)
        {
            string messages = messageSaver[ip];
            MessageHolder.Controls.Clear();
            foreach(string val in messages.Split('\n'))
            {
                MsgBox msgBox = new MsgBox();
                var x = val.Split(':');
                if (x.Length!=2)
                    continue;
                if(x[0].Trim().Equals("Me"))
                {
                    msgBox.Direction = DesignDirection.Right;
                }
                else
                {
                    msgBox.Direction = DesignDirection.Left;
                }
                msgBox.TextData = x[1].Trim();
                msgBox.MessageColor = Color.LightBlue;
                msgBox.Dock = DockStyle.Bottom;
                MessageHolder.Controls.Add(msgBox);
            }
        }

    }
}
