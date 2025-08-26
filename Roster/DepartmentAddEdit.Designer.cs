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
            this.DepartName = new System.Windows.Forms.TextBox();
            this.DepartmentName = new System.Windows.Forms.Label();
            this.DepartmentCode = new System.Windows.Forms.Label();
            this.Memo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PartCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DepartName
            // 
            this.DepartName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DepartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DepartName.Location = new System.Drawing.Point(205, 91);
            this.DepartName.Name = "DepartName";
            this.DepartName.Size = new System.Drawing.Size(167, 21);
            this.DepartName.TabIndex = 38;
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
            // Memo
            // 
            this.Memo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Memo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Memo.Location = new System.Drawing.Point(15, 137);
            this.Memo.Name = "Memo";
            this.Memo.Size = new System.Drawing.Size(357, 21);
            this.Memo.TabIndex = 51;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(8, 117);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 23);
            this.label13.TabIndex = 52;
            this.label13.Text = "메모";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Location = new System.Drawing.Point(276, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 31);
            this.button2.TabIndex = 58;
            this.button2.Text = "닫기";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Location = new System.Drawing.Point(164, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 31);
            this.button1.TabIndex = 57;
            this.button1.Text = "저장";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PartCode
            // 
            this.PartCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PartCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PartCode.Location = new System.Drawing.Point(15, 91);
            this.PartCode.Name = "PartCode";
            this.PartCode.Size = new System.Drawing.Size(167, 21);
            this.PartCode.TabIndex = 59;
            // 
            // DepartmentAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 211);
            this.Controls.Add(this.PartCode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Memo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DepartName);
            this.Controls.Add(this.DepartmentName);
            this.Controls.Add(this.DepartmentCode);
            this.Name = "DepartmentAddEdit";
            this.Text = "부서추가";
            this.Load += new System.EventHandler(this.DepartmentAddEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DepartName;
        private System.Windows.Forms.Label DepartmentName;
        private System.Windows.Forms.Label DepartmentCode;
        private System.Windows.Forms.TextBox Memo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox PartCode;
    }
}