using Newtonsoft.Json;
using Roster_Dev.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
//using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
                //return default(T);
                throw new Exception("API 응답 본문이 비어 있습니다.");
            }

            try
            {
                // 역직렬화
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(jsonString);

                // 응답 구조체에서 실제 데이터(Data 필드)를 반환
                if (apiResponse != null && apiResponse.Data != null)
                {
                    return apiResponse.Data;
                }
                else if (apiResponse != null && !string.IsNullOrEmpty(apiResponse.Error))
                {
                    // API에서 에러 메시지를 반환한 경우 처리
                    throw new Exception($"API 에러: {apiResponse.Error}");
                }
                else
                {
                    // Data 필드가 null인 경우 (빈 값으로 들어온다는 오류 메시지와 일치)
                    // 빈 리스트여야 하는 상황이면 빈 리스트가 담겨 있어야 하는데, null이면 문제가 됩니다.
                    // 하지만 리스트가 아닌 경우도 있으므로, 여기서는 기본 예외를 던집니다.
                    throw new Exception("API 응답 데이터(Data 필드)가 비어 있거나 올바르지 않습니다.");
                }
            }
            catch (JsonException)
            {
                // 역직렬화 실패 시, raw T 타입으로 재시도
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

        /// <summary>
        /// 사원 전체 조회
        /// </summary>
        /// <param name="factoryId"></param>
        /// <returns></returns>
        public async Task<List<EmployeeWorkout>> GetEmployeeWorkoutsAsync(long factoryId)
        {
            string url = $"api/Employee?factoryId=1";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await DeserializeApiResponseData<List<EmployeeWorkout>>(response.Content);
        }

        /// <summary>
        /// 사원 추가
        /// </summary>
        /// <param name="newEmployee"></param>
        /// <returns></returns>
        public async Task<EmployeeWorkout> AddEmployeeWorkoutAsync(EmployeeWorkout newEmployee)
        {
            string url = "api/Employee";

            var createBody = new
            {
                DepartmentId = newEmployee.DepartmentId,
                Code = newEmployee.Code,
                Name = newEmployee.Name,
                Position = newEmployee.Position,
                ContractType = newEmployee.ContractType,
                Email = newEmployee.Email,
                PhoneNumber = newEmployee.PhoneNumber,
                MessengerId = newEmployee.MessengerId,
                Memo = newEmployee.Memo,
                LoginId = newEmployee.LoginId,
                LoginPassword = newEmployee.LoginPassword,
                LoginTag = newEmployee.LoginTag,
                IsAdmin = newEmployee.IsAdmin
            };

            var json = JsonConvert.SerializeObject(createBody, Formatting.Indented);
            Console.WriteLine("POST Body JSON (filtered):\n"+json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response Status: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);

            response.EnsureSuccessStatusCode();

            return await DeserializeApiResponseData<EmployeeWorkout>(response.Content);

            //var response = await _httpClient.PostAsync(url, SerializeToJsonContent(newEmployee));
            //response.EnsureSuccessStatusCode();
            //return await DeserializeApiResponseData<EmployeeWorkout>(response.Content);
        }

        /// <summary>
        /// 사원 수정
        /// </summary>
        /// <param name="updatedEmployee"></param>
        /// <returns></returns>
        public async Task UpdateEmployeeWorkoutAsync(EmployeeWorkout updatedEmployee)
        {
            string url = $"api/Employee/{updatedEmployee.Id}";
            //var response = await _httpClient.PutAsync(url, SerializeToJsonContent(updatedEmployee));

            var updateBody = new
            {
                Name = updatedEmployee.Name,
                Code = updatedEmployee.Code,
                DepartmentId = updatedEmployee.DepartmentId,
                Position = updatedEmployee.Position,
                ContractType = updatedEmployee.ContractType,
                Email = updatedEmployee.Email,
                PhoneNumber = updatedEmployee.PhoneNumber,
                MessengerId = updatedEmployee.MessengerId,
                Memo = updatedEmployee.Memo
            };
            var json = JsonConvert.SerializeObject(updateBody, Formatting.Indented);
            Console.WriteLine("PUT Body JSON (filtered):\n" + json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response Status: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);

            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// 사원 삭제
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task DeleteEmployeeWorkoutAsync(long employeeId)
        {
            string url = $"api/Employee/{employeeId}";

            var response = await _httpClient.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("DELETE Response Status: " + response.StatusCode);
                Console.WriteLine("DELETE Response Body: " + responseBody);

                // DeserializeApiResponseData를 사용하여 Error 메시지를 추출 시도
                try
                {
                    // 실패 응답시 API 서버에서 에러 메시지를 JSON 형태로 보낼 수 있음.
                    var errorResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseBody);
                    if (errorResponse != null && !string.IsNullOrEmpty(errorResponse.Error))
                    {
                        throw new Exception($"사원 삭제 실패: {errorResponse.Error}");
                    }
                }
                catch (Exception)
                {
                    // JSON 역직렬화에 실패하거나 Error 필드가 없으면 기본 HTTP 상태 코드로 예외 처리
                    response.EnsureSuccessStatusCode();
                }
            }
        }

        /// <summary>
        /// 부서 전체 조회
        /// </summary>
        /// <param name="factoryId"></param>
        /// <returns></returns>
        public async Task<List<DepartmentWorkout>> GetDepartmentWorkoutsAsync(long factoryId)
        {
            //string url = $"api/Department?factoryId=1";
            //var response = await _httpClient.GetAsync(url);
            //response.EnsureSuccessStatusCode();

            //return await DeserializeApiResponseData<List<DepartmentWorkout>>(response.Content);
            string url = $"api/Department?factoryId=1";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var list = await DeserializeApiResponseData<List<DepartmentWorkout>>(response.Content);
            return list ?? new List<DepartmentWorkout>();
        }

        /// <summary>
        /// 부서 추가
        /// </summary>
        /// <param name="newDepartment"></param>
        /// <returns></returns>
        public async Task<DepartmentWorkout> AddDepartmentWorkoutAsync(DepartmentWorkout newDepartment)
        {
            string url = $"api/Department";
            var createBody = new
            {
                Name = newDepartment.Name,
                Code = newDepartment.Code,
                Memo = newDepartment.Memo,
                UpperDepartmentId = newDepartment.UpperDepartmentId,
                FactoryId = newDepartment.FactoryId
            };
            var json = JsonConvert.SerializeObject(createBody, Formatting.Indented);
            Console.WriteLine("POST Body JSON (filtered):\n" + json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response Status: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);

            response.EnsureSuccessStatusCode();

            return await DeserializeApiResponseData<DepartmentWorkout>(response.Content);

            //var requestContent = SerializeToJsonContent(newDepartment);
            //var response = await _httpClient.PostAsync(url, requestContent);

            //response.EnsureSuccessStatusCode();

        }

        /// <summary>
        /// 부서 수정
        /// </summary>
        /// <param name="updatedDepartment"></param>
        /// <returns></returns>
        public async Task UpdateDepartmentWorkoutAsync(DepartmentWorkout updatedDepartment)
        {
            // URL에 부서코드를 포함하여 특정 부서를 지정
            string url = $"api/Department/{updatedDepartment.Id}";
            var updateBody = new
            {
                Name = updatedDepartment.Name,
                Code = updatedDepartment.Code,
                Memo = updatedDepartment.Memo,
                UpperDepartmentId = updatedDepartment.UpperDepartmentId,
                FactoryId = updatedDepartment.FactoryId
            };

            // JSON 직렬화
            var json = JsonConvert.SerializeObject(updateBody, Formatting.Indented);
            Console.WriteLine("PUT Body JSON (filtered):\n" + json);

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);

            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Response Status: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);

            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// 부서 삭제
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteDepartmentWorkoutAsync(long departmentId)
        {
            string url = $"api/Department/{departmentId}";
            var response = await _httpClient.DeleteAsync(url);
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Response Status: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);

            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    // 서버 응답이 JSON 형태라면, 에러 메시지 추출 시도
                    var errorResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseBody);
                    if (errorResponse != null && !string.IsNullOrEmpty(errorResponse.Error))
                    {
                        throw new Exception($"부서 삭제 실패: {errorResponse.Error}");
                    }
                }
                catch (JsonException)
                {
                    // JSON 구조가 아닐 경우 그냥 본문 그대로 출력
                    throw new Exception($"부서 삭제 실패: {responseBody}");
                }

                // 마지막으로 HTTP 상태 코드 기반 예외 처리
                response.EnsureSuccessStatusCode();
            }
        }

        // 상위 부서 전체 조회
        public async Task<List<UpperDepartmentWorkout>> GetUpperDepartmentWorkoutsAsync(long factoryId)
        {
            string url = $"api/upperDepartment?factoryId=1";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var list = await DeserializeApiResponseData<List<UpperDepartmentWorkout>>(response.Content);

            return list?.GroupBy(x => x.UpperDepartmentId)
                        .Select(g => g.First())
                        .ToList() ?? new List<UpperDepartmentWorkout>();
        }

        public async Task<UpperDepartmentWorkout> AddUpperDepartmentWorkoutAsync(UpperDepartmentWorkout newUpper)
        {
            string url = "api/upperDepartment";
            var requestContent = SerializeToJsonContent(newUpper);
            var response = await _httpClient.PostAsync(url, requestContent);

            response.EnsureSuccessStatusCode();

            return await DeserializeApiResponseData<UpperDepartmentWorkout>(response.Content);
        }

        public async Task<UpperDepartmentWorkout> EditUpperDepartmentWorkoutAsync(UpperDepartmentWorkout updateUpper)
        {
            string url = "api/upperDepartment";
            var requestContent = SerializeToJsonContent(updateUpper);
            var response = await _httpClient.PostAsync(url, requestContent);

            response.EnsureSuccessStatusCode();

            return await DeserializeApiResponseData<UpperDepartmentWorkout>(response.Content);
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