using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster.Models
{
    internal class DepartmentValue
    {
        public static DepartmentWorkout FromDataRow(DataRow row)
        {
            return new DepartmentWorkout
            {
                DepartmentCode = row["DepartmentCode"]?.ToString(),
                DepartmentName = row["DepartmentName"]?.ToString(),
                Memo           = row["Memo"]?.ToString()
            };
        }

        public static DepartmentWorkout FromGridRow(DataGridViewRow row)
        {
            return new DepartmentWorkout
            {
                DepartmentCode = row.Cells["DepartmentCode"].Value?.ToString(),
                DepartmentName = row.Cells["DepartmentName"].Value?.ToString(),
                Memo           = row.Cells["Memo"].Value?.ToString()
            };
        }

        public static void InsertDepartment(DepartmentWorkout model)
        {
            SqlRepository.InsertDepartment(
                model.DepartmentCode,
                model.DepartmentName,
                model.Memo);
        }

        public static void UpdateDepartment(DepartmentWorkout model)
        {
            SqlRepository.UpdateDepartment(
                model.DepartmentCode,
                model.DepartmentName,
                model.Memo);
        }

        public static void DeleteDepartment(string departmentCode)
        {
            if(string.IsNullOrEmpty(departmentCode)) return;
            SqlRepository.DeleteDepartment(departmentCode);
        }

        public static List<DepartmentWorkout> GetAll()
        {
            var datatable = SqlRepository.GetDepartment();
            return datatable.AsEnumerable().Select(DepartmentValue.FromDataRow).ToList();
        }

        public static DepartmentWorkout FromFormConstrols(DepartmentAddEdit form)
        {
            return new DepartmentWorkout
            {
                DepartmentCode = form.PartCode.Text.Trim(),
                DepartmentName = form.DepartName.Text.Trim(),
                Memo           = form.Memo.Text.Trim()
            };
        }

    }
}
