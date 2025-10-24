using BCrypt.Net;
using Chat_Client.Model;
using Chat_Client;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client.Auth
{
    public partial class Login : Form
    {
        public UserModel UserModel { get; private set; }

        private readonly IMongoCollection<UserModel> _users;

        public Login()
        {
            InitializeComponent();
            //싱글턴 패턴으로 MongoDB 인스턴스 가져오기
            _users = Api.MongoDB.Instance.Users;
            AddEvent();
        }
        private void AddEvent()
        {
            this.Load += Login_Load;
            this.loginBtn.Click += LoginBtn_Click;
            this.registerBtn.Click += RegisterBtn_Click;
            this.cancelBtn.Click += cancelBtn_Click;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            // 로그인 버튼 클릭 시 처리할 코드 작성
            var txtid = id.Text.Trim();
            var txtpassword = password.Text;

            if (string.IsNullOrEmpty(txtid) || string.IsNullOrEmpty(txtpassword))
            {
                MessageBox.Show("아이디와 비밀번호를 입력해주세요.", "경고",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var user = await _users.Find(u => u.UserId == txtid).FirstOrDefaultAsync();
                if (user == null || !BCrypt.Net.BCrypt.Verify(txtpassword, user.Password))
                {
                    MessageBox.Show("아이디 또는 비밀번호가 올바르지 않습니다.", "오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 이미 로그인된 사용자 처리 (선택 사항)
                if(user.LoginTime != null && (DateTime.Now - user.LoginTime).TotalMinutes < 30)
                {
                    var result = MessageBox.Show("이 계정은 이미 로그인되어 있습니다. 계속 진행하시겠습니까?", "경고",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }

                user.LoginTime = DateTime.Now;
                UserModel = user;

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"로그인 처리 중 오류: {ex.Message}", "오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            var registerForm = new View.Register();
            registerForm.ShowDialog();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
