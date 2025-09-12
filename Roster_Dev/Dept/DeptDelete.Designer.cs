namespace Roster_Dev.Dept
{
    partial class DeptDelete
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
            this.deptName = new DevExpress.XtraEditors.LabelControl();
            this.deptCode = new DevExpress.XtraEditors.LabelControl();
            this.deleteQuestion = new DevExpress.XtraEditors.LabelControl();
            this.deptNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.deptCodeLabel = new DevExpress.XtraEditors.LabelControl();
            this.cancel = new DevExpress.XtraEditors.SimpleButton();
            this.deleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.deptDeleteLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deptName
            // 
            this.deptName.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptName.Appearance.Options.UseFont = true;
            this.deptName.Location = new System.Drawing.Point(67, 86);
            this.deptName.Name = "deptName";
            this.deptName.Size = new System.Drawing.Size(53, 20);
            this.deptName.TabIndex = 48;
            this.deptName.Text = "생산1팀";
            // 
            // deptCode
            // 
            this.deptCode.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptCode.Appearance.Options.UseFont = true;
            this.deptCode.Location = new System.Drawing.Point(82, 66);
            this.deptCode.Name = "deptCode";
            this.deptCode.Size = new System.Drawing.Size(47, 20);
            this.deptCode.TabIndex = 47;
            this.deptCode.Text = "dpt001";
            // 
            // deleteQuestion
            // 
            this.deleteQuestion.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteQuestion.Appearance.Options.UseFont = true;
            this.deleteQuestion.Location = new System.Drawing.Point(13, 122);
            this.deleteQuestion.Name = "deleteQuestion";
            this.deleteQuestion.Size = new System.Drawing.Size(127, 20);
            this.deleteQuestion.TabIndex = 46;
            this.deleteQuestion.Text = "삭제하시겠습니까?";
            // 
            // deptNameLabel
            // 
            this.deptNameLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptNameLabel.Appearance.Options.UseFont = true;
            this.deptNameLabel.Location = new System.Drawing.Point(13, 86);
            this.deptNameLabel.Name = "deptNameLabel";
            this.deptNameLabel.Size = new System.Drawing.Size(48, 20);
            this.deptNameLabel.TabIndex = 45;
            this.deptNameLabel.Text = "부서명:";
            // 
            // deptCodeLabel
            // 
            this.deptCodeLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptCodeLabel.Appearance.Options.UseFont = true;
            this.deptCodeLabel.Location = new System.Drawing.Point(13, 66);
            this.deptCodeLabel.Name = "deptCodeLabel";
            this.deptCodeLabel.Size = new System.Drawing.Size(63, 20);
            this.deptCodeLabel.TabIndex = 44;
            this.deptCodeLabel.Text = "부서코드:";
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
            this.cancel.TabIndex = 43;
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
            this.deleteBtn.TabIndex = 42;
            this.deleteBtn.Text = "삭제";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Silver;
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.deptDeleteLabel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(361, 39);
            this.panelControl1.TabIndex = 41;
            // 
            // deptDeleteLabel
            // 
            this.deptDeleteLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.deptDeleteLabel.Appearance.Options.UseFont = true;
            this.deptDeleteLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.deptDeleteLabel.Location = new System.Drawing.Point(12, 8);
            this.deptDeleteLabel.Name = "deptDeleteLabel";
            this.deptDeleteLabel.Size = new System.Drawing.Size(70, 21);
            this.deptDeleteLabel.TabIndex = 0;
            this.deptDeleteLabel.Text = "부서 삭제";
            // 
            // DeptDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 230);
            this.Controls.Add(this.deptName);
            this.Controls.Add(this.deptCode);
            this.Controls.Add(this.deleteQuestion);
            this.Controls.Add(this.deptNameLabel);
            this.Controls.Add(this.deptCodeLabel);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.panelControl1);
            this.Name = "DeptDelete";
            this.Text = "DeptDelete";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl deptName;
        private DevExpress.XtraEditors.LabelControl deptCode;
        private DevExpress.XtraEditors.LabelControl deleteQuestion;
        private DevExpress.XtraEditors.LabelControl deptNameLabel;
        private DevExpress.XtraEditors.LabelControl deptCodeLabel;
        private DevExpress.XtraEditors.SimpleButton cancel;
        private DevExpress.XtraEditors.SimpleButton deleteBtn;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl deptDeleteLabel;
    }
}