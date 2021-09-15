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
    public partial class search_market : Form
    {
        public List<string> jongmok
        { get; set; }

        public search_market()
        {
            InitializeComponent();
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

        private void market_search_button_Click(object sender, EventArgs e)
        {
           

            String text;
            text = market_search_text.Text;
            if (text == null)
                return;

            String jongmok_cd;
            String jongmok_nm;
            String[] l_arr = null;

            OracleCommand cmd;
            OracleConnection conn;
            OracleDataReader reader;

            String sql_l;

            conn = connect_db();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            sql_l = "";
            sql_l = @"select * from tb_jongmok_lst where jongmok_cd LIKE " + "'%" + text + "%'" + "OR jongmok_nm LIKE " + "'%" + text + "%'" ;

            cmd.CommandText = sql_l;
            reader = cmd.ExecuteReader();

            this.Invoke(new MethodInvoker(
               delegate ()
               {
                   jongmok_lst.Rows.Clear(); // 그리드뷰 초기화
                }));


            while (reader.Read())
            {
                jongmok_nm = "";
                jongmok_cd = "";

                jongmok_nm = reader[0].ToString().Trim();
                jongmok_cd = reader[1].ToString().Trim();

                l_arr = null;
                l_arr = new string[]
                {
                    jongmok_nm.ToString(),
                    jongmok_cd.ToString()
                };
                this.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        jongmok_lst.Rows.Add(l_arr);
                    }));
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            jongmok = new List<string>();

            foreach(DataGridViewRow row in jongmok_lst.Rows)
            {
                if (Convert.ToBoolean(row.Cells[check.Name].Value) != true) continue;

                else
                {
                    jongmok.Add(row.Cells[0].Value.ToString() + "," + row.Cells[1].Value.ToString() );
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            
            this.Close();
        }

        private void search_market_Load(object sender, EventArgs e)
        {

        }
    }
}
