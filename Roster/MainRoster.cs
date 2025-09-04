using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static Roster.RosterAdd;
using static Roster.RosterWorkout;

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

            employeeDataGrid.AutoGenerateColumns = false;
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
            if (employeeDataGrid.Columns[e.ColumnIndex].DataPropertyName == "PhotoPath" && e.Value != null)
            {
                e.Value = Path.GetFileName(e.Value.ToString()); // 파일 이름만 표시
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
            
            //List<RosterWorkout> dataTable = SqlRepository.GetEmployment();
            employeeDataGrid.AutoGenerateColumns = false;  // 자동 컬럼 생성
            var employees = SqlRepository.GetEmployment()
                                   .OrderBy(d => d.DepartmentCode)
                                   .ToList();
            employeeDataGrid.DataSource = employees;
        }

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
            if (employeeDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택해주세요.");
                return;
            }

            var employee = employeeDataGrid.CurrentRow.DataBoundItem as RosterWorkout;

            using (var editForm = new RosterEdit(employee))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e) //삭제
        {
            var employee = employeeDataGrid.CurrentRow?.DataBoundItem as RosterWorkout;

            if (employee == null)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }

            using (var deleteForm = new RosterDelete(employee))
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
