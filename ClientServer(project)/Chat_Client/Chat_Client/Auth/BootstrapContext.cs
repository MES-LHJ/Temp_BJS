using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client.Auth
{
    internal class BootstrapContext : ApplicationContext
    {
        public BootstrapContext()
        {
            ShowLogin();
        }

        private void ShowLogin()
        {
            var login = new Login();
            login.FormClosed += (s, e) =>
            {
                if (login.DialogResult == DialogResult.OK)
                {
                    var userModel = login.UserModel;
                    var client = new Client(userModel);
                    client.FormClosed += (s2, e2) => ExitThread();
                    MainForm = client;
                    client.Show();
                }
                else
                {
                    ExitThread();
                }
            };
            login.Show();
        }
    }
}
