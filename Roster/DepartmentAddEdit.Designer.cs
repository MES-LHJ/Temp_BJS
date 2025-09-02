namespace Roster
{
    partial class DepartmentAddEdit
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
            this.departName = new System.Windows.Forms.TextBox();
            this.DepartmentName = new System.Windows.Forms.Label();
            this.DepartmentCode = new System.Windows.Forms.Label();
            this.memo = new System.Windows.Forms.TextBox();
            this.Memo_label = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.partCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // departName
            // 
            this.departName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.departName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.departName.Location = new System.Drawing.Point(205, 91);
            this.departName.Name = "departName";
            this.departName.Size = new System.Drawing.Size(167, 21);
            this.departName.TabIndex = 38;
            // 
            // DepartmentName
            // 
            this.DepartmentName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepartmentName.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DepartmentName.ForeColor = System.Drawing.Color.Red;
            this.DepartmentName.Location = new System.Drawing.Point(196, 72);
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.Size = new System.Drawing.Size(57, 23);
            this.DepartmentName.TabIndex = 36;
            this.DepartmentName.Text = "부서명";
            this.DepartmentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepartmentCode
            // 
            this.DepartmentCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepartmentCode.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DepartmentCode.ForeColor = System.Drawing.Color.Red;
            this.DepartmentCode.Location = new System.Drawing.Point(12, 72);
            this.DepartmentCode.Name = "DepartmentCode";
            this.DepartmentCode.Size = new System.Drawing.Size(57, 23);
            this.DepartmentCode.TabIndex = 35;
            this.DepartmentCode.Text = "부서코드";
            this.DepartmentCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // memo
            // 
            this.memo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.memo.Location = new System.Drawing.Point(15, 137);
            this.memo.Name = "memo";
            this.memo.Size = new System.Drawing.Size(357, 21);
            this.memo.TabIndex = 51;
            // 
            // Memo_label
            // 
            this.Memo_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Memo_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Memo_label.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Memo_label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Memo_label.Location = new System.Drawing.Point(8, 117);
            this.Memo_label.Name = "Memo_label";
            this.Memo_label.Size = new System.Drawing.Size(42, 23);
            this.Memo_label.TabIndex = 52;
            this.Memo_label.Text = "메모";
            this.Memo_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Exit
            // 
            this.Exit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Exit.BackColor = System.Drawing.Color.Red;
            this.Exit.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Exit.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Exit.Location = new System.Drawing.Point(276, 168);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(96, 31);
            this.Exit.TabIndex = 58;
            this.Exit.Text = "닫기";
            this.Exit.UseVisualStyleBackColor = false;
            // 
            // Save
            // 
            this.Save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Save.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Save.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Save.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Save.Location = new System.Drawing.Point(164, 168);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(96, 31);
            this.Save.TabIndex = 57;
            this.Save.Text = "저장";
            this.Save.UseVisualStyleBackColor = false;
            // 
            // partCode
            // 
            this.partCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.partCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.partCode.Location = new System.Drawing.Point(15, 91);
            this.partCode.Name = "partCode";
            this.partCode.Size = new System.Drawing.Size(167, 21);
            this.partCode.TabIndex = 59;
            // 
            // DepartmentAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 211);
            this.Controls.Add(this.partCode);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.memo);
            this.Controls.Add(this.Memo_label);
            this.Controls.Add(this.departName);
            this.Controls.Add(this.DepartmentName);
            this.Controls.Add(this.DepartmentCode);
            this.Name = "DepartmentAddEdit";
            this.Text = "부서추가";
            this.Load += new System.EventHandler(this.DepartmentAddEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox departName;
        private System.Windows.Forms.Label DepartmentName;
        private System.Windows.Forms.Label DepartmentCode;
        private System.Windows.Forms.TextBox memo;
        private System.Windows.Forms.Label Memo_label;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox partCode;
    }
}