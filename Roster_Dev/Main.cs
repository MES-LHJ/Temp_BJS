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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            AddEvent();
        }

        public void AddEvent()
        {
            this.exitBtn.Click += Exit_Click;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
