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

namespace Roster_Dev.Emp
{
    public partial class EmpDelete : Form
    {
        private readonly EmpWorkout emp;
        public EmpDelete()
        {
            InitializeComponent();
            AddEvent();
            this.emp = new EmpWorkout();
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
                // Implement deletion logic here
                MessageBox.Show("Employee has been deleted.");
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
