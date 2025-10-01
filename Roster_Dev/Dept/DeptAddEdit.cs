using Roster_Dev.Model;
using Roster_Dev.UtilClass;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static DevExpress.Data.Filtering.Helpers.SubExprHelper.ThreadHoppingFiltering;

namespace Roster_Dev.Dept
{
    public partial class DeptAddEdit : Form
    {
        private DepartmentWorkout dept;
        private bool isEditMode;
        private long factoryId;

        // 추가 모드
        public DeptAddEdit(long factoryId)
        {
            InitializeComponent();
            AddEvent();
            isEditMode = false;
            dept = new DepartmentWorkout();
            this.factoryId = factoryId;
        }

        // 수정 모드
        public DeptAddEdit(DepartmentWorkout dept)
        {
            InitializeComponent();
            AddEvent();

            isEditMode = true;
            this.dept = dept;

            this.factoryId = dept.FactoryId;
        }

        private void AddEvent()
        {
            this.Load += Form_Load;
            this.upperDeptCode.EditValueChanged += UpperDeptCode_EditValueChanged;
            this.addEditBtn.Click += Save_Click;
            this.cancel.Click += Cancel_Click;
        }

        private void SetTag()
        {
            upperDeptCode.Tag = upperDeptCodeLayout.Text;
            deptCode.Tag      = deptCodeLayout.Text;
            deptName.Tag      = deptNameLayout.Text;
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                this.Text = "부서 수정";
                deptAddEditLabel.Text = "부서 수정";
                addEditBtn.Text = "수정";
                cancel.Text = "닫기";
                cancel.BackColor = Color.FromArgb(171, 171, 171);
            }
            else
            {
                this.Text = "부서 추가";
                deptAddEditLabel.Text = "부서 추가";
                addEditBtn.Text = "추가";
            }

            SetTag();

            // 상위부서 목록 로드
            var upperDepartments = await ApiRepository.GetUpperDepartmentAsync(factoryId);
            upperDeptCode.Properties.Items.Clear();
            foreach (var upper in upperDepartments)
            {
                upperDeptCode.Properties.Items.Add(upper);
            }

            if (isEditMode && dept != null)
            {
                // 현재 부서 값 세팅
                var selectedUpper = upperDepartments
                    .FirstOrDefault(u => u.UpperDepartmentId == dept.UpperDepartmentId);

                if (selectedUpper != null)
                {
                    upperDeptCode.SelectedItem = selectedUpper;
                    upperDeptName.Text = selectedUpper.UpperDepartmentName;
                }
                deptCode.Text = dept.Code;
                deptName.Text = dept.Name;
                memo.Text     = dept.Memo;
            }
        }

        // 상위부서 선택 시 상위부서명 표시
        private void UpperDeptCode_EditValueChanged(object sender, EventArgs e)
        {
            if (upperDeptCode.SelectedItem is DepartmentWorkout selectedUpper)
                upperDeptName.Text = selectedUpper.UpperDepartmentName;
            else
                upperDeptName.Text = string.Empty;
        }

        private async void Save_Click(object sender, EventArgs e)
        {
            if (!Util.Instance.NullCheck(upperDeptCode, deptCode, deptName))
                return;

            try
            {
                var selectedUpper = upperDeptCode.SelectedItem as UpperDepartmentWorkout;

                var dpt = new DepartmentWorkout
                {
                    UpperDepartmentId = selectedUpper.UpperDepartmentId,
                    Id      = dept.Id,
                    Code    = deptCode.Text.Trim(),
                    Name    = deptName.Text.Trim(),
                    Memo    = memo.Text.Trim(),
                    FactoryId = this.factoryId
                };

                if (isEditMode)
                {
                    await ApiRepository.UpdateDepartmentAsync(dpt);
                    MessageBox.Show("부서가 수정되었습니다.");
                }
                else
                {
                    await ApiRepository.InsertDepartmentAsync(dpt);
                    MessageBox.Show("부서가 추가되었습니다.");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
