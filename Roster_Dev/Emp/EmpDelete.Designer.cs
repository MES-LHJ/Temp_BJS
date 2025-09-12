namespace Roster_Dev.Emp
{
    partial class EmpDelete
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
            this.rosterDeleteLabel = new DevExpress.XtraEditors.LabelControl();
            this.cancel = new DevExpress.XtraEditors.SimpleButton();
            this.deleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.empCodeLabel = new DevExpress.XtraEditors.LabelControl();
            this.empNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.deleteQuestion = new DevExpress.XtraEditors.LabelControl();
            this.empCode = new DevExpress.XtraEditors.LabelControl();
            this.empName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Silver;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.rosterDeleteLabel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(361, 39);
            this.panelControl1.TabIndex = 4;
            // 
            // rosterDeleteLabel
            // 
            this.rosterDeleteLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rosterDeleteLabel.Appearance.Options.UseFont = true;
            this.rosterDeleteLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.rosterDeleteLabel.Location = new System.Drawing.Point(12, 8);
            this.rosterDeleteLabel.Name = "rosterDeleteLabel";
            this.rosterDeleteLabel.Size = new System.Drawing.Size(64, 21);
            this.rosterDeleteLabel.TabIndex = 0;
            this.rosterDeleteLabel.Text = "사원삭제";
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Appearance.BackColor = System.Drawing.Color.Gray;
            this.cancel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Appearance.Options.UseBackColor = true;
            this.cancel.Appearance.Options.UseFont = true;
            this.cancel.Location = new System.Drawing.Point(247, 185);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(102, 33);
            this.cancel.TabIndex = 35;
            this.cancel.Text = "취소";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtn.Appearance.BackColor = System.Drawing.Color.Red;
            this.deleteBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.deleteBtn.Appearance.Options.UseBackColor = true;
            this.deleteBtn.Appearance.Options.UseFont = true;
            this.deleteBtn.Location = new System.Drawing.Point(135, 185);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(102, 33);
            this.deleteBtn.TabIndex = 34;
            this.deleteBtn.Text = "삭제";
            // 
            // empCodeLabel
            // 
            this.empCodeLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empCodeLabel.Appearance.Options.UseFont = true;
            this.empCodeLabel.Location = new System.Drawing.Point(13, 66);
            this.empCodeLabel.Name = "empCodeLabel";
            this.empCodeLabel.Size = new System.Drawing.Size(63, 20);
            this.empCodeLabel.TabIndex = 36;
            this.empCodeLabel.Text = "사원코드:";
            // 
            // empNameLabel
            // 
            this.empNameLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empNameLabel.Appearance.Options.UseFont = true;
            this.empNameLabel.Location = new System.Drawing.Point(13, 86);
            this.empNameLabel.Name = "empNameLabel";
            this.empNameLabel.Size = new System.Drawing.Size(48, 20);
            this.empNameLabel.TabIndex = 37;
            this.empNameLabel.Text = "사원명:";
            // 
            // deleteQuestion
            // 
            this.deleteQuestion.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteQuestion.Appearance.Options.UseFont = true;
            this.deleteQuestion.Location = new System.Drawing.Point(13, 122);
            this.deleteQuestion.Name = "deleteQuestion";
            this.deleteQuestion.Size = new System.Drawing.Size(127, 20);
            this.deleteQuestion.TabIndex = 38;
            this.deleteQuestion.Text = "삭제하시겠습니까?";
            // 
            // empCode
            // 
            this.empCode.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empCode.Appearance.Options.UseFont = true;
            this.empCode.Location = new System.Drawing.Point(82, 66);
            this.empCode.Name = "empCode";
            this.empCode.Size = new System.Drawing.Size(55, 20);
            this.empCode.TabIndex = 39;
            this.empCode.Text = "EMP001";
            // 
            // empName
            // 
            this.empName.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empName.Appearance.Options.UseFont = true;
            this.empName.Location = new System.Drawing.Point(67, 86);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(45, 20);
            this.empName.TabIndex = 40;
            this.empName.Text = "홍길동";
            // 
            // EmpDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 230);
            this.Controls.Add(this.empName);
            this.Controls.Add(this.empCode);
            this.Controls.Add(this.deleteQuestion);
            this.Controls.Add(this.empNameLabel);
            this.Controls.Add(this.empCodeLabel);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.panelControl1);
            this.Name = "EmpDelete";
            this.Text = "EmpDelete";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl rosterDeleteLabel;
        private DevExpress.XtraEditors.SimpleButton cancel;
        private DevExpress.XtraEditors.SimpleButton deleteBtn;
        private DevExpress.XtraEditors.LabelControl empCodeLabel;
        private DevExpress.XtraEditors.LabelControl empNameLabel;
        private DevExpress.XtraEditors.LabelControl deleteQuestion;
        private DevExpress.XtraEditors.LabelControl empCode;
        private DevExpress.XtraEditors.LabelControl empName;
    }
}