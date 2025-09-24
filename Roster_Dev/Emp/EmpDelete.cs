using Roster_Dev.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.Emp
{
    public partial class EmpDelete : Form
    {
        private readonly EmpWorkout emp;
        public EmpDelete(EmpWorkout emp)
        {
            InitializeComponent();
            AddEvent();
            this.emp = new EmpWorkout();

            this.emp = emp;
            empCode.Text = emp.EmployeeCode;
            empName.Text = emp.EmployeeName;
        }

        private void AddEvent()
        {
            this.Load += Form_Load;
            this.deleteBtn.Click += Delete_Click;
            this.cancelBtn.Click += Cancel_Click;
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string photoPath = SqlReposit.GetPhotoPath(emp.EmployeeId);

                if ((!string.IsNullOrEmpty(photoPath) && System.IO.File.Exists(photoPath)))
                {
                    System.IO.File.Delete(photoPath);
                }

                var result = SqlReposit.DeleteEmp(emp.EmployeeId);

                if (result > 0)
                {
                    MessageBox.Show("삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("삭제할 데이터가 없습니다. (조건 불일치)");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
