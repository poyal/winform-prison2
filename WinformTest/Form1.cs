using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Timers;
using System.Windows.Forms;
using WinformTest.VO;

namespace WinformTest
{
    public partial class Form1 : Form
    {
        private DBConnection dbc = new DBConnection();
        private Util util = new Util();

        private int groupMargin = Properties.CommonProperties.Default.groupMargin;
        private static System.Windows.Forms.Timer aTimer = new System.Windows.Forms.Timer();
        private System.Timers.Timer sensorTimer = new System.Timers.Timer();
        private string selectGroupCode;
        private string sensorSignal = "";
        private Boolean isOpenFlag = true;
        private string sensorGroupCode = "G01";
        private string sensorRoomCode = "R01";

        List<RoomInfoVO> list = new List<RoomInfoVO>();
        NVRControll nvrc;
        int arrIdx = 0;

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
            AddEventHistoryItem();
            AddGroupStatusItem();
            AddRoomStatusItem();
            SensorSearchTimer();
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
                string minRoomName = row["min_room_name"].ToString();
                
                var temp = new UC_GroupStatusItem(groupCode, groupName, openCnt, groupInmates, roomCnt, doorCnt, cameraCnt, selectGroupCode, minRoomName);
                temp.GroupItemClick += new EventHandler(Group_Item_Click);
                int XPos = 0;
                foreach (Control item in group_status_panel.Controls)
                {
                    XPos += item.Width + 20;
                }

                temp.Location = new Point(temp.Location.X + groupMargin + XPos, temp.Location.Y + 10);
                group_status_panel.Controls.Add(temp);

