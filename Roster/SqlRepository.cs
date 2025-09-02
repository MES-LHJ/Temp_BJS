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
    public static class Repetition
    {
        public static void AddValue(this SqlCommand cmd, string name, object value)
        {
            cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }
    }
    internal class SqlRepository
    {
        private const string CS = "Server=DESKTOP-6VSVCKC\\JSTESTSERVER;Database=WorkTestDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        //public static class SqlDepartConst
        //{
        //    public const string DepartmentId = "@DepartmentId";
        //    public const string DepartmentCode = "@DepartmentCode";
        //    public const string DepartmentName = "@DepartmentName";
        //    public const string Memo = "@Memo";
        //}

        //public static class SqlEmployeeConst
        //{
        //    public const string DepartmentId = "@DepartmentId";
        //    public const string EmployeeId = "@EmployeeId";
        //    public const string DepartmentCode = "@DepartmentCode";
        //    public const string DepartmentName = "@DepartmentName";
        //    public const string EmployeeCode = "@EmployeeCode";
        //    public const string EmployeeName = "@EmployeeName";
        //    public const string ID = "@ID";
        //    public const string Password = "@Password";
        //    public const string Position = "@Position";
        //    public const string Employment = "@Employment";
        //    public const string Gender = "@Gender";
        //    public const string PhoneNum = "@PhoneNum";
        //    public const string Email = "@Email";
        //    public const string MessengerID = "@MessengerID";
        //    public const string Memo = "@Memo";
        //}

        // 부서 조회
        public static DataTable LoadRoster()
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
                                 FROM dbo.Employee AS e " +
                                "JOIN dbo.Department AS d " +
                                "ON e.DepartmentId = d.DepartmentId ";

            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                //cmd.AddValue(SqlEmployeeConst.EmployeeId, model.EmployeeId);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


        /// <summary>
        /// 부서 Insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int InsertDepartment(DepartmentWorkout model)
        {
            // 부서 코드 및 부서명 중복 체크
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
                cmd.AddValue($"@{nameof(DepartmentWorkout.DepartmentId)}", model.DepartmentId);
                cmd.AddValue($"@{nameof(DepartmentWorkout.DepartmentCode)}", model.DepartmentCode);
                cmd.AddValue($"@{nameof(DepartmentWorkout.DepartmentName)}", model.DepartmentName);
                cmd.AddValue($"@{nameof(DepartmentWorkout.Memo)}", model.Memo);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 부서 Update
        public static int UpdateDepartment(DepartmentWorkout model)
        {
            const string sql = @"
                IF EXISTS (
                    SELECT 1 FROM dbo.Department 
                    WHERE DepartmentCode = @DepartmentCode
                        AND DepartmentId <> @DepartmentId)
                BEGIN
                    RAISERROR('이미 존재하는 부서 코드입니다.', 16, 1);
                    RETURN;
                END

                IF EXISTS(
                    SELECT 1 FROM dbo.Department 
                    WHERE DepartmentName = @DepartmentName
                        AND DepartmentId <> @DepartmentId)
                BEGIN
                    RAISERROR('이미 존재하는 부서명입니다.', 16, 1);
                    RETURN;
                END

                UPDATE dbo.Department
                SET DepartmentCode = @DepartmentCode,
                    DepartmentName = @DepartmentName,
                    Memo = @Memo
                WHERE DepartmentId = @DepartmentId
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(DepartmentWorkout.DepartmentId)}", model.DepartmentId);
                cmd.AddValue($"@{nameof(DepartmentWorkout.DepartmentCode)}", model.DepartmentCode);
                cmd.AddValue($"@{nameof(DepartmentWorkout.DepartmentName)}", model.DepartmentName);
                cmd.AddValue($"@{nameof(DepartmentWorkout.Memo)}", model.Memo);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 부서 Delete
        public static int DeleteDepartment(string departmentId)
        {
            const string sql = @"DELETE FROM dbo.Department WHERE DepartmentId = @DepartmentId;";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(DepartmentWorkout.DepartmentId)}", departmentId);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 사원 Insert 
        public static RosterWorkout InsertEmployee(RosterWorkout model)
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
            ( DepartmentId, DepartmentCode, EmployeeCode, EmployeeName, [ID], [Password],
              [Position], Form_of_employment, Gender, PhoneNum, Email, MessengerID, Memo )
            VALUES
            (@DepartmentId, @DepartmentCode, @EmployeeCode, @EmployeeName, @ID, @Password,
            @Position, @Employment, @Gender, @PhoneNum, @Email, @MessengerID, @Memo)
            ;";

            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(RosterWorkout.DepartmentId)}", model.DepartmentId);
                cmd.AddValue($"@{nameof(RosterWorkout.DepartmentCode)}", model.DepartmentCode);
                cmd.AddValue($"@{nameof(RosterWorkout.EmployeeId)}", model.EmployeeId);
                cmd.AddValue($"@{nameof(RosterWorkout.EmployeeCode)}", model.EmployeeCode);
                cmd.AddValue($"@{nameof(RosterWorkout.EmployeeName)}", model.EmployeeName);
                cmd.AddValue($"@{nameof(RosterWorkout.ID)}", model.ID);
                cmd.AddValue($"@{nameof(RosterWorkout.Password)}", model.Password);
                cmd.AddValue($"@{nameof(RosterWorkout.Position)}", model.Position);
                cmd.AddValue($"@{nameof(RosterWorkout.Employment)}", model.Employment);
                cmd.AddValue($"@{nameof(RosterWorkout.Gender)}", model.Gender);
                cmd.AddValue($"@{nameof(RosterWorkout.PhoneNum)}", model.PhoneNum);
                cmd.AddValue($"@{nameof(RosterWorkout.Email)}", model.Email);
                cmd.AddValue($"@{nameof(RosterWorkout.MessengerID)}", model.MessengerID);
                cmd.AddValue($"@{nameof(RosterWorkout.Memo)}", model.Memo);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            return model;
        }

        // 사원 Update
        public static int UpdateEmployee(RosterWorkout model)
        {
            const string sql = @"
            IF EXISTS (
                SELECT 1 FROM dbo.Employee
                WHERE EmployeeId = @EmployeeId
            BEGIN
                RAISERROR('이미 존재하는 사원 코드입니다.', 16, 1);
                RETURN;
            END

            IF EXISTS (
                SELECT 1 FROM dbo.Employee 
                WHERE Email = @Email
                    AND EmployeeId <> @EmployeeId)
            BEGIN
                RAISERROR('이미 존재하는 이메일입니다.', 16, 1);
                RETURN;
            END

            IF EXISTS (
                SELECT 1 FROM dbo.Employee 
                WHERE PhoneNum = @PhoneNum
                    AND EmployeeId <> @EmployeeId)
            BEGIN
                RAISERROR('이미 존재하는 전화번호입니다.', 16, 1);
                RETURN;
            END

            IF EXISTS (
                SELECT 1 FROM dbo.Employee
                WHERE MessengerID = @MessengerID
                    AND EmployeeId <> @EmployeeId)
            BEGIN
                RAISERROR('이미 존재하는 메신저ID입니다.', 16, 1);
                RETURN;
            END

            UPDATE e
            SET e.DepartmentId = @DepartmentId,
                e.EmployeeId = @EmployeeId,
                e.[Position] = @Position,
                e.Form_of_employment = @Employment,
                e.Gender = @Gender,
                e.PhoneNum = @PhoneNum,
                e.Email = @Email,
                e.MessengerID = @MessengerID,
                e.Memo = @Memo
            FROM dbo.Department AS d
            WHERE d.DepartmentId = @DepartmentId;";


            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(RosterWorkout.DepartmentId)}", model.DepartmentId);
                cmd.AddValue($"@{nameof(RosterWorkout.DepartmentCode)}", model.DepartmentCode);
                cmd.AddValue($"@{nameof(RosterWorkout.EmployeeCode)}", model.EmployeeCode);
                cmd.AddValue($"@{nameof(RosterWorkout.EmployeeName)}", model.EmployeeName);
                cmd.AddValue($"@{nameof(RosterWorkout.Position)}", model.Position);
                cmd.AddValue($"@{nameof(RosterWorkout.Employment)}", model.Employment);
                cmd.AddValue($"@{nameof(RosterWorkout.Gender)}", model.Gender);
                cmd.AddValue($"@{nameof(RosterWorkout.PhoneNum)}", model.PhoneNum);
                cmd.AddValue($"@{nameof(RosterWorkout.Email)}", model.Email);
                cmd.AddValue($"@{nameof(RosterWorkout.MessengerID)}", model.MessengerID);
                cmd.AddValue($"@{nameof(RosterWorkout.Memo)}", model.Memo);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // 사원 Delete
        public static int DeleteEmployee(string employeeId)
        {
            const string sql = @"DELETE FROM dbo.Employee WHERE EmployeeId = @EmployeeId;";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(RosterWorkout.EmployeeId)}", employeeId);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public static DataTable GetEmployeeWithDepartment()
        {
            const string sql = @"
        SELECT 
            d.DepartmentId,
            e.EmployeeId,
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

        //public static DataTable GetDepartment()
        //{
        //    const string sql = @"
        //                SELECT DepartmentCode, 
        //                DepartmentName, 
        //                Memo FROM dbo.Department";
        //    using (var conn = new SqlConnection(CS))
        //    using (var cmd = new SqlCommand(sql, conn))
        //    using (var da = new SqlDataAdapter(cmd))
        //    {
        //        var dt = new DataTable();
        //        da.Fill(dt);
        //        return dt;
        //    }
        //}

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
