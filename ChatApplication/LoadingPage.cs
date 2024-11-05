using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;

namespace ChatApplication
{
    public partial class LoadingPage : Form
    {
        private Timer timer;
        private int panelWidth;
        public LoadingPage()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10;
            panelWidth = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
            DoubleBuffered = true;
            this.ShowInTaskbar = false;
            //AddService();

            
        }

        private void AddService()
        {
            string service = "AndavanSonan";
            try
            {
                ServiceController controller = new ServiceController(service);

                if(controller.Status==ServiceControllerStatus.Stopped)
                {
                    controller.Start();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.SuspendLayout();
            panelWidth += 2;
            if (panelWidth > LoadingPanel.Width)
            {
                timer.Stop();
                this.Close();
            }
            LoadingPanel.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            Rectangle rectangle = new Rectangle(0, 0, panelWidth, LoadingPanel.Height);
            LoadingPanel.Region = new Region(rectangle);
            e.Graphics.FillRectangle(Brushes.Green, rectangle);
            this.ResumeLayout();
        }
    }
}
