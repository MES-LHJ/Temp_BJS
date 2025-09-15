using Roster_Dev.UtilClass;
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
    public partial class EmpAdd1 : Form
    {
        public EmpAdd1()
        {
            InitializeComponent();
            AddEvent();
        }

        private void AddEvent()
        {
            this.Load += Form_Load;
            this.saveBtn.Click += Save_Click;
            this.cancel.Click += Cancel_Click;
        }

        public enum Gender
        {
            Male,
            Female
        }

        private void SetTag()
        {
            upperDptCode.Tag = upperDptCodeLabel.Text;
            dptCode.Tag      = dptCodeLabel.Text;
            empCode.Tag      = empCodeLabel.Text;
            empName.Tag      = empNameLabel.Text;
            loginId.Tag      = loginIdLabel.Text;
            password.Tag     = passwordLabel.Text;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            SetTag();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!Util.Instance.NullCheck(upperDptCode, dptCode, empCode, empName, loginId, password))
            {
                return;
            }
            // Save logic here
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
