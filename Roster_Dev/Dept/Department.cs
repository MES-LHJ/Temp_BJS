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
        private readonly long _factoryId;

        public Department(long factoryId)
        {
            InitializeComponent();
            AddEvent();
            this._factoryId = factoryId;
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
                upperGridView.FocusedRowChanged += UpperGridView_FocusedRowChanged;
            }
        }

        public async Task RefreshGrid()
        {
            try
            {
                var upperDepartments = await ApiRepository.GetUpperDepartmentAsync(_factoryId);
                upperDeptGrid.DataSource = upperDepartments;

                var departments = await ApiRepository.GetDepartmentsAsync(_factoryId);
                deptGrid.DataSource = departments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }

        private void UpperGridView_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            var view = sender as GridView;
            if (view != null || !allDepartments.Any()) return;

            var selectedUpperDept = view.GetFocusedRow() as UpperDepartmentWorkout;

            var filteredDepartments = new List<DepartmentWorkout>();

            if (selectedUpperDept != null)
            {
                long parentId = selectedUpperDept.Id;

                filteredDepartments = allDepartments
                        .Where(d => d.UpperDepartmentId.HasValue && d.UpperDepartmentId.Value == parentId)
                        .ToList();
            }
            deptGrid.DataSource = filteredDepartments;
            (deptGrid.MainView as GridView)?.RefreshData();
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            await RefreshGrid();
        }

        private void UpperDept_Click(object sender, EventArgs e)
        {
            using (var Form = new UpperDept(_factoryId))
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
            using (var Form = new DeptChart(_factoryId))
            {
                Form.ShowDialog();
            }
        }

        private async void Add_Click(object sender, EventArgs e)
        {
            var dept = new DepartmentWorkout();
            using (var Form = new DeptAddEdit(_factoryId))
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

            using (var Form = new DeptAddEdit(department))
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
