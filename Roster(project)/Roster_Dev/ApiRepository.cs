using Roster_Dev.ApiClient;
using Roster_Dev.Model;
using Roster_Dev.UtilClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        public static async Task<List<UpperDepartmentWorkout>> GetUpperDepartmentAsync(long factoryId)
        {
            //return await ApiClient.GetUpperDepartmentWorkoutsAsync(factoryId);
            var departments = await ApiClient.GetDepartmentWorkoutsAsync(factoryId);

            var factories = departments
                .Where(d => d.FactoryId > 0)
                .GroupBy(d => d.FactoryId)
                .Select(g =>
                {
                    var any = g.First();
                    return new UpperDepartmentWorkout
                    {
                        Id = g.Key,
                        FactoryId = g.Key,
                        FactoryCode = any.FactoryCode,
                        FactoryName = any.FactoryName,
                    };
                })
                .ToList();

            return factories;
        }

        public static async Task AddEmployeeAsync(EmployeeWorkout emp)
        {

            // 공장 전체 사원 목록 가져오기
            var existingEmployees = await ApiClient.GetEmployeeWorkoutsAsync(emp.FactoryId);

            // 중복 여부 확인
            bool isDuplicateCode = existingEmployees.Any(e => e.Code == emp.Code);
            bool isDuplicateLogin = existingEmployees.Any(e => e.LoginId == emp.LoginId);

            if (isDuplicateCode || isDuplicateLogin)
            {
                string dupMsg = isDuplicateCode ? "이미 존재하는 사원코드입니다."
                    : "이미 존재하는 로그인ID입니다.";

                MessageBox.Show(dupMsg, "중복 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 중복이면 저장 중단
            }

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
