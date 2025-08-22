using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster
{
    internal class SqlRepository
    {
        private const string CS = "Server=DESKTOP-6VSVCKC\\JSTESTSERVER;Database=WorkTestDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        // 부서 Upsert (코드 기준)
        public static int UpsertDepartment(string partCode, string departmentName, string memo)
        {
            const string sql = @"
            MERGE dbo.Department AS T
            USING (SELECT @DepartmentCode AS DepartmentCode,
                          @DepartmentName AS DepartmentName,
                          @Memo AS Memo) AS S
            ON (T.DepartmentCode = S.DepartmentCode)
            WHEN MATCHED THEN
              UPDATE SET T.DepartmentName = S.DepartmentName,
                         T.Memo = S.Memo
            WHEN NOT MATCHED THEN
              INSERT (DepartmentCode, DepartmentName, Memo)
              VALUES (S.DepartmentCode, S.DepartmentName, S.Memo);";

            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DepartmentCode", (object)partCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentName", (object)departmentName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Memo", (object)memo ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 사원 Insert 
        public static int InsertEmployee(
            string partCode, string departmentName,
            string employeeCode, string employeeName,
            string id, string password,
            string position, string employment, string gender,
            string phoneNum, string email, string messengerId, string memo)
        {
            const string sql = @"
            INSERT INTO dbo.Employee
            ( DepartmentId, DepartmentCode, DepartmentName, EmployeeCode, EmployeeName, [ID], [Password],
              [Position], Form_of_employment, Gender, PhoneNum, Email, MessengerID, Memo )
            SELECT
              d.DepartmentId, @DepartmentCode, @DepartmentName,
              @EmployeeCode, @EmployeeName, @ID, @Password,
              @Position, @Employment, @Gender, @PhoneNum, @Email, @MessengerID, @Memo
            FROM dbo.Department AS d
            WHERE d.DepartmentCode = @DepartmentCode;";

            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DepartmentCode", (object)partCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentName", (object)departmentName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeCode", (object)employeeCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeName", (object)employeeName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ID", (object)id ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Password", (object)password ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Position", (object)position ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Employment", (object)employment ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", (object)gender ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNum", (object)phoneNum ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MessengerID", (object)messengerId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Memo", (object)memo ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 사원 Update (사원코드 기준)
        public static int UpdateEmployee(
            string employeeCode, string departmentName,
            string partCode, string employeeName,
            string position, string employment, string gender,
            string phoneNum, string email, string messengerId, string memo)
        {
            const string sql = @"
            UPDATE e
            SET e.DepartmentId = d.DepartmentId,
                e.DepartmentCode = @DepartmentCode,
                e.DepartmentName = @DepartmentName,
                e.EmployeeCode = @EmployeeCode,
                e.EmployeeName = @EmployeeName,
                e.[Position] = @Position,
                e.Form_of_employment = @Employment,
                e.Gender = @Gender,
                e.PhoneNum = @PhoneNum,
                e.Email = @Email,
                e.MessengerID = @MessengerID,
                e.Memo = @Memo
            FROM dbo.Employee AS e
            JOIN dbo.Department AS d ON d.DepartmentCode = @DepartmentCode
            WHERE e.EmployeeCode = @EmployeeCode;";

            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DepartmentCode", (object)partCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentName", (object)departmentName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeCode", (object)employeeCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeName", (object)employeeName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Position", (object)position ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Employment", (object)employment ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", (object)gender ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNum", (object)phoneNum ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MessengerID", (object)messengerId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Memo", (object)memo ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 사원 Delete (사원코드 기준)
        public static int DeleteEmployeeByCode(string employeeCode)
        {
            const string sql = @"DELETE FROM dbo.Employee WHERE EmployeeCode = @EmployeeCode;";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeCode", (object)employeeCode ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static DataTable GetEmployeeWithDepartment()
        {
            const string sql = @"
        SELECT 
            d.DepartmentCode,
            d.DepartmentName,
            e.EmployeeCode,
            e.EmployeeName,
            e.ID,
            e.Password,
            e.Position,
            e.Form_of_employment,
            e.Gender,
            e.PhoneNum,
            e.Email,
            e.MessengerID,
            e.Memo
        FROM dbo.Employee e
        JOIN dbo.Department d ON e.DepartmentId = d.DepartmentId";

            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static List<(string Code, string Name)> GetDepartments()
        {
            const string sql = "SELECT DepartmentCode, DepartmentName FROM dbo.Department";
            var list = new List<(string, string)>();
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add((reader["DepartmentCode"].ToString(), reader["DepartmentName"].ToString()));
                    }
                }
            }
            return list;
        }
    }
}
