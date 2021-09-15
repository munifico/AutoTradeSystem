namespace autoServer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.err_log = new System.Windows.Forms.TextBox();
            this.msg_log = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.count_text = new System.Windows.Forms.Label();
            this.process_status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(199, 202);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(100, 50);
            this.axKHOpenAPI1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.err_log);
            this.groupBox1.Controls.Add(this.msg_log);
            this.groupBox1.Controls.Add(this.axKHOpenAPI1);
            this.groupBox1.Location = new System.Drawing.Point(12, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(709, 368);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "로그";
            // 
            // err_log
            // 
            this.err_log.BackColor = System.Drawing.SystemColors.WindowText;
            this.err_log.ForeColor = System.Drawing.Color.Lime;
            this.err_log.Location = new System.Drawing.Point(363, 22);
            this.err_log.Multiline = true;
            this.err_log.Name = "err_log";
            this.err_log.ReadOnly = true;
            this.err_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.err_log.Size = new System.Drawing.Size(340, 340);
            this.err_log.TabIndex = 2;
            // 
            // msg_log
            // 
            this.msg_log.BackColor = System.Drawing.SystemColors.WindowText;
            this.msg_log.ForeColor = System.Drawing.Color.Lime;
            this.msg_log.Location = new System.Drawing.Point(6, 22);
            this.msg_log.Multiline = true;
            this.msg_log.Name = "msg_log";
            this.msg_log.ReadOnly = true;
            this.msg_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.msg_log.Size = new System.Drawing.Size(340, 340);
            this.msg_log.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.count_text);
            this.groupBox2.Controls.Add(this.process_status);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(709, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "상태표시줄";
            // 
            // count_text
            // 
            this.count_text.AutoSize = true;
            this.count_text.Location = new System.Drawing.Point(236, 21);
            this.count_text.Name = "count_text";
            this.count_text.Size = new System.Drawing.Size(102, 15);
            this.count_text.TabIndex = 3;
            this.count_text.Text = "조회 카운트 : ";
            // 
            // process_status
            // 
            this.process_status.AutoSize = true;
            this.process_status.Location = new System.Drawing.Point(16, 21);
            this.process_status.Name = "process_status";
            this.process_status.Size = new System.Drawing.Size(52, 15);
            this.process_status.TabIndex = 0;
            this.process_status.Text = "상태 : ";
            this.process_status.Click += new System.EventHandler(this.process_status_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 444);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label process_status;
        private System.Windows.Forms.TextBox err_log;
        private System.Windows.Forms.TextBox msg_log;
        private System.Windows.Forms.Label count_text;
        public System.Windows.Forms.GroupBox groupBox1;
    }
}

