using DevExpress.Charts.Model;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Roster_Dev.Dept;
using Roster_Dev.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.Dpt
{
    public partial class Department : Form
    {
        private List<DepartmentWorkout> allDepartments = new List<DepartmentWorkout>();
        private List<DepartmentWorkout> filteredDepartments;
        private long factoryId;

        public Department(long factoryId)
        {
            InitializeComponent();
            AddEvent();
            //this.factoryId = new factoryId();
        }

        public void AddEvent()
        {
            this.Load += Form_Load;
            this.upperDeptBtn.Click += UpperDept_Click;
            this.deptTreeBtn.Click += Tree_Click;
            this.deptChartBtn.Click += Chart_Click;
            this.deptAddBtn.Click += Add_Click;
            this.deptEditBtn.Click += Edit_Click;
            this.deleteBtn.Click += Delete_Click;
            this.exitBtn.Click += Exit_Click;
            var upperGridView = this.upperDeptGrid.MainView as GridView;
            if (upperGridView != null)
            {
                upperGridView.FocusedRowChanged += UpperDeptGrid_FocusedRowChanged;
            }
        }

        public async Task RefreshGrid()
        {
            try
            {
                var departmentList = await ApiRepository.GetDepartmentsAsync(factoryId);
                deptGrid.DataSource = departmentList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void UpperDeptGrid_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var view = upperDeptGrid.MainView as GridView;
            if (view == null) return;

            // 모델 클래스로 연동
            var upperDepartment = view.GetFocusedRow() as DepartmentWorkout; 

            if (upperDepartment != null)
            {
                // 부서 필터링 헬퍼 메서드
                FilterByUpperDept(upperDepartment.FactoryId);
            }
        }

        private void FilterByUpperDept(long upperDepartmentId)
        {
            //var allDepartments = SqlReposit.GetDepartments().OrderBy(d => d.DepartmentCode).ToList();

            //// 상위 부서 코드 기준
            //var filteredDepartments = allDepartments
            //    .Where(d => d.UpperDepartmentId == upperDeptId)
            //    .ToList();

            //deptGrid.DataSource = filteredDepartments;

            filteredDepartments = allDepartments
                                .Where(d => d.UpperDepartmentId == upperDepartmentId)
                                .ToList();

            // 하위 부서 GridView에 바인딩
            deptGrid.DataSource = filteredDepartments;
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            //var upperDepartments = ApiRepository.GetUpperDepartmentAsync();
            //upperDeptGrid.DataSource = upperDepartments;

            // 모든 부서 로드
            //var departments = ApiRepository.GetDepartmentsAsync();
            //deptGrid.DataSource = departments;

            // 상위 부서 필터링
            //if (upperDepartments.Any())
            //{
            //    var firstUpperDept = upperDepartments.First();
            //    FilterByUpperDept(firstUpperDept.UpperDepartmentId);
            //}
            try
            {
                // 1. 모든 부서 데이터 로드 (ApiRepository는 필터링 없는 전체 데이터를 가져와야 함)
                //var allDepts = await ApiRepository.GetDepartmentsAsync();
                //allDepartments = allDepts; // 필드에 저장

                // 2. 상위 부서만 필터링 (UpperDepartmentId가 null 또는 0인 부서)
                //var upperDepartments = allDepts
                //                        .Where(d => d.UpperDepartmentId == null || d.UpperDepartmentId == 0)
                //                        .ToList();

                // 3. 상위 부서 GridView에 바인딩
                //upperDeptGrid.DataSource = upperDepartments;

                // 4. 초기 하위 부서 필터링 (첫 번째 상위 부서 기준)
                //if (upperDepartments.Any())
                //{
                    //var firstUpperDept = upperDepartments.First();
                    //FilterByUpperDept(firstUpperDept.Id); // ID로 필터링
                //}
                //else
                //{
                    // 상위 부서가 없으면 하위 부서도 비워둡니다.
                //    deptGrid.DataSource = new List<DepartmentWorkout>();
                //}

                var departmentList = await ApiRepository.GetDepartmentsAsync(factoryId);
                deptGrid.DataSource = departmentList;

                var upperDepartmentList = await ApiRepository.GetUpperDepartmentAsync();
                upperDeptGrid.DataSource = upperDepartmentList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void UpperDept_Click(object sender, EventArgs e)
        {
            using (var Form = new UpperDept(factoryId))
            {
                Form.ShowDialog();
            }
        }

        private void Tree_Click(object sender, EventArgs e)
        {
            using (var Form = new Tree()) 
            {
                Form.ShowDialog();
            }
        }

        private void Chart_Click(object sender, EventArgs e)
        {
            using (var Form = new DeptChart())
            {
                Form.ShowDialog();
            }
        }

        private async void Add_Click(object sender, EventArgs e)
        {
            var dept = new DeptWorkout();
            using (var Form = new DeptAddEdit(dept))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
                }
            }
        }

        private async void Edit_Click(object sender, EventArgs e)
        {
            var view = deptGrid.MainView as GridView;
            if (view == null) return;

            var department = view.GetFocusedRow() as DepartmentWorkout;

            if (department == null)
            {
                MessageBox.Show("수정할 부서를 선택하세요.");
                return;
            }

            using (var Form = new DeptAddEdit(factoryId))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
                }
            }
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            var view = deptGrid.MainView as GridView;
            var department = view?.GetFocusedRow() as DepartmentWorkout;
            if (department == null)
            {
                MessageBox.Show("삭제할 부서를 선택하세요.");
                return;
            }

            using (var Form = new DeptDelete(department))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGrid();
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
