using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roster.Models;

namespace Roster
{
    public partial class DepartmentDelete : MetroForm
    {
        private Department _parentForm;
        public DepartmentDelete(Department parentForm, string code, string name)
        {
            InitializeComponent();
            this.Delete.Click += Delete_Click;
            this.Cancel.Click += Cancel_Click;
            _parentForm = parentForm;

            PartCode.Text = code;
            DepartmentName.Text = name;
        }

        private void Delete_Click(object sender, EventArgs e) //삭제
        {
            // DB 삭제
            DepartmentValue.DeleteDepartment(PartCode.Text?.Trim());
            _parentForm.DepartmentDataGrid.DataSource = null;
            _parentForm.DepartmentDataGrid.DataSource = DepartmentValue.GetAll();


            MessageBox.Show("삭제되었습니다.");
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기
        }
    }
}
