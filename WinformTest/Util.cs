using System.Drawing;

namespace WinformTest
{
    /// <summary>
    /// 공통 클래스
    /// </summary>
    class Util
    {
        /// <summary>
        /// string 숫자 -> string 두자리 숫자
        /// </summary>
        /// <param name="number">string형 숫자</param>
        /// <returns></returns>
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

        /// <summary>
        /// 호실 코드 -> 방번호
        /// </summary>
        /// <param name="roomCode">호실 코드</param>
        /// <returns>int 형 방번호</returns>
        public int ReturnRoomCodeToRoomNo(string roomCode)
        {
            int roomNo;
            int.TryParse(roomCode.Substring(1, 2), out roomNo);
            return roomNo;
        }

        /// <summary>
        /// RGB 형변환
        /// </summary>
        /// <param name="red">R</param>
        /// <param name="blue">G</param>
        /// <param name="green">B</param>
        /// <returns>Color형</returns>
        public Color GetRGBColor(int red, int blue, int green)
        {
            Color myRgbColor = new Color();
            myRgbColor = Color.FromArgb(red, blue, green);
            return myRgbColor;
        }
    }
}
