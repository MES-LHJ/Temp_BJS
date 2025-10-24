using Chat_Client.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client.View
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            AddEvent();
        }
        private void AddEvent()
        {
            this.Load += Register_Load;
            this.join.Click += JoinBtn_Click;
            this.cancel.Click += CancelBtn_Click;
        }
        private void Register_Load(object sender, EventArgs e)
        {
        }

        private async void JoinBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var users = Api.MongoDB.Instance.Users;

                // 중복된 아이디 확인
                var existingUser = await users.Find(u => u.UserId == id.Text.Trim()).FirstOrDefaultAsync();
                if (existingUser != null)
                {
                    Console.WriteLine("중복된 아이디입니다.");
                    MessageBox.Show("중복된 아이디입니다.", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 회원가입 버튼 클릭 시 처리할 코드 작성
                var txtid = id.Text.Trim();
                var txtpassword = password.Text;
                var txtnickname = nickName.Text.Trim();
                var txtname = name.Text.Trim();
                var txtemail = email.Text.Trim();
                if (string.IsNullOrEmpty(txtid) || string.IsNullOrEmpty(txtpassword) || string.IsNullOrEmpty(txtnickname))
                {
                    MessageBox.Show("아이디, 비밀번호, 닉네임을 모두 입력해주세요.", "경고",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 여기에 회원가입 로직 추가 (예: 데이터베이스에 사용자 정보 저장)
                var newUser = new UserModel
                {
                    UserId = txtid,
                    Password = BCrypt.Net.BCrypt.HashPassword(txtpassword),
                    NickName = txtnickname,
                    UserName = txtname,
                    Email = txtemail
                };

                await users.InsertOneAsync(newUser);
                Console.WriteLine("회원가입이 완료되었습니다.");
                MessageBox.Show("회원가입이 완료되었습니다!", "정보",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"회원가입 중 오류가 발생했습니다: {ex.Message}");
                MessageBox.Show("회원가입 중 오류가 발생했습니다.", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
