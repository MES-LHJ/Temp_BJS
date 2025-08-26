using MaterialSkin;
using MetroFramework.Forms;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Roster.Models.Gender;
using static Roster.RosterAdd;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Roster
{
    public partial class RosterAdd : MetroForm
    {
        public RosterAdd()
        {
            InitializeComponent();
            EmployeeValue.FromFormControls(this);
            this.AcceptButton = this.Save;
            this.Load +=RosterAdd_Load;
            this.PartCode.SelectedIndexChanged += PartCode_SelectedIndexChanged;
            this.Save.Click += Save_Click;
            this.Exit.Click += Exit_Click;
            this.Pass.KeyPress += Pass_KeyPress;
            this.PhoneNum.TextChanged += PhoneNum_TextChanged;
            this.Male.CheckedChanged += Male_CheckedChanged;
            this.Female.CheckedChanged += Female_CheckedChanged;
        }

        public enum Gender
        {
            Male,
            Female,
        }

        private Dictionary<string, string> departmentMap = new Dictionary<string, string>();
        private void RosterAdd_Load(object sender, EventArgs e) // 폼 로드 시 콤보 박스 초기화 및 정렬
        {
            PartCode.Items.Clear();
            departmentMap.Clear();
            var departments = SqlRepository.GetDepartments()
                .OrderBy(d => int.TryParse(d.Code, out var n) ? n : int.MaxValue)
                .ThenBy(d => d.Code);
            foreach (var dept in departments)
            {
                PartCode.Items.Add(dept.Code);
                departmentMap[dept.Code] = dept.Name;
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

        private bool IsValidPassword(string password) // 비밀번호 형식 검증
        {
            // 영문, 숫자 포함 8자리 이상
            return Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            if (Male.Checked) Female.Checked = false;
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            if (Female.Checked) Male.Checked = false;
        }


        private void Pass_KeyPress(object sender, KeyPressEventArgs e) // 비밀번호 형식
        {
            // 영문(대소문자) 또는 숫자가 아니면 입력x
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true; // 입력 차단
            }
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
            if (string.IsNullOrWhiteSpace(EmployeeCode.Text))
            {
                MessageBox.Show("사원코드를 입력해주세요.");
                EmployeeCode.Focus();
                EmployeeCode.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(EmployeeName.Text))
            {
                MessageBox.Show("사원명을 입력해주세요.");
                EmployeeName.Focus();
                EmployeeName.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(ID.Text))
            {
                MessageBox.Show("로그인 ID를 입력해주세요.");
                ID.Focus();
                ID.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(Pass.Text))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                Pass.Focus();
                Pass.SelectAll();
                return;
            }

            // 이메일 형식 검증
            if (!IsValidEmail(Email.Text))
            {
                MessageBox.Show("올바른 이메일 형식이 아닙니다.");
                Email.Focus();
                Email.SelectAll();
                return;
            }

            if (!IsValidPassword(Pass.Text))
            {
                // 비밀번호 규칙 x
                MessageBox.Show("비밀번호는 영문, 숫자를 포함하여 8자리 이상이어야 합니다.");
                Pass.Focus();
                Pass.SelectAll();
                return;
            }

            SavedModel = EmployeeValue.FromFormControls(this);

            EmployeeValue.InsertEmployee(SavedModel);

            MessageBox.Show("사원이 추가되었습니다.");
            this.DialogResult = DialogResult.OK;
            this.Close(); // 폼 닫기
        }

        private void Exit_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
