namespace ats
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jongmok_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jongmok_nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_amt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.earning_rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_msg_log = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_err_log = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buy_data_view = new System.Windows.Forms.DataGridView();
            this.buy_ord_jongmok_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_ord_jongmok_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_ord_cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_ord_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buy_ord_price_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.sell_data_view = new System.Windows.Forms.DataGridView();
            this.sell_ord_jongmok_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_ord_jongmok_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_ord_cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_ord_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sell_ord_price_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buy_data_view)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sell_data_view)).BeginInit();
            this.SuspendLayout();
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(616, 142);
            this.axKHOpenAPI1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(125, 63);
            this.axKHOpenAPI1.TabIndex = 0;
            this.axKHOpenAPI1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1360, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.axKHOpenAPI1);
            this.groupBox2.Location = new System.Drawing.Point(11, 90);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(829, 298);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "보유 주식";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jongmok_cd,
            this.jongmok_nm,
            this.priority,
            this.buy_amt,
            this.buy_price,
            this.cnt,
            this.earning_rate});
            this.dataGridView1.Location = new System.Drawing.Point(11, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(812, 272);
            this.dataGridView1.TabIndex = 0;
            // 
            // jongmok_cd
            // 
            this.jongmok_cd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.jongmok_cd.HeaderText = "종목코드";
            this.jongmok_cd.MinimumWidth = 80;
            this.jongmok_cd.Name = "jongmok_cd";
            // 
            // jongmok_nm
            // 
            this.jongmok_nm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.jongmok_nm.HeaderText = "종목명";
            this.jongmok_nm.MinimumWidth = 80;
            this.jongmok_nm.Name = "jongmok_nm";
            // 
            // priority
            // 
            this.priority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.priority.HeaderText = "매매강도";
            this.priority.MinimumWidth = 80;
            this.priority.Name = "priority";
            // 
            // buy_amt
            // 
            this.buy_amt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.buy_amt.HeaderText = "총 매수금액";
            this.buy_amt.MinimumWidth = 80;
            this.buy_amt.Name = "buy_amt";
            // 
            // buy_price
            // 
            this.buy_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.buy_price.HeaderText = "매수가";
            this.buy_price.MinimumWidth = 80;
            this.buy_price.Name = "buy_price";
            // 
            // cnt
            // 
            this.cnt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cnt.HeaderText = "매매 개수";
            this.cnt.MinimumWidth = 80;
            this.cnt.Name = "cnt";
            // 
            // earning_rate
            // 
            this.earning_rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.earning_rate.HeaderText = "수익률";
            this.earning_rate.MinimumWidth = 80;
            this.earning_rate.Name = "earning_rate";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Location = new System.Drawing.Point(12, 11);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(316, 74);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "자동매매 시작/중지";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(164, 22);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(147, 44);
            this.button6.TabIndex = 1;
            this.button6.Text = "자동매매 중지";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 22);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(152, 44);
            this.button5.TabIndex = 0;
            this.button5.Text = "자동매매 시작";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_msg_log);
            this.groupBox4.Location = new System.Drawing.Point(846, 33);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(502, 327);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "메시지 로그";
            // 
            // textBox_msg_log
            // 
            this.textBox_msg_log.BackColor = System.Drawing.Color.Black;
            this.textBox_msg_log.ForeColor = System.Drawing.Color.Lime;
            this.textBox_msg_log.Location = new System.Drawing.Point(6, 24);
            this.textBox_msg_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_msg_log.Multiline = true;
            this.textBox_msg_log.Name = "textBox_msg_log";
            this.textBox_msg_log.ReadOnly = true;
            this.textBox_msg_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_msg_log.Size = new System.Drawing.Size(490, 299);
            this.textBox_msg_log.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_err_log);
            this.groupBox5.Location = new System.Drawing.Point(846, 364);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(502, 356);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "오류 로그";
            // 
            // textBox_err_log
            // 
            this.textBox_err_log.BackColor = System.Drawing.Color.Black;
            this.textBox_err_log.ForeColor = System.Drawing.Color.Yellow;
            this.textBox_err_log.Location = new System.Drawing.Point(6, 22);
            this.textBox_err_log.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_err_log.Multiline = true;
            this.textBox_err_log.Name = "textBox_err_log";
            this.textBox_err_log.ReadOnly = true;
            this.textBox_err_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_err_log.Size = new System.Drawing.Size(490, 324);
            this.textBox_err_log.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 718);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1360, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(196, 20);
            this.toolStripStatusLabel1.Text = "ats에 오신 것을 환영합니다.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buy_data_view);
            this.groupBox1.Location = new System.Drawing.Point(13, 394);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(827, 156);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "매수 주문 목록";
            // 
            // buy_data_view
            // 
            this.buy_data_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buy_data_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buy_ord_jongmok_cd,
            this.buy_ord_jongmok_name,
            this.buy_ord_cnt,
            this.buy_ord_price,
            this.buy_ord_price_sum});
            this.buy_data_view.Location = new System.Drawing.Point(9, 21);
            this.buy_data_view.Name = "buy_data_view";
            this.buy_data_view.RowHeadersWidth = 51;
            this.buy_data_view.RowTemplate.Height = 27;
            this.buy_data_view.Size = new System.Drawing.Size(812, 129);
            this.buy_data_view.TabIndex = 0;
            // 
            // buy_ord_jongmok_cd
            // 
            this.buy_ord_jongmok_cd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.buy_ord_jongmok_cd.HeaderText = "종목코드";
            this.buy_ord_jongmok_cd.MinimumWidth = 6;
            this.buy_ord_jongmok_cd.Name = "buy_ord_jongmok_cd";
            this.buy_ord_jongmok_cd.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // buy_ord_jongmok_name
            // 
            this.buy_ord_jongmok_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.buy_ord_jongmok_name.HeaderText = "종목명";
            this.buy_ord_jongmok_name.MinimumWidth = 6;
            this.buy_ord_jongmok_name.Name = "buy_ord_jongmok_name";
            // 
            // buy_ord_cnt
            // 
            this.buy_ord_cnt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.buy_ord_cnt.HeaderText = "개수";
            this.buy_ord_cnt.MinimumWidth = 6;
            this.buy_ord_cnt.Name = "buy_ord_cnt";
            // 
            // buy_ord_price
            // 
            this.buy_ord_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.buy_ord_price.HeaderText = "매수가";
            this.buy_ord_price.MinimumWidth = 6;
            this.buy_ord_price.Name = "buy_ord_price";
            // 
            // buy_ord_price_sum
            // 
            this.buy_ord_price_sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.buy_ord_price_sum.HeaderText = "총 매수 가격";
            this.buy_ord_price_sum.MinimumWidth = 6;
            this.buy_ord_price_sum.Name = "buy_ord_price_sum";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.sell_data_view);
            this.groupBox6.Location = new System.Drawing.Point(13, 556);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(827, 157);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "매도 주문 목록";
            // 
            // sell_data_view
            // 
            this.sell_data_view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sell_data_view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sell_ord_jongmok_cd,
            this.sell_ord_jongmok_name,
            this.sell_ord_cnt,
            this.sell_ord_price,
            this.sell_ord_price_sum});
            this.sell_data_view.Location = new System.Drawing.Point(9, 24);
            this.sell_data_view.Name = "sell_data_view";
            this.sell_data_view.RowHeadersWidth = 51;
            this.sell_data_view.RowTemplate.Height = 27;
            this.sell_data_view.Size = new System.Drawing.Size(812, 127);
            this.sell_data_view.TabIndex = 8;
            // 
            // sell_ord_jongmok_cd
            // 
            this.sell_ord_jongmok_cd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sell_ord_jongmok_cd.HeaderText = "종목코드";
            this.sell_ord_jongmok_cd.MinimumWidth = 6;
            this.sell_ord_jongmok_cd.Name = "sell_ord_jongmok_cd";
            // 
            // sell_ord_jongmok_name
            // 
            this.sell_ord_jongmok_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sell_ord_jongmok_name.HeaderText = "종목명";
            this.sell_ord_jongmok_name.MinimumWidth = 6;
            this.sell_ord_jongmok_name.Name = "sell_ord_jongmok_name";
            // 
            // sell_ord_cnt
            // 
            this.sell_ord_cnt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sell_ord_cnt.HeaderText = "개수";
            this.sell_ord_cnt.MinimumWidth = 6;
            this.sell_ord_cnt.Name = "sell_ord_cnt";
            // 
            // sell_ord_price
            // 
            this.sell_ord_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sell_ord_price.HeaderText = "매수가";
            this.sell_ord_price.MinimumWidth = 6;
            this.sell_ord_price.Name = "sell_ord_price";
            // 
            // sell_ord_price_sum
            // 
            this.sell_ord_price_sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sell_ord_price_sum.HeaderText = "총 매도 가격";
            this.sell_ord_price_sum.MinimumWidth = 6;
            this.sell_ord_price_sum.Name = "sell_ord_price_sum";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(427, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 744);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.Text = "ats";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buy_data_view)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sell_data_view)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_msg_log;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_err_log;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView buy_data_view;
        private System.Windows.Forms.DataGridView sell_data_view;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_ord_jongmok_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_ord_jongmok_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_ord_cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_ord_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_ord_price_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_ord_jongmok_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_ord_jongmok_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_ord_cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_ord_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn sell_ord_price_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn jongmok_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn jongmok_nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_amt;
        private System.Windows.Forms.DataGridViewTextBoxColumn buy_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn earning_rate;
        private System.Windows.Forms.Button button1;
    }
}

