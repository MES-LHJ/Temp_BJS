using DevExpress.Xpo.DB;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_Dev.Model
{
    public class DepartmentWorkout
    {
        public long Id { get; set; }
        public long FactoryId { get; set; }
        public string FactoryCode { get; set; }
        public string FactoryName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Memo { get; set; }
        public long? UpperDepartmentId { get; set; }
        public string UpperDepartmentCode { get; set; }
        public string UpperDepartmentName { get; set; }
        public override string ToString()
        {
                return Code;
        }
    }

    public class UpperDepartmentWorkout
    {
        public long Id { get; set; }
        public long FactoryId { get; set; }
        public string FactoryCode { get; set; }
        public string FactoryName { get; set; }
        public long? UpperDepartmentId { get; set; }
        public string UpperDepartmentCode { get; set; }
        public string UpperDepartmentName { get; set; }
        public string Memo { get; set; }
        public override string ToString()
        {
            return FactoryCode;
        }
    }

    public class DepartmentResponse
    {
        public List<DepartmentWorkout> Data { get; set; }
        public string Error { get; set; }
    }

    public class UpperDepartmentDto 
    {
        public long Id { get; set; }
        public string FactoryCode { get; set; }
        public string FactoryName { get; set; }
    }
}
