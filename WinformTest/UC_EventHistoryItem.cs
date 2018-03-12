using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformTest
{
    public partial class UC_EventHistoryItem : UserControl
    {
        private string groupCode;
        private string groupCodeName;
        private string roomCode;
        private string roomCodeName;
        private string roomStatus;
        private string roomStatusName;
        private string eventTime;

        /// <summary>
        /// 이벤트 로그정보 수신후 생성
        /// </summary>
        /// <param name="groupCode">사동 코드</param>
        /// <param name="groupCodeName">사동 명칭</param>
        /// <param name="roomCode">호실 코드</param>
        /// <param name="roomCodeName">호실 명칭</param>
        /// <param name="roomStatus">상태 코드</param>
        /// <param name="roomStatusName">상태 명칭</param>
        /// <param name="eventTime">이벤트 시간</param>
        public UC_EventHistoryItem(string groupCode, string groupCodeName, string roomCode, string roomCodeName, string roomStatus, string roomStatusName, string eventTime)
        {
            InitializeComponent();

            this.groupCode = groupCode;
            this.groupCodeName = groupCodeName;
            this.roomCode = roomCode;
            this.roomCodeName = roomCodeName;
            this.roomStatus = roomStatus;
            this.roomStatusName = roomStatusName;
            this.eventTime = eventTime;

            event_group_room_label.Text = this.groupCodeName + " " + roomCodeName + "사동";
            event_date_label.Text = this.eventTime;
            event_signal_label.Text = "문" + roomStatusName + " 신호 발생";
        }

        /// <summary>
        /// 이벤트 로그정보 수신후 수정
        /// </summary>
        /// <param name="groupCode">사동 코드</param>
        /// <param name="groupCodeName">사동 명칭</param>
        /// <param name="roomCode">호실 코드</param>
        /// <param name="roomCodeName">호실 명칭</param>
        /// <param name="roomStatus">상태 코드</param>
        /// <param name="roomStatusName">상태 명칭</param>
        /// <param name="eventTime">이벤트 시간</param>
        public void EventHistoryItemUpdate(string groupCode, string groupCodeName, string roomCode, string roomCodeName, string roomStatus, string roomStatusName, string eventTime)
        {
            this.groupCode = groupCode;
            this.groupCodeName = groupCodeName;
            this.roomCode = roomCode;
            this.roomCodeName = roomCodeName;
            this.roomStatus = roomStatus;
            this.roomStatusName = roomStatusName;
            this.eventTime = eventTime;

            event_group_room_label.Text = this.groupCodeName + " " + roomCodeName + "사동";
            event_date_label.Text = this.eventTime;
            event_signal_label.Text = "문" + roomStatusName + " 신호 발생";
        }
    }
}