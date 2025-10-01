using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using Roster_Dev.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Roster_Dev.UtilClass.Util;
using Color = System.Drawing.Color;
using Worksheet = DevExpress.Spreadsheet.Worksheet;

namespace Roster_Dev
{
    public partial class MultiAdd : Form
    {
        private const string Header_deptCode = "부서코드";
        private const string Header_empCode = "사원코드";
        private const string Header_empName = "사원명";
        private const string Header_loginId = "로그인ID";
        private const string Header_password = "비밀번호";
        private const string Header_position = "직위";
        private const string Header_employment = "고용형태";
        private const string Header_gender = "성별";
        private const string Header_phoneNum = "휴대전화";
        private const string Header_email = "이메일";
        private const string Header_messengerId = "메신저ID";
        private const string Header_memo = "메모";

        private List<string> departmentCodes;
        private long factoryId;

        public MultiAdd()
        {
            InitializeComponent();
            InitializeSpreadControlColumns();
            AddEvent();
        }

        private void AddEvent()
        {
            this.Load += Form_Load;
            this.save.Click += SaveBtn_Click;
            this.cancel.Click += CancelBtn_Click;
        }

        private void InitializeSpreadControlColumns()
        {
            var worksheet = multiAddGrid.ActiveWorksheet;

            worksheet.Clear(worksheet.Cells);

            //Style headerStyle = worksheet.Workbook.Styles[BuiltInStyleId.Normal];
            Style headerStyle = worksheet.Workbook.Styles.Add("CustomHeaderStyle");
            headerStyle.Fill.BackgroundColor = worksheet.Workbook.Styles[BuiltInStyleId.Normal].Fill.BackgroundColor;
            headerStyle.Font.Color = worksheet.Workbook.Styles[BuiltInStyleId.Normal].Font.Color;

            headerStyle.Font.Color = Color.Red;
            headerStyle.Font.Bold = true;
            headerStyle.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            //headerStyle.Fill.BackgroundColor = Color.FromArgb(243, 243, 243);

            string[] headers =
            {
        Header_deptCode, Header_empCode, Header_empName,
        Header_loginId, Header_password, Header_position,
        Header_employment, Header_gender, Header_phoneNum,
        Header_email, Header_messengerId, Header_memo
    };

            int[] widths =
            {
        200, 200, 200, 200, 200, 160, 200, 120, 220, 400, 200, 200
    };

            // 첫 번째 행(Row 0)에 순서대로 헤더 텍스트를 할당합니다.
            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cells[0, i].Value = headers[i];

                worksheet.Columns[i].Width = widths[i];
            }

            CellRange headerRowRange = worksheet.Range.FromLTRB(0, 0, 4, 0);
            headerRowRange.Style = headerStyle;

            worksheet.FreezeRows(1);

        }

        private void ApplyDepartmentValidation()
        {
            if (departmentCodes == null || !departmentCodes.Any())
                return;

            Worksheet sheet = multiAddGrid.ActiveWorksheet;

            // A2:A100 범위 (부서코드 입력 칸)
            CellRange range = sheet.Range.FromLTRB(0, 1, 0, 100);

            CellValue[] listValues = departmentCodes.Select(d => CellValue.FromObject((object)d)).ToArray();

            ValueObject listSource = ValueObject.CreateListSource(listValues);

            DataValidation validation = sheet.DataValidations.Add(
                range,
                DataValidationType.List,
                listSource
            );

            validation.ShowDropDown = true;
            validation.ErrorStyle = DataValidationErrorStyle.Stop;
            validation.ErrorTitle = "잘못된 부서코드";
            validation.ErrorMessage = "유효한 부서코드 중 하나를 선택해야 합니다.";
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            var allDepartments = await ApiRepository.GetDepartmentsAsync(factoryId);
            departmentCodes = allDepartments
                                   .Select(d => d.Code)
                                   .ToList();

            // 부서코드 콤보박스 유효성 검사 적용
            ApplyDepartmentValidation();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Worksheet sheet = multiAddGrid.ActiveWorksheet;

                CellRange used = sheet.GetUsedRange();

                // 데이터가 없는 경우 (헤더 행만 있는 경우 포함)
                if (used == null || used.RowCount <= 1)
                {
                    MessageBox.Show("추가할 데이터가 없습니다.");
                    return;
                }

                var departments = SqlReposit.GetDepartments();
                var employeesToSave = new List<EmployeeWorkout>();

                int success = 0, fail = 0;

                for (int row = 1; row < used.RowCount; row++)
                {
                    try
                    {
                        string deptCode = sheet.Cells[row, 0].DisplayText?.Trim();
                        string empCode = sheet.Cells[row, 1].DisplayText?.Trim();
                        string empName = sheet.Cells[row, 2].DisplayText?.Trim();
                        string loginId = sheet.Cells[row, 3].DisplayText?.Trim();
                        string password = sheet.Cells[row, 4].DisplayText?.Trim();

                        if (string.IsNullOrWhiteSpace(deptCode) ||
                            string.IsNullOrWhiteSpace(empCode) ||
                            string.IsNullOrWhiteSpace(empName) ||
                            string.IsNullOrWhiteSpace(loginId) ||
                            string.IsNullOrWhiteSpace(password))
                        {
                            throw new Exception("필수 항목 누락");
                        }

                        var dept = departments.FirstOrDefault(d => d.DepartmentCode == deptCode);
                        if (dept == null)
                            throw new Exception($"부서코드 '{deptCode}' 없음");

                        var emp = new EmployeeWorkout
                        {
                            DepartmentId = dept.DepartmentId,
                            Code = empCode,
                            Name = empName,
                            LoginId = loginId,
                            LoginPassword = password,
                            Position = sheet.Cells[row, 5].DisplayText?.Trim(),
                            ContractType = sheet.Cells[row, 6].DisplayText?.Trim(),
                            PhoneNumber = sheet.Cells[row, 8].DisplayText?.Trim(),
                            Email = sheet.Cells[row, 9].DisplayText?.Trim(),
                            MessengerId = sheet.Cells[row, 10].DisplayText?.Trim(),
                            Memo = sheet.Cells[row, 11].DisplayText?.Trim()
                        };

                        employeesToSave.Add(emp);
                    }
                    catch (Exception ex)
                    {
                        fail++;
                        Console.WriteLine($"Row {row + 1} 실패: {ex.Message}");
                    }
                }

                foreach (var emp in employeesToSave)
                {
                    ApiRepository.AddEmployeeAsync(emp);
                    success++;
                }

                XtraMessageBox.Show($"추가 완료: {success}명, 실패: {fail}명");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 저장 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
