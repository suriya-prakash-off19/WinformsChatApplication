namespace ChatApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Signal = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundedPanel3 = new CustomControls.RoundedPanel();
            this.MessageHolder = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.messageBar1 = new CustomControls.MessageBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedPanel2 = new CustomControls.RoundedPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.roundedPanel4 = new CustomControls.RoundedPanel();
            this.pictureButton1 = new CustomControls.PictureButton();
            this.roundedPanel1 = new CustomControls.RoundedPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Date = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.roundedPanel3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.roundedPanel2.SuspendLayout();
            this.roundedPanel4.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Signal
            // 
            this.Signal.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Signal.BalloonTipTitle = "Hi";
            this.Signal.ContextMenuStrip = this.contextMenuStrip1;
            this.Signal.Icon = ((System.Drawing.Icon)(resources.GetObject("Signal.Icon")));
            this.Signal.Text = "Signal";
            this.Signal.Visible = true;
            this.Signal.DoubleClick += new System.EventHandler(this.Signal_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // roundedPanel3
            // 
            this.roundedPanel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roundedPanel3.BorderRadius = 0;
            this.roundedPanel3.Controls.Add(this.MessageHolder);
            this.roundedPanel3.Controls.Add(this.panel3);
            this.roundedPanel3.Controls.Add(this.panel1);
            this.roundedPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roundedPanel3.Location = new System.Drawing.Point(256, 57);
            this.roundedPanel3.Name = "roundedPanel3";
            this.roundedPanel3.Size = new System.Drawing.Size(963, 588);
            this.roundedPanel3.TabIndex = 2;
            // 
            // MessageHolder
            // 
            this.MessageHolder.AutoScroll = true;
            this.MessageHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageHolder.Location = new System.Drawing.Point(0, 38);
            this.MessageHolder.Name = "MessageHolder";
            this.MessageHolder.Size = new System.Drawing.Size(963, 490);
            this.MessageHolder.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.messageBar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 528);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(963, 60);
            this.panel3.TabIndex = 3;
            // 
            // messageBar1
            // 
            this.messageBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(130)))), ((int)(((byte)(220)))));
            this.messageBar1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.messageBar1.Location = new System.Drawing.Point(273, 3);
            this.messageBar1.MsgFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBar1.MsgText = "";
            this.messageBar1.Name = "messageBar1";
            this.messageBar1.Padding = new System.Windows.Forms.Padding(10, 5, 2, 2);
            this.messageBar1.Size = new System.Drawing.Size(446, 38);
            this.messageBar1.TabIndex = 1;
            this.messageBar1.SendClicked += new System.EventHandler(this.messageBar1_SendClicked);
            this.messageBar1.Load += new System.EventHandler(this.messageBar1_Load);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(130)))), ((int)(((byte)(220)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(963, 38);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(15, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(201, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // roundedPanel2
            // 
            this.roundedPanel2.BorderRadius = 0;
            this.roundedPanel2.Controls.Add(this.flowLayoutPanel1);
            this.roundedPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.roundedPanel2.Location = new System.Drawing.Point(46, 57);
            this.roundedPanel2.Name = "roundedPanel2";
            this.roundedPanel2.Size = new System.Drawing.Size(210, 588);
            this.roundedPanel2.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(210, 588);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // roundedPanel4
            // 
            this.roundedPanel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.roundedPanel4.BorderRadius = 0;
            this.roundedPanel4.Controls.Add(this.pictureButton1);
            this.roundedPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.roundedPanel4.Location = new System.Drawing.Point(2, 57);
            this.roundedPanel4.Name = "roundedPanel4";
            this.roundedPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.roundedPanel4.Size = new System.Drawing.Size(44, 588);
            this.roundedPanel4.TabIndex = 3;
            // 
            // pictureButton1
            // 
            this.pictureButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureButton1.IsBordered = false;
            this.pictureButton1.Location = new System.Drawing.Point(1, 1);
            this.pictureButton1.Name = "pictureButton1";
            this.pictureButton1.Padding = new System.Windows.Forms.Padding(5);
            this.pictureButton1.Picture = null;
            this.pictureButton1.Size = new System.Drawing.Size(42, 37);
            this.pictureButton1.TabIndex = 0;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(118)))), ((int)(((byte)(240)))));
            this.roundedPanel1.BorderRadius = 0;
            this.roundedPanel1.Controls.Add(this.pictureBox1);
            this.roundedPanel1.Controls.Add(this.Date);
            this.roundedPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.roundedPanel1.Location = new System.Drawing.Point(2, 2);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(1217, 55);
            this.roundedPanel1.TabIndex = 0;
            this.roundedPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.roundedPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.roundedPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Image = global::ChatApplication.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(1180, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Date
            // 
            this.Date.Dock = System.Windows.Forms.DockStyle.Left;
            this.Date.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Date.Location = new System.Drawing.Point(0, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(211, 55);
            this.Date.TabIndex = 0;
            this.Date.Text = "label1";
            this.Date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 647);
            this.Controls.Add(this.roundedPanel3);
            this.Controls.Add(this.roundedPanel2);
            this.Controls.Add(this.roundedPanel4);
            this.Controls.Add(this.roundedPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.roundedPanel3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.roundedPanel2.ResumeLayout(false);
            this.roundedPanel4.ResumeLayout(false);
            this.roundedPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomControls.RoundedPanel roundedPanel1;
        private CustomControls.RoundedPanel roundedPanel2;
        private CustomControls.RoundedPanel roundedPanel3;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControls.RoundedPanel roundedPanel4;
        private CustomControls.PictureButton pictureButton1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MessageHolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private CustomControls.MessageBar messageBar1;
        private System.Windows.Forms.NotifyIcon Signal;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

