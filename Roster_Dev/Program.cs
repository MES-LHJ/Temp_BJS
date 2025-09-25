using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ⭐ 재로그인 흐름을 위한 루프 추가
            bool mustExit = false;
            while (!mustExit)
            {
                using (var loginForm = new Login())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // 로그인 성공 시 메인 폼 실행
                        Application.Run(new Main());

                        // Main 폼이 닫힌 후, 토큰 만료 여부 확인
                        if (CurrentToken.NeedsRelogin)
                        {
                            // 토큰 만료로 인한 닫힘 -> 재로그인 유도
                            MessageBox.Show("세션이 만료되었습니다. 보안을 위해 재로그인이 필요합니다.", "세션 만료", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CurrentToken.Reset(); // 토큰 정보 초기화
                            // 루프가 계속되어 Login 폼이 재실행됨
                        }
                        else
                        {
                            // 사용자가 정상적으로 종료 -> 애플리케이션 종료
                            mustExit = true;
                        }
                    }
                    else
                    {
                        // 로그인 폼에서 취소 또는 X 버튼 클릭 -> 애플리케이션 종료
                        mustExit = true;
                    }
                }
            }

            //Application.Exit();
        }
    }
}
