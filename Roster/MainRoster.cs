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
using MetroFramework.Forms;
using Roster.Models;

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

            EmployeeDataGrid.AutoGenerateColumns = true;
            var employees = SqlRepository.GetEmployeeWithDepartment()
                                 .AsEnumerable()
                                 .Select(EmployeeValue.FromDataRow)
                                 .ToList();

            Check.Focus();
        }

        private void EmployeeDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Password 컬럼의 인덱스를 확인
            if (EmployeeDataGrid.Columns[e.ColumnIndex].Name == "Password" && e.Value != null)
            {
                string password = e.Value.ToString();
                if (!string.IsNullOrEmpty(password))
                {
                    e.Value = new string('*', password.Length);
                    e.FormattingApplied = true;
                }
            }
        }

        private static int TryToInt(object value) // 정수 변환, 정렬
        {
            if (value == null) return int.MaxValue;
            var s = value.ToString();
            return int.TryParse(s, out var n) ? n : int.MaxValue;
        }

        private void EmployeeAdd_Click(object sender, EventArgs e) // 추가
        {
            using (var addForm = new RosterAdd())
            {
                addForm.ShowDialog();
            }
        }

        private void EmployeeEdit_Click(object sender, EventArgs e) // 수정
        {
            if (EmployeeDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택해주세요.");
                return;
            }

            var row = EmployeeDataGrid.Rows[EmployeeDataGrid.SelectedCells[0].RowIndex];
            var model = EmployeeValue.FromGridRow(row);

            using (var editForm = new RosterEdit(model))
            {
                editForm.ShowDialog();
            }
        }

        private void Delete_Click(object sender, EventArgs e) //삭제
        {
            if (EmployeeDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }
            int rowIndex = EmployeeDataGrid.SelectedCells[0].RowIndex;
            var row = EmployeeDataGrid.Rows[rowIndex];

            string code = row.Cells["EmployeeCode"].Value?.ToString() ?? "";
            string name = row.Cells["EmployeeName"].Value?.ToString() ?? "";

            using (var deleteForm = new RosterDelete(this, code, name))
            {
                deleteForm.ShowDialog();
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
            EmployeeDataGrid.DataSource = null;

            var dataTable = SqlRepository.GetEmployeeWithDepartment();

            var employees = dataTable
                .AsEnumerable()
                .Select(EmployeeValue.FromDataRow)
                .OrderBy(emp => TryToInt(emp.DepartmentCode))
                .ThenBy(emp => emp.EmployeeCode)
                .ToList();

            EmployeeDataGrid.DataSource = employees;

            EmployeeDataGrid.ClearSelection();
            EmployeeDataGrid.CurrentCell = null;
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
