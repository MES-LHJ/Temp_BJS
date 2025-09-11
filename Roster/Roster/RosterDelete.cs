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
        private readonly RosterWorkout roster;
        public RosterDelete(RosterWorkout roster)
        {
            InitializeComponent();
            this.Delete.Click += Delete_Click;
            this.Cancel.Click += Cancel_Click;
            this.roster = roster;

            RosterCode.Text = roster.EmployeeCode;
            RosterName.Text = roster.EmployeeName;
        }



        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine($"삭제 시도 EmployeeId = {roster.EmployeeId}");
                var result = SqlRepository.DeleteEmployee(roster.EmployeeId);
                Console.WriteLine($"삭제된 행 수 = {result}");

                if (result > 0)
                {
                    MessageBox.Show("삭제되었습니다.");
                }
                else
                {
                    MessageBox.Show("삭제할 데이터가 없습니다. (조건 불일치)");
                }

                //SqlRepository.DeleteEmployee(roster.EmployeeId);
                //MessageBox.Show("삭제되었습니다.");
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
