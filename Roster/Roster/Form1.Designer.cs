namespace Roster
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
            this.Department = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.EmployeeAdd = new System.Windows.Forms.Label();
            this.EmployeeEdit = new System.Windows.Forms.Label();
            this.LoginInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.EmployeeDataGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Department
            // 
            this.Department.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Department.BackColor = System.Drawing.Color.Transparent;
            this.Department.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Department.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Department.Location = new System.Drawing.Point(3, 2);
            this.Department.Name = "Department";
            this.Department.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Department.Size = new System.Drawing.Size(72, 19);
            this.Department.TabIndex = 1;
            this.Department.Text = "부서";
            this.Department.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Department.Click += new System.EventHandler(this.Department_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(81, 1);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "조회";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // EmployeeAdd
            // 
            this.EmployeeAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmployeeAdd.BackColor = System.Drawing.Color.Transparent;
            this.EmployeeAdd.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EmployeeAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EmployeeAdd.Location = new System.Drawing.Point(159, 1);
            this.EmployeeAdd.Name = "EmployeeAdd";
            this.EmployeeAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EmployeeAdd.Size = new System.Drawing.Size(72, 21);
            this.EmployeeAdd.TabIndex = 3;
            this.EmployeeAdd.Text = "추가";
            this.EmployeeAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EmployeeAdd.Click += new System.EventHandler(this.EmployeeAdd_Click);
            // 
            // EmployeeEdit
            // 
            this.EmployeeEdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmployeeEdit.BackColor = System.Drawing.Color.Transparent;
            this.EmployeeEdit.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EmployeeEdit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.EmployeeEdit.Location = new System.Drawing.Point(237, 1);
            this.EmployeeEdit.Name = "EmployeeEdit";
            this.EmployeeEdit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EmployeeEdit.Size = new System.Drawing.Size(72, 21);
            this.EmployeeEdit.TabIndex = 4;
            this.EmployeeEdit.Text = "수정";
            this.EmployeeEdit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EmployeeEdit.Click += new System.EventHandler(this.EmployeeEdit_Click);
            // 
            // LoginInfo
            // 
            this.LoginInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginInfo.BackColor = System.Drawing.Color.Transparent;
            this.LoginInfo.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LoginInfo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LoginInfo.Location = new System.Drawing.Point(315, 2);
            this.LoginInfo.Name = "LoginInfo";
            this.LoginInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoginInfo.Size = new System.Drawing.Size(72, 19);
            this.LoginInfo.TabIndex = 5;
            this.LoginInfo.Text = "로그인정보";
            this.LoginInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LoginInfo.Click += new System.EventHandler(this.LoginInfo_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(393, 1);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label7.Size = new System.Drawing.Size(72, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "삭제";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(471, 1);
            this.label8.Name = "label8";
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label8.Size = new System.Drawing.Size(72, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "자료변환";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(549, 2);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label9.Size = new System.Drawing.Size(77, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "닫기";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel3.Controls.Add(this.Department, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.EmployeeAdd, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.EmployeeEdit, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label9, 7, 0);
            this.tableLayoutPanel3.Controls.Add(this.LoginInfo, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.label7, 5, 0);
            this.tableLayoutPanel3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(759, 25);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(629, 23);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // EmployeeDataGrid
            // 
            this.EmployeeDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.EmployeeDataGrid.CausesValidation = false;
            this.EmployeeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmployeeDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeeDataGrid.Location = new System.Drawing.Point(0, 0);
            this.EmployeeDataGrid.Name = "EmployeeDataGrid";
            this.EmployeeDataGrid.Size = new System.Drawing.Size(1347, 382);
            this.EmployeeDataGrid.TabIndex = 32;
            this.EmployeeDataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.EmployeeDataGrid_CellFormatting);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.EmployeeDataGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1347, 382);
            this.panel1.TabIndex = 33;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 462);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "부서사원";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Department;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label EmployeeAdd;
        private System.Windows.Forms.Label EmployeeEdit;
        private System.Windows.Forms.Label LoginInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.DataGridView EmployeeDataGrid;
        private System.Windows.Forms.Panel panel1;
    }
}

