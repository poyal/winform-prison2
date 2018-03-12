using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformTest
{
    public partial class Form2 : Form
    {
        NVRControll nvrCon;
        string rtspHeader = Properties.NVRAccessProperties.Default.RTSP_HEADER;
        string userName = Properties.NVRAccessProperties.Default.NVR_USER_NAME;
        string userPw = Properties.NVRAccessProperties.Default.NVR_USER_PW;
        string nvrIp = Properties.NVRAccessProperties.Default.NVR_IP;
        string channel = "2";

        public Form2()
        {
            InitializeComponent();
            GetViewCamera();
            MovePreset();
        }

        private void MovePreset()
        {
            nvrCon = new NVRControll();
            nvrCon.MoveCameraPTZ("2", null, null, channel, null);
        }

        private void GetViewCamera()
        {
            axVLCPlugin21.playlist.add(rtspHeader + userName + ":" + userPw + "@" + nvrIp + "/" + channel + "/high", null, null);
            axVLCPlugin21.playlist.next();
            axVLCPlugin21.playlist.play();
        }
    }
}
