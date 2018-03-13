using Newtonsoft.Json.Linq;
using System;

namespace WinformTest
{
    class NVRControll
    {
        DigestAuthFixer digest;

        string rtspHeader = Properties.NVRAccessProperties.Default.RTSP_HEADER;
        string httpHeader = Properties.NVRAccessProperties.Default.HTTP_HEADER;
        string userName = Properties.NVRAccessProperties.Default.NVR_USER_NAME;
        string userPw = Properties.NVRAccessProperties.Default.NVR_USER_PW;
        string nvrIp = Properties.NVRAccessProperties.Default.NVR_IP;

        public void MoveCameraPTZ(string channel, string move, string zoom, string preset, string presetSave)
        {

            string url = string.Concat(httpHeader, nvrIp);
            string dir = "/control/ptz.cgi?level=1";

            if (!String.IsNullOrEmpty(channel))
            {
                dir += "&channel=" + channel;
            }

            if (!String.IsNullOrEmpty(move))
            {
                dir += "&move=" + move;
                dir += "&pentilt_speed=6";
            }

            if (!String.IsNullOrEmpty(zoom))
            {
                dir += "&zoom=" + zoom;
                dir += "&zoom_speed=6";
            }

            if (!String.IsNullOrEmpty(preset))
            {
                dir += "&preset=" + preset;
            }

            if (!String.IsNullOrEmpty(presetSave))
            {
                dir += "&presetSave=" + presetSave;
            }

            digest = new DigestAuthFixer(url, userName, userPw);
            JObject jsonReturn = digest.GrabResponse(dir);
        }
    }
}
