namespace Chat_Server
{
    partial class Server
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
            this.sendButton = new DevExpress.XtraEditors.SimpleButton();
            this.txt_server_send = new DevExpress.XtraEditors.TextEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ipAddress = new DevExpress.XtraEditors.TextEdit();
            this.portAddress = new DevExpress.XtraEditors.TextEdit();
            this.txt_server_chat = new DevExpress.XtraEditors.MemoEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.portControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.ipControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.serverStartBtn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.resetBtn = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_server_send.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_server_chat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sendButton);
            this.panelControl1.Controls.Add(this.txt_server_send);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 367);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 83);
            this.panelControl1.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(269, 48);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(71, 23);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            // 
            // txt_server_send
            // 
            this.txt_server_send.Location = new System.Drawing.Point(20, 15);
            this.txt_server_send.Name = "txt_server_send";
            this.txt_server_send.Properties.AutoHeight = false;
            this.txt_server_send.Size = new System.Drawing.Size(243, 56);
            this.txt_server_send.TabIndex = 0;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.layoutControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(360, 367);
            this.panelControl3.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ipAddress);
            this.layoutControl1.Controls.Add(this.portAddress);
            this.layoutControl1.Controls.Add(this.txt_server_chat);
            this.layoutControl1.Controls.Add(this.serverStartBtn);
            this.layoutControl1.Controls.Add(this.resetBtn);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(356, 363);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ipAddress
            // 
            this.ipAddress.Location = new System.Drawing.Point(18, 33);
            this.ipAddress.Name = "ipAddress";
            this.ipAddress.Size = new System.Drawing.Size(113, 20);
            this.ipAddress.StyleController = this.layoutControl1;
            this.ipAddress.TabIndex = 4;
            // 
            // portAddress
            // 
            this.portAddress.Location = new System.Drawing.Point(147, 33);
            this.portAddress.Name = "portAddress";
            this.portAddress.Size = new System.Drawing.Size(102, 20);
            this.portAddress.StyleController = this.layoutControl1;
            this.portAddress.TabIndex = 5;
            // 
            // txt_server_chat
            // 
            this.txt_server_chat.Enabled = false;
            this.txt_server_chat.Location = new System.Drawing.Point(18, 70);
            this.txt_server_chat.Name = "txt_server_chat";
            this.txt_server_chat.Size = new System.Drawing.Size(320, 275);
            this.txt_server_chat.StyleController = this.layoutControl1;
            this.txt_server_chat.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.portControlItem,
            this.ipControlItem,
            this.layoutControlItem3,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(356, 363);
            this.Root.TextVisible = false;
            // 
            // portControlItem
            // 
            this.portControlItem.Control = this.portAddress;
            this.portControlItem.Location = new System.Drawing.Point(129, 0);
            this.portControlItem.Name = "portControlItem";
            this.portControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 6, 6);
            this.portControlItem.Size = new System.Drawing.Size(118, 52);
            this.portControlItem.Text = "PORT";
            this.portControlItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.portControlItem.TextSize = new System.Drawing.Size(31, 14);
            // 
            // ipControlItem
            // 
            this.ipControlItem.Control = this.ipAddress;
            this.ipControlItem.Location = new System.Drawing.Point(0, 0);
            this.ipControlItem.Name = "ipControlItem";
            this.ipControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 6, 6);
            this.ipControlItem.Size = new System.Drawing.Size(129, 52);
            this.ipControlItem.Text = "IP";
            this.ipControlItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.ipControlItem.TextSize = new System.Drawing.Size(31, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_server_chat;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem3.Size = new System.Drawing.Size(336, 291);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // serverStartBtn
            // 
            this.serverStartBtn.Location = new System.Drawing.Point(259, 38);
            this.serverStartBtn.Name = "serverStartBtn";
            this.serverStartBtn.Size = new System.Drawing.Size(85, 22);
            this.serverStartBtn.StyleController = this.layoutControl1;
            this.serverStartBtn.TabIndex = 7;
            this.serverStartBtn.Text = "서버시작";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.serverStartBtn;
            this.layoutControlItem1.Location = new System.Drawing.Point(247, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(259, 12);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(85, 22);
            this.resetBtn.StyleController = this.layoutControl1;
            this.resetBtn.TabIndex = 8;
            this.resetBtn.Text = "리셋";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.resetBtn;
            this.layoutControlItem2.Location = new System.Drawing.Point(247, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(89, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 450);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "Server";
            this.Text = "Chat_Server";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_server_send.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_server_chat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton sendButton;
        private DevExpress.XtraEditors.TextEdit txt_server_send;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit ipAddress;
        private DevExpress.XtraEditors.TextEdit portAddress;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem portControlItem;
        private DevExpress.XtraLayout.LayoutControlItem ipControlItem;
        private DevExpress.XtraEditors.MemoEdit txt_server_chat;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton serverStartBtn;
        private DevExpress.XtraEditors.SimpleButton resetBtn;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}

