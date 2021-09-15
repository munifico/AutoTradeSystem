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
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading; // 스레드 라이브러리 참조
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;


namespace ats
{
    public partial class Main : Form
    {
        string g_user_id = "jyj9798";
        string g_accnt_no = null;

        Thread thread1 = null;  // 생성된 스레드 객체를 담을 변수        

        // Form1 생성자
        public Main()
        {
            InitializeComponent();
        }



        // 오라클 접속 연결 메서드
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


        // 계좌정보 테이블 세팅 메서드
        public void merge_tb_accnt_info(String i_jongmok_cd, String i_jongmok_nm, int i_boyu_cnt, int i_boyu_price, int i_boyu_amt)
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();


            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            // 계좌정보 테이블 세팅, 기존에 보유한 종목이면 갱신, 보유자히 않았으면 신규로 가입
            l_sql = @"merge into TB_ACCNT_INFO a using (select nvl(max(user_id), '0') user_id, nvl(max(ref_dt), '0') ref_dt, nvl(max(jongmok_cd), '0') jongmok_cd, nvl(max(jongmok_nm), '0') jongmok_nm from TB_ACCNT_INFO where user_id = '" + g_user_id + "'" +
                " and ACCNT_NO = '" + g_accnt_no + "'" +
                " and jongmok_cd = '" + jongmok_cd + "'" +
                " and ref_dt = to_char(sysdate, 'yyyymmdd') " +
                " ) b " +
                " on(a.user_id = b.user_id and a.jongmok_cd = b.jongmok_cd and a.ref_dt = b.ref_dt) " +
                " when matched then update " +
                " set OWN_STOCK_CNT = " + i_boyu_cnt + "," +
                " BUY_PRICE = " + i_boyu_price + "," +
                " OWN_AMT = " + i_boyu_amt + "," +
                " updt_dtm = SYSDATE" + "," +
                " updt_id = 'ats'" +
                " when not matched then " +
                "insert (a.user_id, a.accnt_no, Fa.ref_dt, a.jongmok_cd, a.jongmok_nm, a.BUY_PRICE, a.OWN_STOCK_CNT, a.OWN_AMT, a.inst_dtm, a.inst_id) values ( " +
                "'" + g_user_id + "'" + "," +
                "'" + g_accnt_no + "'" + "," +
                "to_char(sysdate, 'yyyymmdd'), " +
                "'" + i_jongmok_cd + "'" + "," +
                "'" + i_jongmok_nm + "'" + "," +
                i_boyu_price + "," +
                i_boyu_cnt + "," +
                i_boyu_amt + "," +
                "SYSDATE, " +
                "'ats'" +
                " ) ";

