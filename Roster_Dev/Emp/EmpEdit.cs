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
        public EmpEdit()
        {
            InitializeComponent();
            AddEvent();
        }

        public EmpEdit(int employeeId) : this()
        {
            empId = employeeId;
        }

        private void AddEvent()
        {
            this.Load += Form_Load;
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

            emp = SqlReposit.GetEmployees().FirstOrDefault(x => x.EmployeeId == empId);

            if (emp == null)
            {
                MessageBox.Show("해당 사원 정보를 찾을 수 없습니다.");
                this.Close();
                return;
            }

            // 2. 상위부서와 부서 정보도 로드
            dept = SqlReposit.GetDepartments().FirstOrDefault(d => d.DepartmentId == emp.DepartmentId);
            if (dept != null)
            {
                upperDept = SqlReposit.GetUpperDepartments()
                                      .FirstOrDefault(u => u.UpperDepartmentId == dept.UpperDepartmentId);
            }

            // 3. ComboBoxEdit (DevExpress) - DataSource 세팅
            upperDeptCode.Properties.Items.Clear();
            foreach (var item in SqlReposit.GetUpperDepartments())
            {
                upperDeptCode.Properties.Items.Add(item);
            }

            deptCode.Properties.Items.Clear();
            foreach (var item in SqlReposit.GetDepartments().Where(d => d.UpperDepartmentId == dept?.UpperDepartmentId))
            {
                deptCode.Properties.Items.Add(item);
            }

            // 4. 값 바인딩 (TextBox/ComboBoxEdit)
            upperDeptCode.EditValue = upperDept?.UpperDepartmentId;
            deptCode.EditValue = emp.DepartmentId;

            empCode.DataBindings.Add("Text", emp, nameof(emp.EmployeeCode));
            empName.DataBindings.Add("Text", emp, nameof(emp.EmployeeName));
            email.DataBindings.Add("Text", emp, nameof(emp.Email));
            phoneNum.DataBindings.Add("Text", emp, nameof(emp.PhoneNum));
            position.DataBindings.Add("Text", emp, nameof(emp.Position));
            employment.DataBindings.Add("Text", emp, nameof(emp.Employment));
            messengerId.DataBindings.Add("Text", emp, nameof(emp.MessengerId));
            memo.DataBindings.Add("Text", emp, nameof(emp.Memo));

            // 5. 성별 체크박스 반영
            male.Checked = emp.Gender == Util.Gender.Male;
            female.Checked = emp.Gender == Util.Gender.Female;

            // 6. 사진 표시 (Base64)
            if (!string.IsNullOrEmpty(emp.PhotoPath))
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(emp.PhotoPath);
                    using (var ms = new MemoryStream(bytes))
                    {
                        photo.Image = Image.FromStream(ms);
                    }
                }
                catch { }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!UtilClass.Util.Instance.NullCheck(upperDeptCode, deptCode, empCode, empName))
            {
                return;
            }

            try
            {
                // 성별 수동 업데이트 (RadioButton은 DataBinding 어려움)
                emp.Gender = male.Checked ? Util.Gender.Male :
                             (female.Checked ? Util.Gender.Female : (Util.Gender?)null);

                // 사진 업데이트
                if (photo.Image != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        photo.Image.Save(ms, photo.Image.RawFormat);
                        emp.PhotoPath = Convert.ToBase64String(ms.ToArray());
                    }
                }
                else
                {
                    emp.PhotoPath = null;
                }

                int result = SqlReposit.UpdateEmp(emp);

                if (result > 0)
                {
                    MessageBox.Show("사원이 수정되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("사원 수정에 실패했습니다.");
                }
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
