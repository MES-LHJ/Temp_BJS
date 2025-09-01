using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster
{
    public class RosterWorkout
    {
        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
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
        public RosterAdd.Gender Gender { get; set; }
        [DisplayName("전화번호")]
        public string PhoneNum { get; set; }
        [DisplayName("이메일")]
        public string Email { get; set; }
        [DisplayName("메신저ID")]
        public string MessengerID { get; set; }
        [DisplayName("메모")]
        public string Memo { get; set; }
    }
}
