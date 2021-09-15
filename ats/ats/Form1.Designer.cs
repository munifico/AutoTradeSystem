namespace ats
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.jongmok_cd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jongmok_nm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.high_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.low_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.jongmok_cd,
            this.jongmok_nm,
            this.start_price,
            this.high_price,
            this.low_price});
            this.dataGridView1.Location = new System.Drawing.Point(0, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(792, 408);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // jongmok_cd
            // 
            this.jongmok_cd.HeaderText = "종목코드";
            this.jongmok_cd.MinimumWidth = 6;
            this.jongmok_cd.Name = "jongmok_cd";
            this.jongmok_cd.Width = 125;
            // 
            // jongmok_nm
            // 
            this.jongmok_nm.HeaderText = "종목이름";
            this.jongmok_nm.MinimumWidth = 6;
            this.jongmok_nm.Name = "jongmok_nm";
            this.jongmok_nm.Width = 125;
            // 
            // start_price
            // 
            this.start_price.HeaderText = "시가";
            this.start_price.MinimumWidth = 6;
            this.start_price.Name = "start_price";
            this.start_price.Width = 125;
            // 
            // high_price
            // 
            this.high_price.HeaderText = "고가";
            this.high_price.MinimumWidth = 6;
            this.high_price.Name = "high_price";
            this.high_price.Width = 125;
            // 
            // low_price
            // 
            this.low_price.HeaderText = "저가";
            this.low_price.MinimumWidth = 6;
            this.low_price.Name = "low_price";
            this.low_price.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn jongmok_cd;
        private System.Windows.Forms.DataGridViewTextBoxColumn jongmok_nm;
        private System.Windows.Forms.DataGridViewTextBoxColumn start_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn high_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn low_price;
    }
}