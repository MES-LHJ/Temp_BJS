using MetroFramework.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Roster.Models;

namespace Roster
{
    public partial class Department : MetroForm
    {
        public Department()
        {
            InitializeComponent();
            this.Load += Department_Load;
            this.Add.Click += Add_Click;
            this.Edit.Click += Edit_Click;
            this.Delete.Click += Delete_Click;
            this.Exit.Click += Exit_Click;
        }
        private void RefreshDepartmentGrid() // 부서 데이터 정렬 및 갱신
        {
            var departments = SqlRepository.GetDepartments()
                .OrderBy(d => int.TryParse(d.DepartmentCode, out var n) ? n : int.MaxValue)
                .ThenBy(d => d.DepartmentCode).ToList();

            DepartmentDataGrid.DataSource = departments;
        }

        private void Department_Load(object sender, EventArgs e) // 그리드 양식
        {
            DepartmentDataGrid.AutoGenerateColumns = true;
            var departments = SqlRepository.GetDepartment()
                .AsEnumerable()
                .Select(DepartmentValue.FromDataRow)
                .ToList();

            RefreshDepartmentGrid();
        }

        private void Add_Click(object sender, EventArgs e) // 추가
        {
            using (var form = new DepartmentAddEdit())
            {
                form.ShowDialog();
            }
        }
        private void Edit_Click(object sender, EventArgs e) // 수정
        {
            if (DepartmentDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("수정할 항목을 선택해주세요.");
                return;
            }

            int rowIndex = DepartmentDataGrid.SelectedCells[0].RowIndex;
            var model = DepartmentValue.FromGridRow(DepartmentDataGrid.Rows[rowIndex]);

            using (var form = new DepartmentAddEdit(model))
            {
                form.ShowDialog();
            }
        }
        private void Delete_Click(object sender, EventArgs e) // 삭제
        {
            if (DepartmentDataGrid.SelectedCells.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }
            int rowIndex = DepartmentDataGrid.SelectedCells[0].RowIndex;
            var row = DepartmentDataGrid.Rows[rowIndex];

            string code = row.Cells["DepartmentCode"].Value?.ToString() ?? "";
            string name = row.Cells["DepartmentName"].Value?.ToString() ?? "";

            var deleteForm = new DepartmentDelete(this, code, name);
            deleteForm.ShowDialog();
        }
        private void Exit_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
