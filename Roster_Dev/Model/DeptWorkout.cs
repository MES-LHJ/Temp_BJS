using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_Dev.Model
{
    public class DeptWorkout
    {
        public long UpperDepartmentId { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Memo { get; set; }
        public override string ToString()
        {
            return DepartmentCode; // ComboBoxEdit이나 ComboBox에 표시될 값
        }
    }
}
