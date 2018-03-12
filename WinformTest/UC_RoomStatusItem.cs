using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace WinformTest
{
    public partial class UC_RoomStatusItem : UserControl
    {
        private string groupCode;
        private string roomCode;
        private string roomName;
        private string roomStatus;

        DBConnection dbc = new DBConnection();

        Util util = new Util();

        public UC_RoomStatusItem(string groupCode, string roomCode, string roomName, string roomStatus)
        {
            InitializeComponent();

            this.groupCode = groupCode;
            this.roomCode = roomCode;
            this.roomName = roomName;
            this.roomStatus = roomStatus;

            room_name_label.Text = roomName + "호실";

            int roomNo = util.ReturnRoomCodeToRoomNo(this.roomCode);
            if (roomNo <= 10)
            {
                door_panel.Location = new Point(29, 104);
            }
            else
            {
                door_panel.Location = new Point(29, 0);
            }

            RoomColorChange(this.roomStatus);
        }

        public void UpdateRoomStatusItem(string groupCode, string roomCode, string roomName, string roomStatus)
        {
            this.groupCode = groupCode;
            this.roomCode = roomCode;
            this.roomName = roomName;
            this.roomStatus = roomStatus;

            room_name_label.Text = roomName + "호실";

            int roomNo = util.ReturnRoomCodeToRoomNo(this.roomCode);
            if (roomNo <= 10)
            {
                door_panel.Location = new Point(29, 104);
            }
            else
            {
                door_panel.Location = new Point(29, 0);
            }

            RoomColorChange(this.roomStatus);
        }

        public string GetRoomCode()
        {
            return this.roomCode;
        }

        public event EventHandler RoomItemClick;
        private void room_panel_Click(object sender, EventArgs e)
        {
            DataTable roomDataTable = RoomStatusChange();
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
            this.RoomItemClick(json, new EventArgs());
        }

        private void RoomColorChange(string roomStatus)
        {
            if (roomStatus.Equals("O"))
            {
                room_panel.BackColor = Color.DarkRed;
            }
            else if (roomStatus.Equals("C"))
            {
                room_panel.BackColor = util.GetRGBColor(45, 45, 45);
            }
        }

        private DataTable RoomStatusChange()
        {
            dbc.Open();
            if (this.roomStatus.Equals("O"))
            {
                this.roomStatus = "C";
            }
            else
            {
                this.roomStatus = "O";
            }

            RoomColorChange(this.roomStatus);
            DataTable roomDataTable = dbc.UpdateRoomStatus(this.groupCode, this.roomCode, this.roomStatus);
            dbc.Close();
            return roomDataTable;
        }
    }
}
