namespace Chat_Client
{
    partial class Client
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
            this.txt_client_send = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ipAddress = new DevExpress.XtraEditors.TextEdit();
            this.portAddress = new DevExpress.XtraEditors.TextEdit();
            this.connectBtn = new DevExpress.XtraEditors.SimpleButton();
            this.txt_client_chat = new DevExpress.XtraEditors.MemoEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.portControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.ipControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_client_send.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ipAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_client_chat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.portControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipControlItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.sendButton);
            this.panelControl1.Controls.Add(this.txt_client_send);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 367);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 83);
            this.panelControl1.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(269, 48);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(71, 23);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send";
            // 
            // txt_client_send
            // 
            this.txt_client_send.Location = new System.Drawing.Point(20, 15);
            this.txt_client_send.Name = "txt_client_send";
            this.txt_client_send.Properties.AutoHeight = false;
            this.txt_client_send.Size = new System.Drawing.Size(243, 56);
            this.txt_client_send.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.layoutControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(360, 367);
            this.panelControl2.TabIndex = 3;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ipAddress);
            this.layoutControl1.Controls.Add(this.portAddress);
            this.layoutControl1.Controls.Add(this.connectBtn);
            this.layoutControl1.Controls.Add(this.txt_client_chat);
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
            this.ipAddress.Size = new System.Drawing.Size(114, 20);
            this.ipAddress.StyleController = this.layoutControl1;
            this.ipAddress.TabIndex = 4;
            // 
            // portAddress
            // 
            this.portAddress.Location = new System.Drawing.Point(148, 33);
            this.portAddress.Name = "portAddress";
            this.portAddress.Size = new System.Drawing.Size(109, 20);
            this.portAddress.StyleController = this.layoutControl1;
            this.portAddress.TabIndex = 5;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(271, 31);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(69, 22);
            this.connectBtn.StyleController = this.layoutControl1;
            this.connectBtn.TabIndex = 6;
            this.connectBtn.Text = "접속";
            // 
            // txt_client_chat
            // 
            this.txt_client_chat.Enabled = false;
            this.txt_client_chat.Location = new System.Drawing.Point(18, 67);
            this.txt_client_chat.Name = "txt_client_chat";
            this.txt_client_chat.Size = new System.Drawing.Size(320, 278);
            this.txt_client_chat.StyleController = this.layoutControl1;
            this.txt_client_chat.TabIndex = 7;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.portControlItem,
            this.ipControlItem});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(356, 363);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.ContentVertAlignment = DevExpress.Utils.VertAlignment.Bottom;
            this.layoutControlItem3.Control = this.connectBtn;
            this.layoutControlItem3.Location = new System.Drawing.Point(255, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(6, 6, 6, 6);
            this.layoutControlItem3.Size = new System.Drawing.Size(81, 49);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_client_chat;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 49);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 8, 8);
            this.layoutControlItem4.Size = new System.Drawing.Size(336, 294);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // portControlItem
            // 
            this.portControlItem.Control = this.portAddress;
            this.portControlItem.Location = new System.Drawing.Point(130, 0);
            this.portControlItem.Name = "portControlItem";
            this.portControlItem.Padding = new DevExpress.XtraLayout.Utils.Padding(8, 8, 6, 6);
            this.portControlItem.Size = new System.Drawing.Size(125, 49);
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
            this.ipControlItem.Size = new System.Drawing.Size(130, 49);
            this.ipControlItem.Text = "IP";
            this.ipControlItem.TextLocation = DevExpress.Utils.Locations.Top;
            this.ipControlItem.TextSize = new System.Drawing.Size(31, 14);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 450);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Client";
            this.Text = "Chat_Client";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_client_send.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ipAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_client_chat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.portControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipControlItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton sendButton;
        private DevExpress.XtraEditors.TextEdit txt_client_send;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit ipAddress;
        private DevExpress.XtraEditors.TextEdit portAddress;
        private DevExpress.XtraEditors.SimpleButton connectBtn;
        private DevExpress.XtraEditors.MemoEdit txt_client_chat;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem portControlItem;
        private DevExpress.XtraLayout.LayoutControlItem ipControlItem;
    }
}

