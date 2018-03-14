using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using WinformTest.VO;

namespace WinformTest
{
    /// <summary>
    /// 호실상태 UserController
    /// </summary>
    public partial class UC_RoomStatusItem : UserControl
    {

        private string groupCode;
        private string roomCode;
        private string roomName;
        private string roomStatus;

        DBConnection dbc = new DBConnection();

        Util util = new Util();

        /// <summary>
        /// UC_RoomStatusItem 객체 생성
        /// </summary>
        /// <param name="groupCode">사동코드</param>
        /// <param name="roomCode">호실코드</param>
        /// <param name="roomName">호실명</param>
        /// <param name="roomStatus">호실상태</param>
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

        /// <summary>
        /// 호실 상태 수정
        /// </summary>
        /// <param name="groupCode">사동코드</param>
        /// <param name="roomCode">호실코드</param>
        /// <param name="roomName">호실명</param>
        /// <param name="roomStatus">호실상태</param>
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

        /// <summary>
        /// 호실코드 리턴
        /// </summary>
        /// <returns>호실코드</returns>
        public string GetRoomCode()
        {
            return this.roomCode;
        }

        /// <summary>
        /// 방상태정보 parent로 callback
        /// </summary>
        public event EventHandler RoomItemClick;

        /// <summary>
        /// 호실 클릭 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void room_panel_Click(object sender, EventArgs e)
        {
            DataTable roomDataTable = RoomStatusChange();
            DataRow[] rows = roomDataTable.Select();
            RoomInfoVO riVo = new RoomInfoVO();
            riVo.groupCode = rows[0]["group_code"].ToString();
            riVo.groupName = rows[0]["group_name"].ToString();
            riVo.roomCode = rows[0]["room_code"].ToString();
            riVo.roomName = rows[0]["room_name"].ToString();
            riVo.roomStatusName = rows[0]["room_status_name"].ToString();
            riVo.roomStatus = rows[0]["room_status"].ToString();
            riVo.preset = rows[0]["preset"].ToString();

            this.RoomItemClick(riVo, new EventArgs());
        }

        /// <summary>
        /// 호실 상태 변경
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 호실 상태색 변경
        /// </summary>
        /// <param name="roomStatus">호실상태</param>
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
