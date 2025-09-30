using DevExpress.XtraEditors.TextEditController.Win32;
using DocumentFormat.OpenXml.Vml;
using Roster_Dev.Model;
using Roster_Dev.UtilClass;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Path = System.IO.Path;

namespace Roster_Dev.Emp
{
    public partial class EmpAdd : Form
    {
        private EmpWorkout emp;
        private DepartmentWorkout _deptWorkout;
        private long factoryId;

        public EmpAdd(DepartmentWorkout deptWorkout)
        {
            InitializeComponent();
            AddEvent();
            _deptWorkout = deptWorkout;
            emp = new EmpWorkout();
        }
        private void AddEvent()
        {
            this.Load += Form_Load;
            this.upperDeptCode.EditValueChanged += UpperDeptCode_EditValueChanged;
            this.deptCode.EditValueChanged += DeptCode_EditValueChanged;
            this.addEditBtn.Click += Save_Click;
            this.cancel.Click += Cancel_Click;
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

        private async void UpperDeptCode_EditValueChanged(object sender, EventArgs e)
        {
            deptCode.Properties.Items.Clear();
            deptCode.Text = string.Empty;
            deptName.Text = string.Empty;

            if (upperDeptCode.SelectedItem is DepartmentWorkout selectedUpper)
            {
                upperDeptName.Text = selectedUpper.UpperDepartmentName;

                // 하위부서 바인딩
                var departments = await ApiRepository.GetDepartmentsAsync(factoryId);
                    //.Where(d => d.UpperDepartmentId == selectedUpper.UpperDepartmentId)
                    //.OrderBy(d => d.DepartmentCode)
                    //.ToList();

                deptCode.Properties.Items.Clear();
                foreach (var dept in departments)
                {
                    deptCode.Properties.Items.Add(dept);
                }
            }
        }

        private void DeptCode_EditValueChanged(object sender, EventArgs e)
        {
            if (deptCode.SelectedItem is DepartmentWorkout selectedDept)
            {
                deptName.Text = selectedDept.Name;
            }
            else
            {
                deptName.Text = string.Empty;
            }
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            SetTag();
            // 상위부서코드
            var upperDepartments = await ApiRepository.GetUpperDepartmentAsync(factoryId);
                //.OrderBy(u => u.UpperDepartmentCode)
                //.ToList();

            upperDeptCode.Properties.Items.Clear();
            foreach (var upperDept in upperDepartments)
            {
                upperDeptCode.Properties.Items.Add(upperDept);
                upperDeptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }

            deptCode.Properties.Items.Clear();

            var departments = await ApiRepository.GetDepartmentsAsync(factoryId);

            deptCode.Properties.Items.Clear();
            foreach (var dept in departments)
            {
                deptCode.Properties.Items.Add(dept);
                deptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }

            // 하위부서 선택
            foreach (DepartmentWorkout item in deptCode.Properties.Items)
            {
                if (item.Id == _deptWorkout.Id)
                {
                    deptCode.SelectedItem = item;
                    break;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!Util.Instance.NullCheck(upperDeptCode, deptCode, empCode, empName, loginId, password))
            {
                return;
            }
            try
            {
                var selectedDept = deptCode.SelectedItem as DeptWorkout;
                emp.DepartmentId = selectedDept.DepartmentId;
                emp.EmployeeCode = empCode.Text;
                emp.EmployeeName = empName.Text;
                emp.LoginId = loginId.Text;
                emp.Password = password.Text;
                emp.Email = string.IsNullOrWhiteSpace(email.Text) ? null : email.Text;
                emp.PhoneNum = string.IsNullOrWhiteSpace(phoneNum.Text) ? null : phoneNum.Text;
                emp.Position = string.IsNullOrWhiteSpace(position.Text) ? null : position.Text;
                emp.Employment = string.IsNullOrWhiteSpace(employment.Text) ? null : employment.Text;
                emp.MessengerId = string.IsNullOrWhiteSpace(messengerId.Text) ? null : messengerId.Text;
                emp.Memo = string.IsNullOrWhiteSpace(memo.Text) ? null : memo.Text;

                var result = SqlReposit.InsertEmp(emp);
                if (result > 0)
                {
                    MessageBox.Show("사원이 추가되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
