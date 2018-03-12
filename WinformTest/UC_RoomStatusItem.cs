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

        public event EventHandler RoomItemClick;
        private void room_panel_Click(object sender, EventArgs e)
        {
            JObject json = new JObject();
            json.Add("groupCode", this.groupCode);
            json.Add("roomCode", this.roomCode);
            json.Add("roomName", this.roomName);
            json.Add("roomStatus", this.roomStatus);
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
    }
}
