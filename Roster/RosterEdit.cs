using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Roster.Models;

namespace Roster
{
    public partial class RosterEdit : MetroForm
    {
        public RosterEdit(RosterWorkout model)
        {
            InitializeComponent();
            EmployeeValue.ToFormControls(model, this);
            this.Load += RosterEdit_Load;
            this.PartCode.SelectedIndexChanged += PartCode_SelectedIndexChanged;
            this.Male.CheckedChanged += Male_CheckedChanged_1;
            this.Female.CheckedChanged += Female_CheckedChanged_1;
            this.PhoneNum.TextChanged += PhoneNum_TextChanged;
            this.Save.Click += Save_Click;
            this.Exit.Click += Exit_Click_1;
        }

        private Dictionary<string, string> departmentMap = new Dictionary<string, string>();
        private void RosterEdit_Load(object sender, EventArgs e) // 폼 로드 시 콤보 박스 초기화 및 정렬
        {
            PartCode.Items.Clear();
            departmentMap.Clear();
            var departments = SqlRepository.GetDepartments()
                .OrderBy(d => d.DepartmentCode)
                .ThenBy(d => d.DepartmentCode);
            foreach (var dept in departments)
            {
                PartCode.Items.Add(dept.DepartmentCode);
                departmentMap[dept.DepartmentCode] = dept.DepartmentName;
            }
        }

        private void PartCode_SelectedIndexChanged(object sender, EventArgs e) // 부서 코드
        {
            string code = PartCode.SelectedItem?.ToString();
            if (code != null && departmentMap.ContainsKey(code))
            {
                DepartName.Text = departmentMap[code];
            }
            else
            {
                DepartName.Text = string.Empty;
            }
        }

        private void Male_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Male.Checked) Female.Checked = false;
        }

        private void Female_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Female.Checked) Male.Checked = false;
        }

        private void PhoneNum_TextChanged(object sender, EventArgs e) // 휴대전화 번호 포맷팅
        {
            // 현재 커서 위치 저장
            int oldSelectionStart = PhoneNum.SelectionStart;
            int oldLength = PhoneNum.Text.Length;

            // 숫자만 추출 (최대 11자리로 제한)
            string digits = new string(PhoneNum.Text.Where(char.IsDigit).ToArray());
            if (digits.Length > 11)
                digits = digits.Substring(0, 11);

            // 010으로 시작하고 11자리 이하일 때만 포맷 적용
            string formatted = digits;
            if (digits.StartsWith("010"))
            {
                if (digits.Length > 7)
                    formatted = $"{digits.Substring(0, 3)}-{digits.Substring(3, 4)}-{digits.Substring(7)}";
                else if (digits.Length > 3)
                    formatted = $"{digits.Substring(0, 3)}-{digits.Substring(3)}";
            }
            else
            {
                formatted = digits;
            }

            // 값이 다를 때만 갱신 (무한루프 방지)
            if (PhoneNum.Text != formatted)
            {
                // 하이픈 개수 차이 계산
                int oldHyphenCount = PhoneNum.Text.Take(oldSelectionStart).Count(c => c == '-');
                int newHyphenCount = formatted.Take(oldSelectionStart).Count(c => c == '-');

                PhoneNum.Text = formatted;

                // 커서 위치 보정
                int newSelectionStart = oldSelectionStart + (newHyphenCount - oldHyphenCount);
                PhoneNum.SelectionStart = Math.Max(0, Math.Min(newSelectionStart, PhoneNum.Text.Length));
            }
        }

        private bool IsValidEmail(string email) // 이메일 형식 검증
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        public RosterWorkout SavedModel { get; private set; }

        private void Save_Click(object sender, EventArgs e) // 저장 버튼
        {
            if (string.IsNullOrWhiteSpace(PartCode.Text))
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                PartCode.Focus();
                PartCode.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(EmployeeCo.Text))
            {
                MessageBox.Show("사원코드를 입력해주세요.");
                EmployeeCo.Focus();
                EmployeeCo.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(EmployeeName.Text))
            {
                MessageBox.Show("사원명을 입력해주세요.");
                EmployeeName.Focus();
                EmployeeName.SelectAll();
                return;
            }

            if (!IsValidEmail(Email.Text))
            {
                MessageBox.Show("올바른 이메일 형식이 아닙니다.");
                Email.Focus();
                Email.SelectAll();
                return;
            }

            try
            {
                SavedModel = EmployeeValue.FromFormEditControls(this);

                EmployeeValue.UpdateEmployee(SavedModel);

                MessageBox.Show("수정 되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close(); // 폼 닫기
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
