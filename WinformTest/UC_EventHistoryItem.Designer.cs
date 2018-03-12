namespace WinformTest
{
    partial class UC_EventHistoryItem
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
            this.event_date_label = new System.Windows.Forms.Label();
            this.event_signal_label = new System.Windows.Forms.Label();
            this.event_group_room_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // event_date_label
            // 
            this.event_date_label.AutoSize = true;
            this.event_date_label.Font = new System.Drawing.Font("Segoe UI Emoji", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.event_date_label.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.event_date_label.Location = new System.Drawing.Point(293, 61);
            this.event_date_label.Name = "event_date_label";
            this.event_date_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.event_date_label.Size = new System.Drawing.Size(69, 17);
            this.event_date_label.TabIndex = 0;
            this.event_date_label.Text = "TempTime";
            // 
            // event_signal_label
            // 
            this.event_signal_label.AutoSize = true;
            this.event_signal_label.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.event_signal_label.ForeColor = System.Drawing.SystemColors.Window;
            this.event_signal_label.Location = new System.Drawing.Point(81, 24);
            this.event_signal_label.Name = "event_signal_label";
            this.event_signal_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.event_signal_label.Size = new System.Drawing.Size(59, 24);
            this.event_signal_label.TabIndex = 1;
            this.event_signal_label.Text = "Status";
            // 
            // event_group_room_label
            // 
            this.event_group_room_label.AutoSize = true;
            this.event_group_room_label.Font = new System.Drawing.Font("Segoe UI Emoji", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.event_group_room_label.ForeColor = System.Drawing.SystemColors.Window;
            this.event_group_room_label.Location = new System.Drawing.Point(83, 61);
            this.event_group_room_label.Name = "event_group_room_label";
            this.event_group_room_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.event_group_room_label.Size = new System.Drawing.Size(84, 17);
            this.event_group_room_label.TabIndex = 2;
            this.event_group_room_label.Text = "Group Room";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(0, 99);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 1);
            this.panel1.TabIndex = 3;
            // 
            // UC_EventHistoryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.event_group_room_label);
            this.Controls.Add(this.event_signal_label);
            this.Controls.Add(this.event_date_label);
            this.Name = "UC_EventHistoryItem";
            this.Size = new System.Drawing.Size(473, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label event_date_label;
        private System.Windows.Forms.Label event_signal_label;
        private System.Windows.Forms.Label event_group_room_label;
        private System.Windows.Forms.Panel panel1;
    }
}
