namespace Roster_Dev
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.empBtns = new DevExpress.Utils.Layout.StackPanel();
            this.deptBtn = new DevExpress.XtraEditors.SimpleButton();
            this.referenceBtn = new DevExpress.XtraEditors.SimpleButton();
            this.addBtn = new DevExpress.XtraEditors.SimpleButton();
            this.multiAddBtn = new DevExpress.XtraEditors.SimpleButton();
            this.editBtn = new DevExpress.XtraEditors.SimpleButton();
            this.loginInfoBtn = new DevExpress.XtraEditors.SimpleButton();
            this.deleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.convertBtn = new DevExpress.XtraEditors.SimpleButton();
            this.exitBtn = new DevExpress.XtraEditors.SimpleButton();
            this.rosterLabel = new DevExpress.XtraEditors.LabelControl();
            this.imageEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.empGrid = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.departmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.departmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.loginId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.password = new DevExpress.XtraGrid.Columns.GridColumn();
            this.position = new DevExpress.XtraGrid.Columns.GridColumn();
            this.employment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gender = new DevExpress.XtraGrid.Columns.GridColumn();
            this.phoneNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.messengerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.image = new DevExpress.XtraGrid.Columns.GridColumn();
            this.photoToolTip = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empBtns)).BeginInit();
            this.empBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.empBtns);
            this.panelControl1.Controls.Add(this.rosterLabel);
            this.panelControl1.Controls.Add(this.imageEdit1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1225, 39);
            this.panelControl1.TabIndex = 1;
            // 
            // empBtns
            // 
            this.empBtns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.empBtns.Controls.Add(this.deptBtn);
            this.empBtns.Controls.Add(this.referenceBtn);
            this.empBtns.Controls.Add(this.addBtn);
            this.empBtns.Controls.Add(this.multiAddBtn);
            this.empBtns.Controls.Add(this.editBtn);
            this.empBtns.Controls.Add(this.loginInfoBtn);
            this.empBtns.Controls.Add(this.deleteBtn);
            this.empBtns.Controls.Add(this.convertBtn);
            this.empBtns.Controls.Add(this.exitBtn);
            this.empBtns.Location = new System.Drawing.Point(673, 0);
            this.empBtns.Name = "empBtns";
            this.empBtns.Size = new System.Drawing.Size(552, 39);
            this.empBtns.TabIndex = 1;
            // 
            // deptBtn
            // 
            this.deptBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deptBtn.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deptBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deptBtn.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.deptBtn.Appearance.Options.UseBackColor = true;
            this.deptBtn.Appearance.Options.UseBorderColor = true;
            this.deptBtn.Appearance.Options.UseFont = true;
            this.deptBtn.AppearanceDisabled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deptBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deptBtn.AppearanceDisabled.Options.UseBackColor = true;
            this.deptBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.deptBtn.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deptBtn.AppearanceHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deptBtn.AppearanceHovered.Options.UseBackColor = true;
            this.deptBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.deptBtn.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deptBtn.AppearancePressed.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deptBtn.AppearancePressed.Options.UseBackColor = true;
            this.deptBtn.AppearancePressed.Options.UseBorderColor = true;
            this.deptBtn.Location = new System.Drawing.Point(3, 1);
            this.deptBtn.Name = "deptBtn";
            this.deptBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.deptBtn.Size = new System.Drawing.Size(51, 37);
            this.deptBtn.TabIndex = 0;
            this.deptBtn.Text = "부서";
            // 
            // referenceBtn
            // 
            this.referenceBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.referenceBtn.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.referenceBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenceBtn.Appearance.Options.UseBackColor = true;
            this.referenceBtn.Appearance.Options.UseBorderColor = true;
            this.referenceBtn.Appearance.Options.UseFont = true;
            this.referenceBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.referenceBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.referenceBtn.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.referenceBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.referenceBtn.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.referenceBtn.AppearancePressed.Options.UseBorderColor = true;
            this.referenceBtn.Location = new System.Drawing.Point(60, 1);
            this.referenceBtn.Name = "referenceBtn";
            this.referenceBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.referenceBtn.Size = new System.Drawing.Size(51, 37);
            this.referenceBtn.TabIndex = 1;
            this.referenceBtn.Text = "조회";
            // 
            // addBtn
            // 
            this.addBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.addBtn.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.addBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Appearance.Options.UseBackColor = true;
            this.addBtn.Appearance.Options.UseBorderColor = true;
            this.addBtn.Appearance.Options.UseFont = true;
            this.addBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.addBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.addBtn.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.addBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.addBtn.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.addBtn.AppearancePressed.Options.UseBorderColor = true;
            this.addBtn.Location = new System.Drawing.Point(117, 1);
            this.addBtn.Name = "addBtn";
            this.addBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.addBtn.Size = new System.Drawing.Size(51, 37);
            this.addBtn.TabIndex = 2;
            this.addBtn.Text = "추가";
            // 
            // multiAddBtn
            // 
            this.multiAddBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.multiAddBtn.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.multiAddBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.multiAddBtn.Appearance.Options.UseBackColor = true;
            this.multiAddBtn.Appearance.Options.UseBorderColor = true;
            this.multiAddBtn.Appearance.Options.UseFont = true;
            this.multiAddBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.multiAddBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.multiAddBtn.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.multiAddBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.multiAddBtn.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.multiAddBtn.AppearancePressed.Options.UseBorderColor = true;
            this.multiAddBtn.Location = new System.Drawing.Point(174, 1);
            this.multiAddBtn.Name = "multiAddBtn";
            this.multiAddBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.multiAddBtn.Size = new System.Drawing.Size(59, 37);
            this.multiAddBtn.TabIndex = 3;
            this.multiAddBtn.Text = "다중추가";
            // 
            // editBtn
            // 
            this.editBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.editBtn.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.editBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Appearance.Options.UseBackColor = true;
            this.editBtn.Appearance.Options.UseBorderColor = true;
            this.editBtn.Appearance.Options.UseFont = true;
            this.editBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.editBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.editBtn.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.editBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.editBtn.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.editBtn.AppearancePressed.Options.UseBorderColor = true;
            this.editBtn.Location = new System.Drawing.Point(239, 1);
            this.editBtn.Name = "editBtn";
            this.editBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.editBtn.Size = new System.Drawing.Size(51, 37);
            this.editBtn.TabIndex = 4;
            this.editBtn.Text = "수정";
            // 
            // loginInfoBtn
            // 
            this.loginInfoBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.loginInfoBtn.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.loginInfoBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginInfoBtn.Appearance.Options.UseBackColor = true;
            this.loginInfoBtn.Appearance.Options.UseBorderColor = true;
            this.loginInfoBtn.Appearance.Options.UseFont = true;
            this.loginInfoBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.loginInfoBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.loginInfoBtn.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.loginInfoBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.loginInfoBtn.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.loginInfoBtn.AppearancePressed.Options.UseBorderColor = true;
            this.loginInfoBtn.Location = new System.Drawing.Point(296, 1);
            this.loginInfoBtn.Name = "loginInfoBtn";
            this.loginInfoBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.loginInfoBtn.Size = new System.Drawing.Size(75, 37);
            this.loginInfoBtn.TabIndex = 5;
            this.loginInfoBtn.Text = "로그인정보";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deleteBtn.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.deleteBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Appearance.Options.UseBackColor = true;
            this.deleteBtn.Appearance.Options.UseBorderColor = true;
            this.deleteBtn.Appearance.Options.UseFont = true;
            this.deleteBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.deleteBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.deleteBtn.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.deleteBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.deleteBtn.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.deleteBtn.AppearancePressed.Options.UseBorderColor = true;
            this.deleteBtn.Location = new System.Drawing.Point(377, 1);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.deleteBtn.Size = new System.Drawing.Size(51, 37);
            this.deleteBtn.TabIndex = 6;
            this.deleteBtn.Text = "삭제";
            // 
            // convertBtn
            // 
            this.convertBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.convertBtn.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.convertBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convertBtn.Appearance.Options.UseBackColor = true;
            this.convertBtn.Appearance.Options.UseBorderColor = true;
            this.convertBtn.Appearance.Options.UseFont = true;
            this.convertBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.convertBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.convertBtn.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.convertBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.convertBtn.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.convertBtn.AppearancePressed.Options.UseBorderColor = true;
            this.convertBtn.Location = new System.Drawing.Point(434, 1);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.convertBtn.Size = new System.Drawing.Size(60, 37);
            this.convertBtn.TabIndex = 7;
            this.convertBtn.Text = "자료변환";
            // 
            // exitBtn
            // 
            this.exitBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.exitBtn.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.exitBtn.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Appearance.Options.UseBackColor = true;
            this.exitBtn.Appearance.Options.UseBorderColor = true;
            this.exitBtn.Appearance.Options.UseFont = true;
            this.exitBtn.AppearanceDisabled.BorderColor = System.Drawing.Color.Transparent;
            this.exitBtn.AppearanceDisabled.Options.UseBorderColor = true;
            this.exitBtn.AppearanceHovered.BorderColor = System.Drawing.Color.Transparent;
            this.exitBtn.AppearanceHovered.Options.UseBorderColor = true;
            this.exitBtn.AppearancePressed.BorderColor = System.Drawing.Color.Transparent;
            this.exitBtn.AppearancePressed.Options.UseBorderColor = true;
            this.exitBtn.Location = new System.Drawing.Point(500, 1);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.exitBtn.Size = new System.Drawing.Size(51, 37);
            this.exitBtn.TabIndex = 8;
            this.exitBtn.Text = "닫기";
            // 
            // rosterLabel
            // 
            this.rosterLabel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rosterLabel.Appearance.Options.UseFont = true;
            this.rosterLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.rosterLabel.Location = new System.Drawing.Point(30, 9);
            this.rosterLabel.Name = "rosterLabel";
            this.rosterLabel.Size = new System.Drawing.Size(64, 21);
            this.rosterLabel.TabIndex = 0;
            this.rosterLabel.Text = "부서사원";
            // 
            // imageEdit1
            // 
            this.imageEdit1.EditValue = ((object)(resources.GetObject("imageEdit1.EditValue")));
            this.imageEdit1.Location = new System.Drawing.Point(9, 10);
            this.imageEdit1.Name = "imageEdit1";
            this.imageEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.imageEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.imageEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.imageEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.imageEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.imageEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imageEdit1.Size = new System.Drawing.Size(20, 20);
            this.imageEdit1.TabIndex = 2;
            this.imageEdit1.TabStop = true;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.empGrid);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 39);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1225, 411);
            this.panelControl2.TabIndex = 2;
            // 
            // empGrid
            // 
            this.empGrid.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.empGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.empGrid.Location = new System.Drawing.Point(2, 2);
            this.empGrid.MainView = this.gridView1;
            this.empGrid.Name = "empGrid";
            this.empGrid.Size = new System.Drawing.Size(1221, 407);
            this.empGrid.TabIndex = 0;
            this.empGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.White;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.departmentCode,
            this.departmentName,
            this.employeeCode,
            this.employeeName,
            this.loginId,
            this.password,
            this.position,
            this.employment,
            this.gender,
            this.phoneNum,
            this.email,
            this.messengerId,
            this.memo,
            this.image});
            this.gridView1.GridControl = this.empGrid;
            this.gridView1.Name = "gridView1";
            // 
            // departmentCode
            // 
            this.departmentCode.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.departmentCode.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentCode.AppearanceCell.Options.UseFont = true;
            this.departmentCode.AppearanceHeader.Options.UseTextOptions = true;
            this.departmentCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.departmentCode.Caption = "부서코드";
            this.departmentCode.FieldName = "DepartmentCode";
            this.departmentCode.Name = "departmentCode";
            this.departmentCode.OptionsFilter.AllowFilter = false;
            this.departmentCode.Visible = true;
            this.departmentCode.VisibleIndex = 0;
            // 
            // departmentName
            // 
            this.departmentName.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.departmentName.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentName.AppearanceCell.Options.UseFont = true;
            this.departmentName.AppearanceHeader.Options.UseTextOptions = true;
            this.departmentName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.departmentName.Caption = "부서명";
            this.departmentName.FieldName = "DepartmentName";
            this.departmentName.Name = "departmentName";
            this.departmentName.Visible = true;
            this.departmentName.VisibleIndex = 1;
            // 
            // employeeCode
            // 
            this.employeeCode.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.employeeCode.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeCode.AppearanceCell.Options.UseFont = true;
            this.employeeCode.AppearanceHeader.Options.UseTextOptions = true;
            this.employeeCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.employeeCode.Caption = "사원코드";
            this.employeeCode.FieldName = "EmployeeCode";
            this.employeeCode.Name = "employeeCode";
            this.employeeCode.Visible = true;
            this.employeeCode.VisibleIndex = 2;
            // 
            // employeeName
            // 
            this.employeeName.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.employeeName.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeName.AppearanceCell.Options.UseFont = true;
            this.employeeName.AppearanceHeader.Options.UseTextOptions = true;
            this.employeeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.employeeName.Caption = "사원명";
            this.employeeName.FieldName = "EmployeeName";
            this.employeeName.Name = "employeeName";
            this.employeeName.Visible = true;
            this.employeeName.VisibleIndex = 3;
            // 
            // loginId
            // 
            this.loginId.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.loginId.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginId.AppearanceCell.Options.UseFont = true;
            this.loginId.AppearanceHeader.Options.UseTextOptions = true;
            this.loginId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.loginId.Caption = "로그인ID";
            this.loginId.FieldName = "LoginId";
            this.loginId.Name = "loginId";
            this.loginId.Visible = true;
            this.loginId.VisibleIndex = 4;
            // 
            // password
            // 
            this.password.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.password.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.AppearanceCell.Options.UseFont = true;
            this.password.AppearanceHeader.Options.UseTextOptions = true;
            this.password.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.password.Caption = "비밀번호";
            this.password.FieldName = "Password";
            this.password.Name = "password";
            this.password.Visible = true;
            this.password.VisibleIndex = 5;
            // 
            // position
            // 
            this.position.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.position.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.position.AppearanceCell.Options.UseFont = true;
            this.position.AppearanceHeader.Options.UseTextOptions = true;
            this.position.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.position.Caption = "직위";
            this.position.FieldName = "Position";
            this.position.Name = "position";
            this.position.Visible = true;
            this.position.VisibleIndex = 6;
            // 
            // employment
            // 
            this.employment.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.employment.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employment.AppearanceCell.Options.UseFont = true;
            this.employment.AppearanceHeader.Options.UseTextOptions = true;
            this.employment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.employment.Caption = "고용형태";
            this.employment.FieldName = "Employment";
            this.employment.Name = "employment";
            this.employment.Visible = true;
            this.employment.VisibleIndex = 7;
            // 
            // gender
            // 
            this.gender.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.gender.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gender.AppearanceCell.Options.UseFont = true;
            this.gender.AppearanceHeader.Options.UseTextOptions = true;
            this.gender.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gender.Caption = "성별";
            this.gender.FieldName = "Gender";
            this.gender.Name = "gender";
            this.gender.Visible = true;
            this.gender.VisibleIndex = 8;
            // 
            // phoneNum
            // 
            this.phoneNum.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.phoneNum.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNum.AppearanceCell.Options.UseFont = true;
            this.phoneNum.AppearanceHeader.Options.UseTextOptions = true;
            this.phoneNum.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.phoneNum.Caption = "휴대전화";
            this.phoneNum.FieldName = "PhoneNum";
            this.phoneNum.Name = "phoneNum";
            this.phoneNum.Visible = true;
            this.phoneNum.VisibleIndex = 9;
            // 
            // email
            // 
            this.email.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.email.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.AppearanceCell.Options.UseFont = true;
            this.email.AppearanceHeader.Options.UseTextOptions = true;
            this.email.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.email.Caption = "이메일";
            this.email.FieldName = "Email";
            this.email.Name = "email";
            this.email.Visible = true;
            this.email.VisibleIndex = 10;
            // 
            // messengerId
            // 
            this.messengerId.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.messengerId.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messengerId.AppearanceCell.Options.UseFont = true;
            this.messengerId.AppearanceHeader.Options.UseTextOptions = true;
            this.messengerId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.messengerId.Caption = "메신저ID";
            this.messengerId.FieldName = "MessengerId";
            this.messengerId.Name = "messengerId";
            this.messengerId.Visible = true;
            this.messengerId.VisibleIndex = 11;
            // 
            // memo
            // 
            this.memo.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.memo.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memo.AppearanceCell.Options.UseFont = true;
            this.memo.AppearanceHeader.Options.UseTextOptions = true;
            this.memo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.memo.Caption = "메모";
            this.memo.FieldName = "Memo";
            this.memo.Name = "memo";
            this.memo.Visible = true;
            this.memo.VisibleIndex = 12;
            // 
            // image
            // 
            this.image.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.image.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.image.AppearanceCell.Options.UseFont = true;
            this.image.AppearanceHeader.Options.UseTextOptions = true;
            this.image.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.image.Caption = "이미지";
            this.image.FieldName = "PhotoPath";
            this.image.Name = global::Roster_Dev.Properties.Settings.Default.PhotoPath;
            this.image.Visible = true;
            this.image.VisibleIndex = 13;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 450);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Main";
            this.Text = "Main";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.empBtns)).EndInit();
            this.empBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.empGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl rosterLabel;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl empGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn departmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn departmentName;
        private DevExpress.XtraGrid.Columns.GridColumn employeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn employeeName;
        private DevExpress.XtraGrid.Columns.GridColumn loginId;
        private DevExpress.XtraGrid.Columns.GridColumn password;
        private DevExpress.XtraGrid.Columns.GridColumn position;
        private DevExpress.XtraGrid.Columns.GridColumn employment;
        private DevExpress.XtraGrid.Columns.GridColumn gender;
        private DevExpress.XtraGrid.Columns.GridColumn phoneNum;
        private DevExpress.XtraGrid.Columns.GridColumn email;
        private DevExpress.XtraGrid.Columns.GridColumn messengerId;
        private DevExpress.XtraGrid.Columns.GridColumn memo;
        private DevExpress.XtraGrid.Columns.GridColumn image;
        private DevExpress.Utils.Layout.StackPanel empBtns;
        private DevExpress.XtraEditors.SimpleButton multiAddBtn;
        private DevExpress.XtraEditors.SimpleButton addBtn;
        private DevExpress.XtraEditors.SimpleButton referenceBtn;
        private DevExpress.XtraEditors.SimpleButton deptBtn;
        private DevExpress.XtraEditors.SimpleButton editBtn;
        private DevExpress.XtraEditors.SimpleButton loginInfoBtn;
        private DevExpress.XtraEditors.SimpleButton deleteBtn;
        private DevExpress.XtraEditors.SimpleButton convertBtn;
        private DevExpress.XtraEditors.SimpleButton exitBtn;
        private DevExpress.XtraEditors.PictureEdit imageEdit1;
        private DevExpress.Utils.ToolTipController photoToolTip;
    }
}