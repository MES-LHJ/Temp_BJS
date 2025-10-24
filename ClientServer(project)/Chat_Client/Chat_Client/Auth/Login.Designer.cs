namespace Chat_Client.Auth
{
    partial class Login
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.id = new DevExpress.XtraEditors.TextEdit();
            this.password = new DevExpress.XtraEditors.TextEdit();
            this.loginBtn = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.registerBtn = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.아이디 = new DevExpress.XtraLayout.LayoutControlItem();
            this.비밀번호 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.아이디)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.비밀번호)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.layoutControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(340, 176);
            this.panelControl1.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.id);
            this.layoutControl1.Controls.Add(this.password);
            this.layoutControl1.Controls.Add(this.loginBtn);
            this.layoutControl1.Controls.Add(this.cancelBtn);
            this.layoutControl1.Controls.Add(this.registerBtn);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(336, 172);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(112, 30);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(164, 20);
            this.id.StyleController = this.layoutControl1;
            this.id.TabIndex = 4;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(112, 90);
            this.password.Name = "password";
            this.password.Properties.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(164, 20);
            this.password.StyleController = this.layoutControl1;
            this.password.TabIndex = 5;
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(176, 135);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(67, 22);
            this.loginBtn.StyleController = this.layoutControl1;
            this.loginBtn.TabIndex = 6;
            this.loginBtn.Text = "로그인";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(253, 135);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(68, 22);
            this.cancelBtn.StyleController = this.layoutControl1;
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "취소";
            // 
            // registerBtn
            // 
            this.registerBtn.Location = new System.Drawing.Point(15, 135);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(71, 22);
            this.registerBtn.StyleController = this.layoutControl1;
            this.registerBtn.TabIndex = 8;
            this.registerBtn.Text = "회원가입";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.아이디,
            this.비밀번호,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(336, 172);
            this.Root.TextVisible = false;
            // 
            // 아이디
            // 
            this.아이디.Control = this.id;
            this.아이디.Location = new System.Drawing.Point(0, 0);
            this.아이디.Name = "아이디";
            this.아이디.Padding = new DevExpress.XtraLayout.Utils.Padding(50, 50, 20, 20);
            this.아이디.Size = new System.Drawing.Size(316, 60);
            this.아이디.TextLocation = DevExpress.Utils.Locations.Left;
            this.아이디.TextSize = new System.Drawing.Size(40, 14);
            // 
            // 비밀번호
            // 
            this.비밀번호.Control = this.password;
            this.비밀번호.Location = new System.Drawing.Point(0, 60);
            this.비밀번호.Name = "비밀번호";
            this.비밀번호.Padding = new DevExpress.XtraLayout.Utils.Padding(50, 50, 20, 20);
            this.비밀번호.Size = new System.Drawing.Size(316, 60);
            this.비밀번호.TextLocation = DevExpress.Utils.Locations.Left;
            this.비밀번호.TextSize = new System.Drawing.Size(40, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem3.Control = this.loginBtn;
            this.layoutControlItem3.Location = new System.Drawing.Point(161, 120);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem3.Size = new System.Drawing.Size(77, 32);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.ContentVertAlignment = DevExpress.Utils.VertAlignment.Center;
            this.layoutControlItem4.Control = this.cancelBtn;
            this.layoutControlItem4.Location = new System.Drawing.Point(238, 120);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem4.Size = new System.Drawing.Size(78, 32);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.registerBtn;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 120);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem1.Size = new System.Drawing.Size(81, 32);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(81, 120);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(80, 32);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 176);
            this.Controls.Add(this.panelControl1);
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.아이디)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.비밀번호)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit id;
        private DevExpress.XtraEditors.TextEdit password;
        private DevExpress.XtraEditors.SimpleButton loginBtn;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem 아이디;
        private DevExpress.XtraLayout.LayoutControlItem 비밀번호;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton registerBtn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}