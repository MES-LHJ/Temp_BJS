using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Roster_Dev
{
    internal class RestApiToken
    {
        // 1. Connection String을 필드로 유지
        // Trusted_Connection=True 는 Windows 인증을 사용하겠다는 의미입니다.
        private readonly string CS = "Server=DESKTOP-6VSVCKC\\JSTESTSERVER;database=RestApiData;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        // 2. 토큰을 받아서 DB에 저장하는 '메서드'를 생성해야 합니다.
        public void SaveTokensToDB(string companyToken, string employeeToken)
        {
            // 3. 실행 가능한 모든 코드는 메서드 본문 내부에 있어야 합니다.
            try
            {
                using (SqlConnection conn = new SqlConnection(CS))
                {
                    conn.Open();

                    // SQL Injection 방지를 위해 매개변수화된 쿼리 사용
                    string query = "INSERT INTO ApiTokens (CompanyToken, EmployeeToken) VALUES (@company, @employee)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // 외부에서 받은 토큰 값을 매개변수에 할당
                        cmd.Parameters.AddWithValue("@company", companyToken);
                        cmd.Parameters.AddWithValue("@employee", employeeToken);

                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("DB에 토큰 저장 완료!");
            }
            catch (Exception ex)
            {
                // 예외 처리: 연결 실패나 쿼리 오류 시 메시지 출력
                Console.WriteLine($"DB 저장 오류 발생: {ex.Message}");
            }
        }

        // *참고: 실제 사용 시에는 이 클래스의 인스턴스를 만들고 메서드를 호출해야 합니다.*
        /*
        // Main 메서드에서 호출 예시:
        static void Main(string[] args)
        {
            var tokenManager = new RestApiToken();
            string receivedCompanyToken = "YOUR_COMPANY_TOKEN_VALUE"; // 포스트맨에서 받은 실제 토큰 값
            string receivedEmployeeToken = "YOUR_EMPLOYEE_TOKEN_VALUE"; // 포스트맨에서 받은 실제 토큰 값
            
            tokenManager.SaveTokensToDB(receivedCompanyToken, receivedEmployeeToken);
        }
        */
    }
}
