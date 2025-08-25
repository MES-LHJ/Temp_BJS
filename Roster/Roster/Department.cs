using MetroFramework.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Roster
{
    public partial class Department : MetroForm
    {
        public Department()
        {
            InitializeComponent();
        }
        private void RefreshDepartmentGrid() // 부서 데이터 정렬 및 갱신
        {
            DepartmentDataGrid.Rows.Clear();

            var departments = SqlRepository.GetDepartments()
                .OrderBy(d => int.TryParse(d.Code, out var n) ? n : int.MaxValue)
                .ThenBy(d => d.Code);

            foreach (var dept in departments)
            {
                DepartmentDataGrid.Rows.Add(dept.Code, dept.Name, "");
            }
        }

        private void Department_Load(object sender, EventArgs e) // 그리드 양식
        {
            DepartmentDataGrid.Columns.Add("PartCode", "부서코드");
            DepartmentDataGrid.Columns.Add("DepartmentName", "부서명");
            DepartmentDataGrid.Columns.Add("Memo", "메모");
            RefreshDepartmentGrid();
        }

        private void label1_Click(object sender, EventArgs e) // 추가
        {
            using (var form = new DepartmentAddEdit())
            {
                form.OnSave += (partCode, departmentName, memo) =>
                {
                    SqlRepository.InsertDepartment(partCode, departmentName, memo);
                    RefreshDepartmentGrid();
                };
                form.ShowDialog();
            }
        }
        private void label2_Click(object sender, EventArgs e) // 수정
        {
            if (DepartmentDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택해주세요.");
                return;
            }

            int rowIndex = DepartmentDataGrid.SelectedCells[0].RowIndex;
            var row = DepartmentDataGrid.Rows[rowIndex];
            if (row.IsNewRow) return;

            string partCode = row.Cells["PartCode"].Value?.ToString() ?? "";
            string departmentName = row.Cells["DepartmentName"].Value?.ToString() ?? "";
            string memo = row.Cells["Memo"].Value?.ToString() ?? "";

            using (var form = new DepartmentAddEdit(partCode, departmentName, memo))
            {
                form.OnSave += (updatedCode, updatedName, updatedMemo) =>
                {
                    // DB Upsert
                    SqlRepository.InsertDepartment(updatedCode, updatedName, updatedMemo);

                    row.Cells["PartCode"].Value       = updatedCode;
                    row.Cells["DepartmentName"].Value = updatedName;
                    row.Cells["Memo"].Value           = updatedMemo;
                };

                form.ShowDialog();
            }
        }
        private void label3_Click(object sender, EventArgs e) // 삭제
        {
            if (DepartmentDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }
            int rowIndex = DepartmentDataGrid.SelectedCells[0].RowIndex;
            var row = DepartmentDataGrid.Rows[rowIndex];

            string code = row.Cells["PartCode"].Value?.ToString() ?? "";
            string name = row.Cells["DepartmentName"].Value?.ToString() ?? "";

            var deleteForm = new DepartmentDelete(this, code, name);
            deleteForm.ShowDialog();
        }
        private void label4_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
