using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Roster_Dev.Model
{
    public class UpperDeptWorkout
    {
        public long ParentId { get; set; } = 0;
        public long UpperDepartmentId { get; set; }
        public string UpperDepartmentCode { get; set; }
        public string UpperDepartmentName { get; set; }
        public string Memo { get; set; }
        public override string ToString()
        {
            return UpperDepartmentCode; // ComboBoxEdit이나 ComboBox에 표시될 값
        }
    }
}
