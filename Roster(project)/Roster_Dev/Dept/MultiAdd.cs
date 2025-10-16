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
        private const string Header_phoneNum = "휴대전화";
        private const string Header_email = "이메일";
        private const string Header_messengerId = "메신저ID";
        private const string Header_memo = "메모";

        private List<string> departmentCodes;
        private long factoryId;

        public MultiAdd(long factoryId)
        {
            InitializeComponent();
            this.factoryId = factoryId;
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

            Style headerStyle = worksheet.Workbook.Styles.Add("CustomHeaderStyle");
            headerStyle.Fill.BackgroundColor = worksheet.Workbook.Styles[BuiltInStyleId.Normal].Fill.BackgroundColor;
            //headerStyle.Font.Color = worksheet.Workbook.Styles[BuiltInStyleId.Normal].Font.Color;

            //headerStyle.Font.Color = Color.Red;
            //headerStyle.Font.Bold = true;
            headerStyle.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

            // 0~4번째 컬럼만 빨간색 스타일 적용
            CellRange redRange = worksheet.Range.FromLTRB(0, 0, 4, 0);
            redRange.Style = headerStyle;

            string[] headers =
            {
            Header_deptCode, Header_empCode, Header_empName,
            Header_loginId, Header_password, Header_position,
            Header_employment, Header_phoneNum,
            Header_email, Header_messengerId, Header_memo
        };

            int[] widths =
            {
            220, 220, 220, 220, 220, 160, 200, 220, 400, 200, 200
        };

            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cells[0, i].Value = headers[i];
                worksheet.Columns[i].Width = widths[i];
            }

            CellRange headerRowRange = worksheet.Range.FromLTRB(0, 0, headers.Length - 1, 0);
            headerRowRange.Style = headerStyle;

            worksheet.FreezeRows(1);

        }

        private void ApplyDepartmentValidation()
        {
            if (departmentCodes == null || !departmentCodes.Any())
                return;

            Worksheet sheet = multiAddGrid.ActiveWorksheet;

            // A1:A100 범위 (필요 시 늘리기)
            CellRange range = sheet.Range.FromLTRB(0, 0, 0, 100);

            var cleanCodes = departmentCodes
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .ToList();

            CellValue[] listValues = cleanCodes.Select(c => CellValue.FromObject((object)c)).ToArray();

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
            departmentCodes = (allDepartments ?? new List<DepartmentWorkout>())
                                    .Select(d => d.Code)
                                    .Where(c => !string.IsNullOrWhiteSpace(c))
                                    .Distinct()
                                    .ToList();

            ApplyDepartmentValidation();
        }
        private async void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Worksheet sheet = multiAddGrid.ActiveWorksheet;
                CellRange used = sheet.GetUsedRange();

                if (used == null || used.RowCount <= 1)
                {
                    MessageBox.Show("추가할 데이터가 없습니다.");
                    return;
                }

                var deptList = await ApiRepository.GetDepartmentsAsync(factoryId);
                var deptByCode = (deptList ?? new List<DepartmentWorkout>())
                    .Where(d => !string.IsNullOrWhiteSpace(d.Code))
                    .GroupBy(d => d.Code.Trim())
                    .ToDictionary(g => g.Key, g => g.First());

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

                        // 빈 줄 스킵 처리 (필수 5개 모두 비어있으면 continue)
                        bool allEmpty = string.IsNullOrWhiteSpace(deptCode)
                                        && string.IsNullOrWhiteSpace(empCode)
                                        && string.IsNullOrWhiteSpace(empName)
                                        && string.IsNullOrWhiteSpace(loginId)
                                        && string.IsNullOrWhiteSpace(password);
                        if (allEmpty) continue;

                        // 필수값 검사
                        if (string.IsNullOrWhiteSpace(deptCode) ||
                            string.IsNullOrWhiteSpace(empCode)  ||
                            string.IsNullOrWhiteSpace(empName)  ||
                            string.IsNullOrWhiteSpace(loginId)  ||
                            string.IsNullOrWhiteSpace(password))
                        {
                            string[] headerNames = { Header_deptCode, Header_empCode, Header_empName, Header_loginId, Header_password };
                            MessageBox.Show(
                                $"'{string.Join(", ", headerNames)}' 항목은 필수 입력입니다.",
                                "입력 오류",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                            return;
                        }

                        if (!deptByCode.TryGetValue(deptCode, out var dept))
                            throw new Exception($"부서코드 '{deptCode}' 없음");

                        var emp = new EmployeeWorkout
                        {
                            DepartmentId = dept.Id,
                            Code = empCode,
                            Name = empName,
                            LoginId = loginId,
                            LoginPassword = password,
                            Position = sheet.Cells[row, 5].DisplayText?.Trim(),
                            ContractType = sheet.Cells[row, 6].DisplayText?.Trim(),
                            PhoneNumber = sheet.Cells[row, 8].DisplayText?.Trim(),
                            Email = sheet.Cells[row, 9].DisplayText?.Trim(),
                            MessengerId = sheet.Cells[row, 10].DisplayText?.Trim(),
                            Memo = sheet.Cells[row, 11].DisplayText?.Trim(),

                            //FactoryId = dept.FactoryId,
                            //FactoryCode = dept.FactoryCode,
                            //FactoryName = dept.FactoryName,

                        };

                        employeesToSave.Add(emp);
                    }
                    catch (Exception exLine)
                    {
                        fail++;
                        Console.WriteLine($"Row {row + 1} 실패: {exLine.Message}");
                    }
                }

                // 저장 실행
                foreach (var emp in employeesToSave)
                {
                    await ApiRepository.AddEmployeeAsync(emp);
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
