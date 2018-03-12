﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformTest
{
    public partial class Form1 : Form
    {
        private DBConnection dbc = new DBConnection();
        private Util util = new Util();
        private int groupMargin = Properties.CommonProperties.Default.groupMargin;
        private string sensorSignal = "";
        private System.Timers.Timer aTimer;
        private string preset = "1";
        private string selectGroupCode;

        public Form1()
        {
            InitializeComponent();

            dbc.Open();
            ViewCamera("2");
            SensorSearchTimer();
            AddGroupStatusItem();
            AddEventHistoryItem();
            SettingRoom();
        }

        private void LeftMenuDashboardClick(object sender, EventArgs e)
        {
            //this.Visible = false; // 현재 폼 안보이게 하기
            Form1 frm = new Form1(); // 새 폼 생성¬
            frm.Owner = this; // 새 폼의 오너를 현재 폼으로
            frm.Show(); // 새폼 보여 주 기
        }

        private void LeftMenuSettingClick(object sender, EventArgs e)
        {
            //this.Visible = false; // 현재 폼 안보이게 하기
            //Form2 frm = new Form2(); // 새 폼 생성¬
            //frm.Owner = this; // 새 폼의 오너를 현재 폼으로
            //frm.Show(); // 새폼 보여 주 기
        }

        private void AddGroupStatusItem()
        {
            DataTable groupDataTable = dbc.SelectGroupStatus();
            int index = 0;
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
                    XPos += item.Width;
                }

                int locationX = 0;
                if (index == 0)
                {
                    locationX = temp.Location.X + groupMargin + XPos;
                }
                else
                {
                    locationX = temp.Location.X + groupMargin * 2 + XPos;
                }
                temp.Location = new Point(locationX, temp.Location.Y + 10);
                group_status_panel.Controls.Add(temp);

                index++;
            }
        }

        public void UpdateGroupItem()
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

        public void Group_Item_Click(object sender, EventArgs e)
        {
            JObject json = sender as JObject;
            Console.WriteLine("groupCode = " + json["groupCode"]);
            Console.WriteLine("groupCodeName = " + json["groupCodeName"]);
        }

        /// <summary>
        /// 방열림정보 셋팅
        /// </summary>
        private void AddEventHistoryItem()
        {
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

        private void SensorSearchTimer()
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 1000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            string comportStr = "";
            foreach (string comport in SerialPort.GetPortNames())
            {
                comportStr = comport;
            }

            if (!comportStr.Equals(""))
            {
                aTimer.Stop();
                SensorConnect(comportStr);
            }
        }

        private void SensorConnect(string comportStr)
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
            btnPortOpen_Click();
        }

        private void btnPortOpen_Click()
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

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string data = serialPort1.ReadExisting();

                if (data.Trim() != string.Empty)
                {
                    char[] values = data.ToCharArray();
                    int value = Convert.ToInt32(values[0]);


                    if (data.Trim() != sensorSignal && data.Trim().Length == 1)
                    {
                        /*
                        if (sensorSignal == "")
                        {
                            isOpenFlag = true;
                        }
                        */
                        Console.WriteLine("----------------------");
                        Console.WriteLine("data = " + data.Trim());
                        sensorSignal = data.Trim();

                        //Console.WriteLine("-------------------------");
                        //Console.WriteLine("data = " + data.Trim());

                        //string status = "";
                        //if (data.Trim() == "1")
                        //{
                        //status = "C";
                        //RoomStatusUpdate(1, 1, status);
                        //SensorSignalCollector(1, 1, status);
                        //}
                        //else if (data.Trim() == "0")
                        //{
                        //status = "O";
                        //RoomStatusUpdate(1, 1, status);
                        //SensorSignalCollector(1, 1, status);
                        //}
                    }
                }
            }
        }

        private void SettingRoom()
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
        /// 각 호실 클릭 이벤트
        /// </summary>
        public void Room_Item_Click(object sender, EventArgs e)
        {
            UpdateGroupItem();
            JObject json = sender as JObject;
            Console.WriteLine("============== sender :: " + json.ToString());
            NVRControll nvrc = new NVRControll();

            AddEventHistoryItem();

            if ("C".Equals(json.GetValue("roomStatus").ToString()))
            {
                nvrc.MoveCameraPTZ("2", null, null, "1", null);
            } else
            {
                nvrc.MoveCameraPTZ("2", null, null, json.GetValue("preset").ToString(), null);
            }
            
        }

        /// <summary>
        /// nvr streaming
        /// </summary>
        private void ViewCamera(String channel)
        {
            axVLCPlugin21.playlist.add("rtsp://admin:Tjxldnpdj2018!@192.168.10.124/" + channel + "/high", null, null);
            axVLCPlugin21.playlist.next();
            axVLCPlugin21.playlist.play();
        }
    }
}
