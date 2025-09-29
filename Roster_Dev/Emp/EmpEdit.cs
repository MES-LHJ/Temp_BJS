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
        private EmployeeWorkout emp;
        private long factoryId;

        //private DepartmentWorkout dept;
        //private DepartmentWorkout upperDept;
        //private string currentPhotoPath;
        private readonly int empId;

        public EmpEdit(int employeeId)
        {
            InitializeComponent();
            AddEvent();
            empId = employeeId;
            //EditVariable();
        }

        private void AddEvent()
        {
            this.Load += Form_Load;
            //this.male.CheckedChanged += Male_CheckedChanged;
            //this.female.CheckedChanged += Female_CheckedChanged;
            this.addEditBtn.Click += Save_Click;
            //this.photo.Click += Photo_Click;
            this.cancel.Click += Cancel_Click;
        }

        //private void EditVariable()
        //{
            //emp = SqlReposit.GetEmployees().FirstOrDefault(x => x.EmployeeId == empId);
            //emp = ApiRepository.GetEmployeesAsync().FirstOrDefault(x => x.Id == empId);
            //dept = SqlReposit.GetDepartments().FirstOrDefault(d => d.DepartmentId == emp.DepartmentId);
            //if (dept != null)
            //{
            //    upperDept = SqlReposit.GetUpperDepartments()
            //                          .FirstOrDefault(u => u.UpperDepartmentId == dept.UpperDepartmentId);
            //}
        //}

        private void SetTag()
        {
            upperDeptCode.Tag = upperDeptCodeLayout.Text;
            deptCode.Tag = deptCodeLayout.Text;
            empCode.Tag = empCodeLayout.Text;
            empName.Tag = empNameLayout.Text;
        }

        private void BindControls()
        {
            if (emp == null) return;

            // ⭐ 모델명 통일: EmployeeWorkout 모델의 속성 사용
            this.empName.Text = emp.Name;
            this.empCode.Text = emp.Code;
            this.position.Text = emp.Position;
            this.employment.Text = emp.ContractType;
            this.email.Text = emp.Email;
            this.phoneNum.Text = emp.PhoneNumber;
            this.messengerId.Text = emp.MessengerId;
            this.memo.Text = emp.Memo;
            // this.deptComboBox.EditValue = emp.DepartmentId; // 부서 선택 컨트롤 바인딩
            // this.upperDeptComboBox.EditValue = emp.UpperDepartmentId; // 상위 부서 선택 컨트롤 바인딩

            // 체크박스 등 나머지 컨트롤 바인딩 로직...
        }

        /// <summary>
        /// API를 통해 사원 데이터를 비동기로 로드합니다.
        /// </summary>
        private async Task LoadEmployeeData()
        {
            try
            {
                // ⭐ ApiRepository를 통해 모든 사원을 가져와서 필터링 (사원 상세 조회 API가 있다면 그것을 사용)
                var allEmployees = await ApiRepository.GetEmployeesAsync();
                emp = allEmployees.FirstOrDefault(x => x.Id == empId);

                if (emp == null)
                {
                    MessageBox.Show("해당 사원 ID를 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"사원 데이터 로드 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emp = null;
            }
        }

        /// <summary>
        /// 부서 목록을 비동기로 로드합니다. (부서 콤보박스 등에 사용)
        /// </summary>
        private async Task LoadDepartmentData()
        {
            try
            {
                var departments = await ApiRepository.GetDepartmentsAsync(factoryId);
                // 부서 콤보박스 등에 departments를 바인딩하는 로직 추가
            }
            catch (Exception ex)
            {
                MessageBox.Show($"부서 데이터 로드 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 폼 로드 시 데이터 로딩 및 바인딩
        private async void Form_Load(object sender, EventArgs e)
        {
            SetTag();

            await LoadEmployeeData();
            await LoadDepartmentData();

            // 데이터 로딩이 완료된 후에 컨트롤에 바인딩합니다.
            BindControls();
        }

        //private void Form_Load(object sender, EventArgs e)
        //{
        //    SetTag();

        //    var upperDepartments = SqlReposit.GetUpperDepartments();

        //    var upperDeptList = upperDepartments
        //        .Where(u => u.UpperDepartmentId == dept.UpperDepartmentId)
        //        .OrderBy(u => u.UpperDepartmentCode)
        //        .ToList();

        //    var departments = SqlReposit.GetDepartments()
        //        .Where(d => d.UpperDepartmentId == upperDeptList.FirstOrDefault()?.UpperDepartmentId)
        //        .OrderBy(d => d.DepartmentId == emp.DepartmentId);

        //    if (upperDeptList.Any())
        //    {
        //        upperDeptCode.Properties.Items.Clear();
        //        foreach (var item in upperDeptList)
        //        {
        //            upperDeptCode.Properties.Items.Add(item);
        //            upperDeptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        //        }
        //        upperDeptCode.Text = upperDept.UpperDepartmentCode;
        //        upperDeptName.Text = upperDept.UpperDepartmentName;
        //    }

        //    if (departments.Any())
        //    {
        //        deptCode.Properties.Items.Clear();
        //        foreach (var item in departments)
        //        {
        //            deptCode.Properties.Items.Add(item);
        //            deptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        //            deptCode.Text = dept.Code;
        //        }
        //        deptName.Text = dept.Name;
        //    }
        //    empCode.Text = emp.Code;
        //    empName.Text = emp.Name;
        //    position.Text = emp.Position;
        //    employment.Text = emp.ContractType;
        //    phoneNum.Text = emp.PhoneNumber;
        //    email.Text = emp.Email;
        //    messengerId.Text = emp.MessengerId;
        //    memo.Text = emp.Memo;

            //male.Checked = (emp.Gender == Util.Gender.Male);
            //female.Checked = (emp.Gender == Util.Gender.Female);

            //if (!string.IsNullOrEmpty(emp.PhotoPath) && File.Exists(emp.PhotoPath))
            //{
            //    using (var fs = new FileStream(emp.PhotoPath, FileMode.Open, FileAccess.Read))
            //    {
            //        photo.Image = Image.FromStream(fs);
            //    }
            //    photo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            //}
        //}

        //private void Photo_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog openFileDialog = new OpenFileDialog())
        //    {
        //        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
        //        openFileDialog.Title = "사원 이미지 변경";

        //        if (openFileDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            using (var fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
        //            {
        //                photo.Image = Image.FromStream(fs);
        //            }
        //            photo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
        //            currentPhotoPath = openFileDialog.FileName;
        //        }
        //    }
        //}

        //private void Male_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (male.Checked) female.Checked = false;
        //}
        //private void Female_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (female.Checked) male.Checked = false;
        //}

        private async void Save_Click(object sender, EventArgs e)
        {
            if (emp == null)
            {
                MessageBox.Show("사원 정보가 로드되지 않았습니다.");
                return;
            }

            try
            {
                // 컨트롤에서 변경된 데이터를 emp 객체에 다시 반영
                emp.Name = this.empName.Text;
                emp.Code = this.empCode.Text;
                emp.Position = this.position.Text;
                // ... (나머지 필드도 모두 반영)

                // SQL 호출 코드를 API 호출 코드로 교체
                // 기존: SqlReposit.UpdateEmp(emp);
                await ApiRepository.UpdateEmployeeAsync(emp);

                MessageBox.Show("사원이 수정되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // API 통신 실패 시 예외 처리
                MessageBox.Show("사원 수정 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
