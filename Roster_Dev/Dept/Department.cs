using Roster_Dev.Dept;
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
            this.deptAddBtn.Click += Add_Click;
            this.deptEditBtn.Click += Edit_Click;
            this.deleteBtn.Click += Delete_Click;
            this.exitBtn.Click += Exit_Click;
        }

        private void Form_Load(object sender, EventArgs e)
        {
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (var Form = new DeptAddEdit())
            {
                Form.ShowDialog();
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            using (var Form = new DeptAddEdit())
            {
                Form.ShowDialog();
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
