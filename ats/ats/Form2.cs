using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ats
{
    public partial class Form2 : Form
    {
        string jongmok_cd;

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

        public Form2(string jongmok_cd)
        {
            InitializeComponent();
            initailChart();
        } 

        

        void initailChart()
        {
            Chart chart = new Chart();
            chart.initChart(jongmok_cd);
            Info[] nfo = chart.getInfo();

            for (int i=0; i<99; i++)
            {
                
                chart1.Series["Series 1"].Points.AddXY(nfo[i].tm, nfo[i].low_price, nfo[i].high_price);
            }
        }
    }
}
