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
            DepartmentDataGrid.DataSource = null; // 기존 데이터 소스 초기화
            var departments = SqlRepository.RosterCheck()
                .OrderBy(d => d.DepartmentCode); // 부서코드 기준으로 오름차순 정렬

            DepartmentDataGrid.DataSource = departments;
            DepartmentDataGrid.ClearSelection(); // 초기 선택 해제
            DepartmentDataGrid.CurrentCell = null;
        }

        private void Department_Load(object sender, EventArgs e) // 그리드 양식
        {
            DepartmentDataGrid.AutoGenerateColumns = true;

            RefreshDepartmentGrid();
        }

        private void Add_Click(object sender, EventArgs e) // 추가
        {
            using (var form = new DepartmentAddEdit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshDepartmentGrid();
                }
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
            var model = SqlRepository.UpdateDepartment(DepartmentDataGrid.Rows[rowIndex]);

            using (var form = new DepartmentAddEdit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshDepartmentGrid();
                }
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

            using (var deleteForm = new DepartmentDelete(this, code, name))
            {
                if (deleteForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshDepartmentGrid();
                }
            }
        }
        private void Exit_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
