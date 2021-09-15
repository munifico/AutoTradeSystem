using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace ats
{

    struct Info
    {
        public int start_price;
        public int high_price;
        public int low_price;
        public DateTime tm;
    }

    class Chart
    {
        string jongmok_cd;
        Info[] nfo;

       

        public Info[] getInfo()
        {
            return nfo;
        }

        public int getStart_price()
        {
            return nfo[99].start_price;
        }

        public int getHigh_price()
        {
            return nfo[99].high_price;
        }

        public int getLow_price()
        {
            return nfo[99].low_price;
        }

        public void initChart(string jongmok_cd)
        {
            this.jongmok_cd = jongmok_cd;
            nfo = new Info[100];

            OracleCommand cmd;
            OracleConnection conn;
            OracleDataReader reader;
            string sql;

            conn = null;
            conn = connect_db();

            cmd = null;
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql = null;
            sql = @"select * from TB_DAY_CHART WHERE jongmok_cd = " + jongmok_cd + "order by TRD_TM";

            cmd.CommandText = sql;
            reader = cmd.ExecuteReader();
            int i = 0;
            while(reader.Read())
            {
                nfo[i].tm = DateTime.Parse(reader[4].ToString().Trim());
                nfo[i].start_price = int.Parse(reader[5].ToString().Trim());
                nfo[i].high_price = int.Parse(reader[6].ToString().Trim());
                nfo[i].low_price = int.Parse(reader[7].ToString().Trim());
                i++;
            }
    
            conn.Close();
        }

        public bool estimateChart()
        {
            // 1. 5%이상 상승하는지만 체크해보자
            if (nfo[0].start_price * 0.05 > nfo[99].start_price)
                return true;

            return false;
        }

        private OracleConnection connect_db()   // 오라클 연결 변수 리턴
        {
            // 접속 변수 저장
            String conninfo = "User Id=ats;Password=1234;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=xe)));";

            OracleConnection conn = new OracleConnection(conninfo); // 오라클 연결 인스턴스 생성

            try
            {
                conn.Open();    // 오라클 접속
            }
            catch (Exception ex) // 접속 실패 시
            {

                MessageBox.Show("connect_db() FAIL! " + ex.Message, "오류 발생");   // 메시지 박스 출력
                conn = null;
            }
            return conn;    // conn 변수 리턴
        }
    }
}
