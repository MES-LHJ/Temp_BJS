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

namespace Roster
{
    public partial class DepartmentDelete : MetroForm
    {
        private Department _parentForm;
        public DepartmentDelete(Department parentForm, string code, string name)
        {
            InitializeComponent();
            _parentForm = parentForm;

            PartCode.Text = code;
            DepartmentName.Text = name;
        }

        private void button1_Click(object sender, EventArgs e) //삭제
        {
            // 선택된 행 삭제
            if (_parentForm.DepartmentDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("삭제할 행을 선택해주세요.");
                return;
            }

            // 선택된 행 삭제 (중복 삭제 방지)
            var rowIndexes = _parentForm.DepartmentDataGrid.SelectedCells
                .Cast<DataGridViewCell>()
                .Select(cell => cell.RowIndex)
                .Distinct()
                .OrderByDescending(i => i);

            foreach (int rowIndex in rowIndexes)
            {
                if (rowIndex >= 0 && rowIndex < _parentForm.DepartmentDataGrid.Rows.Count && !_parentForm.DepartmentDataGrid.Rows[rowIndex].IsNewRow)
                {
                    _parentForm.DepartmentDataGrid.Rows.RemoveAt(rowIndex);
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
