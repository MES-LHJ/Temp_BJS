using MetroFramework.Forms;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Roster.Models;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace Roster
{
    public partial class Department : MetroForm
    {
        public Department()
        {
            InitializeComponent();
            this.Load += Department_Load;
            this.chart.Click += chart_Click;
            this.add.Click += add_Click;
            this.edit.Click += edit_Click;
            this.delete.Click += delete_Click;
            this.exit.Click += exit_Click;
        }
        public void RefreshDepartmentGrid() // 부서 데이터 정렬 및 갱신
        {
            DepartmentDataGrid.AutoGenerateColumns = false;
            var departments = SqlRepository.GetDepartments()
                .OrderBy(d => d.DepartmentCode).ToList(); // 부서코드 기준으로 오름차순 정렬

            DepartmentDataGrid.DataSource = departments;
        }

        private void Department_Load(object sender, EventArgs e) // 그리드 양식
        {
            RefreshDepartmentGrid();
        }
        
        private void chart_Click(object sender, EventArgs e) // 차트
        {
            using (var chartForm = new deptChart())
            {
                chartForm.ShowDialog();
            }
        }

        private void add_Click(object sender, EventArgs e) // 추가
        {
            using (var form = new DepartmentAddEdit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshDepartmentGrid();
                }
            }
        }
        private void edit_Click(object sender, EventArgs e) // 수정
        {
            var department = DepartmentDataGrid.CurrentRow?.DataBoundItem as DepartmentWorkout;

            if (department == null)
            {
                MessageBox.Show("수정할 항목을 선택해주세요.");
                return;
            }

            using (var form = new DepartmentAddEdit(department))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshDepartmentGrid();
                }
            }
        }
        private void delete_Click(object sender, EventArgs e) // 삭제
        {
            var department = DepartmentDataGrid.CurrentRow?.DataBoundItem as DepartmentWorkout;

            if (department == null)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }

            using (var deleteForm = new DepartmentDelete(department))
            {
                if (deleteForm.ShowDialog() == DialogResult.OK)
                {
                    RefreshDepartmentGrid();
                }
            }
        }
        private void exit_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
