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
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;

            EmployeeDataGrid.Columns.Add("DepartmentCode", "부서코드");
            EmployeeDataGrid.Columns.Add("DepartmentName", "부서명");
            EmployeeDataGrid.Columns.Add("EmployeeCode", "사원코드");
            EmployeeDataGrid.Columns.Add("EmployeeName", "사원명");
            EmployeeDataGrid.Columns.Add("ID", "로그인ID");
            EmployeeDataGrid.Columns.Add("Password", "비밀번호");
            EmployeeDataGrid.Columns.Add("Position", "직위");
            EmployeeDataGrid.Columns.Add("Form_of_employment", "고용형태");
            EmployeeDataGrid.Columns.Add("Gender", "성별");
            EmployeeDataGrid.Columns.Add("PhoneNum", "휴대전화");
            EmployeeDataGrid.Columns.Add("Email", "이메일");
            EmployeeDataGrid.Columns.Add("MessengerID", "메신저ID");
            EmployeeDataGrid.Columns.Add("Memo", "메모");
            // cell 선택 초기화
            EmployeeDataGrid.ClearSelection();
            EmployeeDataGrid.CurrentCell = null; // 포커스도 해제

            refreshGrid();

            label3.Focus();
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

        private void refreshGrid() // 그리드 최신화
        {
            EmployeeDataGrid.ClearSelection();
            EmployeeDataGrid.CurrentCell = null;
        }

        private void EmployeeAdd_Click(object sender, EventArgs e) // 추가
        {
            using (var form = new RosterAdd())
            {
                form.OnSave += (departmentCode, departmentName, employeeCode, employeeName, id, password,
                                position, employment, gender, phoneNum, email, messengerId, memo) =>
                {
                    // 부서 Upsert 
                    SqlRepository.UpsertDepartment(departmentCode, departmentName, null);

                    // 사원 Insert 
                    SqlRepository.InsertEmployee(
                        departmentCode, departmentName,
                        employeeCode, employeeName,
                        id, password,
                        position, employment, gender,
                        phoneNum, email, messengerId, memo
                    );

                    // 그리드 반영 
                    EmployeeDataGrid.Rows.Add(departmentCode, departmentName, employeeCode, employeeName, id,
                                            password, position, employment, gender, phoneNum, email, messengerId, memo);
                };
                form.ShowDialog();
            }
        }

        private void EmployeeEdit_Click(object sender, EventArgs e) // 수정
        {
            if (EmployeeDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택해주세요.");
                return;
            }
            int rowIndex = EmployeeDataGrid.SelectedCells[0].RowIndex;
            var row = EmployeeDataGrid.Rows[rowIndex];

            using (var form = new RosterEdit())
            {
                form.PartCode.Text = row.Cells["DepartmentCode"].Value?.ToString() ?? "";
                form.DepartName.Text = row.Cells["DepartmentName"].Value?.ToString() ?? "";
                form.MosCode.Text = row.Cells["EmployeeCode"].Value?.ToString() ?? "";
                form.MosName.Text = row.Cells["EmployeeName"].Value?.ToString() ?? "";
                form.Position.Text = row.Cells["Position"].Value?.ToString() ?? "";
                form.Form_of_employment.Text = row.Cells["Form_of_employment"].Value?.ToString() ?? "";
                string currentGender = row.Cells["Gender"].Value?.ToString() ?? "";
                form.Male.Checked = currentGender == "남자";
                form.Female.Checked = currentGender == "여자";
                form.PhoneNum.Text = row.Cells["PhoneNum"].Value?.ToString() ?? "";
                form.Email.Text = row.Cells["Email"].Value?.ToString() ?? "";
                form.MessengerId.Text = row.Cells["MessengerID"].Value?.ToString() ?? "";
                form.Memo.Text = row.Cells["Memo"].Value?.ToString() ?? "";

                form.OnSave += (departmentCode, departmentName, employeeCode, employeeName, position,
                                employment, newGender, phoneNum, email, messengerId, memo) =>
                {
                    // 부서 Upsert 
                    SqlRepository.UpsertDepartment(departmentCode, departmentName, null);

                    // 사원 Update 
                    SqlRepository.UpdateEmployee(
                        employeeCode, departmentName,
                        departmentCode, employeeName,
                        position, employment, newGender,
                        phoneNum, email, messengerId, memo
                    );

                    // 그리드도 갱신
                    row.Cells["DepartmentCode"].Value = departmentCode;
                    row.Cells["DepartmentName"].Value = departmentName;
                    row.Cells["EmployeeCode"].Value     = employeeCode;
                    row.Cells["EmployeeName"].Value     = employeeName;
                    row.Cells["Position"].Value       = position;
                    row.Cells["Form_of_employment"].Value = employment;
                    row.Cells["Gender"].Value         = newGender;
                    row.Cells["PhoneNum"].Value       = phoneNum;
                    row.Cells["Email"].Value          = email;
                    row.Cells["MessengerID"].Value    = messengerId;
                    row.Cells["Memo"].Value           = memo;
                };

                form.ShowDialog();
            }
        }

        private void label7_Click(object sender, EventArgs e) //삭제
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

        private void label3_Click(object sender, EventArgs e) // 조회
        {
            var dt = SqlRepository.GetEmployeeWithDepartment(); // DataTable

            var rows = dt.AsEnumerable()
                // 부서 숫자  사원 숫자  문자열 순으로 정렬
                .OrderBy(r => TryToInt(r["DepartmentCode"]))
                .ThenBy(r => TryToInt(r["EmployeeCode"]))
                .ThenBy(r => r["DepartmentCode"].ToString())
                .ThenBy(r => r["EmployeeCode"].ToString());

            EmployeeDataGrid.Rows.Clear();

            foreach (var row in rows)
            {
                EmployeeDataGrid.Rows.Add(
                    row["DepartmentCode"],
                    row["DepartmentName"],
                    row["EmployeeCode"],
                    row["EmployeeName"],
                    row["ID"],
                    row["Password"],             // CellFormatting 적용
                    row["Position"],
                    row["Form_of_employment"],
                    row["Gender"],
                    row["PhoneNum"],
                    row["Email"],
                    row["MessengerID"],
                    row["Memo"]
                );
            }

            refreshGrid();
        }

        private void LoginInfo_Click(object sender, EventArgs e) // 로그인 정보
        {
            var exePath = System.IO.Path.Combine(Application.StartupPath, "Roster_Login.exe");
            System.Diagnostics.Process.Start(exePath);
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
