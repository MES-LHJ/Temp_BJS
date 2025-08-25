namespace Roster
{
    partial class MainRoster
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.EmployeeDataGrid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Department = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            this.EmployeeAdd = new System.Windows.Forms.Button();
            this.EmployeeEdit = new System.Windows.Forms.Button();
            this.LoginInfo = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Document = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.26357F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.78295F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.71318F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.93798F));
            this.tableLayoutPanel3.Controls.Add(this.EmployeeAdd, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.Check, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.EmployeeEdit, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.LoginInfo, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.Delete, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.Document, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.Department, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Exit, 7, 0);
            this.tableLayoutPanel3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(742, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(645, 29);
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
            // Department
            // 
            this.Department.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Department.Location = new System.Drawing.Point(3, 3);
            this.Department.Name = "Department";
            this.Department.Size = new System.Drawing.Size(72, 23);
            this.Department.TabIndex = 34;
            this.Department.Text = "부서";
            this.Department.UseVisualStyleBackColor = true;
            // 
            // Check
            // 
            this.Check.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Check.Location = new System.Drawing.Point(83, 3);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(72, 23);
            this.Check.TabIndex = 35;
            this.Check.Text = "조회";
            this.Check.UseVisualStyleBackColor = true;
            // 
            // EmployeeAdd
            // 
            this.EmployeeAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EmployeeAdd.Location = new System.Drawing.Point(163, 3);
            this.EmployeeAdd.Name = "EmployeeAdd";
            this.EmployeeAdd.Size = new System.Drawing.Size(72, 23);
            this.EmployeeAdd.TabIndex = 36;
            this.EmployeeAdd.Text = "추가";
            this.EmployeeAdd.UseVisualStyleBackColor = true;
            // 
            // EmployeeEdit
            // 
            this.EmployeeEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.EmployeeEdit.Location = new System.Drawing.Point(243, 3);
            this.EmployeeEdit.Name = "EmployeeEdit";
            this.EmployeeEdit.Size = new System.Drawing.Size(72, 23);
            this.EmployeeEdit.TabIndex = 37;
            this.EmployeeEdit.Text = "수정";
            this.EmployeeEdit.UseVisualStyleBackColor = true;
            // 
            // LoginInfo
            // 
            this.LoginInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LoginInfo.Location = new System.Drawing.Point(323, 3);
            this.LoginInfo.Name = "LoginInfo";
            this.LoginInfo.Size = new System.Drawing.Size(85, 23);
            this.LoginInfo.TabIndex = 38;
            this.LoginInfo.Text = "로그인정보";
            this.LoginInfo.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Delete.Location = new System.Drawing.Point(414, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(69, 23);
            this.Delete.TabIndex = 39;
            this.Delete.Text = "삭제";
            this.Delete.UseVisualStyleBackColor = true;
            // 
            // Document
            // 
            this.Document.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Document.Location = new System.Drawing.Point(489, 3);
            this.Document.Name = "Document";
            this.Document.Size = new System.Drawing.Size(72, 23);
            this.Document.TabIndex = 40;
            this.Document.Text = "자료변환";
            this.Document.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Exit.Location = new System.Drawing.Point(570, 3);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(72, 23);
            this.Exit.TabIndex = 41;
            this.Exit.Text = "닫기";
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // MainRoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 462);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panel1);
            this.Name = "MainRoster";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "부서사원";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeeDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.DataGridView EmployeeDataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Department;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Document;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button LoginInfo;
        private System.Windows.Forms.Button EmployeeEdit;
        private System.Windows.Forms.Button EmployeeAdd;
        private System.Windows.Forms.Button Check;
    }
}

