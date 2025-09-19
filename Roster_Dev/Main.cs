using Roster_Dev.Dpt;
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

namespace Roster_Dev
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            AddEvent();
        }

        public void AddEvent()
        {
            this.Load += Form_Load;
            this.deptBtn.Click += Dept_Click;
            this.referenceBtn.Click += Reference_Click;
            this.addBtn.Click += Add_Click;
            this.multiAddBtn.Click += MultiAdd_Click;
            this.editBtn.Click += Edit_Click;
            this.loginInfoBtn.Click += LoginInfo_Click;
            this.deleteBtn.Click += Delete_Click;
            this.convertBtn.Click += Convert_Click;
            this.exitBtn.Click += Exit_Click;
        }

        private void RefreshGrid()
        {
            var emp = SqlReposit.GetEmployees().OrderBy(e => e.EmployeeCode).ToList();

            empGrid.DataSource = emp;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void Dept_Click(object sender, EventArgs e)
        {
            using (var Form = new Department())
            {
                Form.ShowDialog();
            }
        }

        private void Reference_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            var dept = new DeptWorkout();
            using (var Form = new Emp.EmpAdd(dept))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }

        private void MultiAdd_Click(object sender, EventArgs e)
        {
            using (var Form = new MultiAdd())
            {
                Form.ShowDialog();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var view = empGrid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null || view.FocusedRowHandle < 0)
                return;

            // 현재 선택된 행의 EmployeeId 가져오기
            var empId = Convert.ToInt32(view.GetFocusedRowCellValue("EmployeeId"));

            using (var Form = new Emp.EmpEdit(empId))
            {
                Form.ShowDialog();
            }
        }

        private void LoginInfo_Click(object sender, EventArgs e)
        {
            using (var Form = new Login())
            {
                Form.ShowDialog();
                if (Form.DialogResult == DialogResult.OK)
                {
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            using (var Form = new Emp.EmpDelete())
            {
                Form.ShowDialog();
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
