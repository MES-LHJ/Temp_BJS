using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            AddEvent();
        }

        private void AddEvent()
        {
            this.AcceptButton = this.loginBtn;
            this.loginBtn.Click += loginBtn_Click;
            this.exit.Click += exit_Click;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //using (var Form = new Main())
            //{
            //    Form.ShowDialog();
            //    if (Form.DialogResult == DialogResult.OK)
            //    {
            //        this.Close();
            //    }
            //}
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
