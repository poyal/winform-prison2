using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformTest
{
    class Util
    {
        public string ReturnIntToString(string number)
        {
            string strNum = "";
            strNum = number;
            if (strNum.Length == 1)
            {
                strNum = "0" + strNum;
            }
            return strNum;
        }

        public int ReturnRoomCodeToRoomNo(string roomCode)
        {
            int roomNo;
            int.TryParse(roomCode.Substring(1, 2), out roomNo);
            return roomNo;
        }

        public Color GetRGBColor(int red, int blue, int green)
        {
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(red, blue, green);
            return myRgbColor;
        }
    }
}
