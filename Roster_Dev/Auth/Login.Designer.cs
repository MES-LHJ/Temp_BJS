namespace Roster_Dev
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.loginLabel = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.loginIDlabel = new DevExpress.XtraEditors.LabelControl();
            this.loginPasswordLabel = new DevExpress.XtraEditors.LabelControl();
            this.id = new DevExpress.XtraEditors.TextEdit();
            this.password = new DevExpress.XtraEditors.TextEdit();
            this.loginBtn = new DevExpress.XtraEditors.SimpleButton();
            this.exit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Silver;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.loginLabel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(435, 39);
            this.panelControl1.TabIndex = 0;
            // 
            // loginLabel
            // 
            this.loginLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.loginLabel.Appearance.Options.UseFont = true;
            this.loginLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.loginLabel.Location = new System.Drawing.Point(12, 8);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(80, 21);
            this.loginLabel.TabIndex = 0;
            this.loginLabel.Text = "로그인정보";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.exit);
            this.panelControl2.Controls.Add(this.loginBtn);
            this.panelControl2.Controls.Add(this.password);
            this.panelControl2.Controls.Add(this.id);
            this.panelControl2.Controls.Add(this.loginPasswordLabel);
            this.panelControl2.Controls.Add(this.loginIDlabel);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 39);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(435, 177);
            this.panelControl2.TabIndex = 1;
            // 
            // loginIDlabel
            // 
            this.loginIDlabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.loginIDlabel.Appearance.Options.UseFont = true;
            this.loginIDlabel.Location = new System.Drawing.Point(27, 32);
            this.loginIDlabel.Name = "loginIDlabel";
            this.loginIDlabel.Size = new System.Drawing.Size(65, 21);
            this.loginIDlabel.TabIndex = 0;
            this.loginIDlabel.Text = "로그인ID";
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.loginPasswordLabel.Appearance.Options.UseFont = true;
            this.loginPasswordLabel.Location = new System.Drawing.Point(225, 32);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(64, 21);
            this.loginPasswordLabel.TabIndex = 1;
            this.loginPasswordLabel.Text = "비밀번호";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(27, 63);
            this.id.Name = "id";
            this.id.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.id.Properties.Appearance.Options.UseFont = true;
            this.id.Size = new System.Drawing.Size(169, 24);
            this.id.TabIndex = 2;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(225, 63);
            this.password.Name = "password";
            this.password.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Properties.Appearance.Options.UseFont = true;
            this.password.Size = new System.Drawing.Size(169, 24);
            this.password.TabIndex = 3;
            // 
            // loginBtn
            // 
            this.loginBtn.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.loginBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.loginBtn.Appearance.Options.UseBackColor = true;
            this.loginBtn.Appearance.Options.UseFont = true;
            this.loginBtn.Location = new System.Drawing.Point(213, 120);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(88, 33);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "저장";
            // 
            // exit
            // 
            this.exit.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.exit.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Appearance.Options.UseBackColor = true;
            this.exit.Appearance.Options.UseFont = true;
            this.exit.Location = new System.Drawing.Point(317, 120);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(88, 33);
            this.exit.TabIndex = 5;
            this.exit.Text = "닫기";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 216);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl loginLabel;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit id;
        private DevExpress.XtraEditors.LabelControl loginPasswordLabel;
        private DevExpress.XtraEditors.LabelControl loginIDlabel;
        private DevExpress.XtraEditors.SimpleButton exit;
        private DevExpress.XtraEditors.SimpleButton loginBtn;
        private DevExpress.XtraEditors.TextEdit password;
    }
}

