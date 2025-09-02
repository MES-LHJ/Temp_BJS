namespace Roster
{
    partial class Department
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.exit = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.DepartmentDataGrid = new System.Windows.Forms.DataGridView();
            this.partCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.exit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.delete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.edit, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(236, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(249, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(189, 3);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(57, 23);
            this.exit.TabIndex = 6;
            this.exit.Text = "닫기";
            this.exit.UseVisualStyleBackColor = true;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(3, 3);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(56, 23);
            this.add.TabIndex = 2;
            this.add.Text = "추가";
            this.add.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(127, 3);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(56, 23);
            this.delete.TabIndex = 5;
            this.delete.Text = "삭제";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(65, 3);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(56, 23);
            this.edit.TabIndex = 4;
            this.edit.Text = "수정";
            this.edit.UseVisualStyleBackColor = true;
            // 
            // DepartmentDataGrid
            // 
            this.DepartmentDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.DepartmentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepartmentDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.partCode,
            this.departName,
            this.memo});
            this.DepartmentDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartmentDataGrid.Location = new System.Drawing.Point(20, 60);
            this.DepartmentDataGrid.Name = "DepartmentDataGrid";
            this.DepartmentDataGrid.RowTemplate.Height = 23;
            this.DepartmentDataGrid.Size = new System.Drawing.Size(446, 370);
            this.DepartmentDataGrid.TabIndex = 1;
            // 
            // partCode
            // 
            this.partCode.HeaderText = "부서코드";
            this.partCode.Name = "partCode";
            // 
            // departName
            // 
            this.departName.HeaderText = "부서명";
            this.departName.Name = "departName";
            // 
            // memo
            // 
            this.memo.HeaderText = "메모";
            this.memo.Name = "memo";
            // 
            // Department
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 450);
            this.Controls.Add(this.DepartmentDataGrid);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Department";
            this.Text = "부서";
            this.Load += new System.EventHandler(this.Department_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView DepartmentDataGrid;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn partCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn departName;
        private System.Windows.Forms.DataGridViewTextBoxColumn memo;
    }
}