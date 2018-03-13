namespace WinformTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.group_status_panel = new System.Windows.Forms.Panel();
            this.room_panel = new System.Windows.Forms.Panel();
            this.bottom_room_panel = new System.Windows.Forms.Panel();
            this.top_room_panel = new System.Windows.Forms.Panel();
            this.center_fild_panel = new System.Windows.Forms.Panel();
            this.EventHistory_panel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.title_label = new System.Windows.Forms.Label();
            this.menu_panel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.axVLCPlugin21 = new AxAXVLC.AxVLCPlugin2();
            this.room_panel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menu_panel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).BeginInit();
            this.SuspendLayout();
            // 
            // group_status_panel
            // 
            this.group_status_panel.AutoScroll = true;
            this.group_status_panel.BackColor = System.Drawing.Color.Black;
            this.group_status_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.group_status_panel.Location = new System.Drawing.Point(130, 72);
            this.group_status_panel.Name = "group_status_panel";
            this.group_status_panel.Size = new System.Drawing.Size(1278, 189);
            this.group_status_panel.TabIndex = 0;
            // 
            // room_panel
            // 
            this.room_panel.BackColor = System.Drawing.Color.Black;
            this.room_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.room_panel.Controls.Add(this.bottom_room_panel);
            this.room_panel.Controls.Add(this.top_room_panel);
            this.room_panel.Controls.Add(this.center_fild_panel);
            this.room_panel.Location = new System.Drawing.Point(130, 270);
            this.room_panel.Name = "room_panel";
            this.room_panel.Size = new System.Drawing.Size(1278, 679);
            this.room_panel.TabIndex = 1;
            // 
            // bottom_room_panel
            // 
            this.bottom_room_panel.Location = new System.Drawing.Point(45, 457);
            this.bottom_room_panel.Margin = new System.Windows.Forms.Padding(0);
            this.bottom_room_panel.Name = "bottom_room_panel";
            this.bottom_room_panel.Size = new System.Drawing.Size(1180, 118);
            this.bottom_room_panel.TabIndex = 1;
            // 
            // top_room_panel
            // 
            this.top_room_panel.Location = new System.Drawing.Point(45, 145);
            this.top_room_panel.Margin = new System.Windows.Forms.Padding(0);
            this.top_room_panel.Name = "top_room_panel";
            this.top_room_panel.Size = new System.Drawing.Size(1180, 118);
            this.top_room_panel.TabIndex = 0;
            // 
            // center_fild_panel
            // 
            this.center_fild_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.center_fild_panel.Location = new System.Drawing.Point(45, 263);
            this.center_fild_panel.Margin = new System.Windows.Forms.Padding(0);
            this.center_fild_panel.Name = "center_fild_panel";
            this.center_fild_panel.Size = new System.Drawing.Size(1180, 194);
            this.center_fild_panel.TabIndex = 0;
            // 
            // EventHistory_panel
            // 
            this.EventHistory_panel.AutoScroll = true;
            this.EventHistory_panel.BackColor = System.Drawing.Color.Black;
            this.EventHistory_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EventHistory_panel.Location = new System.Drawing.Point(1422, 483);
            this.EventHistory_panel.Margin = new System.Windows.Forms.Padding(0);
            this.EventHistory_panel.Name = "EventHistory_panel";
            this.EventHistory_panel.Size = new System.Drawing.Size(473, 466);
            this.EventHistory_panel.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(1422, 434);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(473, 49);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(26, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "알림";
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("Segoe UI Emoji", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.title_label.ForeColor = System.Drawing.Color.DimGray;
            this.title_label.Location = new System.Drawing.Point(133, 19);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(162, 33);
            this.title_label.TabIndex = 4;
            this.title_label.Text = "DASHBOARD";
            // 
            // menu_panel
            // 
            this.menu_panel.Controls.Add(this.panel4);
            this.menu_panel.Location = new System.Drawing.Point(2, 72);
            this.menu_panel.Name = "menu_panel";
            this.menu_panel.Size = new System.Drawing.Size(122, 877);
            this.menu_panel.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(21, 22);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(71, 73);
            this.panel4.TabIndex = 6;
            this.panel4.Click += new System.EventHandler(this.LeftMenuSettingClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Dashboard";
            this.label2.Click += new System.EventHandler(this.LeftMenuSettingClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Location = new System.Drawing.Point(7, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(56, 50);
            this.panel5.TabIndex = 6;
            this.panel5.Click += new System.EventHandler(this.LeftMenuSettingClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(1422, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 49);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(26, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "CCTV";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.axVLCPlugin21);
            this.panel2.Location = new System.Drawing.Point(1422, 121);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(473, 303);
            this.panel2.TabIndex = 3;
            // 
            // axVLCPlugin21
            // 
            this.axVLCPlugin21.Enabled = true;
            this.axVLCPlugin21.Location = new System.Drawing.Point(0, 2);
            this.axVLCPlugin21.Name = "axVLCPlugin21";
            this.axVLCPlugin21.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axVLCPlugin21.OcxState")));
            this.axVLCPlugin21.Size = new System.Drawing.Size(469, 298);
            this.axVLCPlugin21.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1904, 961);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu_panel);
            this.Controls.Add(this.title_label);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.EventHistory_panel);
            this.Controls.Add(this.room_panel);
            this.Controls.Add(this.group_status_panel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.room_panel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menu_panel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axVLCPlugin21)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel group_status_panel;
        private System.Windows.Forms.Panel room_panel;
        private System.Windows.Forms.Panel EventHistory_panel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label title_label;
        private System.Windows.Forms.Panel menu_panel;
        private System.Windows.Forms.Panel center_fild_panel;
        private System.Windows.Forms.Panel bottom_room_panel;
        private System.Windows.Forms.Panel top_room_panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private AxAXVLC.AxVLCPlugin2 axVLCPlugin21;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
    }
}

