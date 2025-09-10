using ClosedXML.Excel;
using ClosedXML.Excel;
using MetroFramework.Drawing;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

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
            this.convert.Click += convert_Click;
            this.Exit.Click += Exit_Click;
            this.EmployeeDataGrid.CellMouseEnter += EmployeeDataGridEnter;
            this.EmployeeDataGrid.CellMouseLeave += new DataGridViewCellMouseEventHandler(this.EmployeeDataGrid_CellMouseLeave);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;

            employeeDataGrid.AutoGenerateColumns = false;
        }

        private void EmployeeDataGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Password 컬럼의 인덱스를 확인
            if (employeeDataGrid.Columns[e.ColumnIndex].Name == "password" && e.Value != null)
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
            employeeDataGrid.AutoGenerateColumns = false;  // 자동 컬럼 생성
            var employees = SqlRepository.GetEmployment()
                                   .OrderBy(d => d.DepartmentCode)
                                   .ToList();
            employeeDataGrid.DataSource = employees;
        }

        private void EmployeeDataGridEnter(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
        employeeDataGrid.Columns[e.ColumnIndex].Name == "PhotoPath")
            {
                string photoPath = employeeDataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!string.IsNullOrEmpty(photoPath) && File.Exists(photoPath))
                {
                    // 기존 PictureBox 제거
                    RemovePreview();

                    // 새 PictureBox 생성
                    pictureBoxPreview = new PictureBox
                    {
                        Image = Image.FromFile(photoPath),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(150, 150),
                        BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                        Location = this.PointToClient(Cursor.Position + new Size(15, 15)) // 마우스 근처
                    };

                    this.Controls.Add(pictureBoxPreview);
                    pictureBoxPreview.BringToFront();
                }
            }
        }

        private void EmployeeDataGrid_CellMouseLeave(object sender, DataGridViewCellMouseEventArgs e)
        {
            RemovePreview();
        }

        private void RemovePreview()
        {
            if (pictureBoxPreview != null)
            {
                if (pictureBoxPreview.Parent != null)
                {
                    pictureBoxPreview.Parent.Controls.Remove(pictureBoxPreview);
                }
                pictureBoxPreview.Dispose();
                pictureBoxPreview = null;
            }
        }

        private void EmployeeAdd_Click(object sender, EventArgs e) // 추가
        {
            using (var addForm = new RosterAdd())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
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

        private void convert_Click(object sender, EventArgs e) //자료변환
        {
            if (employeeDataGrid.Rows.Count == 0)
            {
                MessageBox.Show("내보낼 데이터가 없습니다.");
                return;
            }

            try
            {
                // 임시 파일 경로 생성
                string filePath = Path.Combine(Path.GetTempPath(), $"Export_{DateTime.Now:yyyyMMddHHmmss}.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Employees");

                    // 헤더 추가
                    for (int i = 0; i < employeeDataGrid.Columns.Count; i++)
                    {
                        worksheet.Cell(1, i + 1).Value = employeeDataGrid.Columns[i].HeaderText;
                    }

                    // 데이터 추가
                    for (int i = 0; i < employeeDataGrid.Rows.Count; i++)
                    {
                        for (int j = 0; j < employeeDataGrid.Columns.Count; j++)
                        {
                            worksheet.Cell(i + 2, j + 1).Value = employeeDataGrid.Rows[i].Cells[j].Value?.ToString();
                        }
                    }
                    var range = worksheet.RangeUsed();

                    range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Column(1).AdjustToContents();
                    worksheet.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);
                }

                // Excel 자동 실행
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel 변환 중 오류 발생: " + ex.Message);
            }
        }

        private void Exit_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
