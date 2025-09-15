using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.UtilClass
{
    public sealed class Util
    {
        private static readonly Util instance = new Util();
        public static Util Instance { get { return instance; } }
        private Util() { }
        public bool NullCheck(params Control[] texts)
        {
            foreach (var text in texts)
            {
                if (string.IsNullOrWhiteSpace(text.Text))
                {
                    string labelName = text.Tag?.ToString() ?? text.Name;
                    MessageBox.Show($"{labelName}을(를) 입력해주세요");
                    text.Focus();
                    return false;
                }
            }
            return true;
        }
    }
}
