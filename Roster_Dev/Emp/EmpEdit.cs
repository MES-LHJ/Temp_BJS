using Roster_Dev;
using Roster_Dev.Model;
using Roster_Dev.UtilClass;
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
using static DevExpress.Data.Filtering.Helpers.SubExprHelper.ThreadHoppingFiltering;

namespace Roster_Dev.Emp
{
    public partial class EmpEdit : Form
    {
        private EmployeeWorkout emp;
        private long factoryId;
        private readonly long empId;

        private List<UpperDepartmentWorkout> upperDepartments;
        private List<DepartmentWorkout> departments;

        public EmpEdit(long employeeId)
        {
            InitializeComponent();
            AddEvent();
            empId = employeeId;
        }

        private void AddEvent()
        {
            this.Load += Form_Load;
            this.addEditBtn.Click += Save_Click;
            this.cancel.Click += Cancel_Click;
            this.upperDeptCode.EditValueChanged += UpperDeptCode_EditValueChanged;
            this.deptCode.EditValueChanged += DeptCode_EditValueChanged;
        }

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

            // 모델명 통일 EmployeeWorkout 모델의 속성 사용
            this.upperDeptName.Text = emp.FactoryName;
            this.empName.Text = emp.Name;
            this.empCode.Text = emp.Code;
            this.position.Text = emp.Position;
            this.employment.Text = emp.ContractType;
            this.email.Text = emp.Email;
            this.phoneNum.Text = emp.PhoneNumber;
            this.messengerId.Text = emp.MessengerId;
            this.memo.Text = emp.Memo;
            //this.deptCode.EditValue = emp.DepartmentId; // 부서 선택 컨트롤 바인딩
            //this.upperDeptCode.EditValue = emp.UpperDepartmentId; // 상위 부서 선택 컨트롤 바인딩

            BindDepartmentData();
        }

        private void BindDepartmentData()
        {
            // 상위 부서 정보 바인딩 (ID로 선택 및 이름 조회)
            var selectedUpperDept = upperDepartments.FirstOrDefault(d => d.Id == emp.FactoryId);
            this.upperDeptCode.EditValue = emp.FactoryCode;

            // 안전하게 null 체크 후 이름 바인딩
            this.upperDeptName.Text = selectedUpperDept?.FactoryName;

            // 부서 정보 바인딩 (ID로 선택 및 이름 조회)
            var selectedDept = departments.FirstOrDefault(d => d.Id == emp.DepartmentId);
            this.deptCode.EditValue = emp.DepartmentCode;

            // 안전하게 null 체크 후 이름 바인딩
            this.deptName.Text = selectedDept?.Name;
        }

        /// <summary>
        /// API를 통해 사원 데이터를 비동기로 로드
        /// </summary>
        private async Task LoadEmployeeData()
        {
            try
            {
                // ApiRepository를 통해 모든 사원을 가져와서 필터링 (사원 상세 조회 API가 있다면 그것을 사용)
                var allEmployees = await ApiRepository.GetEmployeesAsync(factoryId);

                emp = allEmployees.FirstOrDefault(x => x.Id == empId);

                if (emp != null)
                {
                    this.factoryId = emp.FactoryId;
                }

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
        /// 부서 목록을 비동기로 로드(부서 콤보박스 등에 사용)
        /// </summary>
        private async Task LoadDepartmentData()
        {
            try
            {
                // 상위 부서 목록 로드 및 필드에 저장
                upperDepartments = await ApiRepository.GetUpperDepartmentAsync(factoryId);

                // 부서 목록 로드 및 필드에 저장
                departments = await ApiRepository.GetDepartmentsAsync(factoryId);
            }
            catch (Exception ex)
            {
                // API 통신 실패 시에도 null 대신 빈 리스트로 초기화 (ArgumentNullException 방지)
                upperDepartments = new List<UpperDepartmentWorkout>();
                departments = new List<DepartmentWorkout>();
                MessageBox.Show($"부서/상위부서 정보 로드 실패: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // 데이터 로드 실패 시 바인딩 작업을 막기 위해 리턴
            }

            UpdateDepartmentComboBoxes();
        }

        private async void UpdateDepartmentComboBoxes()
        {
            // upperDeptCode 콤보박스에 FactoryCode 값만 추가
            var upperDepartments = await ApiRepository.GetUpperDepartmentAsync(factoryId);
            upperDeptCode.Properties.Items.Clear();
            foreach (var upperDept in upperDepartments)
            {
                upperDeptCode.Properties.Items.Add(upperDept);
                upperDeptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }
            //this.upperDeptCode.Properties.Items.AddRange(upperDepartments.Select(d => d.FactoryCode).ToArray());

            // deptCode 콤보박스에 DepartmentCode 값만 추가
            deptCode.Properties.Items.Clear();
            foreach (var dept in departments)
            {
                deptCode.Properties.Items.Add(dept);
                deptCode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }
            //this.deptCode.Properties.Items.AddRange(departments.Select(d => d.Code).ToArray());
        }

        private void UpperDeptCode_EditValueChanged(object sender, EventArgs e)
        {
            if (upperDeptCode.SelectedItem is UpperDepartmentWorkout selectedUpper)
            {
                upperDeptName.Text = selectedUpper.FactoryName;

                // 하위부서 바인딩
                //var departments = await ApiRepository.GetDepartmentsAsync(factoryId);

                //deptCode.Properties.Items.Clear();
                //foreach (var dept in departments)
                //{
                //    deptCode.Properties.Items.Add(dept);
                //}
            }
            else
            {
                upperDeptName.Text = string.Empty;
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

        // 폼 로드 시 데이터 로딩 및 바인딩
        private async void Form_Load(object sender, EventArgs e)
        {
            SetTag();

            await LoadEmployeeData();
            await LoadDepartmentData();

            // 데이터 로딩이 완료된 후에 컨트롤에 바인딩합니다.
            BindControls();
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            if (emp == null)
            {
                MessageBox.Show("사원 정보가 로드되지 않았습니다.");
                return;
            }

            try
            {
                emp.Name = this.empName.Text;
                emp.Code = this.empCode.Text;
                emp.Position = this.position.Text;
                emp.ContractType = this.employment.Text;
                emp.Email = this.email.Text;
                emp.PhoneNumber = this.phoneNum.Text;
                emp.MessengerId = this.messengerId.Text;
                emp.Memo = this.memo.Text;

                if (this.deptCode.SelectedItem is DepartmentWorkout selectedDept)
                {
                    emp.DepartmentId = selectedDept.Id;
                }
                // SQL 호출 코드를 API 호출 코드로 교체
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