using DevExpress.Charts.Model;
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
        public Department()
        {
            InitializeComponent();
            AddEvent();
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

        private void RefreshGrid()
        {
            var departments = SqlReposit.GetDepartments().OrderBy(d => d.DepartmentCode).ToList();
            deptGrid.DataSource = departments;
        }

        private void UpperDeptGrid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = upperDeptGrid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            // 모델 클래스로 연동
            var upperDepartment = view.GetFocusedRow() as UpperDeptWorkout; 

            if (upperDepartment != null)
            {
                // 부서 필터링 헬퍼 메서드
                FilterByUpperDept(upperDepartment.UpperDepartmentId);
            }
        }

        private void FilterByUpperDept(long upperDeptId)
        {
            var allDepartments = SqlReposit.GetDepartments().OrderBy(d => d.DepartmentCode).ToList();

            // 상위 부서 코드 기준
            var filteredDepartments = allDepartments
                .Where(d => d.UpperDepartmentId == upperDeptId)
                .ToList();

            deptGrid.DataSource = filteredDepartments;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var upperDepartments = SqlReposit.GetUpperDepartments()
                .OrderBy(u => u.UpperDepartmentCode)
                .ToList();
            upperDeptGrid.DataSource = upperDepartments;

            // 모든 부서 로드
            var departments = SqlReposit.GetDepartments()
                .OrderBy(d => d.DepartmentCode)
                .ToList();
            deptGrid.DataSource = departments;

            // 상위 부서 필터링
            if (upperDepartments.Any())
            {
                var firstUpperDept = upperDepartments.First();
                FilterByUpperDept(firstUpperDept.UpperDepartmentId);
            }
        }

        private void UpperDept_Click(object sender, EventArgs e)
        {
            using (var Form = new UpperDept())
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

        private void Add_Click(object sender, EventArgs e)
        {
            var dept = new DeptWorkout();
            using (var Form = new DeptAddEdit())
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var view = deptGrid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;

            var department = view.GetFocusedRow() as DeptWorkout;

            if (department == null)
            {
                MessageBox.Show("수정할 부서를 선택하세요.");
                return;
            }

            using (var Form = new DeptAddEdit(department))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var view = deptGrid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            var department = view?.GetFocusedRow() as DeptWorkout;
            if (department == null)
            {
                MessageBox.Show("삭제할 부서를 선택하세요.");
                return;
            }

            using (var Form = new DeptDelete(department))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
