using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster.Models
{
    internal class EmployeeValue
    {
        public static RosterWorkout FromDataRow(DataRow row)
        {
            return new RosterWorkout
            {
                DepartmentCode = int.TryParse(row["DepartmentCode"]?.ToString(), out var deptCode) ? deptCode : 0,
                DepartmentName = row["DepartmentName"]?.ToString(),
                EmployeeCode   = row["EmployeeCode"]?.ToString(),
                EmployeeName   = row["EmployeeName"]?.ToString(),
                ID             = row["ID"]?.ToString(),
                Password       = row["Password"]?.ToString(),
                Position       = row["Position"]?.ToString(),
                Employment     = row["Form_of_employment"]?.ToString(),
                Gender         = Enum.TryParse<RosterAdd.Gender>(row["Gender"]?.ToString(), out var g) ? g : RosterAdd.Gender.Male,
                PhoneNum       = row["PhoneNum"]?.ToString(),
                Email          = row["Email"]?.ToString(),
                MessengerID    = row["MessengerID"]?.ToString(),
                Memo           = row["Memo"]?.ToString()
            };
        }

        public static RosterWorkout FromGridRow(DataGridViewRow row)
        {
            return new RosterWorkout
            {
                DepartmentCode = Convert.ToInt32(row.Cells["DepartmentCode"].Value),
                DepartmentName = row.Cells["DepartmentName"].Value?.ToString(),
                EmployeeCode   = row.Cells["EmployeeCode"].Value?.ToString(),
                EmployeeName   = row.Cells["EmployeeName"].Value?.ToString(),
                ID             = row.Cells["ID"].Value?.ToString(),
                Password       = row.Cells["Password"].Value?.ToString(),
                Position       = row.Cells["Position"].Value?.ToString(),
                Employment     = row.Cells["Employment"].Value?.ToString(),
                Gender         = Enum.TryParse<RosterAdd.Gender>(row.Cells["Gender"].Value?.ToString(), out var g) ? g : RosterAdd.Gender.Male,
                PhoneNum       = row.Cells["PhoneNum"].Value?.ToString(),
                Email          = row.Cells["Email"].Value?.ToString(),
                MessengerID    = row.Cells["MessengerID"].Value?.ToString(),
                Memo           = row.Cells["Memo"].Value?.ToString()
            };
        }

        public static void InsertEmployee(RosterWorkout model)
        {
            SqlRepository.InsertEmployee(
                model.DepartmentCode,
                model.DepartmentName,
                model.EmployeeCode,
                model.EmployeeName,
                model.ID,
                model.Password,
                model.Position,
                model.Employment,
                model.Gender.ToString(),
                model.PhoneNum,
                model.Email,
                model.MessengerID,
                model.Memo
                );
        }

        public static void UpdateEmployee(RosterWorkout model)
        {
            SqlRepository.UpdateEmployee(
                model.EmployeeCode,
                model.EmployeeName,
                model.DepartmentCode,
                model.DepartmentName,
                model.Position,
                model.Employment,
                model.Gender.ToString(),
                model.PhoneNum,
                model.Email,
                model.MessengerID,
                model.Memo
            );
        }

        public static void ToFormControls(RosterWorkout model, RosterEdit form)
        {
            form.PartCode.Text = model.DepartmentCode.ToString();
            form.DepartName.Text = model.DepartmentName;
            form.EmployeeCo.Text   = model.EmployeeCode;
            form.EmployeeName.Text   = model.EmployeeName;
            form.Position.Text       = model.Position;
            form.Form_of_employment.Text     = model.Employment;
            form.Male.Checked      = model.Gender == RosterAdd.Gender.Male;
            form.Female.Checked    = model.Gender == RosterAdd.Gender.Female;
            form.PhoneNum.Text       = model.PhoneNum;
            form.Email.Text          = model.Email;
            form.MessengerId.Text    = model.MessengerID;
            form.Memo.Text           = model.Memo;
        }

        public static RosterWorkout FromFormControls(RosterAdd form)
        {
            return new RosterWorkout
            {
                DepartmentCode = int.TryParse(form.PartCode.Text, out var deptCode) ? deptCode : 0,
                DepartmentName = form.DepartName.Text,
                EmployeeCode   = form.EmployeeCode.Text,
                EmployeeName   = form.EmployeeName.Text,
                ID             = form.ID.Text,
                Password       = form.Pass.Text,
                Position       = form.Position.Text,
                Employment     = form.Form_of_employment.Text,
                Gender         = form.Male.Checked ? RosterAdd.Gender.Male : RosterAdd.Gender.Female,
                PhoneNum       = form.PhoneNum.Text,
                Email          = form.Email.Text,
                MessengerID    = form.MessengerId.Text,
                Memo           = form.Memo.Text
            };
        }

        public static RosterWorkout FromFormEditControls(RosterEdit form)
        {
            return new RosterWorkout
            {
                DepartmentCode = int.TryParse(form.PartCode.Text, out var deptCode) ? deptCode : 0,
                DepartmentName = form.DepartName.Text,
                EmployeeCode   = form.EmployeeCo.Text,
                EmployeeName   = form.EmployeeName.Text,
                Position       = form.Position.Text,
                Employment     = form.Form_of_employment.Text,
                Gender         = form.Male.Checked ? RosterAdd.Gender.Male : RosterAdd.Gender.Female,
                //Male = form.Male.Checked,
                //Female = form.Female.Checked,
                PhoneNum       = form.PhoneNum.Text,
                Email          = form.Email.Text,
                MessengerID    = form.MessengerId.Text,
                Memo           = form.Memo.Text
            };
        }
    }
}
