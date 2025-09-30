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

        private readonly int empId;

        public EmpEdit(int employeeId)
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
                // ApiRepository를 통해 모든 사원을 가져와서 필터링 (사원 상세 조회 API가 있다면 그것을 사용)
                var allEmployees = await ApiRepository.GetEmployeesAsync(factoryId);
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
                emp.Email = this.email.Text;
                emp.ContractType = this.employment.Text;
                emp.PhoneNumber = this.phoneNum.Text;
                emp.MessengerId = this.messengerId.Text;
                emp.Memo = this.memo.Text;

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
