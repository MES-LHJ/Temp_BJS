using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
//using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Roster_Dev.Model;

namespace Roster_Dev.ApiClient
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "http://test.smartqapis.com:5000/"; // 기본 URL 설정
        private string _customerToken; // 업체 토큰 저장용 필드

        public ApiClient()
        {
            // HttpClient 인스턴스 초기화
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        // 업체 토큰을 받아와 설정하는 메서드
        // ApiClient.cs 파일 내부

        private StringContent SerializeToJsonContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private async Task<T> DeserializeApiResponseData<T>(HttpContent content)
        {
            var jsonString = await content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                return default(T);
            }

            try
            {
                // API 응답이 { "Data": T, "Error": string } 구조라고 가정하고 역직렬화
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(jsonString);

                // ApiResponse 구조가 아닌 경우 (예: 사원 토큰 API의 Raw Token 응답) 또는 Data/Error 필드가 없는 경우
                if (apiResponse == null || (apiResponse.Data == null && apiResponse.Error == null))
                {
                    // Raw T 타입으로 재시도
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }

                if (!string.IsNullOrEmpty(apiResponse.Error))
                {
                    throw new Exception($"API 오류: {apiResponse.Error}");
                }

                return apiResponse.Data;
            }
            catch (JsonException)
            {
                // 역직렬화 실패 시, raw T 타입으로 재시도 (가장 단순한 형태의 응답을 처리)
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                // 기타 예외 처리
                throw new Exception($"JSON 응답 처리 중 오류 발생: {ex.Message}");
            }
        }



        // 업체 토큰을 획득 (사원 토큰 발급을 위해 선행되어야 함)
        public async Task GetCustomerTokenAsync(string brn)
        {
            string url = "http://test.smartqapis.com:5001/api/Customers/authenticate";
            var body = new { Brn = brn }; // "Brn" : "debug"

            using (var client = new HttpClient())
            {
                var response = await _httpClient.PostAsync(url, SerializeToJsonContent(body));
                response.EnsureSuccessStatusCode();

                // 응답 구조: Data { Token: string }
                var tokenResponse = await DeserializeApiResponseData<CustomerTokenData>(response.Content);
                _customerToken = tokenResponse.Token;
            }
        }

        // 사원 토큰을 획득하고 HttpClient에 설정
        public async Task GetAndSetEmployeeTokenAsync(string loginId, string password)
        {
            if (string.IsNullOrEmpty(_customerToken))
            {
                throw new InvalidOperationException("업체 토큰이 먼저 발급되어야 합니다.");
            }

            // 사원 토큰 발급 시 Bearer Token으로 업체 토큰 값을 요구
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _customerToken);

            // 사원 토큰 발급 API 경로 및 요청 데이터 설정
            string tokenUrl = "http://test.smartqapis.com:5000/api/Login";
            // "loginId" : admin, "password" : 1111
            var tokenRequest = new { loginId = loginId, password = password };

            var requestContent = SerializeToJsonContent(tokenRequest);
            var tokenResponse = await _httpClient.PostAsync(tokenUrl, requestContent);
            tokenResponse.EnsureSuccessStatusCode();

            // 응답에서 사원 토큰 값 추출
            //var employeeTokenData = await tokenResponse.Content.ReadFromJsonAsync<EmployeeTokenResponse>();
            var employeeTokenData = await DeserializeApiResponseData<string>(tokenResponse.Content);

            // 후속 요청에 사용되도록 Authorization 헤더에 사원 토큰으로 변경 설정
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", employeeTokenData);
        }

        //사원 전체 조회(List<Employee> 를 List<EmployeeWorkout> 으로 변경)
        public async Task<List<EmployeeWorkout>> GetEmployeeWorkoutsAsync(long factoryId)
        {
            // GET http://test.smartqapis.com:5000/api/Employee?factoryId=1
            string url = "api/Employee?factoryId=1";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            // 💡 수정 지점 1: 반환 타입 T를 ApiResponse<List<EmployeeWorkout>>으로 지정해야 합니다.
            var apiResponse = await DeserializeApiResponseData<ApiResponse<List<EmployeeWorkout>>>(response.Content);

            // 💡 수정 지점 2: 이제 apiResponse는 Data와 Error 속성을 가진 객체이므로 접근이 가능합니다.
            if (apiResponse == null || apiResponse.Data == null)
            {
                // 🚨 Error 필드에 접근할 때 Null-conditional Operator '?'를 붙여야 NullReferenceException을 피할 수 있습니다.
                throw new Exception($"사원 데이터 가져오기 실패: {apiResponse?.Error ?? "응답 구조 오류"}");
            }
            return apiResponse.Data;
        }

        //public async Task<List<EmployeeWorkout>> GetEmployeeWorkoutsAsync(long factoryId)
        //{
        //    string url = $"api/Employee?factoryId={factoryId}";
        //    var response = await _httpClient.GetAsync(url);
        //    response.EnsureSuccessStatusCode();

        //    return await DeserializeApiResponseData<List<EmployeeWorkout>>(response.Content);
        //}

        // 사원 추가 (Employee를 EmployeeWorkout으로 변경)
        public async Task<EmployeeWorkout> AddEmployeeWorkoutAsync(EmployeeWorkout newEmployee)
        {
            string url = "api/Employee";
            var response = await _httpClient.PostAsync(url, SerializeToJsonContent(newEmployee));
            response.EnsureSuccessStatusCode();
            return await DeserializeApiResponseData<EmployeeWorkout>(response.Content);
        }

        // 사원 수정 (Employee를 EmployeeWorkout으로 변경하고, Code 속성을 사용)
        public async Task UpdateEmployeeWorkoutAsync(EmployeeWorkout updatedEmployee)
        {
            // URL에 사원코드를 포함하여 특정 사원을 지정 (EmployeeWorkout의 Code 속성을 사용)
            string url = $"api/employees/{updatedEmployee.Id}";
            var response = await _httpClient.PutAsync(url, SerializeToJsonContent(updatedEmployee));
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEmployeeWorkoutAsync(string employeeCode)
        {
            string url = $"api/employees/{employeeCode}";
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        // 부서 전체 조회
        public async Task<List<DepartmentWorkout>> GetDepartmentWorkoutsAsync()
        {
            var response = await _httpClient.GetAsync("api/Department?factoryId=1");
            response.EnsureSuccessStatusCode();

            var apiresponse = await DeserializeApiResponseData<DepartmentResponse>(response.Content);
            return apiresponse.Data;
        }

        // 부서 추가
        public async Task<DepartmentWorkout> AddDepartmentWorkoutAsync(DepartmentWorkout newDepartment)
        {
            string url = "api/Department";
            var requestContent = SerializeToJsonContent(newDepartment);
            var response = await _httpClient.PostAsync(url, requestContent); 
            
            response.EnsureSuccessStatusCode();
            
            return await DeserializeApiResponseData<DepartmentWorkout>(response.Content);
        }

        public async Task UpdateDepartmentWorkoutAsync(DepartmentWorkout updatedDepartment)
        {
            // URL에 부서코드를 포함하여 특정 부서를 지정
            string url = $"api/departments/{updatedDepartment.Id}";
            var response = await _httpClient.PutAsync(url, SerializeToJsonContent(updatedDepartment));
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteDepartmentWorkoutAsync(string departmentId)
        {
            string url = $"api/departments/{departmentId}";
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }

        // 상위 부서 전체 조회
        public async Task<List<DepartmentWorkout>> GetUpperDepartmentWorkoutsAsync()
        {
            var response = await _httpClient.GetAsync("api/Department?factoryId=1");
            response.EnsureSuccessStatusCode();
            return await DeserializeApiResponseData<List<DepartmentWorkout>>(response.Content);
        }

    } // ApiClient 클래스 닫음

    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
    }

    //public class CustomerTokenResponse
    //{
    //    public CustomerTokenData Data { get; set; }
    //    public string Error { get; set; }
    //}
    public class CustomerTokenResponse : ApiResponse<CustomerTokenData> { }
    public class CustomerTokenData
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DataLogCertificationKey { get; set; }
        public string ImagePath { get; set; }
        public string Token { get; set; } // 업체 토큰
    }

    //public class EmployeeTokenResponse
    //{
    //    public string Data { get; set; } // 사원 토큰 (string)
    //    public string Error { get; set; }
    //}
    public class EmployeeTokenResponse : ApiResponse<string> { } // Data가 사원 토큰 문자열
}