using Roster_Dev.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roster_Dev.UtilClass;

namespace Roster_Dev.Emp
{
    public partial class EmpEdit : Form
    {
        private EmpWorkout emp;
        private DeptWorkout dept;
        private UpperDeptWorkout upperDept;
        private string currentPhotoPath;
        private readonly int empId;
        public EmpEdit(int employeeId)
        {
            InitializeComponent();
            AddEvent();
            empId = employeeId;
            EditVariable();
        }

        private void EditVariable()
        {
            emp = SqlReposit.GetEmployees().FirstOrDefault(x => x.EmployeeId == empId);
            dept = SqlReposit.GetDepartments().FirstOrDefault(d => d.DepartmentId == emp.DepartmentId);
            if (dept != null)
            {
                upperDept = SqlReposit.GetUpperDepartments()
                                      .FirstOrDefault(u => u.UpperDepartmentId == dept.UpperDepartmentId);
            }
        }

        private void AddEvent()
        {
            this.Load += Form_Load;
            this.male.CheckedChanged += Male_CheckedChanged;
            this.female.CheckedChanged += Female_CheckedChanged;
            this.addEditBtn.Click += Save_Click;
            this.photo.Click += Photo_Click;
            this.cancel.Click += Cancel_Click;
        }

        private void SetTag()
        {
            upperDeptCode.Tag = upperDeptCodeLayout.Text;
            deptCode.Tag = deptCodeLayout.Text;
            empCode.Tag = empCodeLayout.Text;
            empName.Tag = empNameLayout.Text;
        }



        private void Form_Load(object sender, EventArgs e)
        {
            SetTag();

            var upperDepartments = SqlReposit.GetUpperDepartments();

            var upperDeptList = upperDepartments
                .Where(u => u.UpperDepartmentId == dept.UpperDepartmentId)
                .OrderBy(u => u.UpperDepartmentCode)
                .ToList();

            var departments = SqlReposit.GetDepartments()
                .Where(d => d.UpperDepartmentId == upperDeptList.FirstOrDefault()?.UpperDepartmentId)
                .OrderBy(d => d.DepartmentId == emp.DepartmentId);

            if (upperDeptList.Any())
            {
                upperDeptCode.Properties.Items.Clear();
                foreach (var item in upperDeptList)
                {
                    upperDeptCode.Properties.Items.Add(item);
                    upperDeptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                }
                upperDeptCode.Text = upperDept.UpperDepartmentCode;
                upperDeptName.Text = upperDept.UpperDepartmentName;
            }

            if (departments.Any())
            {
                deptCode.Properties.Items.Clear();
                foreach (var item in departments)
                {
                    deptCode.Properties.Items.Add(item);
                    deptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                    deptCode.Text = dept.DepartmentCode;
                }
                deptName.Text = dept.DepartmentName;
            }
            empCode.Text = emp.EmployeeCode;
            empName.Text = emp.EmployeeName;
            position.Text = emp.Position;
            employment.Text = emp.Employment;
            phoneNum.Text = emp.PhoneNum;
            email.Text = emp.Email;
            messengerId.Text = emp.MessengerId;
            memo.Text = emp.Memo;

            //if (emp.Gender == Util.Gender.Male)
            //{
            //    male.Checked = true;
            //    female.Checked = false;
            //}
            //else if (emp.Gender == Util.Gender.Female)
            //{
            //    male.Checked = false;
            //    female.Checked = true;
            //}
            //else
            //{
            //    male.Checked = false;
            //    female.Checked = false;
            //}

            male.Checked = (emp.Gender == Util.Gender.Male);
            female.Checked = (emp.Gender == Util.Gender.Female);

            if (!string.IsNullOrEmpty(emp.PhotoPath) && File.Exists(emp.PhotoPath))
            {
                using (var fs = new FileStream(emp.PhotoPath, FileMode.Open, FileAccess.Read))
                {
                    photo.Image = Image.FromStream(fs);
                }
                photo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            }
        }

        private void Photo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "사원 이미지 변경";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        photo.Image = Image.FromStream(fs);
                    }
                    photo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    currentPhotoPath = openFileDialog.FileName;
                }
            }
        }

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            if (male.Checked) female.Checked = false;
        }
        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            if (female.Checked) male.Checked = false;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!Util.Instance.NullCheck(upperDeptCode, deptCode, empCode, empName))
                return;

            try
            {
                // 사원 기본정보
                emp.DepartmentId = dept.DepartmentId;
                emp.UpperDeppartmentId = upperDept.UpperDepartmentId;
                emp.EmployeeCode = empCode.Text.Trim();
                emp.EmployeeName = empName.Text.Trim();
                emp.Position = position.Text.Trim();
                emp.Employment = employment.Text.Trim();
                emp.PhoneNum = phoneNum.Text.Trim();
                emp.Gender = male.Checked ? Util.Gender.Male :
                             (female.Checked ? Util.Gender.Female : (Util.Gender?)null);
                emp.Email = email.Text.Trim();
                emp.MessengerId = messengerId.Text.Trim();
                emp.Memo = memo.Text.Trim();

                string imagesFolder = @"C:\work\Roster\Roster_Dev\Picture";

                // 사진 저장 처리
                if (!string.IsNullOrEmpty(emp.PhotoPath) && File.Exists(emp.PhotoPath))
                {
                    string newFileName = Path.GetFileName(currentPhotoPath);
                    string newPhotoPath = Path.Combine(imagesFolder, newFileName);

                    File.Copy(emp.PhotoPath, newPhotoPath, true);

                    //원본 사진은 삭제
                    if (!string.IsNullOrEmpty(currentPhotoPath) && File.Exists(currentPhotoPath))
                    {
                        if (photo.Image != null)
                        {
                            photo.Image.Dispose();
                            photo.Image = null;
                        }
                        File.Delete(emp.PhotoPath);
                    }

                    emp.PhotoPath = newPhotoPath; // DB에 저장할 최종 경로

                    using (var fs = new FileStream(newPhotoPath, FileMode.Open, FileAccess.Read))
                    {
                        photo.Image = Image.FromStream(fs);
                    }
                    photo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                }

                SqlReposit.UpdateEmp(emp);

                MessageBox.Show("사원이 수정되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다: " + ex.Message);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
