using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.Models
{
    public class DepartmentWorkout
    {
        public int DepartmentId { get; set; }
        [DisplayName("부서코드")]
        public string DepartmentCode { get; set; }
        [DisplayName("부서명")]
        public string DepartmentName { get; set; }
        [DisplayName("메모")]
        public string Memo { get; set; }

        public override string ToString()
        {
            return DepartmentCode;
        }
    }
}
