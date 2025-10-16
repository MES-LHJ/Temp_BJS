using DevExpress.XtraCharts.Native;
using Roster_Dev.UtilClass;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_Dev.Model
{
    public class EmpWorkout
    {
        public long Id { get; set; }
        public long FactotyId { get; set; }
        public long UpperDeppartmentId { get; set; }
        public long DepartmentId { get; set; }
        public long EmployeeId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Employment { get; set; }
        public Util.Gender? Gender { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string MessengerId { get; set; }
        public string Memo { get; set; }
        public string PhotoPath { get; set; }
    }
}
