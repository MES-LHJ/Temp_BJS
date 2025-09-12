using DevExpress.XtraCharts.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster_Dev.Model
{
    public class Empworkout
    {
        //public long upperDptCode {  get; set; }
        public long dptCode { get; set; }
        public string empCode { get; set; }
        public string empName { get; set; }
        public string logiId { get; set; }
        public string password { get; set; }
        public string position { get; set; }
        public string employment { get; set; }
        public Emp.EmpAdd.Gender? gender { get; set; }
        public string phoneNum { get; set; }
        public string email { get; set; }
        public string messangerId { get; set; }
        public string memo { get; set; }
        public string photoPath {  get; set; }
    }
}
