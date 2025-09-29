using Roster_Dev.Model;
using Roster_Dev.UtilClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.Dept
{
    public partial class UpperDept : Form
    {
        public UpperDept(long factoryId)
        {
            InitializeComponent();
            AddEvent();
        }
        private void AddEvent()
        {
            this.Load += Form_Load;
            this.convertBtn.Click += Convert_Click;
            this.upperDeptAddBtn.Click += Add_Click;
            this.upperDeptEditBtn.Click += Edit_Click;
            this.deleteBtn.Click += Delete_Click;
            this.exitBtn.Click += Exit_Click;
        }

        private async void RefreshGrid()
        {
            //var upperDepartments = SqlReposit.GetUpperDepartments()
            //    .OrderBy(u => u.UpperDepartmentCode)
            //    .ToList();
            //upperDeptGrid.DataSource = upperDepartments;
            //upperDeptGrid.Refresh();

            try
            {
                // 1. ApiRepository를 사용하여 API에서 사원 목록을 비동기로 가져옵니다.
                // GetEmployeesAsync는 이미 List<EmployeeWorkout>을 반환하도록 ApiRepository에 정의되어 있습니다.
                var upperDeptList = await ApiRepository.GetUpperDepartmentAsync();

                // 2. 가져온 데이터를 GridControl (empGrid)에 바인딩합니다.
                // DevExpress GridControl에 List<T>를 바인딩합니다.
                upperDeptGrid.DataSource = upperDeptList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            var upperDepartments = ApiRepository.GetUpperDepartmentAsync();

            upperDeptGrid.DataSource = upperDepartments;
            RefreshGrid();
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if(upperDeptGrid.DataSource == null)
            {
                MessageBox.Show("변환할 데이터가 없습니다.");
                return;
            }
            Util.Instance.Convert(upperDeptGrid, "UpperDept.xlsx");
        }

        private void Add_Click(object sender, EventArgs e)
        {
            using (var Form = new UpperDeptAddEdit())
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            var view = upperDeptGrid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null) return;
            var selectedRow = view.GetFocusedRow() as UpperDeptWorkout;
            if (selectedRow == null)
            {
                MessageBox.Show("수정할 부서를 선택하세요.");
                return;
            }
            using (var Form = new UpperDeptAddEdit(selectedRow))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            var view = upperDeptGrid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

            var selectedRow = view?.GetFocusedRow() as UpperDeptWorkout;
            if (selectedRow == null)
            {
                MessageBox.Show("삭제할 부서를 선택하세요.");
                return;
            }
            using (var form = new UpperDeptDelete(selectedRow))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
