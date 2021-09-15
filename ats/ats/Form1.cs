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
    public partial class Form1 : Form
    {
        public OracleConnection connect_db()   // 오라클 연결 변수 리턴
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

        public Form1()
        {
            InitializeComponent();

            Chart temp = new Chart();

            String jongmok_cd;
            String jongmok_nm;

            OracleCommand cmd;
            OracleConnection conn;
            OracleDataReader reader;

            String sql_l;

            conn = connect_db();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql_l = "";
            sql_l = @"select * from tb_jongmok_lst";

            cmd.CommandText = sql_l;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                jongmok_cd = "";
                jongmok_nm = "";
                jongmok_cd = reader[0].ToString().Trim();
                jongmok_nm = reader[1].ToString().Trim();

                temp = null;
                temp = new Chart();
                temp.initChart(jongmok_cd);
                if (temp.estimateChart())
                {
                    // 코드 이름 시가 고가 저가
                    string[] row = { jongmok_cd, jongmok_nm, temp.getStart_price().ToString(), temp.getHigh_price().ToString(), temp.getLow_price().ToString() };
                    dataGridView1.Rows.Add(row);
                }


            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string jongmok_cd = dataGridView1.Rows[i].Cells[0].Value.ToString();

            Form2 form2 = new Form2(jongmok_cd);

            form2.Activate();
        }
    }
}
