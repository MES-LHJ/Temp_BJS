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
                //upperDeptCode.DataBindings.Add("Text", departments, nameof(departments));
                //upperDeptCode.Properties.DataSource = upperDeptList;
                //upperDeptCode.Properties.DisplayMember = "UpperDepartmentCode";
                //upperDeptCode.Properties.ValueMember = "UpperDepartmentId";
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
            photo.Text = emp.PhotoPath;


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

            //emp = SqlReposit.GetEmployees().FirstOrDefault(x => x.EmployeeId == empId);

            // 상위부서와 부서 정보도 로드
            //dept = SqlReposit.GetDepartments().FirstOrDefault(d => d.DepartmentId == emp.DepartmentId);
            //if (dept != null)
            //{
            //    upperDept = SqlReposit.GetUpperDepartments()
            //                          .FirstOrDefault(u => u.UpperDepartmentId == dept.UpperDepartmentId);
            //}

            // ComboBoxEdit (DevExpress) - DataSource 세팅
            //upperDeptCode.Properties.Items.Clear();
            //foreach (var item in SqlReposit.GetUpperDepartments())
            //{
            //    upperDeptCode.Properties.Items.Add(item);
            //}

            //deptCode.Properties.Items.Clear();
            //foreach (var item in SqlReposit.GetDepartments().Where(d => d.UpperDepartmentId == dept?.UpperDepartmentId))
            //{
            //    deptCode.Properties.Items.Add(item);
            //}

            // 값 바인딩 (TextBox/ComboBoxEdit)
            //upperDeptCode.EditValue = upperDept?.UpperDepartmentId;
            //deptCode.EditValue = emp.DepartmentId;

            //empCode.DataBindings.Add("Text", emp, nameof(emp.EmployeeCode));
            //empName.DataBindings.Add("Text", emp, nameof(emp.EmployeeName));
            //email.DataBindings.Add("Text", emp, nameof(emp.Email));
            //phoneNum.DataBindings.Add("Text", emp, nameof(emp.PhoneNum));
            //position.DataBindings.Add("Text", emp, nameof(emp.Position));
            //employment.DataBindings.Add("Text", emp, nameof(emp.Employment));
            //messengerId.DataBindings.Add("Text", emp, nameof(emp.MessengerId));
            //memo.DataBindings.Add("Text", emp, nameof(emp.Memo));

            // 성별 체크박스 반영
            //male.Checked = emp.Gender == Util.Gender.Male;
            //female.Checked = emp.Gender == Util.Gender.Female;

            //사진 표시(Base64)
            //    if (!string.IsNullOrEmpty(emp.PhotoPath))
            //{
            //    try
            //    {
            //        byte[] bytes = Convert.FromBase64String(emp.PhotoPath);
            //        using (var ms = new MemoryStream(bytes))
            //        {
            //            photo.Image = Image.FromStream(ms);
            //        }
            //    }
            //    catch { }
            //}
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
            if (!UtilClass.Util.Instance.NullCheck(upperDeptCode, deptCode, empCode, empName))
            {
                return;
            }

            try
            {
                // 상위부서, 부서, 사원 정보 업데이트
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
                emp.DepartmentId = dept.DepartmentId;
                emp.UpperDeppartmentId = upperDept.UpperDepartmentId;


                // 사진 업데이트
                string imagesFolder = @"C:\work\Roster\Roster_Dev";// 사진 저장 폴더 경로 설정

                if (string.IsNullOrEmpty(emp.PhotoPath) && File.Exists(emp.PhotoPath))
                {
                    // 사진이 선택되어 있고, 기존에 사진이 없는 경우
                    string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(emp.PhotoPath)}";
                    string destPath = Path.Combine(imagesFolder, newFileName);
                    File.Copy(emp.PhotoPath, destPath);
                    emp.PhotoPath = destPath;
                }
                else if (!string.IsNullOrEmpty(emp.PhotoPath) && !File.Exists(emp.PhotoPath))
                {
                    // 사진이 변경되었고, 기존에 사진이 있는 경우
                    string newFileName = $"{Guid.NewGuid()}{Path.GetExtension(emp.PhotoPath)}";
                    string destPath = Path.Combine(imagesFolder, newFileName);
                    File.Copy(emp.PhotoPath, destPath);
                    emp.PhotoPath = destPath;
                }

                SqlReposit.UpdateEmp(emp);

                MessageBox.Show("사원이 수정되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("오류가 발생했습니다: " + ex.Message);
                return;
            }

        }

        private void Photo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "사진 선택";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image selectedImage = Image.FromFile(openFileDialog.FileName);
                        photo.Image = selectedImage;
                        // 사진을 Base64 문자열로 변환하여 emp.PhotoPath에 저장
                        using (var ms = new MemoryStream())
                        {
                            selectedImage.Save(ms, selectedImage.RawFormat);
                            emp.PhotoPath = Convert.ToBase64String(ms.ToArray());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("이미지를 불러오는 중 오류가 발생했습니다: " + ex.Message);
                    }
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
