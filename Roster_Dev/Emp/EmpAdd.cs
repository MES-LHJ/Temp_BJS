using DevExpress.XtraEditors.TextEditController.Win32;
using DocumentFormat.OpenXml.Vml;
using Roster_Dev.Model;
using Roster_Dev.UtilClass;
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
        private DeptWorkout _deptWorkout;

        public EmpAdd(DeptWorkout deptWorkout)
        {
            InitializeComponent();
            AddEvent();
            _deptWorkout = deptWorkout;
            emp = new EmpWorkout();
        }
        private void AddEvent()
        {
            this.Load += Form_Load;
            this.male.CheckedChanged += Male_CheckedChanged;
            this.female.CheckedChanged += Female_CheckedChanged;
            this.upperDeptCode.EditValueChanged += UpperDeptCode_EditValueChanged;
            this.deptCode.EditValueChanged += DeptCode_EditValueChanged;
            this.addEditBtn.Click += Save_Click;
            this.photo.Click += Photo_Click;
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

        private void UpperDeptCode_EditValueChanged(object sender, EventArgs e)
        {
            deptCode.Properties.Items.Clear();
            deptCode.Text = string.Empty;
            deptName.Text = string.Empty;

            if (upperDeptCode.SelectedItem is UpperDeptWorkout selectedUpper)
            {
                upperDeptName.Text = selectedUpper.UpperDepartmentName;

                // 하위부서 바인딩
                var departments = SqlReposit.GetDepartments()
                    .Where(d => d.UpperDepartmentId == selectedUpper.UpperDepartmentId)
                    .OrderBy(d => d.DepartmentCode)
                    .ToList();

                deptCode.Properties.Items.Clear();
                foreach (var dept in departments)
                {
                    deptCode.Properties.Items.Add(dept);
                }
            }
        }

        private void DeptCode_EditValueChanged(object sender, EventArgs e)
        {
            if (deptCode.SelectedItem is DeptWorkout selectedDept)
            {
                deptName.Text = selectedDept.DepartmentName;
            }
            else
            {
                deptName.Text = string.Empty;
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

        private void Form_Load(object sender, EventArgs e)
        {
            SetTag();
            // 상위부서코드
            var upperDepartments = SqlReposit.GetUpperDepartments()
                .OrderBy(u => u.UpperDepartmentCode)
                .ToList();

            upperDeptCode.Properties.Items.Clear();
            foreach (var upperDept in upperDepartments)
            {
                upperDeptCode.Properties.Items.Add(upperDept);
                upperDeptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }

            deptCode.Properties.Items.Clear();

            var departments = SqlReposit.GetDepartments()
                    .Where(d => d.UpperDepartmentId == _deptWorkout.UpperDepartmentId)
                    .OrderBy(d => d.DepartmentCode)
                    .ToList();

            deptCode.Properties.Items.Clear();
            foreach (var dept in departments)
            {
                deptCode.Properties.Items.Add(dept);
                deptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }

            // 하위부서 선택
            foreach (DeptWorkout item in deptCode.Properties.Items)
            {
                if (item.DepartmentId == _deptWorkout.DepartmentId)
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
                // 사진 저장 처리
                //if (!string.IsNullOrEmpty(emp.PhotoPath) && File.Exists(emp.PhotoPath))
                //{
                //    string imagesFolder = @"C:\work\Roster\Roster_Dev\Picture";
                //    Directory.CreateDirectory(imagesFolder);

                //    string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(emp.PhotoPath)}";
                //    string destPath = Path.Combine(imagesFolder, newFileName);

                //    File.Copy(emp.PhotoPath, destPath, true);
                //    emp.PhotoPath = destPath; // DB에 저장할 최종 경로
                //}

                //if (string.IsNullOrWhiteSpace(emp.PhotoPath))
                //    emp.PhotoPath = null;

                string imageFolder = @"C:\work\Roster\Roster_Dev\Picture";
                string fileName = Path.GetFileName(emp.PhotoPath);
                string newPhotoPath = Path.Combine(imageFolder, fileName);
                File.Copy(emp.PhotoPath, newPhotoPath, true);

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
                emp.Gender = male.Checked ? Util.Gender.Male : (female.Checked ? Util.Gender.Female : (Util.Gender?)null);
                emp.MessengerId = string.IsNullOrWhiteSpace(messengerId.Text) ? null : messengerId.Text;
                emp.Memo = string.IsNullOrWhiteSpace(memo.Text) ? null : memo.Text;
                //PhotoPath = photo.Image != null ? Convert.ToBase64String((byte[])(new ImageConverter()).ConvertTo(photo.Image, typeof(byte[]))) : null
                emp.PhotoPath = newPhotoPath;

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


        private void Photo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "사원 이미지 선택";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 미리보기
                    Image selectedImage = Image.FromFile(openFileDialog.FileName);
                    photo.Image = selectedImage;
                    photo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;

                    // 경로만 임시로 저장
                    emp.PhotoPath = openFileDialog.FileName;
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
