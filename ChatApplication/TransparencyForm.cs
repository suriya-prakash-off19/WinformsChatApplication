using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class TransparencyForm : Form
    {
        private new bool Load;
        public TransparencyForm(bool load)
        {
            InitializeComponent();
            AllowTransparency = true;
            Opacity = 0.7;
            WindowState = FormWindowState.Maximized;
            BackColor = Color.Black;
            Load = load;
            ShowInTaskbar = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if(Load)
            {
                LoadingPage loadingPage = new LoadingPage();
                loadingPage.ShowDialog();
                loadingPage.Close();
                Close();
            }
        }
    }
}
