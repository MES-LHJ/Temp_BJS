using MetroFramework.Forms;
using Roster.Models;
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
using System.Xml.Linq;

namespace Roster
{
    public partial class RosterDelete : MetroForm
    {
        public RosterDelete(string code, string name)
        {
            InitializeComponent();
            this.Delete.Click += Delete_Click;
            this.Cancel.Click += Cancel_Click;

            RosterCode.Text = code;
            RosterName.Text = name;
        }

        

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                SqlRepository.DeleteDepartment(RosterCode.Text?.Trim());
                MessageBox.Show("삭제되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기
        }
    }
}
