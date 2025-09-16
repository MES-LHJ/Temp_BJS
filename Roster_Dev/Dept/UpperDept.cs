using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.Dept
{
    public partial class UpperDept : Form
    {
        public UpperDept()
        {
            InitializeComponent();
            AddEvent();
        }
        private void AddEvent()
        {
            this.Load += Form_Load;
            this.upperDeptAddBtn.Click += Add_Click;
            this.upperDeptEditBtn.Click += Edit_Click;
            this.deleteBtn.Click += Delete_Click;
            this.exitBtn.Click += Exit_Click;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            var upperDepartments = SqlReposit.GetUpperDepartments()
                .OrderBy(u => u.UpperDepartmentCode)
                .ToList();

            upperDeptGrid.DataSource = upperDepartments;
        }
        private void Add_Click(object sender, EventArgs e)
        {
            using (var Form = new UpperDeptAddEdit())
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    Refresh();
                }
            }
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            var view = upperDeptGrid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;
            var selectedRow = view.GetFocusedRow() as Model.UpperDeptWorkout;
            if (selectedRow == null)
            {
                MessageBox.Show("수정할 부서를 선택하세요.");
                return;
            }
            using (var Form = new UpperDeptAddEdit(selectedRow))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    Refresh();
                }
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            var view = upperDeptGrid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;
            var selectedRow = view.GetFocusedRow() as Model.UpperDeptWorkout;
            if (selectedRow == null)
            {
                MessageBox.Show("삭제할 부서를 선택하세요.");
                return;
            }
            if (DialogResult == DialogResult.OK)
            {
                using (var form = new UpperDeptDelete(selectedRow))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        Refresh();
                    }
                }
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
