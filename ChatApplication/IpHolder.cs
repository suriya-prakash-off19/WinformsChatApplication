using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    
    public partial class IpHolder : UserControl
    {
        public static List<IpHolder> Holders = new List<IpHolder>();
        public IpHolder(string text)
        {
            InitializeComponent();
            label1.Text = text;
            Holders.Add(this);
            Disposed += IpHolder_Disposed;
            HasMessage = false;
        }

        private void IpHolder_Disposed(object sender, EventArgs e)
        {
            Holders.Remove(this);
        }

        private bool isSelected;
        private bool hasMessage;

        [Browsable(true)]
        [Category("Holder")]
        public Font HolderFont
        {
            get => label1.Font;
            set => label1.Font = value;
        }

        [Browsable(true)]
        [Category("Holder")]
        public string HolderText
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        [Browsable(true)]
        [Category("Holder")]
        public Image HolderPic
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
        [Browsable(true)]
        [Category("Holder")]
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                if(value==true)
                {
                    BorderStyle = BorderStyle.FixedSingle;
                }
                else
                {
                    BorderStyle = BorderStyle.None;
                }
                
            }
        }
        [Browsable(true)]
        [Category("Holder")]
        public bool HasMessage
        {
            get => hasMessage;
            set
            {
                hasMessage = value;
                panel1.Visible = value;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            OnClick(e);
            foreach(var s in Holders)
            {
                s.IsSelected = false;
            }
            IsSelected = true;
            HasMessage = false;
        }
    }
}
