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
    public partial class UpperDeptDelete : Form
    {
        private readonly Model.UpperDeptWorkout upperDept;
        public UpperDeptDelete(Model.UpperDeptWorkout selectedRow)
        {
            InitializeComponent();
            AddEvent();

            this.upperDept = selectedRow;
            upperDeptCode.Text = upperDept.UpperDepartmentCode;
            upperDeptName.Text = upperDept.UpperDepartmentName;
        }
        private void AddEvent()
        {
            this.Load += Form_Load;
            this.deleteBtn.Click += Delete_Click;
            this.cancel.Click += Cancel_Click;
        }
        private void Form_Load(object sender, EventArgs e)
        {
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlReposit.DeleteUpperDept(upperDept.UpperDepartmentId.ToString());
                MessageBox.Show("삭제되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류가 발생했습니다: {ex.Message}");
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
