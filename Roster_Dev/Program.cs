using Roster_Dev.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);

        //    using (var loginForm = new Login())
        //    {
        //        if (loginForm.ShowDialog() == DialogResult.OK)
        //        {
        //            Application.Run(new Main());
        //        }
        //        else
        //        {
        //            Application.Exit();
        //        }
        //    }

        //Application.Exit();
        //}
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new Login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //업체 토큰 -> 사원 토큰
                        // Brn 값은 "debug"
                        await ApiRepository.ApiClient.GetCustomerTokenAsync("debug");
                        await ApiRepository.ApiClient.GetAndSetEmployeeTokenAsync("admin", "1111");

                        // 토큰 및 데이터 획득 성공 시, 메인 폼 실행
                        Application.Run(new Main());
                    }
                    catch (Exception ex)
                    {
                        // 에러 발생 시 프로그램 종료
                        MessageBox.Show($"인증/데이터 로드 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}
