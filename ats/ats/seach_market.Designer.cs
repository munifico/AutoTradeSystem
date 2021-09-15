namespace ats
{
    partial class search_market
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(search_market));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.market_search_button = new System.Windows.Forms.Button();
            this.market_search_text = new System.Windows.Forms.TextBox();
            this.시장검색 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.jongmok_lst = new System.Windows.Forms.DataGridView();
            this.jongmok_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jongmok_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jongmok_lst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.market_search_button);
            this.groupBox1.Controls.Add(this.market_search_text);
            this.groupBox1.Controls.Add(this.시장검색);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "시장구분";
            // 
            // market_search_button
            // 
            this.market_search_button.Location = new System.Drawing.Point(324, 26);
            this.market_search_button.Name = "market_search_button";
            this.market_search_button.Size = new System.Drawing.Size(50, 23);
            this.market_search_button.TabIndex = 4;
            this.market_search_button.Text = "검색";
            this.market_search_button.UseVisualStyleBackColor = true;
            this.market_search_button.Click += new System.EventHandler(this.market_search_button_Click);
            // 
            // market_search_text
            // 
            this.market_search_text.Location = new System.Drawing.Point(84, 24);
            this.market_search_text.Name = "market_search_text";
            this.market_search_text.Size = new System.Drawing.Size(232, 25);
            this.market_search_text.TabIndex = 3;
            // 
            // 시장검색
            // 
            this.시장검색.AutoSize = true;
            this.시장검색.Location = new System.Drawing.Point(6, 27);
            this.시장검색.Name = "시장검색";
            this.시장검색.Size = new System.Drawing.Size(82, 15);
            this.시장검색.TabIndex = 1;
            this.시장검색.Text = "시장검색 : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.jongmok_lst);
            this.groupBox2.Location = new System.Drawing.Point(12, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 401);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "종목 목록";
            // 
            // jongmok_lst
            // 
            this.jongmok_lst.AllowUserToResizeRows = false;
            this.jongmok_lst.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.jongmok_lst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jongmok_lst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jongmok_code,
            this.jongmok_name,
            this.check});
            this.jongmok_lst.Location = new System.Drawing.Point(6, 29);
            this.jongmok_lst.Name = "jongmok_lst";
            this.jongmok_lst.RowHeadersVisible = false;
            this.jongmok_lst.RowHeadersWidth = 51;
            this.jongmok_lst.RowTemplate.Height = 27;
            this.jongmok_lst.Size = new System.Drawing.Size(377, 372);
            this.jongmok_lst.TabIndex = 0;
            // 
            // jongmok_code
            // 
            this.jongmok_code.HeaderText = "종목코드";
            this.jongmok_code.MinimumWidth = 100;
            this.jongmok_code.Name = "jongmok_code";
            this.jongmok_code.ReadOnly = true;
            this.jongmok_code.Width = 125;
            // 
            // jongmok_name
            // 
            this.jongmok_name.HeaderText = "종목이름";
            this.jongmok_name.MinimumWidth = 100;
            this.jongmok_name.Name = "jongmok_name";
            this.jongmok_name.ReadOnly = true;
            this.jongmok_name.Width = 125;
            // 
            // check
            // 
            this.check.HeaderText = "선택";
            this.check.MinimumWidth = 80;
            this.check.Name = "check";
            this.check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.check.Width = 80;
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(12, 534);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(100, 50);
            this.axKHOpenAPI1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(229, 490);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 44);
            this.button1.TabIndex = 1;
            this.button1.Text = "리스트에 추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // search_market
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 596);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "search_market";
            this.Text = "seach_market";
            this.Load += new System.EventHandler(this.search_market_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jongmok_lst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label 시장검색;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView jongmok_lst;
        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.Button market_search_button;
        private System.Windows.Forms.TextBox market_search_text;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn jongmok_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn jongmok_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
    }
}