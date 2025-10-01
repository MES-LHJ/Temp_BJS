using Roster_Dev.Model;
using Roster_Dev.ApiClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_Dev
{
    public static class ApiRepository
    {
        public static readonly ApiClient.ApiClient ApiClient = new ApiClient.ApiClient();

        /// <summary>
        /// 사원 조회
        /// </summary>
        /// <returns></returns>
        public static async Task<List<EmployeeWorkout>> GetEmployeesAsync(long factoryId)
        {
            return await ApiClient.GetEmployeeWorkoutsAsync(factoryId);
        }

        public static async Task<List<DepartmentWorkout>> GetDepartmentsAsync(long factoryId)
        {
            // ApiClient의 부서 조회 메서드를 호출
            return await ApiClient.GetDepartmentWorkoutsAsync(factoryId);
            //try
            //{
            //    // factoryId를 ApiClient로 전달하도록 수정되었는지 확인
            //    return await ApiClient.GetDepartmentWorkoutsAsync(factoryId);
            //}
            //catch (Exception ex)
            //{
            //    // ... (에러 처리)
            //    Console.WriteLine($"부서 조회 에러: {ex.Message}");
            //    return new List<DepartmentWorkout>();
            //}
        }

        public static async Task<List<UpperDepartmentWorkout>> GetUpperDepartmentAsync(long factoryId)
        {
            return await ApiClient.GetUpperDepartmentWorkoutsAsync(factoryId);
        }

        public static async Task AddEmployeeAsync(EmployeeWorkout emp)
        {
            await ApiClient.AddEmployeeWorkoutAsync(emp);
        }

        public static async Task UpdateEmployeeAsync(EmployeeWorkout emp)
        {
            // ApiClient의 사원 수정 메서드를 호출
            await ApiClient.UpdateEmployeeWorkoutAsync(emp);
        }

        public static async Task<int> DeleteEmployeeAsync(long employeeId)
        {
            await ApiClient.DeleteEmployeeWorkoutAsync(employeeId);
            return 1;
        }

        public static async Task InsertDepartmentAsync(DepartmentWorkout emp)
        {
            await ApiClient.AddDepartmentWorkoutAsync(emp);
        }

        public static async Task UpdateDepartmentAsync(DepartmentWorkout emp)
        {
            await ApiClient.UpdateDepartmentWorkoutAsync(emp);
        }

        public static async Task<int> DeleteDepartment(long departmentId)
        {
            await ApiClient.DeleteDepartmentWorkoutAsync(departmentId);
            return 1;
        }

        public static async Task InsertUpperDepartmentAsync(UpperDepartmentWorkout upperDept)
        {
            await ApiClient.AddUpperDepartmentWorkoutAsync(upperDept);
        }
        public static async Task UpdateUpperDepartmentAsync(UpperDepartmentWorkout upperDept)
        {
            await ApiClient.EditUpperDepartmentWorkoutAsync(upperDept);
        }
        //public void Task 

    }
}
