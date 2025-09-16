using Roster_Dev.Emp;
using Roster_Dev.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_Dev
{
    public static class Repetition
    {
        public static void AddValue(this SqlCommand cmd, string name, object value)
        {
            cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
        }
        public static object DbNull(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? (object)DBNull.Value : value;
        }
    }
    internal class SqlReposit
    {
        private const string CS = @"Server=DESKTOP-6VSVCKC\JSTESTSERVER;database=EmpDB;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        /// <summary>
        /// 상위부서추가
        /// </summary>
        /// <param name="dpt"></param>
        /// <returns></returns>
        public static int InsertUpperDept(UpperDeptWorkout dpt)
        {
            const string sql = @"
                            IF EXISTS (SELECT 1 FROM dbo.UpperDepartment WHERE UpperDepartmentCode = @UpperDepartmentCode)
                            BEGIN
                                RAISERROR('이미 존재하는 코드입니다.', 16, 1);
                                RETURN;
                            END
                            IF EXISTS (SELECT 1 FROM dbo.UpperDepartment WHERE UpperDepartmentName = @UpperDepartmentName)
                            BEGIN
                                RAISERROR('이미 존재하는 부서명입니다.', 16, 1);
                                RETURN;
                            END
                            INSERT INTO dbo.UpperDepartment (UpperDepartmentCode, UpperDepartmentName, Memo)
                            VALUES (@UpperDepartmentCode, @UpperDepartmentName, @Memo);
            ";

            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(UpperDeptWorkout.UpperDepartmentCode)}", dpt.UpperDepartmentCode);
                cmd.AddValue($"@{nameof(UpperDeptWorkout.UpperDepartmentName)}", dpt.UpperDepartmentName);
                cmd.AddValue($"@{nameof(UpperDeptWorkout.Memo)}", dpt.Memo.DbNull());

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 상위부서수정
        /// </summary>
        /// <param name="dpt"></param>
        /// <returns></returns>
        public static int UpdateUpperDept(UpperDeptWorkout dpt)
        {
            const string sql = @"
                            IF EXISTS (SELECT 1 FROM dbo.UpperDepartment WHERE UpperDepartmentCode = @UpperDepartmentCode AND UpperDepartmentId != @UpperDepartmentId)
                            BEGIN
                                RAISERROR('이미 존재하는 코드입니다.', 16, 1);
                                RETURN;
                            END
                            IF EXISTS (SELECT 1 FROM dbo.UpperDepartment WHERE UpperDepartmentName = @UpperDepartmentName AND UpperDepartmentId != @UpperDepartmentId)
                            BEGIN
                                RAISERROR('이미 존재하는 부서명입니다.', 16, 1);
                                RETURN;
                            END
                            UPDATE dbo.UpperDepartment
                            SET UpperDepartmentCode = @UpperDepartmentCode,
                                UpperDepartmentName = @UpperDepartmentName,
                                Memo = @Memo
                            WHERE UpperDepartmentId = @UpperDepartmentId;
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(UpperDeptWorkout.UpperDepartmentId)}", dpt.UpperDepartmentId);
                cmd.AddValue($"@{nameof(UpperDeptWorkout.UpperDepartmentCode)}", dpt.UpperDepartmentCode);
                cmd.AddValue($"@{nameof(UpperDeptWorkout.UpperDepartmentName)}", dpt.UpperDepartmentName);
                cmd.AddValue($"@{nameof(UpperDeptWorkout.Memo)}", dpt.Memo.DbNull());

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 상위부서삭제
        /// </summary>
        /// <param name="upperDepartmentId"></param>
        /// <returns></returns>
        public static int DeleteUpperDept(string upperDepartmentId)
        {
            const string sql = @"
                            IF EXISTS (SELECT 1 FROM dbo.Department WHERE UpperDepartmentId = @UpperDepartmentId)
                            BEGIN
                                RAISERROR('하위 부서가 존재하여 삭제할 수 없습니다.', 16, 1);
                                RETURN;
                            END
                            DELETE FROM dbo.UpperDepartment
                            WHERE UpperDepartmentId = @UpperDepartmentId;
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(UpperDeptWorkout.UpperDepartmentId)}", upperDepartmentId);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 부서추가
        /// </summary>
        /// <param name="dpt"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DeptWorkout InsertDept(DeptWorkout dpt)
        {
            const string sql = @"
                            IF EXISTS (SELECT 1 FROM dbo.Department WHERE DepartmentCode = @DepartmentCode)
                            BEGIN
                                RAISERROR('이미 존재하는 코드입니다.', 16, 1);
                                RETURN;
                            END
                            IF EXISTS (SELECT 1 FROM dbo.Department WHERE DepartmentName = @DepartmentName)
                            BEGIN
                                RAISERROR('이미 존재하는 부서명입니다.', 16, 1);
                                RETURN;
                            END
                            INSERT INTO dbo.Department (UpperDepartmentId, DepartmentCode, DepartmentName, Memo)
                            OUTPUT INSERTED.UpperDepartmentId, INSERTED.DepartmentId, INSERTED.DepartmentCode, INSERTED.DepartmentName, INSERTED.Memo
                            VALUES (@UpperDepartmentId, @DepartmentCode, @DepartmentName, @Memo);
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(DeptWorkout.UpperDepartmentId)}", dpt.UpperDepartmentId);
                cmd.AddValue($"@{nameof(DeptWorkout.DepartmentCode)}", dpt.DepartmentCode);
                cmd.AddValue($"@{nameof(DeptWorkout.DepartmentName)}", dpt.DepartmentName);
                cmd.AddValue($"@{nameof(DeptWorkout.Memo)}", dpt.Memo.DbNull());
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DeptWorkout
                        {
                            UpperDepartmentId = Convert.ToInt32(reader[nameof(DeptWorkout.UpperDepartmentId)]),
                            DepartmentId = Convert.ToInt32(reader[nameof(DeptWorkout.DepartmentId)]),
                            DepartmentCode = reader[nameof(DeptWorkout.DepartmentCode)].ToString(),
                            DepartmentName = reader[nameof(DeptWorkout.DepartmentName)].ToString(),
                            Memo = reader[nameof(DeptWorkout.Memo)] as string
                        };
                    }
                    else
                    {
                        throw new Exception("부서 추가에 실패했습니다.");
                    }
                }
            }
        }

        /// <summary>
        /// 부서수정
        /// </summary>
        /// <param name="dpt"></param>
        /// <returns></returns>
        public static int UpdateDept(DeptWorkout dpt)
        {
            const string sql = @"
                            IF EXISTS (SELECT 1 FROM dbo.Department WHERE DepartmentCode = @DepartmentCode AND DepartmentId != @DepartmentId)
                            BEGIN
                                RAISERROR('이미 존재하는 코드입니다.', 16, 1);
                                RETURN;
                            END
                            IF EXISTS (SELECT 1 FROM dbo.Department WHERE DepartmentName = @DepartmentName AND DepartmentId != @DepartmentId)
                            BEGIN
                                RAISERROR('이미 존재하는 부서명입니다.', 16, 1);
                                RETURN;
                            END
                            UPDATE dbo.Department
                            SET UpperDepartmentId = @UpperDepartmentId,
                                DepartmentCode = @DepartmentCode,
                                DepartmentName = @DepartmentName,
                                Memo = @Memo
                            WHERE DepartmentId = @DepartmentId;
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(DeptWorkout.UpperDepartmentId)}", dpt.UpperDepartmentId);
                cmd.AddValue($"@{nameof(DeptWorkout.DepartmentId)}", dpt.DepartmentId);
                cmd.AddValue($"@{nameof(DeptWorkout.DepartmentCode)}", dpt.DepartmentCode);
                cmd.AddValue($"@{nameof(DeptWorkout.DepartmentName)}", dpt.DepartmentName);
                cmd.AddValue($"@{nameof(DeptWorkout.Memo)}", dpt.Memo.DbNull());
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 부서삭제
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public static int DeleteDept(string departmentId)
        {
            const string sql = @"
                            IF EXISTS (SELECT 1 FROM dbo.Employee WHERE DeptId = @DepartmentId)
                            BEGIN
                                RAISERROR('해당 부서에 소속된 사원이 존재하여 삭제할 수 없습니다.', 16, 1);
                                RETURN;
                            END
                            DELETE FROM dbo.Department
                            WHERE DepartmentId = @DepartmentId;
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(DeptWorkout.DepartmentId)}", departmentId);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int InsertEmp(EmpWorkout emp)
        {
            const string sql = @"
                            IF EXISTS (SELECT 1 FROM dbo.Employee WHERE EmpCode = @EmpCode)
                            BEGIN
                                RAISERROR('이미 존재하는 사원코드입니다.', 16, 1);
                                RETURN;
                            END
                            IF EXISTS (SELECT 1 FROM dbo.Employee WHERE LoginId = @LoginId)
                            BEGIN
                                RAISERROR('이미 존재하는 로그인ID입니다.', 16, 1);
                                RETURN;
                            END
                            INSERT INTO dbo.Employee (DeptId, EmpCode, EmpName, LoginId, Password, Position, Employment,
                                Gender, PhoneNum, Email, MessangerId, Memo, PhotoPath)
                            VALUES (@DeptId, @EmpCode, @EmpName, @LoginId, @Password, @Position, @Employment,
                                @Gender, @PhoneNum, @Email, @MessangerId, @Memo, @PhotoPath);
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(EmpWorkout.DeptId)}", emp.DeptId);
                cmd.AddValue($"@{nameof(EmpWorkout.EmpCode)}", emp.EmpCode);
                cmd.AddValue($"@{nameof(EmpWorkout.EmpName)}", emp.EmpName);
                cmd.AddValue($"@{nameof(EmpWorkout.LoginId)}", emp.LoginId);
                cmd.AddValue($"@{nameof(EmpWorkout.Password)}", emp.Password);
                cmd.AddValue($"@{nameof(EmpWorkout.Position)}", emp.Position);
                cmd.AddValue($"@{nameof(EmpWorkout.Employment)}", emp.Employment);
                cmd.AddValue($"@{nameof(EmpWorkout.Gender)}", emp.Gender.ToString());
                cmd.AddValue($"@{nameof(EmpWorkout.PhoneNum)}", emp.PhoneNum.DbNull());
                cmd.AddValue($"@{nameof(EmpWorkout.Email)}", emp.Email.DbNull());
                cmd.AddValue($"@{nameof(EmpWorkout.MessangerId)}", emp.MessangerId.DbNull());
                cmd.AddValue($"@{nameof(EmpWorkout.Memo)}", emp.Memo.DbNull());
                cmd.AddValue($"@{nameof(EmpWorkout.PhotoPath)}", emp.PhotoPath.DbNull());
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int UpdateEmp(EmpWorkout emp)
        {
            const string sql = @"
                            IF EXISTS (SELECT 1 FROM dbo.Employee WHERE EmpCode = @EmpCode AND EmpId != @EmpId)
                            BEGIN
                                RAISERROR('이미 존재하는 사원코드입니다.', 16, 1);
                                RETURN;
                            END
                            IF EXISTS (SELECT 1 FROM dbo.Employee WHERE LoginId = @LoginId AND EmpId != @EmpId)
                            BEGIN
                                RAISERROR('이미 존재하는 로그인ID입니다.', 16, 1);
                                RETURN;
                            END
                            UPDATE dbo.Employee
                            SET DeptId = @DeptId,
                                EmpCode = @EmpCode,
                                EmpName = @EmpName,
                                LoginId = @LoginId,
                                Password = @Password,
                                Position = @Position,
                                Employment = @Employment,
                                Gender = @Gender,
                                PhoneNum = @PhoneNum,
                                Email = @Email,
                                MessangerId = @MessangerId,
                                Memo = @Memo,
                                PhotoPath = @PhotoPath
                            WHERE EmpId = @EmpId;
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(EmpWorkout.DeptId)}", emp.DeptId);
                cmd.AddValue($"@{nameof(EmpWorkout.EmpId)}", emp.EmpId);
                cmd.AddValue($"@{nameof(EmpWorkout.EmpCode)}", emp.EmpCode);
                cmd.AddValue($"@{nameof(EmpWorkout.EmpName)}", emp.EmpName);
                cmd.AddValue($"@{nameof(EmpWorkout.LoginId)}", emp.LoginId);
                cmd.AddValue($"@{nameof(EmpWorkout.Password)}", emp.Password);
                cmd.AddValue($"@{nameof(EmpWorkout.Position)}", emp.Position);
                cmd.AddValue($"@{nameof(EmpWorkout.Employment)}", emp.Employment);
                cmd.AddValue($"@{nameof(EmpWorkout.Gender)}", emp.Gender.ToString());
                cmd.AddValue($"@{nameof(EmpWorkout.PhoneNum)}", emp.PhoneNum.DbNull());
                cmd.AddValue($"@{nameof(EmpWorkout.Email)}", emp.Email.DbNull());
                cmd.AddValue($"@{nameof(EmpWorkout.MessangerId)}", emp.MessangerId.DbNull());
                cmd.AddValue($"@{nameof(EmpWorkout.Memo)}", emp.Memo.DbNull());
                cmd.AddValue($"@{nameof(EmpWorkout.PhotoPath)}", emp.PhotoPath.DbNull());
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static int DeleteEmp(long empId)
        {
            const string sql = @"
                            DELETE FROM dbo.Employee
                            WHERE EmpId = @EmpId;
            ";
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.AddValue($"@{nameof(EmpWorkout.EmpId)}", empId);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static List<UpperDeptWorkout> GetUpperDepartments()
        {
            const string sql = @"
                            SELECT UpperDepartmentId, UpperDepartmentCode, UpperDepartmentName, Memo
                            FROM dbo.UpperDepartment;
            ";
            var list = new List<UpperDeptWorkout>();
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UpperDeptWorkout
                        {
                            UpperDepartmentId = Convert.ToInt32(reader[nameof(UpperDeptWorkout.UpperDepartmentId)]),
                            UpperDepartmentCode = reader[nameof(UpperDeptWorkout.UpperDepartmentCode)].ToString(),
                            UpperDepartmentName = reader[nameof(UpperDeptWorkout.UpperDepartmentName)].ToString(),
                            Memo = reader[nameof(UpperDeptWorkout.Memo)] as string
                        });
                    }
                }
            }
            return list;
        }

        public static List<DeptWorkout> GetDepartments()
        {
            const string sql = @"
                            SELECT UpperDepartmentId, DepartmentId, DepartmentCode, DepartmentName, Memo
                            FROM dbo.Department;
            ";
            var list = new List<DeptWorkout>();
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DeptWorkout
                        {
                            UpperDepartmentId = Convert.ToInt32(reader[nameof(DeptWorkout.UpperDepartmentId)]),
                            DepartmentId = Convert.ToInt32(reader[nameof(DeptWorkout.DepartmentId)]),
                            DepartmentCode = reader[nameof(DeptWorkout.DepartmentCode)].ToString(),
                            DepartmentName = reader[nameof(DeptWorkout.DepartmentName)].ToString(),
                            Memo = reader[nameof(DeptWorkout.Memo)] as string
                        });
                    }
                }
            }
            return list;
        }

        public static List<EmpWorkout> GetEmployees()
        {
            const string sql = @"
                            SELECT e.DeptId, d.DeptCode,d.DeptName, e.EmpId, e.EmpCode, e.EmpName, e.LoginId, e.Password, e.Position, e.Employment,
                                   e.Gender, e.PhoneNum, e.Email, e.MessangerId, e.Memo, e.PhotoPath FROM dbo.Employee e
                            JOIN dbo.Department d ON e.DeptId = d.DepartmentId;
            ";
            var list = new List<EmpWorkout>();
            using (var conn = new SqlConnection(CS))
            using (var cmd = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new EmpWorkout
                        {
                            DeptId = Convert.ToInt32(reader[nameof(EmpWorkout.DeptId)]),
                            EmpId = Convert.ToInt32(reader[nameof(EmpWorkout.EmpId)]),
                            EmpCode = reader[nameof(EmpWorkout.EmpCode)].ToString(),
                            EmpName = reader[nameof(EmpWorkout.EmpName)].ToString(),
                            LoginId = reader[nameof(EmpWorkout.LoginId)].ToString(),
                            Password = reader[nameof(EmpWorkout.Password)].ToString(),
                            Position = reader[nameof(EmpWorkout.Position)].ToString(),
                            Employment = reader[nameof(EmpWorkout.Employment)].ToString(),
                            Gender = reader[nameof(EmpWorkout.Gender)] == DBNull.Value ? 
                                    (EmpAdd.Gender?)null : reader[nameof(EmpWorkout.Gender)].ToString() == "Male" ? 
                                    EmpAdd.Gender.Male : EmpAdd.Gender.Female,
                            PhoneNum = reader[nameof(EmpWorkout.PhoneNum)].ToString(),
                            Email = reader[nameof(EmpWorkout.Email)].ToString(),
                            MessangerId = reader[nameof(EmpWorkout.MessangerId)].ToString(),
                            Memo = reader[nameof(EmpWorkout.Memo)].ToString(),
                            PhotoPath = reader[nameof(EmpWorkout.PhotoPath)].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
