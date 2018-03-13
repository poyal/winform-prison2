using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WinformTest
{
    /// <summary>
    /// 사동 정보 UserController
    /// </summary>
    public partial class UC_GroupStatusItem : UserControl
    {
        private string groupCode;
        private string groupCodeName;
        private string openCnt;
        private string groupInmates;
        private string roomCnt;
        private string doorCnt;
        private string cameraCnt;
        
        /// <summary>
        /// 사동정보 객체 생성
        /// </summary>
        /// <param name="groupCode">사동코드</param>
        /// <param name="groupCodeName">사동명</param>
        /// <param name="openCnt">열린문의 수</param>
        /// <param name="groupInmates">수감인원</param>
        /// <param name="roomCnt">호실수</param>
        /// <param name="doorCnt">문수</param>
        /// <param name="cameraCnt">카메라수</param>
        public UC_GroupStatusItem(string groupCode, string groupCodeName, string openCnt, string groupInmates, string roomCnt, string doorCnt, string cameraCnt)
        {
            InitializeComponent();

            this.groupCode = groupCode;
            this.groupCodeName = groupCodeName;
            this.openCnt = openCnt;
            this.groupInmates = groupInmates;
            this.roomCnt = roomCnt;
            this.doorCnt = doorCnt;
            this.cameraCnt = cameraCnt;

            group_name_label.Text = this.groupCodeName;
            prison_num_label.Text = this.groupInmates;
            room_num_label.Text = this.roomCnt;
            door_num_label.Text = this.doorCnt;
            camera_num_label.Text = this.cameraCnt;
            ChangeGroupColor(this.openCnt);
        }

        /// <summary>
        /// 사동정보 수정
        /// </summary>
        /// <param name="groupCode">사동코드</param>
        /// <param name="groupCodeName">사동명</param>
        /// <param name="openCnt">열린문의 수</param>
        /// <param name="groupInmates">수감인원</param>
        /// <param name="roomCnt">호실수</param>
        /// <param name="doorCnt">문수</param>
        /// <param name="cameraCnt">카메라수</param>
        public void UpdateGroupStatusItem(string groupCode, string groupCodeName, string openCnt, string groupInmates, string roomCnt, string doorCnt, string cameraCnt)
        {
            this.groupCode = groupCode;
            this.groupCodeName = groupCodeName;
            this.openCnt = openCnt;
            this.groupInmates = groupInmates;
            this.roomCnt = roomCnt;
            this.doorCnt = doorCnt;
            this.cameraCnt = cameraCnt;

            group_name_label.Text = this.groupCodeName;
            prison_num_label.Text = this.groupInmates;
            room_num_label.Text = this.roomCnt;
            door_num_label.Text = this.doorCnt;
            camera_num_label.Text = this.cameraCnt;
            ChangeGroupColor(this.openCnt);
        }
        
        /// <summary>
        /// 사동정보 리턴
        /// </summary>
        /// <returns>사동코드</returns>
        public string GetGroupCode()
        {
            return this.groupCode;
        }

        /// <summary>
        /// 문열림 정보에 따라 색 변경
        /// </summary>
        /// <param name="openCnt">열린문의 수</param>
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

        /// <summary>
        ///  사동상태정보 parent로 callback
        /// </summary>
        public event EventHandler GroupItemClick;

        /// <summary>
        /// 사동 버튼 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Group_status_Click(object sender, EventArgs e)
        {
            JObject json = new JObject();
            json.Add("groupCode", groupCode);
            json.Add("groupCodeName", groupCodeName);
            this.GroupItemClick(json, new EventArgs());
        }
    }
}
