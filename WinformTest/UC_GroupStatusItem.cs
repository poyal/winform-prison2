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
        private string minRoomName;

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
        /// <param name="minRoomName">문열린 낮은 호실명</param>
        public UC_GroupStatusItem(string groupCode, string groupCodeName, string openCnt, string groupInmates, string roomCnt, string doorCnt, string cameraCnt, string selectGroupCode, string minRoomName)
        {
            InitializeComponent();

            this.groupCode = groupCode;
            this.groupCodeName = groupCodeName;
            this.openCnt = openCnt;
            this.groupInmates = groupInmates;
            this.roomCnt = roomCnt;
            this.doorCnt = doorCnt;
            this.cameraCnt = cameraCnt;
            this.minRoomName = minRoomName;

            group_name_label.Text = this.groupCodeName;
            //prison_num_label.Text = this.groupInmates;
            //room_num_label.Text = this.roomCnt;
            //door_num_label.Text = this.doorCnt;
            //camera_num_label.Text = this.cameraCnt;
            if (!string.IsNullOrEmpty(minRoomName))
            {
                int openNum = Int32.Parse(openCnt) - 1;
                if (openNum > 0)
                {
                    min_room_label.Text = string.Format("{0}호실 외 {1}개", minRoomName, openNum);
                }
                else
                {
                    min_room_label.Text = string.Format("{0}호실", minRoomName);

                }
                
            }
            else
            {
                min_room_label.Text = "";
            }
            ChangeGroupColor(this.openCnt);

            ColorTransparentSetting();
            SelectedItem(selectGroupCode);
        }

        /// <summary>
        /// 부모색상 참조
        /// </summary>
        private void ColorTransparentSetting()
        {
            group_name_label.BackColor = Color.Transparent;
            //prison_name_label.BackColor = Color.Transparent;
            //prison_num_label.BackColor = Color.Transparent;
            //room_name_label.BackColor = Color.Transparent;
            //room_num_label.BackColor = Color.Transparent;
            //door_num_label.BackColor = Color.Transparent;
            //door_name_label.BackColor = Color.Transparent;
            //camera_name_label.BackColor = Color.Transparent;
            //camera_num_label.BackColor = Color.Transparent;

            group_name_label.Parent = group_status_panel;
            //prison_name_label.Parent = group_status_panel;
            //prison_num_label.Parent = group_status_panel;
            //room_name_label.Parent = group_status_panel;
            //room_num_label.Parent = group_status_panel;
            //door_num_label.Parent = group_status_panel;
            //door_name_label.Parent = group_status_panel;
            //camera_name_label.Parent = group_status_panel;
            //camera_num_label.Parent = group_status_panel;
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
        /// <param name="minRoomName">문열린 낮은 호실명</param>
        public void UpdateGroupStatusItem(string groupCode, string groupCodeName, string openCnt, string groupInmates, string roomCnt, string doorCnt, string cameraCnt, string minRoomName)
        {
            this.groupCode = groupCode;
            this.groupCodeName = groupCodeName;
            this.openCnt = openCnt;
            this.groupInmates = groupInmates;
            this.roomCnt = roomCnt;
            this.doorCnt = doorCnt;
            this.cameraCnt = cameraCnt;
            this.minRoomName = minRoomName;

            group_name_label.Text = this.groupCodeName;
            //prison_num_label.Text = this.groupInmates;
            //room_num_label.Text = this.roomCnt;
            //door_num_label.Text = this.doorCnt;
            //camera_num_label.Text = this.cameraCnt;
            if (!string.IsNullOrEmpty(minRoomName))
            {
                int openNum = Int32.Parse(openCnt) - 1;
                if (openNum > 0)
                {
                    min_room_label.Text = string.Format("{0}호실 외 {1}개", minRoomName, openNum);
                }
                else
                {
                    min_room_label.Text = string.Format("{0}호실", minRoomName);
                }
            }
            else
            {
                min_room_label.Text = "";
            }
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
            }
            else
            {
                group_status_panel.BackColor = Color.DarkRed;
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
            json.Add("openCnt", openCnt);
            json.Add("groupInmates", groupInmates);
            json.Add("roomCnt", roomCnt);
            json.Add("doorCnt", doorCnt);
            json.Add("cameraCnt", cameraCnt);
            this.GroupItemClick(json, new EventArgs());
        }

        /// <summary>
        /// 사동 선택 이벤트
        /// </summary>
        /// <param name="selectedGroupCode">선택된 사동정보</param>
        public void SelectedItem(string selectedGroupCode)
        {
            if (selectedGroupCode.Equals(this.groupCode))
            {
                group_status_border_panel.BackColor = Color.DarkGray;
            }
            else
            {
                group_status_border_panel.BackColor = Color.Black;
            }
        }
    }
}