                if(groupCode.Equals(selectGroupCode))
                {
                    JObject json = new JObject();

                    json.Add("groupCode", groupCode);
                    json.Add("groupCodeName", groupName);
                    json.Add("openCnt", openCnt);
                    json.Add("groupInmates", groupInmates);
                    json.Add("roomCnt", roomCnt);
                    json.Add("doorCnt", doorCnt);
                    json.Add("cameraCnt", cameraCnt);

                    GroupTitleChange(json);
                }
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
                    string minRoomName = "";


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
                            minRoomName = row["min_room_name"].ToString();
                        }
                    }

                    groupControl.UpdateGroupStatusItem(groupCode, groupName, openCnt, groupInmates, roomCnt, doorCnt, cameraCnt, minRoomName);
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
            GroupItemClickEvent(groupCode);
            GroupTitleChange(json);
        }

        /// <summary>
        /// 사동 변경
        /// </summary>
        /// <param name="json">사동정보</param>
        private void GroupTitleChange(JObject json)
        {
            string groupCode = json["groupCode"].ToString();
            string groupCodeName = json["groupCodeName"].ToString();
            string openCnt = json["openCnt"].ToString();
            string groupInmates = json["groupInmates"].ToString();
            string roomCnt = json["roomCnt"].ToString();
            string doorCnt = json["doorCnt"].ToString();
            string cameraCnt = json["cameraCnt"].ToString();

            group_title_label.Text = string.Format("{0}", groupCodeName);
            group_info_label.Text = string.Format("수감인원: {0} / 호실수: {1} / 도어수: {2} / 카메라수: {3}", groupInmates, roomCnt, doorCnt, cameraCnt);
        }

        /// <summary>
        /// 사동정보 클릭
        /// </summary>
        /// <param name="groupCode"></param>
        private void GroupItemClickEvent(string groupCode)
        {
            selectGroupCode = groupCode;
            UpdateRoomStatusItem();
            SelectedGroupStatusItem(groupCode);
        }

        /// <summary>
        /// 사동선택 이벤트
        /// </summary>
        /// <param name="groupCode">사동 코드</param>
        private void SelectedGroupStatusItem(string groupCode)
        {
            foreach (Control control in this.group_status_panel.Controls)
            {
                if(control is UC_GroupStatusItem)
                {
                    UC_GroupStatusItem groupControl = control as UC_GroupStatusItem;
                    groupControl.SelectedItem(groupCode);
                }
            }
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
            arrIdx = 0;
            UpdateGroupStatusItem();
            RoomInfoVO riVo = sender as RoomInfoVO;
            nvrc = new NVRControll();

            AddEventHistoryItem();

            if ("C".Equals(riVo.roomStatus))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].groupCode.Equals(riVo.groupCode) && list[i].roomCode.Equals(riVo.roomCode))
                    {
                        list.RemoveAt(i);
                    }
                }
                
                if(list.Count == 0)
                {
                    nvrc.MoveCameraPTZ("2", null, null, "1", null);
                }
            }
            else
            {
                list.Add(riVo);
                nvrc.MoveCameraPTZ("2", null, null, riVo.preset, null);
                aTimer.Stop();
                aTimer.Start();
            }
        }

        

        private void Timer_tick(Object source, EventArgs e)
        {
            if (list.Count > 0)
            {
                nvrc.MoveCameraPTZ("2", null, null, list[arrIdx].preset, null);
                if (arrIdx + 1 == list.Count)
                {
                    arrIdx = 0;
                }
                else
                {
                    arrIdx++;
                }
            }
            else
            {
                aTimer.Stop();
                arrIdx = 0;
            }
        }

        delegate void SetRoomUserControl();
        /// <summary>
        /// 방열림정보 셋팅
        /// </summary>
        private void AddEventHistoryItem()
        {
            if (EventHistory_panel.InvokeRequired)
            {
                SetRoomUserControl dele = new SetRoomUserControl(AddEventHistoryItem);
                this.Invoke(dele, new object[] {});
            }
            else
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

            axVLCPlugin21.playlist.add(rtspHeader + userName + ":" + userPw + "@" + nvrIp + "/" + channel + "/high", null, null);
            axVLCPlugin21.playlist.next();
            axVLCPlugin21.playlist.play();
        }

        /// <summary>
        /// 센서 연결 타이머 시작
        /// </summary>
        private void SensorSearchTimer()
        {
            sensorTimer = new System.Timers.Timer();
            sensorTimer.Interval = 1000;
            sensorTimer.Elapsed += OnTimedEvent;
            sensorTimer.AutoReset = true;
            sensorTimer.Enabled = true;
        }

        /// <summary>
        /// 센서 타이머 연결 반복
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            string comportStr = "";
            foreach (string comport in SerialPort.GetPortNames())
            {
                comportStr = comport;
            }

            if (!comportStr.Equals(""))
            {
                sensorTimer.Stop();
                SensorSetting(comportStr);
            }
        }

        // 센서 셋팅정보
        private void SensorSetting(string comportStr)
        {
            Console.WriteLine("Sensor IN -------------------");
            Console.WriteLine("PortName = " + comportStr);
            Console.WriteLine("BaudRate = " + 9600);
            Console.WriteLine("DataBits = " + 8);
            Console.WriteLine("Parity = " + Parity.None);
            Console.WriteLine("StopBits = " + StopBits.One);
            serialPort1.PortName = comportStr;
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.Parity = Parity.None;
            serialPort1.StopBits = StopBits.One;
            SerialPortOpen();
        }

        /// <summary>
        /// 센서 연결
        /// </summary>
        private void SerialPortOpen()
        {
            try
            {
                serialPort1.Open();
            }
            catch
            {
                Console.WriteLine("해당 포트는 사용 중입니다.");
                return;
            }

            if (serialPort1.IsOpen)
            {
                Console.WriteLine("포트가 연결되었습니다.");
            }
            else
            {
                Console.WriteLine("포트를 연결하지 못했습니다.");
            }
        }

        /// <summary>
        /// 센서 정보 수신
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string data = serialPort1.ReadExisting();

                if (data.Trim() != string.Empty)
                {
                    char[] values = data.ToCharArray();
                    int value = Convert.ToInt32(values[0]);

                    if (data.Trim() != sensorSignal)
                    {
                        if (!String.IsNullOrEmpty(data.Trim()) && data.Trim().Length == 1)
                        {
                            if (sensorSignal == "")
                            {
                                isOpenFlag = true;
                            }

                            sensorSignal = data.Trim();
                            string status = util.SensorDataToStatusCode(data.Trim());

                            nvrc = new NVRControll();
                            GroupItemClickEvent(sensorGroupCode);
                            JObject json = UpdateRoomStatusItemBySensor(sensorGroupCode, sensorRoomCode, status);

                            UpdateGroupStatusItem();
                            AddEventHistoryItem();

                            if(data.Trim() == "1")
                            {
                                nvrc.MoveCameraPTZ("2", null, null, json["preset"].ToString(), null);
                            }
                            else
                            {
                                nvrc.MoveCameraPTZ("2", null, null, "1", null);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 호실 상태정보 수정 및 UserController 수정
        /// </summary>
        /// <param name="groupCode">사동코드</param>
        /// <param name="roomCode">호실코드</param>
        /// <param name="roomStatus">문상태</param>
        /// <returns>호실 정보</returns>
        private JObject UpdateRoomStatusItemBySensor(string groupCode, string roomCode, string roomStatus)
        {
            DataTable roomDataTable = dbc.UpdateRoomStatus(groupCode, roomCode, roomStatus);

            UC_RoomStatusItem roomControl = null;

            foreach (Control control in this.top_room_panel.Controls)
            {
                if (control is UC_RoomStatusItem)
                {
                    UC_RoomStatusItem temp = control as UC_RoomStatusItem;
                    string UC_GroupCode = temp.GetGroupCode();
                    string UC_RoomCode = temp.GetRoomCode();
                    if (UC_GroupCode.Equals(groupCode) && UC_RoomCode.Equals(roomCode))
                    {
                        roomControl = control as UC_RoomStatusItem;
                    }
                }
            }

            foreach (Control control in this.bottom_room_panel.Controls)
            {
                if (control is UC_RoomStatusItem)
                {
                    UC_RoomStatusItem temp = control as UC_RoomStatusItem;
                    string UC_GroupCode = temp.GetGroupCode();
                    string UC_RoomCode = temp.GetRoomCode();
                    if (UC_GroupCode.Equals(groupCode) && UC_RoomCode.Equals(roomCode))
                    {
                        roomControl = control as UC_RoomStatusItem;
                    }
                }
            }

            if(roomControl != null)
            {
                roomControl.RoomColorChange(roomStatus);
            }

            DataRow[] rows = roomDataTable.Select();
            JObject json = new JObject();
            json.Add("groupCode", rows[0]["group_code"].ToString());
            json.Add("groupName", rows[0]["group_name"].ToString());
            json.Add("roomName", rows[0]["room_name"].ToString());
            json.Add("roomCode", rows[0]["room_code"].ToString());
            json.Add("roomStatus", rows[0]["room_status"].ToString());
            json.Add("roomStatusName", rows[0]["room_status_name"].ToString());
            json.Add("updatTime", rows[0]["updat_time"].ToString());
            json.Add("preset", rows[0]["preset"].ToString());

            return json;
        }
    }
}
