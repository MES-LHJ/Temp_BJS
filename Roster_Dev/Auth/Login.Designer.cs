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
            this.exit = new DevExpress.XtraEditors.SimpleButton();
            this.loginBtn = new DevExpress.XtraEditors.SimpleButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.loginId = new DevExpress.XtraEditors.TextEdit();
            this.password = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.idLayoutControl = new DevExpress.XtraLayout.LayoutControlItem();
            this.passwordLayoutControl = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idLayoutControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLayoutControl)).BeginInit();
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
            this.panelControl1.Size = new System.Drawing.Size(398, 39);
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
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Controls.Add(this.flowLayoutPanel1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 39);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(398, 134);
            this.panelControl2.TabIndex = 1;
            // 
            // exit
            // 
            this.exit.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.exit.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Appearance.Options.UseBackColor = true;
            this.exit.Appearance.Options.UseFont = true;
            this.exit.Location = new System.Drawing.Point(299, 7);
            this.exit.Margin = new System.Windows.Forms.Padding(3, 7, 7, 7);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(88, 33);
            this.exit.TabIndex = 5;
            this.exit.Text = "닫기";
            // 
            // loginBtn
            // 
            this.loginBtn.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.loginBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.loginBtn.Appearance.Options.UseBackColor = true;
            this.loginBtn.Appearance.Options.UseFont = true;
            this.loginBtn.Location = new System.Drawing.Point(205, 7);
            this.loginBtn.Margin = new System.Windows.Forms.Padding(7, 7, 3, 7);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(88, 33);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "저장";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.exit);
            this.flowLayoutPanel1.Controls.Add(this.loginBtn);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 85);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(394, 47);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.loginId);
            this.layoutControl1.Controls.Add(this.password);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(394, 83);
            this.layoutControl1.TabIndex = 9;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // loginId
            // 
            this.loginId.Location = new System.Drawing.Point(20, 37);
            this.loginId.Name = "loginId";
            this.loginId.Size = new System.Drawing.Size(167, 20);
            this.loginId.StyleController = this.layoutControl1;
            this.loginId.TabIndex = 4;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(207, 37);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(167, 20);
            this.password.StyleController = this.layoutControl1;
            this.password.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.idLayoutControl,
            this.passwordLayoutControl});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(394, 83);
            this.Root.TextVisible = false;
            // 
            // idLayoutControl
            // 
            this.idLayoutControl.Control = this.loginId;
            this.idLayoutControl.Location = new System.Drawing.Point(0, 0);
            this.idLayoutControl.Name = "idLayoutControl";
            this.idLayoutControl.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.idLayoutControl.Size = new System.Drawing.Size(187, 63);
            this.idLayoutControl.Text = "로그인ID";
            this.idLayoutControl.TextLocation = DevExpress.Utils.Locations.Top;
            this.idLayoutControl.TextSize = new System.Drawing.Size(42, 14);
            // 
            // passwordLayoutControl
            // 
            this.passwordLayoutControl.Control = this.password;
            this.passwordLayoutControl.Location = new System.Drawing.Point(187, 0);
            this.passwordLayoutControl.Name = "passwordLayoutControl";
            this.passwordLayoutControl.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.passwordLayoutControl.Size = new System.Drawing.Size(187, 63);
            this.passwordLayoutControl.Text = "비밀번호";
            this.passwordLayoutControl.TextLocation = DevExpress.Utils.Locations.Top;
            this.passwordLayoutControl.TextSize = new System.Drawing.Size(42, 14);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 173);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loginId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idLayoutControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordLayoutControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl loginLabel;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton exit;
        private DevExpress.XtraEditors.SimpleButton loginBtn;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit loginId;
        private DevExpress.XtraEditors.TextEdit password;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem idLayoutControl;
        private DevExpress.XtraLayout.LayoutControlItem passwordLayoutControl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

