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
using MetroFramework.Forms;

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

            var dataTable = SqlRepository.GetEmployeeWithDepartment();

            var employees = dataTable.AsEnumerable().Select(row => new RosterWorkout
            {
                    DepartmentCode = int.TryParse(row["DepartmentCode"]?.ToString(), out var deptCode) ? deptCode : 0,
                    DepartmentName = row["DepartmentName"].ToString(),
                    EmployeeCode = int.TryParse(row["EmployeeCode"]?.ToString(), out var empCode) ? empCode : 0,
                    EmployeeName = row["EmployeeName"].ToString(),
                    ID = row["ID"].ToString(),
                    Password = row["Password"].ToString(),
                    Position = row["Position"].ToString(),
                    Employment = row["Form_of_employment"].ToString(),
                    Gender = Enum.TryParse<RosterAdd.Gender>(row["Gender"].ToString(), out var g) ? g : RosterAdd.Gender.Male,
                    PhoneNum = row["PhoneNum"].ToString(),
                    Email = row["Email"].ToString(),
                    MessengerID = row["MessengerID"].ToString(),
                    Memo = row["Memo"].ToString()
            }).ToList();

            EmployeeDataGrid.DataSource = employees;

            EmployeeDataGrid.ClearSelection();
            EmployeeDataGrid.CurrentCell = null;

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
            var addForm = new RosterAdd();
            addForm.OnSave += (model) =>
            {
                EmployeeDataGrid.Rows.Add(
                    model.DepartmentCode,
                    model.DepartmentName,
                    model.EmployeeCode,
                    model.EmployeeName,
                    model.ID,
                    model.Password,
                    model.Position,
                    model.Employment,
                    model.PhoneNum,
                    model.Email,
                    model.MessengerID,
                    model.Memo
                    );
            };
            addForm.ShowDialog();
        }

        private void EmployeeEdit_Click(object sender, EventArgs e) // 수정
        {
            if (EmployeeDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택해주세요.");
                return;
            }

            var editForm = new RosterEdit();
            editForm.OnSave += (SqlRepository.UpdateEmployee()) =>
            {
                EmployeeDataGrid.Rows(
                    model.DepartmentCode,
                    model.DepartmentName,
                    model.EmployeeCode,
                    model.EmployeeName,
                    model.Position,
                    model.Employment,
                    model.PhoneNum,
                    model.Email,
                    model.MessengerID,
                    model.Memo
                    );
                //int rowIndex = EmployeeDataGrid.SelectedCells[0].RowIndex;
                //var row = EmployeeDataGrid.Rows[rowIndex];

                //using (var form = new RosterEdit())
                //{
                //    form.PartCode.Text = row.Cells["DepartmentCode"].Value?.ToString() ?? "";
                //    form.DepartName.Text = row.Cells["DepartmentName"].Value?.ToString() ?? "";
                //    form.MosCode.Text = row.Cells["EmployeeCode"].Value?.ToString() ?? "";
                //    form.MosName.Text = row.Cells["EmployeeName"].Value?.ToString() ?? "";
                //    form.Position.Text = row.Cells["Position"].Value?.ToString() ?? "";
                //    form.Form_of_employment.Text = row.Cells["Form_of_employment"].Value?.ToString() ?? "";
                //    string currentGender = row.Cells["Gender"].Value?.ToString() ?? "";
                //    form.Male.Checked = currentGender == "남자";
                //    form.Female.Checked = currentGender == "여자";
                //    form.PhoneNum.Text = row.Cells["PhoneNum"].Value?.ToString() ?? "";
                //    form.Email.Text = row.Cells["Email"].Value?.ToString() ?? "";
                //    form.MessengerId.Text = row.Cells["MessengerID"].Value?.ToString() ?? "";
                //    form.Memo.Text = row.Cells["Memo"].Value?.ToString() ?? "";

                //    form.OnSave += (departmentCode, departmentName, employeeCode, employeeName, position,
                //                    employment, newGender, phoneNum, email, messengerId, memo) =>
                //    {
                //        // 부서 Upsert 
                //        SqlRepository.InsertDepartment(departmentCode, departmentName, null);

                //        // 사원 Update 
                //        SqlRepository.UpdateEmployee(
                //            employeeCode, departmentName,
                //            departmentCode, employeeName,
                //            position, employment, newGender,
                //            phoneNum, email, messengerId, memo
                //        );

                //        // 그리드도 갱신
                //        row.Cells["DepartmentCode"].Value = departmentCode;
                //        row.Cells["DepartmentName"].Value = departmentName;
                //        row.Cells["EmployeeCode"].Value     = employeeCode;
                //        row.Cells["EmployeeName"].Value     = employeeName;
                //        row.Cells["Position"].Value       = position;
                //        row.Cells["Form_of_employment"].Value = employment;
                //        row.Cells["Gender"].Value         = newGender;
                //        row.Cells["PhoneNum"].Value       = phoneNum;
                //        row.Cells["Email"].Value          = email;
                //        row.Cells["MessengerID"].Value    = messengerId;
                //        row.Cells["Memo"].Value           = memo;
                //    };

                //    form.ShowDialog();
                //}
            };
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

            var deleteForm = new RosterDelete(this, code, name);
            deleteForm.ShowDialog();
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

            var employees = dataTable.AsEnumerable().Select(row => new RosterWorkout
            {
                DepartmentCode = int.TryParse(row["DepartmentCode"]?.ToString(), out var deptCode) ? deptCode : 0,
                DepartmentName = row["DepartmentName"].ToString(),
                EmployeeCode = int.TryParse(row["EmployeeCode"]?.ToString(), out var empCode) ? empCode : 0,
                EmployeeName = row["EmployeeName"].ToString(),
                ID = row["ID"].ToString(),
                Password = row["Password"].ToString(),
                Position = row["Position"].ToString(),
                Employment = row["Form_of_employment"].ToString(),
                Gender = Enum.TryParse<RosterAdd.Gender>(row["Gender"].ToString(), out var g) ? g : RosterAdd.Gender.Male,
                PhoneNum = row["PhoneNum"].ToString(),
                Email = row["Email"].ToString(),
                MessengerID = row["MessengerID"].ToString(),
                Memo = row["Memo"].ToString()
            }).ToList();

            EmployeeDataGrid.DataSource = employees;

            EmployeeDataGrid.ClearSelection();
            EmployeeDataGrid.CurrentCell = null;
        }

        private void LoginInfo_Click(object sender, EventArgs e) // 로그인 정보
        {
            var loginInfoForm = new Login();
            loginInfoForm.ShowDialog();
            this.Close();
        }

        private void Exit_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
