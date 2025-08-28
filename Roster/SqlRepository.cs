using Roster.Models;
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

        // 부서 Insert
        public static int InsertDepartment(string partCode, string departmentName, string memo)
        {
            const string sql = @"
                IF EXISTS (
                    SELECT 1 FROM dbo.Department 
                    WHERE DepartmentCode = @DepartmentCode)
                BEGIN
                    RAISERROR('이미 존재하는 부서 코드입니다.', 16, 1);
                    RETURN;
                END

                IF EXISTS (
                    SELECT 1 FROM dbo.Department 
                    WHERE DepartmentName = @DepartmentName)
                BEGIN
                    RAISERROR('이미 존재하는 부서명입니다.', 16, 1);
                    RETURN;
                END

               INSERT INTO dbo.Department (DepartmentCode, DepartmentName, Memo)
                VALUES (@DepartmentCode, @DepartmentName, @Memo);
            ";

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

        // 부서 Update
        public static int UpdateDepartment(string partCode, string departmentName, string memo)
        {
            const string sql = @"
                IF EXISTS (
                    SELECT 1 FROM dbo.Department 
                    WHERE DepartmentCode = @NewDepartmentCode
                        AND DepartmentCode <> @OldDepartmentCode)
                BEGIN

                    RAISERROR('이미 존재하는 부서 코드입니다.', 16, 1);
                    RETURN;
                END

                IF EXISTS(
                    SELECT 1 FROM dbo.Department 
                    WHERE DepartmentName = @NewDepartmentName
                        AND DepartmentCode <> @OldDepartmentCode)
                BEGIN
                    RAISERROR('이미 존재하는 부서명입니다.', 16, 1);
                    RETURN;
                END

                UPDATE dbo.Department
                SET DepartmentCode = @NewDepartmentCode,
                    DepartmentName = @NewDepartmentName,
                    Memo = @Memo
                WHERE DepartmentCode = @OldDepartmentCode
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DepartmentCode", (object)partCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OldDepartmentCode", (object)partCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewDepartmentCode", (object)partCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentName", (object)departmentName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewDepartmentName", (object)departmentName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Memo", (object)memo ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 부서 Delete
        public static int DeleteDepartment(string departmentCode)
        {
            const string sql = @"DELETE FROM dbo.Department WHERE DepartmentCode = @DepartmentCode;";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DepartmentCode", (object)departmentCode ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 사원 Insert 
        public static int InsertEmployee(
            string partCode, string departmentName,
            string oldemployeeCode, string employeeName,
            string id, string password,
            string position, string employment, string gender,
            string phoneNum, string email, string messengerId, string memo)
        {
            const string sql = @"
            IF EXISTS (
                SELECT 1 FROM dbo.Employee 
                WHERE EmployeeCode = @EmployeeCode)

            BEGIN
                RAISERROR('이미 존재하는 사원 코드입니다.', 16, 1);
                RETURN;
            END

            IF EXISTS (
                SELECT 1 FROM dbo.Employee 
                WHERE [ID] = @ID)
            BEGIN
                RAISERROR('이미 존재하는 ID입니다.', 16, 1);
                RETURN;
            END
            IF EXISTS (
                SELECT 1 FROM dbo.Employee 
                WHERE PhoneNum = @PhoneNum)
            BEGIN
                RAISERROR('이미 존재하는 전화번호입니다.', 16, 1);
                RETURN;
            END
            IF EXISTS (
                SELECT 1 FROM dbo.Employee 
                WHERE Email = @Email)
            BEGIN
                RAISERROR('이미 존재하는 이메일입니다.', 16, 1);
                RETURN;
            END
            IF EXISTS (
                SELECT 1 FROM dbo.Employee
                WHERE MessengerID = @MessengerID)
            BEGIN
                RAISERROR('이미 존재하는 메신저ID입니다.', 16, 1);
                RETURN;
            END

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
            string partCode, string departmentName,
            string employeeCode, string employeeName,
            string position, string employment, string gender,
            string phoneNum, string email, string messengerId, string memo)
        {
            const string sql = @"
            IF EXISTS (
                SELECT 1 FROM dbo.Employee
                WHERE EmployeeCode = @NewEmployeeCode
                    AND EmployeeCode <> @OldEmployeeCode)
            BEGIN
                RAISERROR('이미 존재하는 사원 코드입니다.', 16, 1);
                RETURN;
            END

            IF EXISTS (
                SELECT 1 FROM dbo.Employee 
                WHERE Email = @NewEmail
                    AND EmployeeCode <> @OldEmployeeCode)
            BEGIN
                RAISERROR('이미 존재하는 이메일입니다.', 16, 1);
                RETURN;
            END

            IF EXISTS (
                SELECT 1 FROM dbo.Employee 
                WHERE PhoneNum = @NewPhoneNum
                    AND EmployeeCode <> @OldEmployeeCode)
            BEGIN
                RAISERROR('이미 존재하는 전화번호입니다.', 16, 1);
                RETURN;
            END

            IF EXISTS (
                SELECT 1 FROM dbo.Employee
                WHERE MessengerID = @NewMessengerID
                    AND EmployeeCode <> @OldEmployeeCode)
            BEGIN
                RAISERROR('이미 존재하는 메신저ID입니다.', 16, 1);
                RETURN;
            END

            UPDATE e
            SET e.DepartmentId = d.DepartmentId,
                e.DepartmentCode = @DepartmentCode,
                e.DepartmentName = @DepartmentName,
                e.EmployeeCode = @NewEmployeeCode,
                e.EmployeeName = @EmployeeName,
                e.[Position] = @Position,
                e.Form_of_employment = @Employment,
                e.Gender = @Gender,
                e.PhoneNum = @NewPhoneNum,
                e.Email = @NewEmail,
                e.MessengerID = @NewMessengerID,
                e.Memo = @Memo
            FROM dbo.Employee AS e
            JOIN dbo.Department AS d ON d.DepartmentCode = @DepartmentCode
            WHERE e.EmployeeCode = @OldEmployeeCode;";

            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@DepartmentCode", (object)partCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentName", (object)departmentName ?? DBNull.Value);
                //cmd.Parameters.AddWithValue("@EmployeeCode", (object)employeeCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewEmployeeCode", (object)employeeCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@OldEmployeeCode", (object)employeeCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeName", (object)employeeName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Position", (object)position ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Employment", (object)employment ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", (object)gender ?? DBNull.Value);
                //cmd.Parameters.AddWithValue("@PhoneNum", (object)phoneNum ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewPhoneNum", (object)phoneNum ?? DBNull.Value);
                //cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewEmail", (object)email ?? DBNull.Value);
                //cmd.Parameters.AddWithValue("@MessengerID", (object)messengerId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NewMessengerID", (object)messengerId ?? DBNull.Value);
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

        public static DataTable GetDepartment()
        {
            const string sql = @"
                SELECT DepartmentCode, 
                DepartmentName, 
                Memo FROM dbo.Department";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static List<DepartmentWorkout> GetDepartments()
        {
            const string sql = "SELECT DepartmentCode, DepartmentName, Memo FROM dbo.Department";
            var list = new List<DepartmentWorkout>();
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DepartmentWorkout
                        {
                            DepartmentCode = reader["DepartmentCode"].ToString(),
                            DepartmentName = reader["DepartmentName"].ToString(),
                            Memo = reader["Memo"].ToString()
                        }
                            );
                    }
                }
            }
            return list;
        }
    }
}
