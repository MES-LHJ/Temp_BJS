using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster
{
    public class RosterWorkout
    {
        public long Id { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string ID { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Employment { get; set; }
        public RosterAdd.Gender Gender { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string MessengerID { get; set; }
        public string Memo { get; set; }
    }
}
