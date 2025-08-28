using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster
{
    public partial class Login : MetroForm
    {
        public Login()
        {
            InitializeComponent();
            this.AcceptButton = this.LoginButton;
            this.Load += Login_Load;                   // 폼 로드 이벤트
            this.LoginButton.Click += LoginButton_Click; // 버튼 클릭 이벤트 연결
            this.Exit.Click += Exit_Click;

        }

        private const string CS = "Server=DESKTOP-6VSVCKC\\JSTESTSERVER;" +
            "Database=WorkTestDB;" +
            "Trusted_Connection=True;" +
            "Encrypt=True;" +
            "TrustServerCertificate=True;";



        private void Login_Load(object sender, EventArgs e)
        {

        }
        // ID/Password 일치 여부 확인
        private bool TryLogin(string userId, string password)
        {
            const string sqlEn = @"
            SELECT COUNT(*)
            FROM dbo.Employee
            WHERE [ID] = @id
              AND [Password] = @pw;";

            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sqlEn, conn))
            {
                cmd.Parameters.AddWithValue("@id", userId ?? "");
                cmd.Parameters.AddWithValue("@pw", password ?? "");
                conn.Open();
                var result = cmd.ExecuteScalar();
                return result != null; // 레코드가 있으면 로그인 성공
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var userId = Id.Text?.Trim();
            var userPw = Password.Text;

            // 공백 검사
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(userPw))
            {
                MessageBox.Show("아이디와 비밀번호를 입력해주세요.");
                if (string.IsNullOrWhiteSpace(userId)) { Id.Focus(); Id.SelectAll(); }
                else { Password.Focus(); Password.SelectAll(); }
                return;
            }
            
            if (!TryLogin(userId, userPw))
            {
                MessageBox.Show("아이디 또는 비밀번호가 잘못되었습니다.");
                Password.Focus(); Password.SelectAll();
                return;
            }

            var main = new Roster.MainRoster();
            // 로그인 폼 숨김, 메인 폼이 닫히면 로그인 폼도 함께 꺼짐
            //this.FormClosed += (s, args) => main.Show();
            this.DialogResult = DialogResult.OK;
            this.Close();
            //main.FormClosed += (s, args) => this.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close(); // 로그인 취소 시 폼 닫기
        }
    }
}
