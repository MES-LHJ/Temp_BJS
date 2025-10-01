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
using System.Text.Json;
using Point = System.Drawing.Point;

namespace Roster_Dev
{
    public partial class Main : Form
    {
        private long factoryId;

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
        }

        private void EmpGrid_CellFormatting(object sender, CustomColumnDisplayTextEventArgs e)
        {
            // Password * 마킹
            if (e.Column.FieldName == "LoginPassword" && e.Value != null)
            {
                string password = e.Value.ToString();
                if (!string.IsNullOrEmpty(password))
                {
                    e.DisplayText = new string('*', password.Length);
                }
            }

            // 이미지 컬럼 파일명으로 표시
            //if (e.Column.FieldName == "PhotoPath" && e.Value != null)
            //{
            //    e.DisplayText = Path.GetFileName(e.Value.ToString());
            //}
        }

        //private void RefreshGrid()
        //{
        //    var emp = SqlReposit.GetEmployees().OrderBy(e => e.EmployeeCode).ToList();

        //    empGrid.DataSource = emp;
        //}

        public async Task RefreshGrid() // Task를 반환하도록 변경하고 async 키워드 추가
        {
            try
            {
                // ApiRepository를 사용하여 API에서 사원 목록을 비동기로 가져옴
                var employeeList = await ApiRepository.GetEmployeesAsync(factoryId);
                // 가져온 데이터를 GridControl (empGrid)에 바인딩
                empGrid.DataSource = employeeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            await RefreshGrid();
        }

        private void Dept_Click(object sender, EventArgs e)
        {
            using (var Form = new Department(factoryId))
            {
                Form.ShowDialog();
            }
        }

        private async void Reference_Click(object sender, EventArgs e)
        {
            await RefreshGrid();
        }

        private async void Add_Click(object sender, EventArgs e)
        {
            var dept = new DepartmentWorkout();
            using (var Form = new Emp.EmpAdd(dept))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
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

        private async void Edit_Click(object sender, EventArgs e)
        {
            var view = empGrid.MainView as GridView;
            if (view == null || view.FocusedRowHandle < 0)
            {
                MessageBox.Show("수정할 행을 선택하세요.");
                return;
            }

            // 현재 선택된 행의 EmployeeId 가져오기
            var empId = Convert.ToInt32(view.GetFocusedRowCellValue("Id"));

            using (var Form = new Emp.EmpEdit(empId))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
                }
            }
        }

        private void LoginInfo_Click(object sender, EventArgs e)
        {
            var loginInfoForm = new Login();
            loginInfoForm.ShowDialog();
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            var view = empGrid.MainView as GridView;
            var employee = view?.GetFocusedRow() as EmployeeWorkout;

            if (employee == null)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }

            using (var Form = new Emp.EmpDelete(employee))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
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
