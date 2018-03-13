namespace WinformTest
{
    partial class UC_RoomStatusItem
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
            this.door_panel = new System.Windows.Forms.Panel();
            this.room_name_label = new System.Windows.Forms.Label();
            this.room_panel = new System.Windows.Forms.Panel();
            this.room_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // door_panel
            // 
            this.door_panel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.door_panel.Location = new System.Drawing.Point(29, 104);
            this.door_panel.Margin = new System.Windows.Forms.Padding(0);
            this.door_panel.Name = "door_panel";
            this.door_panel.Size = new System.Drawing.Size(55, 15);
            this.door_panel.TabIndex = 1;
            // 
            // room_name_label
            // 
            this.room_name_label.AllowDrop = true;
            this.room_name_label.AutoEllipsis = true;
            this.room_name_label.AutoSize = true;
            this.room_name_label.Font = new System.Drawing.Font("Segoe UI Emoji", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.room_name_label.ForeColor = System.Drawing.SystemColors.Menu;
            this.room_name_label.Location = new System.Drawing.Point(19, 33);
            this.room_name_label.Name = "room_name_label";
            this.room_name_label.Size = new System.Drawing.Size(71, 20);
            this.room_name_label.TabIndex = 0;
            this.room_name_label.Text = "Num호실";
            this.room_name_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.room_name_label.Click += new System.EventHandler(this.room_panel_Click);
            // 
            // room_panel
            // 
            this.room_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.room_panel.Controls.Add(this.room_name_label);
            this.room_panel.Location = new System.Drawing.Point(13, 14);
            this.room_panel.Name = "room_panel";
            this.room_panel.Size = new System.Drawing.Size(90, 90);
            this.room_panel.TabIndex = 0;
            this.room_panel.Click += new System.EventHandler(this.room_panel_Click);
            // 
            // UC_RoomStatusItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.door_panel);
            this.Controls.Add(this.room_panel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UC_RoomStatusItem";
            this.Size = new System.Drawing.Size(118, 118);
            this.room_panel.ResumeLayout(false);
            this.room_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel door_panel;
        private System.Windows.Forms.Label room_name_label;
        private System.Windows.Forms.Panel room_panel;
    }
}
