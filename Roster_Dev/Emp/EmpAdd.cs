using Roster_Dev.UtilClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.Emp
{
    public partial class EmpAdd : Form
    {
        public EmpAdd()
        {
            InitializeComponent();
            AddEvent();
        }
        private void AddEvent()
        {
            this.Load += Form_Load;
            this.addEditBtn.Click += Save_Click;
            this.cancel.Click += Cancel_Click;
        }

        public enum Gender
        {
            Male,
            Female
        }

        private void SetTag()
        {
            upperDeptCode.Tag = upperDeptCodeLayout.Text;
            deptCode.Tag      = deptCodeLayout.Text;
            empCode.Tag      = empCodeLayout.Text;
            empName.Tag      = empNameLayout.Text;
            loginId.Tag      = loginIdLayout.Text;
            password.Tag     = passwordLayout.Text;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            SetTag();
            // 상위부서코드
            var upperDepartments = SqlReposit.GetUpperDepartments()
                .OrderBy(u => u.UpperDepartmentCode)
                .ToList();
            upperDeptCode.Properties.DataSource = upperDepartments;
            upperDeptCode.Properties.DisplayMember = "UpperDepartmentCode";
            upperDeptCode.Properties.ValueMember = "UpperDepartmentId";

            // 부서코드
            var departments = SqlReposit.GetDepartments()
                .OrderBy(d => d.DepartmentCode)
                .ToList();
            deptCode.Properties.DataSource = departments;
            deptCode.Properties.DisplayMember = "DepartmentCode";
            deptCode.Properties.ValueMember = "DepartmentId";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!Util.Instance.NullCheck(upperDeptCode, deptCode, empCode, empName, loginId, password))
            {
                return;
            }
            // Save logic here
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
