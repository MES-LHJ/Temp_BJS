using MetroFramework.Forms;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Roster
{
    public partial class RosterDelete : MetroForm
    {
        private MainRoster _parentForm;
        public RosterDelete(MainRoster parentForm, string code, string name)
        {
            InitializeComponent();
            this.Delete.Click += Delete_Click;
            this.Cancel.Click += Cancel_Click;
            _parentForm = parentForm;

            RosterCode.Text = code;
            RosterName.Text = name;
        }

        

        private void Delete_Click(object sender, EventArgs e)
        {
            // DB 삭제
            EmployeeValue.DeleteEmployee(RosterCode.Text?.Trim());

            _parentForm.EmployeeDataGrid.DataSource = null;
            _parentForm.EmployeeDataGrid.DataSource = EmployeeValue.GetAll();
            MessageBox.Show("삭제되었습니다.");
            this.Close();
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기
        }
    }
}
