using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class Notification : Form
    {
        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private Notification.enmAction action;

        public Notification()
        {
            InitializeComponent();
            BackColor = Color.MistyRose;
            TransparencyKey = Color.MistyRose;
            label1.BackColor = Color.FromArgb(255, 58, 110, 210);
            label2.BackColor = Color.FromArgb(255, 58, 110, 210);
            pictureBox1.BackColor = Color.FromArgb(255, 58, 110, 210);
            ShowInTaskbar = false;
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    closeTimer.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    this.closeTimer.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    closeTimer.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }

        }

        private Timer closeTimer;
        public int BorderSize { get; set; } = 3;
        public int BorderRadius { get; set; } = 20;
        public Color BorderColor { get; set; } = Color.Black;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF surfaceRec = new RectangleF(BorderSize / 2, BorderSize / 2, Width - 1F, Height - BorderSize);
            RectangleF borderRec = new RectangleF(BorderSize / 2, BorderSize / 2, Width - 1F - BorderSize / 2, Height - BorderSize / 2 - 1F);

            using (GraphicsPath surfacePath = CreateRoundedRectanglePath(surfaceRec, Height))
            using (GraphicsPath borderPath = CreateRoundedRectanglePath(borderRec, Height))
            using (Brush brushSurface = new SolidBrush(Color.FromArgb(255, 58, 110, 210)))
            using (Pen penBorder = new Pen(BorderColor, BorderSize))
            {
                e.Graphics.FillPath(brushSurface, surfacePath);
                if (BorderSize >= 1)
                {
                    e.Graphics.DrawPath(penBorder, borderPath);
                }
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(RectangleF rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int CornerRadius = radius - BorderSize - 2;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(rect.Width - CornerRadius, rect.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(rect.Width - CornerRadius, rect.Height - CornerRadius, CornerRadius, CornerRadius - 1, 0, 90);
            path.AddArc(rect.X, rect.Height - CornerRadius, CornerRadius, CornerRadius - 1, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            action = enmAction.close;
            closeTimer.Interval = 1;
            closeTimer.Stop();
            closeTimer.Start();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }


        private int x, y;
        public void showAlert(string ip, string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Notification frm = (Notification)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            this.action = enmAction.start;
            closeTimer = new Timer()
            {
                Interval = 1
            };
            label1.Text = ip;
            label2.Text = msg;
            closeTimer.Tick += CloseTimer_Tick;
            closeTimer.Start();
        }
    }
}
