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
            this.DepartmentDataGrid = new System.Windows.Forms.DataGridView();
            this.Add = new System.Windows.Forms.Button();
            this.Edit = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.Exit, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Delete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Edit, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(236, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(249, 29);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DepartmentDataGrid
            // 
            this.DepartmentDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.DepartmentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepartmentDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DepartmentDataGrid.Location = new System.Drawing.Point(20, 60);
            this.DepartmentDataGrid.Name = "DepartmentDataGrid";
            this.DepartmentDataGrid.RowTemplate.Height = 23;
            this.DepartmentDataGrid.Size = new System.Drawing.Size(446, 370);
            this.DepartmentDataGrid.TabIndex = 1;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(3, 3);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(56, 23);
            this.Add.TabIndex = 2;
            this.Add.Text = "추가";
            this.Add.UseVisualStyleBackColor = true;
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(65, 3);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(56, 23);
            this.Edit.TabIndex = 4;
            this.Edit.Text = "수정";
            this.Edit.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(127, 3);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(56, 23);
            this.Delete.TabIndex = 5;
            this.Delete.Text = "삭제";
            this.Delete.UseVisualStyleBackColor = true;
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(189, 3);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(57, 23);
            this.Exit.TabIndex = 6;
            this.Exit.Text = "닫기";
            this.Exit.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Edit;
    }
}