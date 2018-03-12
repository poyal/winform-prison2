namespace WinformTest
{
    partial class UC_GroupStatusItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.group_name_label = new System.Windows.Forms.Label();
            this.prison_name_label = new System.Windows.Forms.Label();
            this.room_name_label = new System.Windows.Forms.Label();
            this.door_name_label = new System.Windows.Forms.Label();
            this.camera_name_label = new System.Windows.Forms.Label();
            this.prison_num_label = new System.Windows.Forms.Label();
            this.room_num_label = new System.Windows.Forms.Label();
            this.door_num_label = new System.Windows.Forms.Label();
            this.camera_num_label = new System.Windows.Forms.Label();
            this.group_status_panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // group_name_label
            // 
            this.group_name_label.AutoSize = true;
            this.group_name_label.Font = new System.Drawing.Font("Segoe UI Emoji", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.group_name_label.ForeColor = System.Drawing.SystemColors.Window;
            this.group_name_label.Location = new System.Drawing.Point(7, 17);
            this.group_name_label.Margin = new System.Windows.Forms.Padding(5);
            this.group_name_label.Name = "group_name_label";
            this.group_name_label.Size = new System.Drawing.Size(85, 33);
            this.group_name_label.TabIndex = 0;
            this.group_name_label.Text = "Group";
            this.group_name_label.Click += new System.EventHandler(this.Group_status_Click);
            // 
            // prison_name_label
            // 
            this.prison_name_label.AutoSize = true;
            this.prison_name_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.prison_name_label.ForeColor = System.Drawing.SystemColors.Window;
            this.prison_name_label.Location = new System.Drawing.Point(9, 66);
            this.prison_name_label.Name = "prison_name_label";
            this.prison_name_label.Size = new System.Drawing.Size(72, 19);
            this.prison_name_label.TabIndex = 1;
            this.prison_name_label.Text = "수감인원 :";
            // 
            // room_name_label
            // 
            this.room_name_label.AutoSize = true;
            this.room_name_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.room_name_label.ForeColor = System.Drawing.SystemColors.Window;
            this.room_name_label.Location = new System.Drawing.Point(23, 84);
            this.room_name_label.Name = "room_name_label";
            this.room_name_label.Size = new System.Drawing.Size(58, 19);
            this.room_name_label.TabIndex = 2;
            this.room_name_label.Text = "호실수 :";
            // 
            // door_name_label
            // 
            this.door_name_label.AutoSize = true;
            this.door_name_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.door_name_label.ForeColor = System.Drawing.SystemColors.Window;
            this.door_name_label.Location = new System.Drawing.Point(23, 102);
            this.door_name_label.Name = "door_name_label";
            this.door_name_label.Size = new System.Drawing.Size(58, 19);
            this.door_name_label.TabIndex = 3;
            this.door_name_label.Text = "도어수 :";
            // 
            // camera_name_label
            // 
            this.camera_name_label.AutoSize = true;
            this.camera_name_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.camera_name_label.ForeColor = System.Drawing.SystemColors.Window;
            this.camera_name_label.Location = new System.Drawing.Point(9, 120);
            this.camera_name_label.Name = "camera_name_label";
            this.camera_name_label.Size = new System.Drawing.Size(72, 19);
            this.camera_name_label.TabIndex = 4;
            this.camera_name_label.Text = "카메라수 :";
            // 
            // prison_num_label
            // 
            this.prison_num_label.AutoSize = true;
            this.prison_num_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.prison_num_label.ForeColor = System.Drawing.SystemColors.Window;
            this.prison_num_label.Location = new System.Drawing.Point(78, 66);
            this.prison_num_label.Name = "prison_num_label";
            this.prison_num_label.Size = new System.Drawing.Size(39, 19);
            this.prison_num_label.TabIndex = 5;
            this.prison_num_label.Text = "Num";
            // 
            // room_num_label
            // 
            this.room_num_label.AutoSize = true;
            this.room_num_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.room_num_label.ForeColor = System.Drawing.SystemColors.Window;
            this.room_num_label.Location = new System.Drawing.Point(78, 85);
            this.room_num_label.Name = "room_num_label";
            this.room_num_label.Size = new System.Drawing.Size(39, 19);
            this.room_num_label.TabIndex = 6;
            this.room_num_label.Text = "Num";
            // 
            // door_num_label
            // 
            this.door_num_label.AutoSize = true;
            this.door_num_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.door_num_label.ForeColor = System.Drawing.SystemColors.Window;
            this.door_num_label.Location = new System.Drawing.Point(78, 104);
            this.door_num_label.Name = "door_num_label";
            this.door_num_label.Size = new System.Drawing.Size(39, 19);
            this.door_num_label.TabIndex = 7;
            this.door_num_label.Text = "Num";
            // 
            // camera_num_label
            // 
            this.camera_num_label.AutoSize = true;
            this.camera_num_label.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.camera_num_label.ForeColor = System.Drawing.SystemColors.Window;
            this.camera_num_label.Location = new System.Drawing.Point(78, 123);
            this.camera_num_label.Name = "camera_num_label";
            this.camera_num_label.Size = new System.Drawing.Size(39, 19);
            this.camera_num_label.TabIndex = 8;
            this.camera_num_label.Text = "Num";
            // 
            // group_status_panel
            // 
            this.group_status_panel.Location = new System.Drawing.Point(0, 0);
            this.group_status_panel.Margin = new System.Windows.Forms.Padding(10);
            this.group_status_panel.Name = "group_status_panel";
            this.group_status_panel.Size = new System.Drawing.Size(147, 169);
            this.group_status_panel.TabIndex = 9;
            this.group_status_panel.Click += new System.EventHandler(this.Group_status_Click);
            // 
            // UC_GroupStatusItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.camera_num_label);
            this.Controls.Add(this.door_num_label);
            this.Controls.Add(this.room_num_label);
            this.Controls.Add(this.prison_num_label);
            this.Controls.Add(this.camera_name_label);
            this.Controls.Add(this.door_name_label);
            this.Controls.Add(this.room_name_label);
            this.Controls.Add(this.prison_name_label);
            this.Controls.Add(this.group_name_label);
            this.Controls.Add(this.group_status_panel);
            this.Name = "UC_GroupStatusItem";
            this.Size = new System.Drawing.Size(147, 169);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label group_name_label;
        private System.Windows.Forms.Label prison_name_label;
        private System.Windows.Forms.Label room_name_label;
        private System.Windows.Forms.Label door_name_label;
        private System.Windows.Forms.Label camera_name_label;
        private System.Windows.Forms.Label prison_num_label;
        private System.Windows.Forms.Label room_num_label;
        private System.Windows.Forms.Label door_num_label;
        private System.Windows.Forms.Label camera_num_label;
        private System.Windows.Forms.Panel group_status_panel;
    }
}
