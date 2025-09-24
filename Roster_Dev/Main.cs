using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Wordprocessing;
using Roster_Dev.Dpt;
using Roster_Dev.Model;
using Roster_Dev.UtilClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Point = System.Drawing.Point;

namespace Roster_Dev
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            AddEvent();
            empGrid.ToolTipController = photoToolTip;
        }

        public void AddEvent()
        {
            this.Load += Form_Load;
            this.deptBtn.Click += Dept_Click;
            this.referenceBtn.Click += Reference_Click;
            this.addBtn.Click += Add_Click;
            this.multiAddBtn.Click += MultiAdd_Click;
            this.editBtn.Click += Edit_Click;
            this.loginInfoBtn.Click += LoginInfo_Click;
            this.deleteBtn.Click += Delete_Click;
            this.convertBtn.Click += Convert_Click;
            this.exitBtn.Click += Exit_Click;
            var view = empGrid.MainView as GridView;
            view.CustomColumnDisplayText += EmpGrid_CellFormatting;
            photoToolTip.GetActiveObjectInfo += photoToolTip_GetActiveObjectInfo;

        }

        private void EmpGrid_CellFormatting(object sender, CustomColumnDisplayTextEventArgs e)
        {
            // Password * 마킹
            if (e.Column.FieldName == "Password" && e.Value != null)
            {
                string password = e.Value.ToString();
                if (!string.IsNullOrEmpty(password))
                {
                    e.DisplayText = new string('*', password.Length);
                }
            }

            // 이미지 컬럼 파일명으로 표시
            if (e.Column.FieldName == "PhotoPath" && e.Value != null)
            {
                e.DisplayText = Path.GetFileName(e.Value.ToString());
            }
        }

        private void photoToolTip_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != empGrid) return;

            GridView view = empGrid.FocusedView as GridView;
            if (view == null) return;

            GridHitInfo hitInfo = view.CalcHitInfo(e.ControlMousePosition);

            if (hitInfo.InRowCell && hitInfo.Column.FieldName == "PhotoPath")
            {
                string photoPath = view.GetRowCellValue(hitInfo.RowHandle, hitInfo.Column)?.ToString();
                if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                {
                    ToolTipControlInfo info = new ToolTipControlInfo();
                    info.Object = hitInfo;
                    info.ToolTipType = ToolTipType.SuperTip;

                    SuperToolTip superTip = new SuperToolTip();
                    superTip.Items.AddTitle("사진 미리보기");

                    using (Image original = Image.FromFile(photoPath))
                    {
                        int targetWidth = 50;   // 원하는 크기
                        int targetHeight = 50;  // 원하는 크기
                        Image resized = new Bitmap(original, new Size(targetWidth, targetHeight));


                        ToolTipItem item = new ToolTipItem
                        {
                            //Image = Image.FromFile(photoPath),
                            Image = new Bitmap(resized),
                            Text = ""
                        };
                        superTip.Items.Add(item);
                    }

                    info.SuperTip = superTip;
                    e.Info = info;
                }
            }
        }

        private void RefreshGrid()
        {
            var emp = SqlReposit.GetEmployees().OrderBy(e => e.EmployeeCode).ToList();

            empGrid.DataSource = emp;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void Dept_Click(object sender, EventArgs e)
        {
            using (var Form = new Department())
            {
                Form.ShowDialog();
            }
        }

        private void Reference_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var dept = new DeptWorkout();
            using (var Form = new Emp.EmpAdd(dept))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void MultiAdd_Click(object sender, EventArgs e)
        {
            using (var Form = new MultiAdd())
            {
                Form.ShowDialog();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var view = empGrid.MainView as GridView;
            if (view == null || view.FocusedRowHandle < 0)
            {
                MessageBox.Show("수정할 행을 선택하세요.");
                return;
            }

            // 현재 선택된 행의 EmployeeId 가져오기
            var empId = Convert.ToInt32(view.GetFocusedRowCellValue("EmployeeId"));

            using (var Form = new Emp.EmpEdit(empId))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void LoginInfo_Click(object sender, EventArgs e)
        {
            var loginInfoForm = new Login();
            loginInfoForm.ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var view = empGrid.MainView as GridView;
            var employee = view?.GetFocusedRow() as EmpWorkout;

            if (employee == null)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }

            using (var Form = new Emp.EmpDelete(employee))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (empGrid.DataSource == null)
            {
                MessageBox.Show("변환할 데이터가 없습니다.");
                return;
            }
            Util.Instance.Convert(empGrid, "Employee.xlsx");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
