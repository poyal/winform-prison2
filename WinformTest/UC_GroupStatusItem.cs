using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WinformTest
{
    public partial class UC_GroupStatusItem : UserControl
    {
        private string groupCode;
        private string groupCodeName;
        private string openCnt;

        /// <summary>
        /// 사동정보 셋팅
        /// </summary>
        /// <param name="groupCode">사동코드</param>
        /// <param name="groupCodeName">사동명칭</param>
        /// <param name="openCnt">현재열린문수</param>
        public UC_GroupStatusItem(string groupCode, string groupCodeName, string openCnt)
        {
            InitializeComponent();

            this.groupCode = groupCode;
            this.groupCodeName = groupCodeName;
            this.openCnt = openCnt;

            group_name_label.Text = this.groupCodeName;

            ChangeGroupColor(this.openCnt);
        }

        /// <summary>
        /// 
        /// 현재열린 문의 갯수에따라 색변경
        /// </summary>
        /// <param name="openCnt">현재열린문수</param>
        private void ChangeGroupColor(string openCnt)
        {
            if (openCnt.Equals("0"))
            {
                group_status_panel.BackColor = Color.Black;
                group_name_label.BackColor = Color.Black;
                prison_name_label.BackColor = Color.Black;
                prison_num_label.BackColor = Color.Black;
                room_name_label.BackColor = Color.Black;
                room_num_label.BackColor = Color.Black;
                door_num_label.BackColor = Color.Black;
                door_name_label.BackColor = Color.Black;
                camera_name_label.BackColor = Color.Black;
                camera_num_label.BackColor = Color.Black;
            }
            else
            {
                group_status_panel.BackColor = Color.DarkRed;
                group_name_label.BackColor = Color.DarkRed;
                prison_name_label.BackColor = Color.DarkRed;
                prison_num_label.BackColor = Color.DarkRed;
                room_name_label.BackColor = Color.DarkRed;
                room_num_label.BackColor = Color.DarkRed;
                door_num_label.BackColor = Color.DarkRed;
                door_name_label.BackColor = Color.DarkRed;
                camera_name_label.BackColor = Color.DarkRed;
                camera_num_label.BackColor = Color.DarkRed;
            }
        }

        public event EventHandler GroupItemClick;

        private void Group_status_Click(object sender, EventArgs e)
        {
            JObject json = new JObject();
            json.Add("groupCode", groupCode);
            json.Add("groupCodeName", groupCodeName);
            this.GroupItemClick(json, new EventArgs());
        }
    }
}
