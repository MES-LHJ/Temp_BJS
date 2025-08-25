using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Roster
{
    public partial class RosterEdit : MetroForm
    {
        public RosterEdit()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> departmentMap = new Dictionary<string, string>();
        private void RosterEdit_Load(object sender, EventArgs e) // 폼 로드 시 콤보 박스 초기화 및 정렬
        {
            PartCode.Items.Clear();
            departmentMap.Clear();
            var departments = SqlRepository.GetDepartments()
                .OrderBy(d => d.Code)
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
        
        private void Male_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Male.Checked) Female.Checked = false;
        }

        private void Female_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Female.Checked) Male.Checked = false;
        }

        private bool IsValidEmail(string email) // 이메일 형식 검증
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        //PublicKey enum Direction
        //{
        //    Male, 
        //    Female
        //};



        public event Action<string, string, string, string, string, string,
            string, string, string, string, string> OnSave;

        private void button1_Click(object sender, EventArgs e) // 저장 버튼
        {
            if (string.IsNullOrWhiteSpace(PartCode.Text))
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(MosCode.Text))
            {
                MessageBox.Show("사원코드를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(MosName.Text))
            {
                MessageBox.Show("사원명을 입력해주세요.");
                return;
            }

            if (!IsValidEmail(Email.Text))
            {
                MessageBox.Show("올바른 이메일 형식이 아닙니다.");
                return;
            }

        string gender = Male.Checked ? "남자" : (Female.Checked ? "여자" : "");

            OnSave?.Invoke(
                PartCode.Text,
                DepartName.Text,
                MosCode.Text,
                MosName.Text,
                Position.Text,
                Form_of_employment.Text,
                gender,
                PhoneNum.Text,
                Email.Text,
                MessengerId.Text,
                Memo.Text
            );

            MessageBox.Show("수정 되었습니다.");
            this.Close(); // 폼 닫기
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
