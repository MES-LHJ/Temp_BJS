namespace Roster
{
    partial class Login
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
            this.Exit = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Id = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Id_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Exit.Location = new System.Drawing.Point(306, 140);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(96, 31);
            this.Exit.TabIndex = 12;
            this.Exit.Text = "닫기";
            this.Exit.UseVisualStyleBackColor = false;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.LoginButton.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LoginButton.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.LoginButton.Location = new System.Drawing.Point(194, 140);
            this.LoginButton.Name = "Login_button";
            this.LoginButton.Size = new System.Drawing.Size(96, 31);
            this.LoginButton.TabIndex = 11;
            this.LoginButton.Text = "로그인";
            this.LoginButton.UseVisualStyleBackColor = false;
            // 
            // Password
            // 
            this.Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password.Location = new System.Drawing.Point(215, 100);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(153, 21);
            this.Password.TabIndex = 10;
            // 
            // Id
            // 
            this.Id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Id.Location = new System.Drawing.Point(24, 100);
            this.Id.Name = "Id";
            this.Id.Size = new System.Drawing.Size(153, 21);
            this.Id.TabIndex = 9;
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Password_label.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Password_label.Location = new System.Drawing.Point(212, 82);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(67, 15);
            this.Password_label.TabIndex = 8;
            this.Password_label.Text = "비밀번호";
            // 
            // Id_label
            // 
            this.Id_label.AutoSize = true;
            this.Id_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Id_label.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Id_label.Location = new System.Drawing.Point(21, 82);
            this.Id_label.Name = "Id_label";
            this.Id_label.Size = new System.Drawing.Size(65, 15);
            this.Id_label.TabIndex = 7;
            this.Id_label.Text = "로그인ID";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 193);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Id);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Id_label);
            this.Name = "Login";
            this.Text = "로그인정보";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Id;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.Label Id_label;
    }
}