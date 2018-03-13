using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinformTest
{
    public partial class Form1 : Form
    {
        private DBConnection dbc = new DBConnection();
        private Util util = new Util();

        private int groupMargin = Properties.CommonProperties.Default.groupMargin;
        private System.Timers.Timer aTimer;
        private string selectGroupCode;

        public string ipVal { get; set; }

        public Form1()
        {
            InitializeComponent();
            FormInit();
        }

        private void FormInit()
        {
            dbc.Open();
            ViewCamera("2");
            AddGroupStatusItem();
            AddEventHistoryItem();
            AddRoomStatusItem();
        }

        /// <summary>
        /// NVR IP셋팅 팝업 페이지
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftMenuSettingClick(object sender, EventArgs e)
        {
            SetNVRIPPopForm ipform = new SetNVRIPPopForm();
            ipform.StartPosition = FormStartPosition.CenterParent;
            DialogResult dr = ipform.ShowDialog();

            if (dr == DialogResult.OK)
            {
                Properties.NVRAccessProperties.Default.NVR_IP = ipVal;
                FormInit();
            }
        }

        /// <summary>
        /// 사동 정보 최초생성
        /// </summary>
        private void AddGroupStatusItem()
        {
            group_status_panel.Controls.Clear();
            DataTable groupDataTable = dbc.SelectGroupStatus();
            foreach (DataRow row in groupDataTable.Rows)
            {
                string groupCode = row["group_code"].ToString();
                string groupName = row["group_name"].ToString();
                string openCnt = row["open_cnt"].ToString();
                string groupInmates = row["group_inmates"].ToString();
                string roomCnt = row["room_cnt"].ToString();
                string doorCnt = row["door_cnt"].ToString();
                string cameraCnt = row["camera_cnt"].ToString();

                var temp = new UC_GroupStatusItem(groupCode, groupName, openCnt, groupInmates, roomCnt, doorCnt, cameraCnt);
                temp.GroupItemClick += new EventHandler(Group_Item_Click);
                int XPos = 0;
                foreach (Control item in group_status_panel.Controls)
                {
                    XPos += item.Width + 20;
                }

                temp.Location = new Point(temp.Location.X + groupMargin + XPos, temp.Location.Y + 10);
                group_status_panel.Controls.Add(temp);
            }
        }

        /// <summary>
        /// 사동정보 수정
        /// </summary>
        public void UpdateGroupStatusItem()
        {
            DataTable groupDataTable = dbc.SelectGroupStatus();
            foreach (Control control in this.group_status_panel.Controls)
            {
                if (control is UC_GroupStatusItem)
                {
                    UC_GroupStatusItem groupControl = control as UC_GroupStatusItem;
                    string controlGroupCode = groupControl.GetGroupCode();

                    string groupCode = "";
                    string groupName = "";
                    string openCnt = "";
                    string groupInmates = "";
                    string roomCnt = "";
                    string doorCnt = "";
                    string cameraCnt = "";


                    foreach (DataRow row in groupDataTable.Rows)
                    {
                        if (controlGroupCode.Equals(row["group_code"].ToString()))
                        {
                            groupCode = row["group_code"].ToString();
                            groupName = row["group_name"].ToString();
                            openCnt = row["open_cnt"].ToString();
                            groupInmates = row["group_inmates"].ToString();
                            roomCnt = row["room_cnt"].ToString();
                            doorCnt = row["door_cnt"].ToString();
                            cameraCnt = row["camera_cnt"].ToString();
                        }
                    }

                    groupControl.UpdateGroupStatusItem(groupCode, groupName, openCnt, groupInmates, roomCnt, doorCnt, cameraCnt);
                }
            }
        }

        /// <summary>
        /// 사동정보 클릭 callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Group_Item_Click(object sender, EventArgs e)
        {
            JObject json = sender as JObject;
            string groupCode = json["groupCode"].ToString();
            selectGroupCode = groupCode;
            UpdateRoomStatusItem();
        }

        /// <summary>
        /// 호실정보 최초 추가
        /// </summary>
        private void AddRoomStatusItem()
        {
            DataTable roomDataTable = dbc.GetRoomList(selectGroupCode, null);

            foreach (DataRow row in roomDataTable.Rows)
            {
                int roomNo = util.ReturnRoomCodeToRoomNo(row["room_code"].ToString());
                string roomCode = row["room_code"].ToString();
                string roomName = row["room_name"].ToString();
                string roomStatus = row["room_status"].ToString();

                int XPos = 0;
                if (roomNo <= 10)
                {
                    var temp = new UC_RoomStatusItem(selectGroupCode, roomCode, roomName, roomStatus);
                    temp.RoomItemClick += new EventHandler(Room_Item_Click);

                    foreach (Control item in top_room_panel.Controls)
                    {
                        XPos += item.Width;
                    }
                    temp.Location = new Point(XPos, temp.Location.Y);
                    top_room_panel.Controls.Add(temp);
                }
                else
                {
                    var temp = new UC_RoomStatusItem(selectGroupCode, roomCode, roomName, roomStatus);
                    temp.RoomItemClick += new EventHandler(Room_Item_Click);

                    foreach (Control item in bottom_room_panel.Controls)
                    {
                        XPos += item.Width;
                    }
                    temp.Location = new Point(XPos, temp.Location.Y);
                    bottom_room_panel.Controls.Add(temp);
                }
            }
        }

        /// <summary>
        /// 호실정보 수정
        /// </summary>
        private void UpdateRoomStatusItem()
        {
            DataTable roomDataTable = dbc.GetRoomList(selectGroupCode, null);

            foreach (Control control in this.top_room_panel.Controls)
            {
                if (control is UC_RoomStatusItem)
                {
                    UC_RoomStatusItem roomControl = control as UC_RoomStatusItem;

                    string controlRoomCode = roomControl.GetRoomCode();

                    string groupCode = "";
                    string roomCode = "";
                    string roomName = "";
                    string roomStatus = "";

                    foreach (DataRow row in roomDataTable.Rows)
                    {
                        if (controlRoomCode.Equals(row["room_code"].ToString()))
                        {
                            groupCode = row["group_code"].ToString();
                            roomCode = row["room_code"].ToString();
                            roomName = row["room_name"].ToString();
                            roomStatus = row["room_status"].ToString();
                        }
                    }

                    roomControl.UpdateRoomStatusItem(groupCode, roomCode, roomName, roomStatus);
                }
            }

            foreach (Control control in this.bottom_room_panel.Controls)
            {
                if (control is UC_RoomStatusItem)
                {
                    UC_RoomStatusItem roomControl = control as UC_RoomStatusItem;

                    string controlRoomCode = roomControl.GetRoomCode();

                    string groupCode = "";
                    string roomCode = "";
                    string roomName = "";
                    string roomStatus = "";

                    foreach (DataRow row in roomDataTable.Rows)
                    {
                        if (controlRoomCode.Equals(row["room_code"].ToString()))
                        {
                            groupCode = row["group_code"].ToString();
                            roomCode = row["room_code"].ToString();
                            roomName = row["room_name"].ToString();
                            roomStatus = row["room_status"].ToString();
                        }
                    }

                    roomControl.UpdateRoomStatusItem(groupCode, roomCode, roomName, roomStatus);
                }
            }
        }

        /// <summary>
        /// 각 호실 클릭 이벤트
        /// </summary>
        public void Room_Item_Click(object sender, EventArgs e)
        {
            UpdateGroupStatusItem();
            JObject json = sender as JObject;
            NVRControll nvrc = new NVRControll();

            AddEventHistoryItem();

            if ("C".Equals(json.GetValue("roomStatus").ToString()))
            {
                nvrc.MoveCameraPTZ("2", null, null, "1", null);
            }
            else
            {
                nvrc.MoveCameraPTZ("2", null, null, json.GetValue("preset").ToString(), null);
            }
        }

        /// <summary>
        /// 방열림정보 셋팅
        /// </summary>
        private void AddEventHistoryItem()
        {
            EventHistory_panel.Controls.Clear();
            DataTable historyDataTable = dbc.SelectRoomStatusHistory();
            foreach (DataRow row in historyDataTable.Rows)
            {
                string groupCode = row["group_code"].ToString();
                string groupCodeName = row["group_code_name"].ToString();
                string roomCode = row["room_code"].ToString();
                string roomCodeName = row["room_code_name"].ToString();
                string roomStatus = row["room_status"].ToString();
                string roomStatusName = row["room_status_name"].ToString();
                string eventTime = row["event_time"].ToString();
                var temp = new UC_EventHistoryItem(groupCode, groupCodeName, roomCode, roomCodeName, roomStatus, roomStatusName, eventTime);

                temp.Width = EventHistory_panel.Width - 23;

                int YPos = 0;
                foreach (Control item in EventHistory_panel.Controls)
                {
                    YPos += item.Height;
                }

                temp.Location = new Point(temp.Location.X, temp.Location.Y + YPos);
                EventHistory_panel.Controls.Add(temp);

                int dataCount = historyDataTable.Select().Length;

                if (dataCount > 0)
                {
                    DataRow[] rows = historyDataTable.Select();
                    selectGroupCode = rows[0]["group_code"].ToString();
                }
                else
                {
                    selectGroupCode = "G01";
                }
            }
        }

        /// <summary>
        /// nvr streaming
        /// </summary>
        private void ViewCamera(String channel)
        {
            string rtspHeader = Properties.NVRAccessProperties.Default.RTSP_HEADER;
            string httpHeader = Properties.NVRAccessProperties.Default.HTTP_HEADER;
            string userName = Properties.NVRAccessProperties.Default.NVR_USER_NAME;
            string userPw = Properties.NVRAccessProperties.Default.NVR_USER_PW;
            string nvrIp = Properties.NVRAccessProperties.Default.NVR_IP;

            Console.WriteLine("header :: " + rtspHeader + userName + ":" + userPw + "@" + nvrIp + "/" + channel + "/high");
            axVLCPlugin21.playlist.add(rtspHeader + userName + ":" + userPw + "@" + nvrIp + "/" + channel + "/high", null, null);
            axVLCPlugin21.playlist.next();
            axVLCPlugin21.playlist.play();
        }

    }
}
