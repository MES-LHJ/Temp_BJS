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
            this.EmployeeAdd = new System.Windows.Forms.Button();
            this.Check = new System.Windows.Forms.Button();
            this.EmployeeEdit = new System.Windows.Forms.Button();
            this.LoginInfo = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.convert = new System.Windows.Forms.Button();
            this.Department = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.employeeDataGrid = new System.Windows.Forms.DataGridView();
            this.partCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.form_of_employment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messengerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.photo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGrid)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
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
            this.tableLayoutPanel3.Controls.Add(this.convert, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.Department, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.Exit, 7, 0);
            this.tableLayoutPanel3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(838, 23);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(645, 29);
            this.tableLayoutPanel3.TabIndex = 24;
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
            // convert
            // 
            this.convert.ForeColor = System.Drawing.SystemColors.ControlText;
            this.convert.Location = new System.Drawing.Point(489, 3);
            this.convert.Name = "convert";
            this.convert.Size = new System.Drawing.Size(72, 23);
            this.convert.TabIndex = 40;
            this.convert.Text = "자료변환";
            this.convert.UseVisualStyleBackColor = true;
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
            // employeeDataGrid
            // 
            this.employeeDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.employeeDataGrid.CausesValidation = false;
            this.employeeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.partCode,
            this.departmentName,
            this.employeeCode,
            this.employeeName,
            this.id,
            this.password,
            this.position,
            this.form_of_employment,
            this.gender,
            this.phoneNum,
            this.email,
            this.messengerId,
            this.memo,
            this.photo});
            this.employeeDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDataGrid.Location = new System.Drawing.Point(0, 0);
            this.employeeDataGrid.Name = "employeeDataGrid";
            this.employeeDataGrid.Size = new System.Drawing.Size(1443, 382);
            this.employeeDataGrid.TabIndex = 32;
            this.employeeDataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.EmployeeDataGrid_CellFormatting);
            // 
            // partCode
            // 
            this.partCode.DataPropertyName = "DepartmentCode";
            this.partCode.HeaderText = "부서코드";
            this.partCode.Name = "partCode";
            // 
            // departmentName
            // 
            this.departmentName.DataPropertyName = "DepartmentName";
            this.departmentName.HeaderText = "부서명";
            this.departmentName.Name = "departmentName";
            // 
            // employeeCode
            // 
            this.employeeCode.DataPropertyName = "EmployeeCode";
            this.employeeCode.HeaderText = "사원코드";
            this.employeeCode.Name = "employeeCode";
            // 
            // employeeName
            // 
            this.employeeName.DataPropertyName = "EmployeeName";
            this.employeeName.HeaderText = "사원명";
            this.employeeName.Name = "employeeName";
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "아이디";
            this.id.Name = "id";
            // 
            // password
            // 
            this.password.DataPropertyName = "Password";
            this.password.HeaderText = "비밀번호";
            this.password.Name = "password";
            // 
            // position
            // 
            this.position.DataPropertyName = "Position";
            this.position.HeaderText = "직급";
            this.position.Name = "position";
            // 
            // form_of_employment
            // 
            this.form_of_employment.DataPropertyName = "Employment";
            this.form_of_employment.HeaderText = "고용형태";
            this.form_of_employment.Name = "form_of_employment";
            // 
            // gender
            // 
            this.gender.DataPropertyName = "Gender";
            this.gender.HeaderText = "성별";
            this.gender.Name = "gender";
            // 
            // phoneNum
            // 
            this.phoneNum.DataPropertyName = "PhoneNum";
            this.phoneNum.HeaderText = "전화번호";
            this.phoneNum.Name = "phoneNum";
            // 
            // email
            // 
            this.email.DataPropertyName = "Email";
            this.email.HeaderText = "이메일";
            this.email.Name = "email";
            // 
            // messengerId
            // 
            this.messengerId.DataPropertyName = "MessengerID";
            this.messengerId.HeaderText = "메신저ID";
            this.messengerId.Name = "messengerId";
            // 
            // memo
            // 
            this.memo.DataPropertyName = "Memo";
            this.memo.HeaderText = "메모";
            this.memo.Name = "memo";
            // 
            // photo
            // 
            this.photo.DataPropertyName = "PhotoPath";
            this.photo.HeaderText = "사원이미지";
            this.photo.Name = "photo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxPreview);
            this.panel1.Controls.Add(this.employeeDataGrid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1443, 382);
            this.panel1.TabIndex = 33;
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Location = new System.Drawing.Point(1088, 56);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(230, 206);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPreview.TabIndex = 33;
            this.pictureBoxPreview.TabStop = false;
            // 
            // MainRoster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 462);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panel1);
            this.Name = "MainRoster";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "부서사원";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView employeeDataGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Department;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button convert;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button LoginInfo;
        private System.Windows.Forms.Button EmployeeEdit;
        private System.Windows.Forms.Button EmployeeAdd;
        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn partCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn form_of_employment;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn messengerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn photo;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
    }
}

