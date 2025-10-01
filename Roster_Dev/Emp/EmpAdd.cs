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
        private EmployeeWorkout emp;
        private DepartmentWorkout _deptWorkout;
        private long factoryId;

        public EmpAdd(DepartmentWorkout deptWorkout)
        {
            InitializeComponent();
            AddEvent();
            _deptWorkout = deptWorkout;
            emp = new EmployeeWorkout();
            factoryId = _deptWorkout.FactoryId;
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

            if (upperDeptCode.SelectedItem is UpperDepartmentWorkout selectedUpper)
            {
                upperDeptName.Text = selectedUpper.FactoryName;

                // 하위부서 바인딩
                var departments = await ApiRepository.GetDepartmentsAsync(factoryId);

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
                //upperDeptCode.Properties.Items.AddRange(upperDepartments.Select(d => d.FactoryCode).ToArray());
            }

            deptCode.Properties.Items.Clear();

            var departments = await ApiRepository.GetDepartmentsAsync(factoryId);

            deptCode.Properties.Items.Clear();
            foreach (var dept in departments)
            {
                deptCode.Properties.Items.Add(dept);
                deptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                //deptCode.Properties.Items.AddRange(departments.Select(d => d.Code).ToArray());
            }

            // 하위부서 선택
            //foreach (DepartmentWorkout item in deptCode.Properties.Items)
            //{
            //    if (item.Code == _deptWorkout.Code)
            //    {
            //        deptCode.SelectedItem = item.Code;
            //        break;
            //    }
            //}
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            if (!Util.Instance.NullCheck(upperDeptCode, deptCode, empCode, empName, loginId, password))
            {
                return;
            }
            try
            {
                var selectedDept = deptCode.SelectedItem as DepartmentWorkout;
                emp.DepartmentId = selectedDept.Id;
                emp.Code = this.empCode.Text;
                emp.Name = this.empName.Text;
                emp.LoginId = this.loginId.Text;
                emp.LoginPassword = this.password.Text;
                emp.Email = this.email.Text;
                emp.PhoneNumber = this.phoneNum.Text;
                emp.Position = this.position.Text;
                emp.ContractType = this.employment.Text;
                emp.MessengerId = this.messengerId.Text;
                emp.Memo = this.memo.Text;
                emp.LoginTag = string.Empty;
                emp.IsAdmin = false;

                await ApiRepository.AddEmployeeAsync(emp);
                MessageBox.Show("사원이 추가되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
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