            cmd.CommandText = l_sql;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                write_err_log("merge TB_ACCNT_INFO ex : [" + ex.Message + "]\r\n", 0);
            }
            conn.Close();
        }

        public void insert_tb_ord_lst(string i_ref_dt, String i_jongmok_cd, String i_jongmok_nm, String i_ord_gb, String i_ord_no, String i_org_ord_no, int i_ord_price, int i_ord_stock_cnt, int i_ord_amt, String i_ord_dtm)  // 주문내역 저장 매서드
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            // 주문내역 저장
            l_sql = @"insert into tb_ord_lst values ( " +
                "'" + g_user_id + "'" + "," +
                "'" + g_accnt_no + "'" + "," +
                "'" + i_ref_dt + "'" + "," +
                "'" + i_jongmok_cd + "'" + "," +
                "'" + i_jongmok_nm + "'" + "," +
                "'" + i_ord_gb + "'" + "," +
                "'" + i_ord_no + "'" + "," +
                "'" + i_org_ord_no + "'" + "," +
                i_ord_price + "," +
                i_ord_stock_cnt + "," +
                i_ord_amt + "," +
                "'" + i_ord_dtm + "'" + "," +
                "'ats'" + "," +
                "SYSDATE" + "," +
                "null" + "," +
                "null" + ") ";

            cmd.CommandText = l_sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                write_err_log("inset tb_ord_lst ex : [" + ex.Message + "] \r\n", 0);
            }
            conn.Close();
        }

        public void update_tb_accnt(String i_chegyul_gb, int i_chegyul_amt) // 계좌 테이블 수정 메서드
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;

            l_sql = null;

            cmd = null;
            conn = null;
            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            if (i_chegyul_gb == "2") // 매수일 때 주문가능금액에서 체결금액 빼기
            {
                l_sql = @" update TB_ACCNT set ORD_POSSIBLE_AMT = ord_possible_amt - " +
                    i_chegyul_amt + ", updt_dtm = SYSDATE, updt_id = 'ats' " +
                    " where user_id = " + "'" + g_user_id + "'" +
                    " and accnt_no = " + "'" + g_accnt_no + "'" +
                    " and ref_dt = to_char(sysdate, 'yyyymmdd') ";
            }
            else if (i_chegyul_gb == "1") // 매도일 때 주문가능금액에 체결금액 더하기
            {
                l_sql = @"update TB_ACCNT set ORD_POSSIBLE_AMT = ord_possible_amt + " +
                    i_chegyul_amt + ", updt_dtm = SYSDATE, updt_id = 'ats' " +
                    " where user_id = " + "'" + g_user_id + "'" +
                    " and accnt_no = " + "'" + g_accnt_no + "'" +
                    " and ref_dt = to_char(sysdate, 'yyyymmdd') ";
            }

            cmd.CommandText = l_sql;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                write_err_log("update TB_ACCNT ex.Message : [" + ex.Message + "]\r\n", 0);
            }
            conn.Close();
        }

        public void insert_tb_chegyul_lst(string i_ref_dt, String i_jongmok_cd, String i_jongmok_nm, String i_chegyul_gb, int i_chegyul_no, int i_chegyul_price, int i_chegyul_stock_cnt, int i_chegyul_amt, String i_chegyul_dtm, String i_ord_no, String i_org_ord_no)
        // 채결내역 저장 매서드
        {
            OracleCommand cmd = null;
            OracleConnection conn = null;
            String l_sql = null;
            l_sql = null;
            cmd = null;
            conn = null;
            conn = connect_db();

            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            // 체결내역 테이블 삽입
            l_sql = @" insert into tb_chegyul_lst values ( " +
                "'" + g_user_id + "'" + "," +
                "'" + g_accnt_no + "'" + "," +
                "'" + i_ref_dt + "'" + "," +
                "'" + i_jongmok_cd + "'" + "," +
                "'" + i_jongmok_nm + "'" + "," +
                "'" + i_chegyul_gb + "'" + "," +
                "'" + i_ord_no + "'" + "," +
                "'" + i_chegyul_gb + "'" + "," +
                i_chegyul_no + "," +
                i_chegyul_price + "," +
                i_chegyul_stock_cnt + "," +
                i_chegyul_amt + "," +
                "'" + i_chegyul_dtm + "'" + "," +
                "'ats'" + "," + "SYSDATE" + "," +
                "null" + "," +
                "null" + ") ";

            cmd.CommandText = l_sql;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                write_err_log("insert tb_chegyul_lst ex : [" + ex.Message + "]\r\n", 0);
            }
            conn.Close();
        }



        public string get_cur_tm() // 현재 시간을 시분초로 리턴하는 함수
        {
            DateTime l_cur_time;
            string l_cur_tm;

            l_cur_time = DateTime.Now;  // 현재시각을 l_cur_time에 저장
            l_cur_tm = l_cur_time.ToString("HHmmss");   // 시분초를 l_cur_tm에 저장

            return l_cur_tm;    // 현재 시간을 리턴
        }

        public string get_cur_date()
        {
            DateTime l_cur_date;
            string l_cur_dt;

            l_cur_date = DateTime.Now;
            l_cur_dt = l_cur_date.ToString("yyyyMMdd");

            return l_cur_dt;
        }

        public string get_jongmok_nm(string i_jongmok_cd)       // 종목코드를 입력값으로 받음
        {
            string l_jongmok_nm = null;

            l_jongmok_nm = axKHOpenAPI1.GetMasterCodeName(i_jongmok_cd);    // 종목명 가져오기
            return l_jongmok_nm;    // 종목명 리턴
        }



        public void write_msg_log(String text, int is_clear) // 메시지로그를 출력
        {
            DateTime l_cur_time;
            String l_cur_dt;

            String l_cur_tm;
            String l_cur_dtm;

            l_cur_dt = "";
            l_cur_tm = "";

            l_cur_time = DateTime.Now;
            l_cur_dt = l_cur_time.ToString("yyyy-") + l_cur_time.ToString("MM-") + l_cur_time.ToString("dd");
            l_cur_tm = l_cur_time.ToString("HH:mm:ss");
            l_cur_dtm = "[" + l_cur_dt + " " + l_cur_tm + "]";
            if (is_clear == 1)
            {
                if (this.textBox_msg_log.InvokeRequired)
                {
                    textBox_msg_log.BeginInvoke(new Action(() => textBox_msg_log.Clear()));
                }
                else
                {
                    this.textBox_msg_log.Clear();
                }
            }
            else
            {
                if (this.textBox_msg_log.InvokeRequired)
                {
                    textBox_msg_log.BeginInvoke(new Action(() => textBox_msg_log.AppendText(l_cur_dtm + text)));
                }
                else
                {
                    this.textBox_msg_log.AppendText(l_cur_dtm + text);
                }
            }
        }


        public void write_err_log(String text, int is_clear)    // 에러로그를 출력
        {
            DateTime l_cur_time;
            String l_cur_dt;
            String l_cur_tm;
            String l_cur_dtm;

            l_cur_dt = "";
            l_cur_tm = "";

            l_cur_time = DateTime.Now;
            l_cur_dt = l_cur_time.ToString("yyyy-") + l_cur_time.ToString("MM-") + l_cur_time.ToString("dd");

            l_cur_tm = l_cur_time.ToString("HH:mm:ss");
            l_cur_dtm = "[" + l_cur_dt + " " + l_cur_tm + "]";

            if (is_clear == 1)
            {
                if (this.textBox_err_log.InvokeRequired)
                {
                    textBox_err_log.BeginInvoke(new Action(() => textBox_err_log.Clear()));
                }
                else
                {
                    this.textBox_err_log.Clear();
                }
            }
            else
            {
                if (this.textBox_err_log.InvokeRequired)
                {
                    textBox_err_log.BeginInvoke(new Action(() => textBox_err_log.AppendText(l_cur_dtm + text)));
                }
                else
                {
                    this.textBox_err_log.AppendText(l_cur_dtm + text);
                }
            }
        }

        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        public DateTime delay(int MS)   // 지연을 위한 메서드
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                try
                {
                    unsafe
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                }

                catch (AccessViolationException ex)
                {
                    write_err_log("delay() ex.Message : [" + ex.Message + "]\r\n", 0);
                }
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }




        //private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    int ret = 0;
        //    int ret2 = 0;

        //    String l_accno = null;          // 증권계좌번호
        //    String l_accno_cnt = null;      // 소유한 증권계좌번호의 수
        //    String[] l_accno_arr = null;    // N개의 증권계좌번호를 저장할 배열

        //    ret = axKHOpenAPI1.CommConnect();   // 로그인 창 호출

        //    if (ret == 0)
        //    {
        //        toolStripStatusLabel1.Text = "로그인 중...";

        //        for (; ; )
        //        {
        //            ret2 = axKHOpenAPI1.GetConnectState(); // 로그인 완료 여부를 가져움 
        //            if (ret2 == 1)   // 로그인이 완료되면
        //            {
        //                break;  // 반복문을 벗어남
        //            }
        //            else
        //            {
        //                delay(1000); // 1초 지연
        //            }
        //        }
        //        toolStripStatusLabel1.Text = "로그인 완료"; // 화면 하단 상태란에 메시지 출력

        //        g_user_id = "";
        //        g_user_id = axKHOpenAPI1.GetLoginInfo("USER_ID").Trim();    // 사용자 아이디를 가져와서 클래스 변수에 저장
        //        textBox1.Text = g_user_id;  // 클래스 변수에 저장한 아이디를 텍스트박스에 출력

        //        l_accno_cnt = "";
        //        l_accno_cnt = axKHOpenAPI1.GetLoginInfo("ACCOUNT_CNT").Trim(); // 사용자의 증권계좌번호 수를 가져옴
        //        l_accno_arr = new string[int.Parse(l_accno_cnt)];

        //        l_accno = "";
        //        l_accno = axKHOpenAPI1.GetLoginInfo("ACCNO").Trim();    // 증권계좌번호 가져옴

        //        l_accno_arr = l_accno.Split(';');

        //        comboBox1.Items.Clear();
        //        comboBox1.Items.AddRange(l_accno_arr);  // N개의 증권계좌번호를 콤보박스에 저장
        //        comboBox1.SelectedIndex = 0;    // 첫 번째 계좌번호를 콤보박스 초기 선택으로 설정
        //        g_accnt_no = comboBox1.SelectedItem.ToString().Trim();  // 설정된 증권계좌번호를 클래스 변수에 저장.
        //    }
        //}

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    g_accnt_no = comboBox1.SelectedItem.ToString().Trim();
        //    write_msg_log("사용할 증권계좌번호는 : [" + g_accnt_no + "] 입니다. \r\n", 0);
        //}

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            axKHOpenAPI1.CommTerminate();
            toolStripStatusLabel1.Text = "로그아웃이 완료되었습니다.";
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    OracleCommand cmd;
        //    OracleConnection conn;
        //    OracleDataReader reader = null;

        //    string sql;
        //    string l_jongmok_cd;
        //    string l_jongmok_nm;

        //    int l_priority;
        //    int l_buy_amt;
        //    int l_buy_price;
        //    int l_target_price;
        //    int l_cut_loss_price;
        //    string l_buy_trd_yn;
        //    string l_sell_trd_yn;
        //    int l_seq = 0;
        //    string[] l_arr = null;

        //    conn = null;
        //    conn = connect_db();    // 데이터베이스 연결

        //    cmd = null;
        //    cmd = new OracleCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandType = CommandType.Text;

        //    sql = null;
        //    sql = " SELECT" +
        //        " JONGMOK_CD , " +
        //        " JONGMOK_NM , " +
        //        " PRIORITY , " +
        //        " BUY_AMT, " +
        //        " BUY_PRICE, " +
        //        " TARGET_PRICE, " +
        //        " CUT_LOSS_PRICE, " +
        //        " BUY_TRD_YN, " +
        //        " SELL_TRD_YN " +
        //        " FROM " +
        //        " TB_TRD_JONGMOK" +
        //        " WHERE USER_ID = " + "'" + g_user_id + "'" +" order by PRIORITY";

        //    cmd.CommandText = sql;

        //    this.Invoke(new MethodInvoker(
        //        delegate ()
        //        {
        //            dataGridView1.Rows.Clear(); // 그리드뷰 초기화
        //        }));

        //    try
        //    {
        //        reader = cmd.ExecuteReader();   // SQL 수행
        //    }
        //    catch (Exception ex)
        //    {
        //        write_err_log("SELECT TB_TRD_JONGMOK ex.Message : [" + ex.Message + "]\r\n", 0);
        //    }

        //    l_jongmok_cd = "";
        //    l_jongmok_nm = "";

        //    l_priority = 0;
        //    l_buy_amt = 0;
        //    l_buy_price = 0;
        //    l_target_price = 0;
        //    l_cut_loss_price = 0;
        //    l_buy_trd_yn = "";
        //    l_sell_trd_yn = "";

        //    while (reader.Read())
        //    {
        //        l_seq++;
        //        l_jongmok_cd = "";
        //        l_jongmok_nm = "";
        //        l_priority = 0;
        //        l_buy_amt = 0;
        //        l_buy_price = 0;
        //        l_target_price = 0;
        //        l_cut_loss_price = 0;
        //        l_buy_trd_yn = "";
        //        l_sell_trd_yn = "";
        //        l_seq = 0;

        //        // 각 칼럭 값 저장
        //        l_jongmok_cd = reader[0].ToString().Trim();
        //        l_jongmok_nm = reader[1].ToString().Trim();
        //        l_priority = int.Parse(reader[2].ToString().Trim());
        //        l_buy_amt = int.Parse(reader[3].ToString().Trim());
        //        l_buy_price = int.Parse(reader[4].ToString().Trim());
        //        l_target_price = int.Parse(reader[5].ToString().Trim());
        //        l_cut_loss_price = int.Parse(reader[6].ToString().Trim());
        //        l_buy_trd_yn = reader[7].ToString().Trim();
        //        l_sell_trd_yn = reader[8].ToString().Trim();

        //        l_arr = null;
        //        l_arr = new String[]    // 가져온 결과를 문자열 배열에 저장
        //        {
        //            l_seq.ToString(),
        //            l_jongmok_cd,
        //            l_jongmok_nm,
        //            l_priority.ToString(),
        //            l_buy_amt.ToString(),
        //            l_buy_price.ToString(),
        //            l_target_price.ToString(),
        //            l_cut_loss_price.ToString(),
        //            l_buy_trd_yn,
        //            l_sell_trd_yn
        //        };
        //        this.Invoke(new MethodInvoker(
        //            delegate ()
        //            {
        //                dataGridView1.Rows.Add(l_arr);  // 데이터그리드뷰에 추가
        //            }));
        //    }
        //    write_msg_log("TB_TRD_JONGMOK 테이블이 조회되었습니다.\r\n", 0);

        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    OracleCommand cmd;
        //    OracleConnection conn;

        //    string sql;

        //    string l_jongmok_cd;
        //    string l_jongmok_nm;
        //    int l_priority;
        //    int l_buy_amt;
        //    int l_buy_price;
        //    int l_target_price;
        //    int l_cut_loss_price;
        //    string l_buy_trd_yn;
        //    string l_sell_trd_yn;

        //    foreach (DataGridViewRow Row in dataGridView1.Rows)
        //    {
        //        if (Convert.ToBoolean(Row.Cells[check.Name].Value) != true)
        //        {
        //            continue;
        //        }
        //        if (Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
        //        {
        //            l_jongmok_cd = Row.Cells[1].Value.ToString();
        //            l_jongmok_nm = Row.Cells[2].Value.ToString();
        //            l_priority = int.Parse(Row.Cells[3].Value.ToString());
        //            l_buy_amt = int.Parse(Row.Cells[4].Value.ToString());
        //            l_buy_price = int.Parse(Row.Cells[5].Value.ToString());

        //            l_target_price = int.Parse(Row.Cells[6].Value.ToString());
        //            l_cut_loss_price = int.Parse(Row.Cells[7].Value.ToString());

        //            l_buy_trd_yn = Row.Cells[8].Value.ToString();
        //            l_sell_trd_yn = Row.Cells[9].Value.ToString();

        //            conn = null;
        //            conn = connect_db();
        //            if(conn == null)
        //            {
        //                write_err_log("DB에 연결되지 않았습니다\r\n", 0);

        //            }
        //            cmd = null;
        //            cmd = new OracleCommand();
        //            cmd.Connection = conn;
        //            cmd.CommandType = CommandType.Text;

        //            sql = null;
        //            sql = @"insert into TB_TRD_JONGMOK values " +
        //                "(" +
        //                "'" + g_user_id + "'" + "," +
        //                "'" + l_jongmok_cd + "'" + "," +
        //                "'" + l_jongmok_nm + "'" + "," +
        //                + l_priority + "," +
        //                + l_buy_amt + "," +
        //                + l_buy_price + "," +
        //                + l_target_price + "," +
        //                + l_cut_loss_price + "," +
        //                "'" + l_buy_trd_yn + "'" + "," +
        //                "'" + l_sell_trd_yn + "'" + "," +
        //                "'" + g_user_id + "'" + "," +
        //                "sysdate " + "," +
        //                "NULL" + "," +
        //                "NULL" + ")";
        //            cmd.CommandText = sql;
        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                write_err_log("insert TB_TRD_JONGMOK ex.Message : [" + ex.Message + "]\r\n", 0);
        //            }
        //            write_msg_log("종목코드 : [" + l_jongmok_cd + "]" + "가 삽입되었습니다.\r\n", 0);
        //            conn.Close();
        //        }
        //    }
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    OracleCommand cmd;
        //    OracleConnection conn;

        //    string sql;

        //    string l_jongmok_cd;
        //    string l_jongmok_nm;
        //    int l_priority;
        //    int l_buy_amt;
        //    int l_buy_price;
        //    int l_target_price;
        //    int l_cut_loss_price;
        //    string l_buy_trd_yn;
        //    string l_sell_trd_yn;

        //    foreach (DataGridViewRow Row in dataGridView1.Rows)
        //    {
        //        if (Convert.ToBoolean(Row.Cells[check.Name].Value) != true)
        //        {
        //            continue;
        //        }
        //        if (Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
        //        {
        //            l_jongmok_cd = Row.Cells[1].Value.ToString();
        //            l_jongmok_nm = Row.Cells[2].Value.ToString();
        //            l_priority = int.Parse(Row.Cells[3].Value.ToString());
        //            l_buy_amt = int.Parse(Row.Cells[4].Value.ToString());
        //            l_buy_price = int.Parse(Row.Cells[5].Value.ToString());
        //            l_target_price = int.Parse(Row.Cells[6].Value.ToString());
        //            l_cut_loss_price = int.Parse(Row.Cells[7].Value.ToString());
        //            l_buy_trd_yn = Row.Cells[8].Value.ToString();
        //            l_sell_trd_yn = Row.Cells[9].Value.ToString();

        //            conn = null;
        //            conn = connect_db();

        //            cmd = null;
        //            cmd = new OracleCommand();
        //            cmd.Connection = conn;
        //            cmd.CommandType = CommandType.Text;

        //            sql = null;
        //            sql = @"UPDATE TB_TRD_JONGMOK SET JONGMOK_NM = " + "'" + l_jongmok_nm + "'" + "," +
        //                " PRIORITY = " + l_priority + "," +
        //                " BUY_AMT = " + l_buy_amt + "," +
        //                " BUY_PRICE = " + l_buy_price + "," +
        //                " TARGET_PRICE = " + l_target_price + "," +
        //                " CUT_LOSS_PRICE = " + l_cut_loss_price + "," +
        //                " BUY_TRD_YN = " + "'" + l_buy_trd_yn + "'"+"," +
        //                " SELL_TRD_YN = " + "'" + l_sell_trd_yn + "'" + "," +
        //                " UPDT_ID = " + "'" + g_user_id + "'" + ","+
        //                " UPDT_DTM = SYSDATE " +
        //                " WHERE JONGMOK_CD = " + "'" + l_jongmok_cd +"'" +
        //                " AND USER_ID = " +"'" + g_user_id + "'";



        //            cmd.CommandText = sql;

        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //            }
        //            catch(Exception ex)
        //            {
        //                write_err_log("UPDATE TB_TRD_JONGMOK ex.Message : [" + ex.Message + "]\r\n", 0);
        //            }
        //            write_msg_log("종목코드 : [" + l_jongmok_cd + "]" + "가 수정되었습니다.\r\n", 0);
        //            conn.Close();
        //        }
        //    }
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    OracleCommand cmd;
        //    OracleConnection conn;

        //    string sql;

        //    string l_jongmok_cd = null;

        //    foreach(DataGridViewRow Row in dataGridView1.Rows)
        //    {
        //        if (Convert.ToBoolean(Row.Cells[check.Name].Value) != true)
        //        {
        //            continue;
        //        }
        //        if(Convert.ToBoolean(Row.Cells[check.Name].Value) == true)
        //        {
        //            l_jongmok_cd = Row.Cells[1].Value.ToString();

        //            conn = null;
        //            conn = connect_db();

        //            cmd = null;
        //            cmd = new OracleCommand();
        //            cmd.Connection = conn;
        //            cmd.CommandType = CommandType.Text;

        //            sql = null;
        //            sql = @" DELETE FROM TB_TRD_JONGMOK " +
        //                " WHERE JONGMOK_CD = " + "'" + l_jongmok_cd + "'" +
        //                " AND USER_ID = " + "'" + g_user_id + "'";

        //            cmd.CommandText = sql;
        //            try
        //            {
        //                cmd.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                write_err_log("DELETE TB_TRD_JONGMOK ex.Message : [" + ex.Message + "]\r\n", 0);
        //            }
        //            write_msg_log("종목코드 : [" + l_jongmok_cd + "]" + "가 삭제되었습니다.\r\n", 0);
        //            conn.Close();
        //        }
        //    }
        //}

        bool g_is_thread = false;
        private void button5_Click(object sender, EventArgs e)
        {
            if (g_is_thread == true)// 스레드가 이미 생성된 상태라면
            {
                write_msg_log("Auto Trading이 이미 시작되었습니다.\r\n", 0);
                return; // 이벤터 메서드 종료
            }

            g_is_thread = false;    // 스레드 생성으로 값 설정

            thread1 = new Thread(new ThreadStart(m_thread1));// 스레드 생성
            thread1.Start();        // 스레드 시작

        }


        StreamWriter sw;
        Process pipeClient;
        AnonymousPipeServerStream pipeServer;
        bool process_flag = false;

        void msg_sender(string msg)
        {

            if (!process_flag)
            {
                pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable);
                pipeClient = new Process();
                pipeClient.StartInfo.FileName = "D:\\Active\\autoServer\\autoServer\\bin\\Debug\\autoServer.exe";
                pipeClient.StartInfo.UseShellExecute = false;
                pipeClient.StartInfo.CreateNoWindow = true;
                pipeClient.StartInfo.Arguments = pipeServer.GetClientHandleAsString();
                pipeClient.EnableRaisingEvents = true;
                pipeClient.Exited += new EventHandler(pipeClient_Exited);
                sw = new StreamWriter(pipeServer);
                sw.AutoFlush = true;

                pipeClient.Start();
                process_flag = true;
                pipeServer.DisposeLocalCopyOfClientHandle();
                sw.WriteLine("SYNC");
                pipeServer.WaitForPipeDrain();


            }

            try
            {
                write_msg_log("Send Msg : " + msg + "\r\n", 0);
                sw.WriteLine(msg);

                pipeServer.WaitForPipeDrain();

            }
            catch (IOException e)
            {
                write_err_log("[SERVER] Error: " + e.Message + "\r\n", 0);
            }

        }

        private void pipeClient_Exited(object sender, EventArgs e)
        {
            write_msg_log("pipeClient Exit\r\n", 0);
            process_flag = false;
        }


        public void m_thread1()
        {
            bool jang_flag = false;
            
            if (g_is_thread == false) // 최초 스레드 생성
            {
                g_is_thread = true;        // 중복 스레드 제거
                write_msg_log("자동매매가 시작되었습니다.\r\n", 0);
            }

            for (; ; ) // 첫번째 무한루프 시작
            {
                string l_cur_tm = get_cur_tm(); // 현재시각 조회
                if (l_cur_tm.CompareTo("083001") >= 0 && l_cur_tm.CompareTo("090001") < 0)   // 8시 30분 이후라면 장시작전 메시지 전달
                {
                    jang_flag = false;
                    msg_sender("장시작전");
                }


                else if (l_cur_tm.CompareTo("090001") >= 0 && l_cur_tm.CompareTo("153001") < 0) // 09시 이후라면 테스트용 시간: 000000 장운영시간 090001
                {
                    msg_sender("장진행중");
                }

                else if (l_cur_tm.CompareTo("153001") > 0 && jang_flag == false)
                {
                    msg_sender("장마강후");
                    

                    // 0. 종목의 개수를 알아서
                    // 1. 데이터를 데이터베이스에서 받아서
                    // 2. 데이터를 각각 98개로 나눠서
                    // 3. 

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
                    sql = @"delete tb_day_chart";

                    cmd.CommandText = sql;

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        write_err_log("delete from tb_day_chart ex.Message : [" + ex.Message + "]\r\n", 0);
                    }

                    sql = null;
                    sql = @"select count(*) from tb_jongmok_lst";

                    cmd.CommandText = sql;

                    reader = cmd.ExecuteReader();

                    reader.Read();
                    int jongmok_cnt = int.Parse(reader[0].ToString().Trim());

                    sql = null;
                    sql = @"select jongmok_cd from tb_jongmok_lst";

                    cmd.CommandText = sql;
                    string jongmok_cd;
                    string msg = "분석시작";
                    int i = 0;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (i >= 99)
                        {
                            msg_sender(msg);
                            msg = null;
                            msg += "분석시작";
                            i = 0;

                            pipeClient.WaitForExit();
                        }

                        jongmok_cd = reader[0].ToString().Trim();
                        msg += ";" + jongmok_cd;
                        i++;
                    }


                    if (i > 0) msg_sender(msg);
                    conn.Close();
                    jang_flag = true;
                }
                else if (jang_flag)
                {

                }
                delay(10000); // 첫 번째 무한루프 지연
            }
        }



        // 그래프 찾기 양봉 2개이상 뜨고, 10일 이상 변동폭이 5프로인 그래프 찾는 함수
        Chart[] findGraph()
        {
            Chart[] chartArr = new Chart[10];

            return chartArr;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            write_msg_log("자동매매 중지 시작\r\n", 0);

            try
            {
                pipeClient.Kill();
                thread1.Abort();
            }
            catch (Exception ex)
            {   
                write_err_log("자동매매 중지 ex.Message : " + ex.Message + "\r\n", 0);
            }
            this.Invoke(new MethodInvoker(() =>
            {
                if (thread1 != null)
                {
                    thread1.Interrupt();
                    thread1 = null;
                }
                
            }));
            process_flag = false;
            g_is_thread = false ;
            write_msg_log("자동매매 중지 완료\r\n", 0);
        }

        //private void anal_thread_1()  // 장마감이후 차트조회
        //{
        //    string jongmok_nm = null;
        //    string jongmok_cd = null;

        //    for (; ; )
        //    {
        //        foreach (DataGridViewRow Row in dataGridView1.Rows)
        //        {
        //            if (Row.Cells[1].Value == null)
        //                break;
        //            jongmok_cd = Row.Cells[1].Value.ToString().Trim();     // 거래종목리스트의 종목코드
        //            jongmok_nm = Row.Cells[0].Value.ToString().Trim();      // 거래종목리스트의 종목명 (수정필) 데이터
        //            // 분봉차트 조회
        //            write_msg_log(jongmok_nm + ": 분봉차트 조회\r\n", 0);
        //            g_rqname = "";
        //            g_rqname = "분봉차트조회";

        //            axKHOpenAPI1.SetInputValue("종목코드", jongmok_cd);
        //            axKHOpenAPI1.SetInputValue("틱범위", "5");
        //            axKHOpenAPI1.SetInputValue("수정가구분", "0");

        //            String l_scr_no = get_scr_no();

        //            axKHOpenAPI1.CommRqData("분봉차트조회", "opt10080", 0, l_scr_no);

        //            for (; ; ) // 요청 후 대기 시작
        //            {
        //                if (g_flag_8 == 1)   // 요청에 대한 응답이 완료되면 루프를 빠져나옴
        //                {
        //                    delay(1000);
        //                    axKHOpenAPI1.DisconnectRealData(l_scr_no);
        //                    break;
        //                }
        //            }

        //            delay(1000);



        //            // 일봉차트 조회
        //            write_msg_log("일봉차트 조회\r\n", 0);
        //            g_rqname = "";
        //            g_rqname = "일봉차트조회";

        //            axKHOpenAPI1.SetInputValue("종목코드", jongmok_cd);
        //            axKHOpenAPI1.SetInputValue("기준일자", "20200401");
        //            axKHOpenAPI1.SetInputValue("수정주가구분", "0");


        //            axKHOpenAPI1.CommRqData("일봉차트조회", "opt10081", 0, l_scr_no);
        //            for (; ; )
        //            {
        //                if (g_flag_9 == 1)
        //                {
        //                    delay(1000);
        //                    axKHOpenAPI1.DisconnectRealData(l_scr_no);
        //                    break;
        //                }
        //            }

        //            delay(1000);

        //            // 주봉차트 조회
        //            write_msg_log("주봉차트조회\r\n", 0);
        //            g_rqname = "";
        //            g_rqname = "주봉차트조회";

        //            axKHOpenAPI1.SetInputValue("종목코드", jongmok_cd);
        //            axKHOpenAPI1.SetInputValue("기준일자", "20200401");
        //            axKHOpenAPI1.SetInputValue("끝일자", "20100101");
        //            axKHOpenAPI1.SetInputValue("수정주가구분", "0");


        //            axKHOpenAPI1.CommRqData("주봉차트조회", "opt10082", 0, l_scr_no);
        //            for (; ; )
        //            {
        //                if (g_flag_10 == 1)
        //                {
        //                    delay(1000);
        //                    axKHOpenAPI1.DisconnectRealData(l_scr_no);
        //                    break;
        //                }
        //            }
        //            delay(1000);
        //        }

        //        delay(300000);
        //    }
        //}




        private void button8_Click(object sender, EventArgs e)
        {
            if(toolStripStatusLabel1.Text.CompareTo("로그인 완료") != 0)
            {
                write_err_log("로그인 해야함.\r\n",0);
                return;
            }
            //get_jongmok_lst();
            search_market sm = new search_market();

            String jongmok_cd;
            String jongmok_nm;
        
            List<string> jongmok;
            jongmok = new List<string>();

           if(sm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
           {
                jongmok = sm.jongmok;
           }
            int i = 0;
           foreach(String j in jongmok)
            {
                jongmok_cd = j.Split(',')[0];
                jongmok_nm = j.Split(',')[1];

                this.Invoke(new MethodInvoker(
                   delegate ()
                   {
                       dataGridView1.Rows.Add(i, jongmok_cd, jongmok_nm);  // 데이터그리드뷰에 추가
                    }));
                i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            
           

            form.ShowDialog();
        }
    }
}
