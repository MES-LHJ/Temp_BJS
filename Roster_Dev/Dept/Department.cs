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
            this.deptAddBtn.Click += Add_Click;
            this.deptEditBtn.Click += Edit_Click;
            this.deleteBtn.Click += Delete_Click;
            this.exitBtn.Click += Exit_Click;
        }

        private void RefreshGrid()
        {
            var departments = SqlReposit.GetDepartments()
                .OrderBy(d => d.DepartmentCode)
                .ToList();
            deptGrid.DataSource = departments;
            deptGrid.Refresh();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var upperDepartments = SqlReposit.GetUpperDepartments()
                .OrderBy(u => u.UpperDepartmentCode)
                .ToList();

            upperDeptGrid.DataSource = upperDepartments;

            var departments = SqlReposit.GetDepartments()
                .OrderBy(d => d.DepartmentCode)
                .ToList();

            deptGrid.DataSource = departments;
            RefreshGrid();
        }

        private void UpperDept_Click(object sender, EventArgs e)
        {
            using (var Form = new UpperDept())
            {
                Form.ShowDialog();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var dept = new DeptWorkout();
            using (var Form = new DeptAddEdit(dept))
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
                    RefreshGrid();// Refresh the grid or perform any necessary actions after editing
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (var Form = new DeptDelete())
            {
                Form.ShowDialog();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
