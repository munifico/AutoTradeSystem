using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace db_chart_update
{
    public partial class Form1 : Form
    {
        int g_flag_9 =0;
        private string g_rqname;
        public Form1()
        {
            InitializeComponent();
            this.axKHOpenAPI1.OnReceiveTrData += new AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEventHandler(this.axKHOpenAPI1_OnReceiveTrData);
            string jongmok_cd = "005930";
            up_tb_chart(jongmok_cd);
        }

        private void axKHOpenAPI1_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (g_rqname.CompareTo(e.sRQName) == 0)
            {
                ;
            }
            else
            {
                switch(g_rqname)
                {
                    case "일봉차트조회":
                        g_flag_9 = 1;
                        break;
                }
                if (e.sRQName == "일봉차트조회")
                {
                    string jongmok_cd = null;
                    int cur_price;
                    int trd_amt;
                    int trd_price;
                    String trd_tm;
                    int start_price;
                    int high_price;
                    int low_price;

                    int repaet_cnt = 0;
                    int ii = 0;

                    jongmok_cd = "";

                    jongmok_cd = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목코드").Trim();
                    repaet_cnt = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);

                    // set_tb_day_chart(jongmok_cd);

                    for (ii = 0; ii < 100; ii++)
                    {
                        cur_price = 0;
                        high_price = 0;
                        low_price = 0;
                        trd_amt = 0;
                        trd_price = 0;
                        trd_tm = "";
                        start_price = 0;



                        cur_price = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, ii, "현재가").Trim());
                        trd_amt = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, ii, "거래량").Trim());
                        trd_price = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, ii, "거래대금").Trim());
                        trd_tm = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, ii, "일자").Trim();
                        start_price = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, ii, "시가").Trim());
                        high_price = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, ii, "고가").Trim());
                        low_price = int.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, ii, "저가").Trim());

                        insert_tb_day_chart(jongmok_cd, cur_price, trd_amt, trd_price, trd_tm, start_price, high_price, low_price);
                    }
                    axKHOpenAPI1.DisconnectRealData(e.sScrNo);
                    g_flag_9 = 1;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void up_tb_chart(string jongmok_cd)
        {
            DateTime dt = DateTime.Today;
            g_rqname = "일봉차트조회";
            axKHOpenAPI1.SetInputValue("종목코드", jongmok_cd);
            axKHOpenAPI1.SetInputValue("기준일자", dt.ToString("yyyyMMdd"));
            axKHOpenAPI1.SetInputValue("수정주가구분", "0");
            axKHOpenAPI1.CommRqData("일봉차트조회", "opt10081", 0, "1");
        }

        private void insert_tb_day_chart(string jongmok_cd, int cur_price, int trd_amt, int trd_price, String trd_tm, int start_price, int high_price, int low_price)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            l_sql = "";

            l_sql = @"insert into tb_day_chart values(" + "'" + jongmok_cd + "'" + "," + cur_price + "," + trd_amt + "," + trd_price + "," + "'" + trd_tm + "'" + "," + start_price + "," + high_price + "," + low_price + ")";

            cmd.CommandText = l_sql;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            

            }
            conn.Close();
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
