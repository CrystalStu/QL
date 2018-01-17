namespace Launcher
{
    partial class Launcher
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
            this.lb_title = new System.Windows.Forms.Label();
            this.list_usb = new System.Windows.Forms.ListBox();
            this.lb_zmessage_list_usb = new System.Windows.Forms.Label();
            this.bt_usb_eject = new System.Windows.Forms.Button();
            this.bt_usb_browse = new System.Windows.Forms.Button();
            this.bt_usb_clear = new System.Windows.Forms.Button();
            this.bt_browse_public = new System.Windows.Forms.Button();
            this.bt_open_all = new System.Windows.Forms.Button();
            this.bt_copyright = new System.Windows.Forms.Button();
            this.timer_Desktop = new System.Windows.Forms.Timer(this.components);
            this.lb_remain_notice = new System.Windows.Forms.Label();
            this.lb_remain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.BackColor = System.Drawing.Color.Transparent;
            this.lb_title.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_title.ForeColor = System.Drawing.Color.White;
            this.lb_title.Location = new System.Drawing.Point(5, 9);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(212, 37);
            this.lb_title.TabIndex = 0;
            this.lb_title.Text = "Quick Launcher";
            this.lb_title.DoubleClick += new System.EventHandler(this.lb_title_DoubleClick);
            // 
            // list_usb
            // 
            this.list_usb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_usb.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.list_usb.FormattingEnabled = true;
            this.list_usb.ItemHeight = 28;
            this.list_usb.Location = new System.Drawing.Point(15, 86);
            this.list_usb.Name = "list_usb";
            this.list_usb.Size = new System.Drawing.Size(530, 392);
            this.list_usb.TabIndex = 1;
            this.list_usb.SelectedIndexChanged += new System.EventHandler(this.list_usb_SelectedIndexChanged);
            // 
            // lb_zmessage_list_usb
            // 
            this.lb_zmessage_list_usb.AutoSize = true;
            this.lb_zmessage_list_usb.BackColor = System.Drawing.Color.Transparent;
            this.lb_zmessage_list_usb.ForeColor = System.Drawing.Color.White;
            this.lb_zmessage_list_usb.Location = new System.Drawing.Point(12, 68);
            this.lb_zmessage_list_usb.Name = "lb_zmessage_list_usb";
            this.lb_zmessage_list_usb.Size = new System.Drawing.Size(124, 15);
            this.lb_zmessage_list_usb.TabIndex = 2;
            this.lb_zmessage_list_usb.Text = "可移动驱动器列表：";
            // 
            // bt_usb_eject
            // 
            this.bt_usb_eject.BackColor = System.Drawing.Color.AntiqueWhite;
            this.bt_usb_eject.Enabled = false;
            this.bt_usb_eject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_usb_eject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_usb_eject.Location = new System.Drawing.Point(303, 484);
            this.bt_usb_eject.Name = "bt_usb_eject";
            this.bt_usb_eject.Size = new System.Drawing.Size(75, 67);
            this.bt_usb_eject.TabIndex = 3;
            this.bt_usb_eject.Text = "弹出";
            this.bt_usb_eject.UseVisualStyleBackColor = false;
            this.bt_usb_eject.Click += new System.EventHandler(this.bt_usb_eject_Click);
            // 
            // bt_usb_browse
            // 
            this.bt_usb_browse.BackColor = System.Drawing.Color.AntiqueWhite;
            this.bt_usb_browse.Enabled = false;
            this.bt_usb_browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_usb_browse.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_usb_browse.Location = new System.Drawing.Point(15, 484);
            this.bt_usb_browse.Name = "bt_usb_browse";
            this.bt_usb_browse.Size = new System.Drawing.Size(282, 67);
            this.bt_usb_browse.TabIndex = 4;
            this.bt_usb_browse.Text = "打开选中项";
            this.bt_usb_browse.UseVisualStyleBackColor = false;
            this.bt_usb_browse.Click += new System.EventHandler(this.bt_usb_browse_Click);
            // 
            // bt_usb_clear
            // 
            this.bt_usb_clear.BackColor = System.Drawing.Color.AntiqueWhite;
            this.bt_usb_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_usb_clear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_usb_clear.Location = new System.Drawing.Point(384, 484);
            this.bt_usb_clear.Name = "bt_usb_clear";
            this.bt_usb_clear.Size = new System.Drawing.Size(161, 67);
            this.bt_usb_clear.TabIndex = 8;
            this.bt_usb_clear.Text = "清除选择";
            this.bt_usb_clear.UseVisualStyleBackColor = false;
            this.bt_usb_clear.Click += new System.EventHandler(this.bt_usb_clear_Click);
            // 
            // bt_browse_public
            // 
            this.bt_browse_public.BackColor = System.Drawing.Color.AntiqueWhite;
            this.bt_browse_public.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_browse_public.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_browse_public.Location = new System.Drawing.Point(15, 557);
            this.bt_browse_public.Name = "bt_browse_public";
            this.bt_browse_public.Size = new System.Drawing.Size(256, 67);
            this.bt_browse_public.TabIndex = 9;
            this.bt_browse_public.Text = "打开公共临时文件夹";
            this.bt_browse_public.UseVisualStyleBackColor = false;
            this.bt_browse_public.Click += new System.EventHandler(this.bt_browse_public_Click);
            // 
            // bt_open_all
            // 
            this.bt_open_all.BackColor = System.Drawing.Color.AntiqueWhite;
            this.bt_open_all.Enabled = false;
            this.bt_open_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_open_all.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_open_all.Location = new System.Drawing.Point(277, 557);
            this.bt_open_all.Name = "bt_open_all";
            this.bt_open_all.Size = new System.Drawing.Size(268, 67);
            this.bt_open_all.TabIndex = 10;
            this.bt_open_all.Text = "打开公共文件夹 && 选中项（用于复制文件）";
            this.bt_open_all.UseVisualStyleBackColor = false;
            this.bt_open_all.Click += new System.EventHandler(this.bt_open_all_Click);
            // 
            // bt_copyright
            // 
            this.bt_copyright.BackColor = System.Drawing.Color.AntiqueWhite;
            this.bt_copyright.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_copyright.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_copyright.Location = new System.Drawing.Point(1809, 1017);
            this.bt_copyright.Name = "bt_copyright";
            this.bt_copyright.Size = new System.Drawing.Size(99, 32);
            this.bt_copyright.TabIndex = 11;
            this.bt_copyright.Text = "版权/关于";
            this.bt_copyright.UseVisualStyleBackColor = false;
            this.bt_copyright.Click += new System.EventHandler(this.bt_copyright_Click);
            // 
            // timer_Desktop
            // 
            this.timer_Desktop.Enabled = true;
            this.timer_Desktop.Interval = 1000;
            this.timer_Desktop.Tick += new System.EventHandler(this.timer_Desktop_Tick);
            // 
            // lb_remain_notice
            // 
            this.lb_remain_notice.AutoSize = true;
            this.lb_remain_notice.BackColor = System.Drawing.Color.Transparent;
            this.lb_remain_notice.ForeColor = System.Drawing.Color.White;
            this.lb_remain_notice.Location = new System.Drawing.Point(621, 68);
            this.lb_remain_notice.Name = "lb_remain_notice";
            this.lb_remain_notice.Size = new System.Drawing.Size(98, 15);
            this.lb_remain_notice.TabIndex = 12;
            this.lb_remain_notice.Text = "距离中考还有：";
            // 
            // lb_remain
            // 
            this.lb_remain.AutoSize = true;
            this.lb_remain.BackColor = System.Drawing.Color.Transparent;
            this.lb_remain.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_remain.ForeColor = System.Drawing.Color.White;
            this.lb_remain.Location = new System.Drawing.Point(615, 86);
            this.lb_remain.Name = "lb_remain";
            this.lb_remain.Size = new System.Drawing.Size(0, 50);
            this.lb_remain.TabIndex = 13;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1372, 749);
            this.Controls.Add(this.lb_remain);
            this.Controls.Add(this.lb_remain_notice);
            this.Controls.Add(this.bt_copyright);
            this.Controls.Add(this.bt_open_all);
            this.Controls.Add(this.bt_browse_public);
            this.Controls.Add(this.bt_usb_clear);
            this.Controls.Add(this.bt_usb_browse);
            this.Controls.Add(this.bt_usb_eject);
            this.Controls.Add(this.lb_zmessage_list_usb);
            this.Controls.Add(this.list_usb);
            this.Controls.Add(this.lb_title);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launcher";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Launcher_Activated);
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.ListBox list_usb;
        private System.Windows.Forms.Label lb_zmessage_list_usb;
        private System.Windows.Forms.Button bt_usb_eject;
        private System.Windows.Forms.Button bt_usb_browse;
        private System.Windows.Forms.Button bt_usb_clear;
        private System.Windows.Forms.Button bt_browse_public;
        private System.Windows.Forms.Button bt_open_all;
        private System.Windows.Forms.Button bt_copyright;
        private System.Windows.Forms.Timer timer_Desktop;
        private System.Windows.Forms.Label lb_remain_notice;
        private System.Windows.Forms.Label lb_remain;
    }
}

