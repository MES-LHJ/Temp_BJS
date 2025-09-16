using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_Dev.Model
{
    internal class DeptWorkout
    {
        public long UpperDepartmentId { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Memo { get; set; }
    }
}
