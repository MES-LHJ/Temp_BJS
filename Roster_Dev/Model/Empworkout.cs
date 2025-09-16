using DevExpress.XtraCharts.Native;
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
        public long DeptId { get; set; }
        public long EmpId { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Employment { get; set; }
        public Emp.EmpAdd.Gender? Gender { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string MessangerId { get; set; }
        public string Memo { get; set; }
        public string PhotoPath { get; set; }
    }
}
