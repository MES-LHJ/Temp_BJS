namespace Roster
{
    partial class RosterDelete
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
            this.RosterCode_label = new System.Windows.Forms.Label();
            this.RosterName_label = new System.Windows.Forms.Label();
            this.Check_label = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.RosterCode = new System.Windows.Forms.Label();
            this.RosterName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RosterCode_label
            // 
            this.RosterCode_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RosterCode_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RosterCode_label.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RosterCode_label.Location = new System.Drawing.Point(9, 70);
            this.RosterCode_label.Name = "RosterCode_label";
            this.RosterCode_label.Size = new System.Drawing.Size(78, 26);
            this.RosterCode_label.TabIndex = 0;
            this.RosterCode_label.Text = "사원코드:";
            this.RosterCode_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RosterName_label
            // 
            this.RosterName_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RosterName_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RosterName_label.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RosterName_label.Location = new System.Drawing.Point(11, 96);
            this.RosterName_label.Name = "RosterName_label";
            this.RosterName_label.Size = new System.Drawing.Size(61, 23);
            this.RosterName_label.TabIndex = 1;
            this.RosterName_label.Text = "사원명:";
            this.RosterName_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Check_label
            // 
            this.Check_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Check_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Check_label.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Check_label.Location = new System.Drawing.Point(9, 127);
            this.Check_label.Name = "Check_label";
            this.Check_label.Size = new System.Drawing.Size(154, 23);
            this.Check_label.TabIndex = 2;
            this.Check_label.Text = "삭제하시겠습니까?";
            this.Check_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Cancel
            // 
            this.Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel.BackColor = System.Drawing.Color.Gray;
            this.Cancel.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Cancel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Cancel.Location = new System.Drawing.Point(265, 160);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(112, 40);
            this.Cancel.TabIndex = 32;
            this.Cancel.Text = "취소";
            this.Cancel.UseVisualStyleBackColor = false;
            // 
            // Delete
            // 
            this.Delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Delete.BackColor = System.Drawing.Color.Red;
            this.Delete.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Delete.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Delete.Location = new System.Drawing.Point(137, 160);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(112, 40);
            this.Delete.TabIndex = 31;
            this.Delete.Text = "삭제";
            this.Delete.UseVisualStyleBackColor = false;
            // 
            // RosterCode
            // 
            this.RosterCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RosterCode.AutoSize = true;
            this.RosterCode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RosterCode.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RosterCode.Location = new System.Drawing.Point(88, 76);
            this.RosterCode.Name = "RosterCode";
            this.RosterCode.Size = new System.Drawing.Size(24, 15);
            this.RosterCode.TabIndex = 33;
            this.RosterCode.Text = "ex";
            // 
            // RosterName
            // 
            this.RosterName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RosterName.AutoSize = true;
            this.RosterName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RosterName.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.RosterName.Location = new System.Drawing.Point(73, 100);
            this.RosterName.Name = "RosterName";
            this.RosterName.Size = new System.Drawing.Size(24, 15);
            this.RosterName.TabIndex = 34;
            this.RosterName.Text = "ex";
            // 
            // RosterDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 214);
            this.Controls.Add(this.RosterName);
            this.Controls.Add(this.RosterCode);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.Check_label);
            this.Controls.Add(this.RosterName_label);
            this.Controls.Add(this.RosterCode_label);
            this.Name = "RosterDelete";
            this.Text = "사원삭제";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RosterCode_label;
        private System.Windows.Forms.Label RosterName_label;
        private System.Windows.Forms.Label Check_label;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Label RosterCode;
        private System.Windows.Forms.Label RosterName;
    }
}