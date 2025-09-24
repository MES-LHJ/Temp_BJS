using DevExpress.Spreadsheet;
using DevExpress.XtraEditors;
using DevExpress.XtraSpreadsheet;
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
using DevExpress.Spreadsheet.Core;

namespace Roster_Dev
{
    public partial class MultiAdd : Form
    {
        private SpreadsheetControl spreadsheetControl;
        private SimpleButton saveBtn;
        private SimpleButton cancelBtn;
        public MultiAdd()
        {
            InitializeComponent();
            AddEvent();
            InitializeSpreadsheetControl();
        }

        private void InitializeSpreadsheetControl()
        {
            // Spreadsheet 컨트롤 동적 생성 및 Dock 설정
            spreadsheetControl = new SpreadsheetControl();
            this.Controls.Add(spreadsheetControl);
            spreadsheetControl.Dock = DockStyle.Fill;
            spreadsheetControl.SendToBack(); // 다른 컨트롤 뒤로 보내기

            // UI 컨트롤 위치 조정 (예시)
            saveBtn = new SimpleButton();
            saveBtn.Text = "저장";
            saveBtn.Click += SaveBtn_Click;

            cancelBtn = new SimpleButton();
            cancelBtn.Text = "취소";
            cancelBtn.Click += CancelBtn_Click;

            // 레이아웃 컨트롤에 버튼 추가
            // 이 부분은 디자이너에 따라 달라질 수 있습니다.
            // 예시로 직접 컨트롤을 Form에 추가하는 코드를 작성했습니다.
            this.Controls.Add(saveBtn);
            this.Controls.Add(cancelBtn);
            saveBtn.BringToFront();
            cancelBtn.BringToFront();
            // 버튼 위치 설정은 디자이너에서 직접 하거나, LayoutControl을 사용하면 더 편리합니다.
        }

        private void AddEvent()
        {
            this.Load += Form_Load;
            this.saveBtn.Click += SaveBtn_Click;
            this.cancelBtn.Click += CancelBtn_Click;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // 폼 로드 시 초기화 로직 (필요 시 추가)
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // SpreadsheetControl의 첫 번째 워크시트 가져오기
                Worksheet worksheet = spreadsheetControl.ActiveWorksheet;
                if (worksheet == null || worksheet.GetUsedRange().RowCount <= 1)
                {
                    MessageBox.Show("스프레드시트에 데이터가 없습니다.");
                    return;
                }

                // A2 셀부터 데이터가 시작한다고 가정 (A1은 헤더)
                DevExpress.Spreadsheet.Range usedRange = worksheet.GetUsedRange();
                int rowCount = usedRange.RowCount;

                // 결과를 저장할 리스트
                List<EmpWorkout> employeesToSave = new List<EmpWorkout>();
                int successCount = 0;
                int failCount = 0;

                for (int i = 1; i < rowCount; i++) // 0번 인덱스는 헤더이므로 건너뜁니다.
                {
                    EmpWorkout emp = new EmpWorkout();
                    try
                    {
                        // 각 열의 데이터를 EmpWorkout 객체로 매핑 (예시)
                        // 실제 열 순서에 맞게 필드명을 수정해야 합니다.
                        emp.EmployeeCode = worksheet.Cells[i, 0].DisplayText; // A열
                        emp.EmployeeName = worksheet.Cells[i, 1].DisplayText; // B열
                        emp.LoginId = worksheet.Cells[i, 2].DisplayText;      // C열
                        emp.Password = worksheet.Cells[i, 3].DisplayText;     // D열

                        // 부서 ID와 상위 부서 ID는 코드로 조회하여 설정
                        string deptCode = worksheet.Cells[i, 4].DisplayText;  // E열
                        var dept = SqlReposit.GetDepartments().FirstOrDefault(d => d.DepartmentCode == deptCode);

                        if (dept != null)
                        {
                            emp.DepartmentId = dept.DepartmentId;
                            emp.UpperDeppartmentId = dept.UpperDepartmentId;
                        }
                        else
                        {
                            // 유효성 검사 실패
                            throw new Exception($"부서 코드 '{deptCode}'를 찾을 수 없습니다.");
                        }

                        // 필요에 따라 다른 필드들도 추가로 매핑
                        // emp.Email = worksheet.Cells[i, 5].DisplayText;
                        // emp.Gender = ...

                        // 필수 필드 유효성 검사
                        if (string.IsNullOrWhiteSpace(emp.EmployeeCode) ||
                            string.IsNullOrWhiteSpace(emp.EmployeeName) ||
                            string.IsNullOrWhiteSpace(emp.LoginId) ||
                            string.IsNullOrWhiteSpace(emp.Password))
                        {
                            throw new Exception("필수 필드(사원코드, 이름, 로그인ID, 비밀번호)가 비어 있습니다.");
                        }

                        employeesToSave.Add(emp);
                    }
                    catch (Exception ex)
                    {
                        failCount++;
                        // 실패한 행에 대한 피드백 (예: 메시지 박스 또는 로그)
                        Console.WriteLine($"행 {i + 1} 처리 중 오류 발생: {ex.Message}");
                    }
                }

                // 유효성 검사를 통과한 직원들만 DB에 저장
                foreach (var emp in employeesToSave)
                {
                    SqlReposit.InsertEmp(emp);
                    successCount++;
                }

                MessageBox.Show($"총 {successCount}명의 사원이 성공적으로 추가되었습니다. (실패: {failCount}명)");
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
