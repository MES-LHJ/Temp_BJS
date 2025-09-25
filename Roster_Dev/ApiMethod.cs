using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev
{
    public class ApiMethod
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseApiUrl = "https://your.api.server.com/api/"; // ⭐ API 기본 URL로 변경하세요.
        public ApiMethod() 
        {
            _httpClient.BaseAddress = new Uri(_baseApiUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private async Task<HttpResponseMessage> SendAuthenticatedAsync(HttpMethod method, string endpoint, object data = null)
        {
            if (string.IsNullOrEmpty(CurrentToken.CompanyToken))
            {
                // 토큰이 없으면 401 오류 처리 플래그를 설정하고 강제로 종료 유도
                CurrentToken.NeedsRelogin = true;
                MessageBox.Show("인증 토큰이 없습니다. 재로그인이 필요합니다.", "인증 오류");
                return null;
            }

            using (var requestMessage = new HttpRequestMessage(method, endpoint))
            {
                // 헤더에 토큰 주입
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", CurrentToken.CompanyToken);

                // POST/PUT 요청인 경우 JSON 데이터 포함
                if (data != null && (method == HttpMethod.Post || method == HttpMethod.Put))
                {
                    var jsonContent = JsonSerializer.Serialize(data);
                    requestMessage.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                }

                var response = await _httpClient.SendAsync(requestMessage);

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized) // 401 Unauthorized
                {
                    // 토큰 만료 감지 시 재로그인 유도
                    CurrentToken.NeedsRelogin = true;
                    MessageBox.Show("세션이 만료되었습니다. 재로그인이 필요합니다.", "세션 만료");
                    return null;
                }

                return response;
            }
        }

        // -------------------------------------------------------------------
        // 1. 사원/부서 데이터 조회 (GET)
        // -------------------------------------------------------------------
        public async Task<string> GetAsync(string endpoint)
        {
            var response = await SendAuthenticatedAsync(HttpMethod.Get, endpoint);

            if (response != null && response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return null;
        }

        // -------------------------------------------------------------------
        // 2. 사원/부서 데이터 추가 (POST)
        // -------------------------------------------------------------------
        public async Task<bool> PostAsync(string endpoint, object data)
        {
            var response = await SendAuthenticatedAsync(HttpMethod.Post, endpoint, data);

            if (response != null && response.IsSuccessStatusCode)
            {
                return true;
            }
            MessageBox.Show($"추가 실패: {response?.StatusCode}", "오류");
            return false;
        }

        // -------------------------------------------------------------------
        // 3. 사원/부서 데이터 수정 (PUT)
        // -------------------------------------------------------------------
        public async Task<bool> PutAsync(string endpoint, object data)
        {
            var response = await SendAuthenticatedAsync(HttpMethod.Put, endpoint, data);

            if (response != null && response.IsSuccessStatusCode)
            {
                return true;
            }
            MessageBox.Show($"수정 실패: {response?.StatusCode}", "오류");
            return false;
        }

        // -------------------------------------------------------------------
        // 4. 사원/부서 데이터 삭제 (DELETE)
        // -------------------------------------------------------------------
        public async Task<bool> DeleteAsync(string endpoint)
        {
            var response = await SendAuthenticatedAsync(HttpMethod.Delete, endpoint);

            if (response != null && response.IsSuccessStatusCode)
            {
                return true;
            }
            MessageBox.Show($"삭제 실패: {response?.StatusCode}", "오류");
            return false;
        }
    }
}
