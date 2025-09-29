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
        public static async Task<List<EmployeeWorkout>> GetEmployeesAsync(long factoryId=1)
        {
            return await ApiClient.GetEmployeeWorkoutsAsync(factoryId);
        }

        public static async Task<List<DepartmentWorkout>> GetDepartmentsAsync(long factoryId = 1)
        {
            // ApiClient의 부서 조회 메서드를 호출
            return await ApiClient.GetDepartmentWorkoutsAsync();
        }

        public static async Task<List<DepartmentWorkout>> GetUpperDepartmentAsync()
        {
            return await ApiClient.GetUpperDepartmentWorkoutsAsync();
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

        //public static async Task<int> DeleteDepartment(long departmentId)
        //{
        //    await ApiClient.DeleteDepartmentWorkoutAsync(departmentId);
        //    return 1;
        //}

        //public void Task 

    }
}
