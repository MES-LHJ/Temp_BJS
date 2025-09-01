namespace Roster
{
    partial class DepartmentDelete
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
            this.Cancel = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Check_label = new System.Windows.Forms.Label();
            this.DepartmentName_label = new System.Windows.Forms.Label();
            this.DepartmentCode_label = new System.Windows.Forms.Label();
            this.DepartmentName = new System.Windows.Forms.Label();
            this.PartCode = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Cancel
            // 
            this.Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel.BackColor = System.Drawing.Color.Gray;
            this.Cancel.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Cancel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Cancel.Location = new System.Drawing.Point(265, 159);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(112, 40);
            this.Cancel.TabIndex = 37;
            this.Cancel.Text = "취소";
            this.Cancel.UseVisualStyleBackColor = false;
            // 
            // Delete
            // 
            this.Delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Delete.BackColor = System.Drawing.Color.Red;
            this.Delete.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Delete.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Delete.Location = new System.Drawing.Point(137, 159);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(112, 40);
            this.Delete.TabIndex = 36;
            this.Delete.Text = "삭제";
            this.Delete.UseVisualStyleBackColor = false;
            // 
            // Check_label
            // 
            this.Check_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Check_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Check_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Check_label.Location = new System.Drawing.Point(9, 126);
            this.Check_label.Name = "Check_label";
            this.Check_label.Size = new System.Drawing.Size(154, 23);
            this.Check_label.TabIndex = 35;
            this.Check_label.Text = "삭제하시겠습니까?";
            this.Check_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepartmentName_label
            // 
            this.DepartmentName_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentName_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepartmentName_label.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DepartmentName_label.Location = new System.Drawing.Point(11, 95);
            this.DepartmentName_label.Name = "DepartmentName_label";
            this.DepartmentName_label.Size = new System.Drawing.Size(61, 23);
            this.DepartmentName_label.TabIndex = 34;
            this.DepartmentName_label.Text = "부서명:";
            this.DepartmentName_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepartmentCode_label
            // 
            this.DepartmentCode_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentCode_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepartmentCode_label.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DepartmentCode_label.Location = new System.Drawing.Point(9, 69);
            this.DepartmentCode_label.Name = "DepartmentCode_label";
            this.DepartmentCode_label.Size = new System.Drawing.Size(78, 26);
            this.DepartmentCode_label.TabIndex = 33;
            this.DepartmentCode_label.Text = "부서코드:";
            this.DepartmentCode_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepartmentName
            // 
            this.DepartmentName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartmentName.AutoSize = true;
            this.DepartmentName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DepartmentName.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.DepartmentName.Location = new System.Drawing.Point(73, 99);
            this.DepartmentName.Name = "DepartmentName";
            this.DepartmentName.Size = new System.Drawing.Size(24, 15);
            this.DepartmentName.TabIndex = 39;
            this.DepartmentName.Text = "ex";
            // 
            // PartCode
            // 
            this.PartCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PartCode.AutoSize = true;
            this.PartCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PartCode.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.PartCode.Location = new System.Drawing.Point(88, 75);
            this.PartCode.Name = "PartCode";
            this.PartCode.Size = new System.Drawing.Size(24, 15);
            this.PartCode.TabIndex = 38;
            this.PartCode.Text = "ex";
            // 
            // DepartmentDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 212);
            this.Controls.Add(this.DepartmentName);
            this.Controls.Add(this.PartCode);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Check_label);
            this.Controls.Add(this.DepartmentName_label);
            this.Controls.Add(this.DepartmentCode_label);
            this.Name = "DepartmentDelete";
            this.Text = "부서삭제";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label Check_label;
        private System.Windows.Forms.Label DepartmentName_label;
        private System.Windows.Forms.Label DepartmentCode_label;
        private System.Windows.Forms.Label DepartmentName;
        private System.Windows.Forms.Label PartCode;
    }
}