namespace Roster
{
    partial class RosterAdd
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
            this.DepartmentCode = new System.Windows.Forms.Label();
            this.DepartmentName = new System.Windows.Forms.Label();
            this.PartCode = new System.Windows.Forms.ComboBox();
            this.DepartName = new System.Windows.Forms.TextBox();
            this.EmployeeName = new System.Windows.Forms.TextBox();
            this.Mosque = new System.Windows.Forms.Label();
            this.MosqueCode = new System.Windows.Forms.Label();
            this.Pass = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.LoginId = new System.Windows.Forms.Label();
            this.Form_of_employment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MessengerId = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Memo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.EmployeeCode = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.TextBox();
            this.Position = new System.Windows.Forms.TextBox();
            this.PhoneNum = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Female = new System.Windows.Forms.CheckBox();
            this.Male = new System.Windows.Forms.CheckBox();
            this.Gender = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DepartmentCode
            // 
            this.DepartmentCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentCode.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DepartmentCode.ForeColor = System.Drawing.Color.Red;
            this.DepartmentCode.Location = new System.Drawing.Point(12, 70);
            this.DepartmentCode.Name = "DepartmentCode";
            this.DepartmentCode.Size = new System.Drawing.Size(57, 23);
            this.DepartmentCode.TabIndex = 1;
            this.DepartmentCode.Text = "부서코드";
            this.DepartmentCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepartmentName
            // 
            this.DepartmentName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DepartmentName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.DepartmentName.Location = new System.Drawing.Point(196, 70);
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.Size = new System.Drawing.Size(57, 23);
            this.DepartmentName.TabIndex = 2;
            this.DepartmentName.Text = "부서명";
            this.DepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PartCode
            // 
            this.PartCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PartCode.FormattingEnabled = true;
            this.PartCode.Items.AddRange(new object[] {
            "001",
            "002",
            "003"});
            this.PartCode.Location = new System.Drawing.Point(15, 90);
            this.PartCode.Name = "PartCode";
            this.PartCode.Size = new System.Drawing.Size(167, 20);
            this.PartCode.TabIndex = 3;
            // 
            // DepartName
            // 
            this.DepartName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DepartName.Location = new System.Drawing.Point(205, 89);
            this.DepartName.Name = "DepartName";
            this.DepartName.ReadOnly = true;
            this.DepartName.Size = new System.Drawing.Size(167, 21);
            this.DepartName.TabIndex = 4;
            // 
            // EmployeeName
            // 
            this.EmployeeName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmployeeName.Location = new System.Drawing.Point(205, 142);
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Size = new System.Drawing.Size(167, 21);
            this.EmployeeName.TabIndex = 8;
            // 
            // Mosque
            // 
            this.Mosque.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Mosque.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Mosque.ForeColor = System.Drawing.Color.Red;
            this.Mosque.Location = new System.Drawing.Point(196, 123);
            this.Mosque.Name = "Mosque";
            this.Mosque.Size = new System.Drawing.Size(57, 23);
            this.Mosque.TabIndex = 6;
            this.Mosque.Text = "사원명";
            this.Mosque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MosqueCode
            // 
            this.MosqueCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MosqueCode.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MosqueCode.ForeColor = System.Drawing.Color.Red;
            this.MosqueCode.Location = new System.Drawing.Point(12, 123);
            this.MosqueCode.Name = "MosqueCode";
            this.MosqueCode.Size = new System.Drawing.Size(57, 23);
            this.MosqueCode.TabIndex = 5;
            this.MosqueCode.Text = "사원코드";
            this.MosqueCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pass
            // 
            this.Pass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pass.Location = new System.Drawing.Point(205, 199);
            this.Pass.Name = "Pass";
            this.Pass.PasswordChar = '*';
            this.Pass.Size = new System.Drawing.Size(167, 21);
            this.Pass.TabIndex = 12;
            this.Pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Pass_KeyPress);
            // 
            // Password
            // 
            this.Password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Password.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Password.ForeColor = System.Drawing.Color.Red;
            this.Password.Location = new System.Drawing.Point(202, 180);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(57, 23);
            this.Password.TabIndex = 10;
            this.Password.Text = "비밀번호";
            this.Password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginId
            // 
            this.LoginId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginId.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LoginId.ForeColor = System.Drawing.Color.Red;
            this.LoginId.Location = new System.Drawing.Point(12, 180);
            this.LoginId.Name = "LoginId";
            this.LoginId.Size = new System.Drawing.Size(57, 23);
            this.LoginId.TabIndex = 9;
            this.LoginId.Text = "로그인ID";
            this.LoginId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_of_employment
            // 
            this.Form_of_employment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Form_of_employment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Form_of_employment.Location = new System.Drawing.Point(205, 262);
            this.Form_of_employment.Name = "Form_of_employment";
            this.Form_of_employment.Size = new System.Drawing.Size(167, 21);
            this.Form_of_employment.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(202, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 23);
            this.label8.TabIndex = 14;
            this.label8.Text = "고용형태";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(4, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 23);
            this.label9.TabIndex = 13;
            this.label9.Text = "직위";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Email
            // 
            this.Email.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Email.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Email.Location = new System.Drawing.Point(205, 325);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(167, 21);
            this.Email.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(196, 306);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 23);
            this.label10.TabIndex = 18;
            this.label10.Text = "이메일";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(13, 306);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 23);
            this.label11.TabIndex = 17;
            this.label11.Text = "휴대전화";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessengerId
            // 
            this.MessengerId.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.MessengerId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MessengerId.Location = new System.Drawing.Point(396, 325);
            this.MessengerId.Name = "MessengerId";
            this.MessengerId.Size = new System.Drawing.Size(167, 21);
            this.MessengerId.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(394, 306);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 23);
            this.label12.TabIndex = 22;
            this.label12.Text = "메신저ID";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Memo
            // 
            this.Memo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Memo.Location = new System.Drawing.Point(15, 379);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(548, 21);
            this.Memo.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(-2, 360);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 23);
            this.label13.TabIndex = 24;
            this.label13.Text = "메모";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeCode
            // 
            this.EmployeeCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.EmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmployeeCode.Location = new System.Drawing.Point(15, 142);
            this.EmployeeCode.Name = "EmployeeCode";
            this.EmployeeCode.Size = new System.Drawing.Size(167, 21);
            this.EmployeeCode.TabIndex = 25;
            // 
            // ID
            // 
            this.ID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID.Location = new System.Drawing.Point(15, 199);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(167, 21);
            this.ID.TabIndex = 26;
            // 
            // Position
            // 
            this.Position.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Position.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Position.Location = new System.Drawing.Point(15, 262);
            this.Position.Name = "Position";
            this.Position.Size = new System.Drawing.Size(167, 21);
            this.Position.TabIndex = 27;
            // 
            // PhoneNum
            // 
            this.PhoneNum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PhoneNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PhoneNum.Location = new System.Drawing.Point(15, 325);
            this.PhoneNum.Name = "PhoneNum";
            this.PhoneNum.Size = new System.Drawing.Size(167, 21);
            this.PhoneNum.TabIndex = 28;
            this.PhoneNum.TextChanged += new System.EventHandler(this.PhoneNum_TextChanged);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Location = new System.Drawing.Point(474, 421);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 31);
            this.button2.TabIndex = 30;
            this.button2.Text = "닫기";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(362, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 31);
            this.button1.TabIndex = 29;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Female
            // 
            this.Female.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Female.AutoSize = true;
            this.Female.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Female.ForeColor = System.Drawing.Color.Black;
            this.Female.Location = new System.Drawing.Point(465, 266);
            this.Female.Name = "Female";
            this.Female.Size = new System.Drawing.Size(48, 16);
            this.Female.TabIndex = 61;
            this.Female.Text = "여자";
            this.Female.UseVisualStyleBackColor = false;
            this.Female.CheckedChanged += new System.EventHandler(this.Female_CheckedChanged);
            // 
            // Male
            // 
            this.Male.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Male.AutoSize = true;
            this.Male.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Male.ForeColor = System.Drawing.Color.Black;
            this.Male.Location = new System.Drawing.Point(400, 266);
            this.Male.Name = "Male";
            this.Male.Size = new System.Drawing.Size(48, 16);
            this.Male.TabIndex = 60;
            this.Male.Text = "남자";
            this.Male.UseVisualStyleBackColor = false;
            this.Male.CheckedChanged += new System.EventHandler(this.Male_CheckedChanged);
            // 
            // Gender
            // 
            this.Gender.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Gender.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Gender.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Gender.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Gender.Location = new System.Drawing.Point(394, 243);
            this.Gender.Name = "Gender";
            this.Gender.Size = new System.Drawing.Size(35, 23);
            this.Gender.TabIndex = 62;
            this.Gender.Text = "성별";
            this.Gender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RosterAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 468);
            this.Controls.Add(this.Female);
            this.Controls.Add(this.Male);
            this.Controls.Add(this.Gender);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PhoneNum);
            this.Controls.Add(this.Position);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.EmployeeCode);
            this.Controls.Add(this.Memo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.MessengerId);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Form_of_employment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.LoginId);
            this.Controls.Add(this.EmployeeName);
            this.Controls.Add(this.Mosque);
            this.Controls.Add(this.MosqueCode);
            this.Controls.Add(this.DepartName);
            this.Controls.Add(this.PartCode);
            this.Controls.Add(this.DepartmentName);
            this.Controls.Add(this.DepartmentCode);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "RosterAdd";
            this.Text = "사원추가";
            this.Load += new System.EventHandler(this.RosterAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label DepartmentCode;
        private System.Windows.Forms.Label DepartmentName;
        private System.Windows.Forms.ComboBox PartCode;
        private System.Windows.Forms.TextBox DepartName;
        private System.Windows.Forms.TextBox EmployeeName;
        private System.Windows.Forms.Label Mosque;
        private System.Windows.Forms.Label MosqueCode;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label LoginId;
        private System.Windows.Forms.TextBox Form_of_employment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox MessengerId;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox EmployeeCode;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox Position;
        private System.Windows.Forms.TextBox PhoneNum;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox Female;
        private System.Windows.Forms.CheckBox Male;
        private System.Windows.Forms.Label Gender;
    }
}