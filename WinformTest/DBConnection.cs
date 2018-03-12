using Npgsql;
using System.Data;

namespace WinformTest
{
    class DBConnection
    {
        private NpgsqlConnection conn;
        private NpgsqlCommand query = null;
        private NpgsqlDataAdapter da;
        private Util util = new Util();

        /// <summary>
        /// DB 연결 정보 (Host, Username, Password, Database)
        /// </summary>
        private string dbSource = "Host=" + Properties.DBProperties.Default.Host + ";" +
            "Username=" + Properties.DBProperties.Default.Username + ";" +
            "Password=" + Properties.DBProperties.Default.Password + ";" +
            "Database=" + Properties.DBProperties.Default.Database;

        /// <summary>
        /// DB 연결
        /// </summary>
        public void Open()
        {
            conn = new NpgsqlConnection(dbSource);
            conn.Open();
        }

        /// <summary>
        /// DB close
        /// </summary>
        public void Close()
        {
            conn.Close();
        }

        /// <summary>
        /// Update query
        /// </summary>
        /// <param name="sql">SQL query</param>
        public void Update(string sql)
        {
            query = new NpgsqlCommand(sql, conn);
            query.ExecuteNonQuery();
            query.Dispose();
        }

        /// <summary>
        /// Select return DataTable
        /// </summary>
        /// <param name="sql">SQL query</param>
        public DataTable SelectDataTable(string sql)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da = new NpgsqlDataAdapter(sql, conn);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            ds.Dispose();
            return dt;
        }

        /// <summary>
        /// 이벤트 로그정보를 조회한다.
        /// </summary>
        /// <returns>이벤트 로그정보</returns>
        public DataTable SelectRoomStatusHistory()
        {
            string sql = "";
            sql += "SELECT ";
            sql += "    group_code                          AS group_code, ";
            sql += "    (SELECT group_name ";
            sql += "     FROM group_info G ";
            sql += "     WHERE G.group_code = A.group_code) AS group_code_name, ";
            sql += "    room_code                           AS room_code, ";
            sql += "    room_name                           AS room_code_name, ";
            sql += "    room_status                         AS room_status, ";
            sql += "    (CASE WHEN room_status = 'O' ";
            sql += "     THEN '열림' ";
            sql += "     ELSE '닫힘' ";
            sql += "     END)                               AS room_status_name, ";
            sql += "    (CASE WHEN room_status = 'O'";
            sql += "     THEN to_char(room_open_time, 'YYYY-MM-DD HH24:MI:SS') ";
            sql += "     ELSE to_char(room_close_time, 'YYYY-MM-DD HH24:MI:SS') ";
            sql += "     END)                               AS event_time ";
            sql += "FROM room_status_history A ";
            sql += "WHERE room_status = 'O' ";
            sql += "ORDER BY event_time DESC ";
            sql += "LIMIT 20 ";

            DataTable historyDataTable = SelectDataTable(sql);
            return historyDataTable;
        }

        /// <summary>
        /// 사동정보를 조회한다.
        /// </summary>
        /// <returns>사동정보</returns>
        public DataTable SelectGroupStatus()
        {
            string sql = "";
            sql += "SELECT ";
            sql += "  A.group_name          AS group_name, ";
            sql += "  A.group_code          AS group_code, ";
            sql += "  A.group_inmates       AS group_inmates, ";
            sql += "  A.room_cnt            AS room_cnt, ";
            sql += "  A.door_cnt            AS door_cnt, ";
            sql += "  A.camera_cnt          AS camera_cnt, ";
            sql += "  COUNT(CASE ";
            sql += "        WHEN B.room_status = 'O' ";
            sql += "          THEN ";
            sql += "            '1' END)    AS open_cnt ";
            sql += "FROM group_info A, room_info B ";
            sql += "WHERE A.group_code = B.group_code ";
            sql += "GROUP BY A.group_code ";
            sql += "ORDER BY A.group_code ASC ";


            DataTable groupDataTable = SelectDataTable(sql);
            return groupDataTable;
        }

        public DataTable GetRoomList(string groupCode, string roomCode)
        {
            string sql = "";
            sql += "SELECT ";
            sql += "  A.group_code                        AS group_code, ";
            sql += "  (SELECT G.group_name ";
            sql += "   FROM group_info G ";
            sql += "   WHERE G.group_code = A.group_code) AS group_name, ";
            sql += "  A.room_code                         AS room_code, ";
            sql += "  A.room_name                         AS room_name, ";
            sql += "  A.room_status AS room_status, ";
            sql += "  (CASE WHEN A.room_status = 'O' ";
            sql += "    THEN '열림' ";
            sql += "   ELSE '닫힘' ";
            sql += "   END)                               AS room_status_name, ";
            sql += "  (CASE WHEN A.room_status = 'O' ";
            sql += "    THEN to_char(A.room_open_time, 'YYYY-MM-DD HH24:MI:SS') ";
            sql += "   ELSE to_char(A.room_close_time, 'YYYY-MM-DD HH24:MI:SS') ";
            sql += "   END)                               AS updat_time ";
            sql += "FROM room_info A ";
            sql += "WHERE 1 = 1 ";
            sql += "      AND A.group_code = '" + groupCode + "' ";
            if (!string.IsNullOrEmpty(roomCode))
            {
                sql += "      AND A.room_code = '" + roomCode + "' ";
            }
            sql += "ORDER BY A.room_code ASC";

            DataTable roomDataTable = SelectDataTable(sql);
            return roomDataTable;
        }

        public DataTable UpdateRoomStatus(string groupCode, string roomCode, string roomStatus)
        {
            string sql = "";
            sql += "UPDATE room_info ";
            sql += "SET ";
            if (roomStatus.Equals("O"))
            {
                sql += "room_status = 'O', ";
                sql += "room_open_time = now() ";
            }
            else if (roomStatus.Equals("C"))
            {
                sql += "room_status = 'C', ";
                sql += "room_close_time = now() ";
            }
            sql += "WHERE ";
            sql += "group_code = '" + groupCode + "' AND room_code = '" + roomCode + "'";

            Update(sql);

            DataTable roomDatatable = GetRoomList(groupCode, roomCode);
            return roomDatatable;
        }
    }
}
