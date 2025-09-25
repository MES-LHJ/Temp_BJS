using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev
{
    public partial class Login : Form
    {
        // 1. 토큰 값을 저장하고 외부에서 읽을 수 있도록 '공개 속성'을 추가합니다.
        public string CompanyToken { get; private set; }
        public string EmployeeToken { get; private set; }

        // 2. 토큰이 유효한 시간 (API 서버에서 보통 'expires_in' 초 단위로 받음)
        // 여기서는 임시로 12시간 (43200초)을 사용하겠습니다.
        private readonly int TOKEN_VALID_SECONDS = 12 * 60 * 60; // 43200초
        public Login()
        {
            InitializeComponent();
            AddEvent();
        }

        private void AddEvent()
        {
            this.AcceptButton = this.loginBtn;
            this.loginBtn.Click += loginBtn_Click;
            this.exit.Click += exit_Click;
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            //using (var Form = new Main())
            //{
            //    Form.ShowDialog();
            //    if (Form.DialogResult == DialogResult.OK)
            //    {
            //        this.Close();
            //    }
            //}
            // TODO: ID/PW 입력 컨트롤에서 값을 가져와야 합니다. (예: idTextBox, passwordTextBox)
            // string loginId = idTextBox.Text; 
            // string password = passwordTextBox.Text; 

            // ⭐ 1. ApiService를 사용하여 인증 요청 (POST)
            var apiService = new ApiMethod();
            // bool success = await apiService.AuthenticateAsync(loginId, password); // API 호출로 대체

            // ⭐ 임시 성공 가정 (실제 구현 시 위 API 호출로 대체)
            bool success = true;

            if (success)
            {
                // TODO: 실제 API 응답에서 받은 토큰 값과 만료 시간을 CurrentToken에 저장해야 합니다.
                CurrentToken.CompanyToken = "SAMPLE_COMPANY_TOKEN";
                CurrentToken.EmployeeToken = "SAMPLE_EMPLOYEE_TOKEN";
                CurrentToken.ExpiryTime = DateTime.Now.AddHours(12); // 12시간 유효 기간 가정

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            // 실패 시 처리는 AuthenticateAsync 내부 또는 여기서 MessageBox로 처리합니다.
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
