using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Roster.RosterAdd;

namespace Roster
{
    public class RosterWorkout
    {
        public long DepartmentId { get; set; }
        public long EmployeeId { get; set; }
        [DisplayName("부서코드")]
        public string DepartmentCode { get; set; }
        [DisplayName("부서명")]
        public string DepartmentName { get; set; }
        [DisplayName("사원코드")]
        public string EmployeeCode { get; set; }
        [DisplayName("사원명")]
        public string EmployeeName { get; set; }
        [DisplayName("아이디")]
        public string ID { get; set; }
        [DisplayName("비밀번호")]
        public string Password { get; set; }
        [DisplayName("직급")]
        public string Position { get; set; }
        [DisplayName("고용형태")]
        public string Employment { get; set; }
        [DisplayName("성별")]
        public RosterAdd.Gender? Gender { get; set; }
        [DisplayName("전화번호")]
        public string PhoneNum { get; set; }
        [DisplayName("이메일")]
        public string Email { get; set; }
        [DisplayName("메신저ID")]
        public string MessengerID { get; set; }
        [DisplayName("메모")]
        public string Memo { get; set; }
        [DisplayName("사원이미지")]
        public string PhotoPath { get; set; }

        public static RosterWorkout DataRow(DataRow row)
        {
            return new RosterWorkout
            {
                EmployeeId = Convert.ToInt32(row[nameof(RosterWorkout.EmployeeId)]),
                DepartmentId = Convert.ToInt32(row[nameof(RosterWorkout.DepartmentId)]),
                DepartmentCode = row[nameof(RosterWorkout.DepartmentCode)].ToString(),
                DepartmentName = row[nameof(RosterWorkout.DepartmentName)].ToString(),
                EmployeeCode = row[nameof(RosterWorkout.EmployeeCode)].ToString(),
                EmployeeName = row[nameof(RosterWorkout.EmployeeName)].ToString(),
                ID = row[nameof(RosterWorkout.ID)].ToString(),
                Password = row[nameof(RosterWorkout.Password)].ToString(),
                Position = row[nameof(RosterWorkout.Position)].ToString(),
                Employment = row[nameof(RosterWorkout.Employment)].ToString(),
                Gender = row[nameof(RosterWorkout.Gender)] == DBNull.Value ? 
                                        (RosterAdd.Gender?)null : row[nameof(RosterWorkout.Gender)].ToString() == "Male" ? 
                                        RosterAdd.Gender.Male : RosterAdd.Gender.Female,
                //Gender = row[nameof(RosterWorkout.Gender)].ToString() == "Male" ? RosterAdd.Gender.Male : row[nameof(RosterWorkout.Gender)].ToString() == "Female" ? RosterAdd.Gender.Female : (RosterAdd.Gender?)null,
                PhoneNum = row[nameof(RosterWorkout.PhoneNum)].ToString(),
                Email = row[nameof(RosterWorkout.Email)].ToString(),
                MessengerID = row[nameof(RosterWorkout.MessengerID)].ToString(),
                Memo = row[nameof(RosterWorkout.Memo)].ToString(),
                PhotoPath = row[nameof(RosterWorkout.PhotoPath)].ToString()
            };
        }

    }
}
