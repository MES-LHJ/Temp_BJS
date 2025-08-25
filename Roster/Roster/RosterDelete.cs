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
using System.Xml.Linq;

namespace Roster
{
    public partial class RosterDelete : MetroForm
    {
        private MainRoster _parentForm;
        public RosterDelete(MainRoster parentForm, string code, string name)
        {
            InitializeComponent();
            _parentForm = parentForm;

            RosterCode.Text = code;
            RosterName.Text = name;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // DB 삭제
            var codeToDelete = RosterCode.Text?.Trim();
            if (!string.IsNullOrEmpty(codeToDelete))
            {
                SqlRepository.DeleteEmployeeByCode(codeToDelete);
            }

            // 선택된 행 삭제
            if (_parentForm.EmployeeDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("삭제할 행을 선택해주세요.");
                return;
            }

            var rowIndexes = _parentForm.EmployeeDataGrid.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(c => c.RowIndex)
                .Distinct()
                .OrderByDescending(i => i);

            foreach (var rowIndex in rowIndexes)
            {
                if (rowIndex >= 0 &&
                    rowIndex < _parentForm.EmployeeDataGrid.Rows.Count &&
                    !_parentForm.EmployeeDataGrid.Rows[rowIndex].IsNewRow)
                {
                    _parentForm.EmployeeDataGrid.Rows.RemoveAt(rowIndex);
                }
            }
            MessageBox.Show("삭제되었습니다.");
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // 폼 닫기
        }
    }
}
