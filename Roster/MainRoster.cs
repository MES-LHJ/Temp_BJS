using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static Roster.RosterAdd;

namespace Roster
{
    public partial class MainRoster : MetroForm
    {
        public MainRoster()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.Department.Click += Department_Click;
            this.EmployeeAdd.Click += EmployeeAdd_Click;
            this.EmployeeEdit.Click += EmployeeEdit_Click;
            this.Delete.Click += Delete_Click;
            this.Check.Click += Check_Click;
            this.LoginInfo.Click += LoginInfo_Click;
            this.Exit.Click += Exit_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;

            employeeDataGrid.AutoGenerateColumns = true;
            
            Check.Focus();
        }

        private void EmployeeDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Password 컬럼의 인덱스를 확인
            if (employeeDataGrid.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
            {
                string password = e.Value.ToString();
                if (!string.IsNullOrEmpty(password))
                {
                    e.Value = new string('*', password.Length);
                    e.FormattingApplied = true;
                }
            }
        }

        private void RefreshGrid() // 그리드 초기화
        {
            //employeeDataGrid.DataSource = new List<RosterWorkout>()
            //{
            //    new RosterWorkout()
            //    {
            //        EmployeeCode = "", EmployeeName = "", 
            //    }
            //}; // 기존 데이터 소스 초기화
            //employeeDataGrid.Refresh();

            employeeDataGrid.DataSource = null; // 기존 데이터 소스 초기화
            List<RosterWorkout> dataTable = SqlRepository.GetEmployeeWithDepartment();

            employeeDataGrid.DataSource = dataTable; // 데이터 소스 설정
            employeeDataGrid.ClearSelection(); // 초기 선택 해제
            employeeDataGrid.CurrentCell = null; // 포커스 제거
        }

        //private static int TryToInt(object value) // 정수 변환, 정렬
        //{
        //    if (value == null) return int.MaxValue;
        //    var s = value.ToString();
        //    return int.TryParse(s, out var n) ? n : int.MaxValue;
        //}

        private void EmployeeAdd_Click(object sender, EventArgs e) // 추가
        {
            using (var addForm = new RosterAdd())
            {
                if(addForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void EmployeeEdit_Click(object sender, EventArgs e) // 수정
        {
            var employee = employeeDataGrid.CurrentRow.DataBoundItem as RosterWorkout;
            if(employee == null)
            {
                MessageBox.Show("수정할 항목을 선택해주세요.");
                return;
            }

            if (employeeDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택해주세요.");
                return;
            }

            //var employee = EmployeeDataGrid.CurrentRow.DataBoundItem as RosterWorkout;

            var row = employeeDataGrid.Rows[employeeDataGrid.SelectedCells[0].RowIndex];

            var model = new RosterWorkout
            {
                EmployeeCode = row.Cells["EmployeeCode"].Value?.ToString() ?? "",
                EmployeeName = row.Cells["EmployeeName"].Value?.ToString() ?? "",
                DepartmentCode = row.Cells["PartCode"].Value?.ToString() ?? "",
                Position = row.Cells["Position"].Value?.ToString() ?? "",
                Employment = row.Cells["Form_of_employment"].Value?.ToString() ?? "",
                Gender = (Gender)Enum.Parse(typeof(Gender), row.Cells["Gender"].Value?.ToString() ?? "Male"),
                PhoneNum = row.Cells["PhoneNum"].Value?.ToString() ?? "",
                Email = row.Cells["Email"].Value?.ToString() ?? "",
                MessengerID = row.Cells["MessengerID"].Value?.ToString() ?? "",
                Memo = row.Cells["Memo"].Value?.ToString() ?? ""
            };

            using (var editForm = new RosterEdit(model))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e) //삭제
        {
            if (employeeDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }
            int rowIndex = employeeDataGrid.SelectedCells[0].RowIndex;
            var row = employeeDataGrid.Rows[rowIndex];

            string code = row.Cells["EmployeeCode"].Value?.ToString() ?? "";
            string name = row.Cells["EmployeeName"].Value?.ToString() ?? "";

            using (var deleteForm = new RosterDelete(code, name))
            {
                if (deleteForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid(); 
                }
            }
        }

        private void Department_Click(object sender, EventArgs e) // 부서
        {
            using (var form = new Department())
            {
                form.ShowDialog();
            }
        }

        private void Check_Click(object sender, EventArgs e) // 조회
        {
            RefreshGrid();
        }

        private void LoginInfo_Click(object sender, EventArgs e) // 로그인 정보
        {
            var loginInfoForm = new Login();
            loginInfoForm.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
