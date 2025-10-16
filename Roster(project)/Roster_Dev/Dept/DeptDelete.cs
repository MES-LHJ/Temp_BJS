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

namespace Roster_Dev.Dept
{
    public partial class DeptDelete : Form
    {
        public readonly DepartmentWorkout dept;
        public DeptDelete(DepartmentWorkout dept)
        {
            InitializeComponent();
            AddEvent();

            this.dept = dept;
            deptCode.Text = dept.Code;
            deptName.Text = dept.Name;
        }

        public void AddEvent()
        {
            this.Load += Form_Load;
            this.deleteBtn.Click += Delete_Click;
            this.cancelBtn.Click += Cancel_Click;

        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await ApiRepository.DeleteDepartment(dept.Id);

                if (result > 0)
                {
                    MessageBox.Show("부서가 삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("부서 삭제에 실패했습니다.");
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
