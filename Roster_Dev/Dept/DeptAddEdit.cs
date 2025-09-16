using Roster_Dev.Model;
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
    public partial class DeptAddEdit : Form
    {
        private bool isEditMode = false;
        public DeptAddEdit()
        {
            InitializeComponent();
            AddEvent();
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
            deptCode.Tag = deptCodeLayout.Text;
            deptName.Tag = deptNameLayout.Text;
        }

        internal DeptAddEdit(DeptWorkout dept) : this()
        {
            isEditMode = true;
            // 상위부서 목록을 가져옴
            var upperDepartments = SqlReposit.GetUpperDepartments();

            // 현재 Dept가 가지고 있는 UpperDepartmentId에 맞는 상위부서코드 찾기
            var upperDept = upperDepartments
                .FirstOrDefault(u => u.UpperDepartmentId == dept.UpperDepartmentId);

            if (upperDept != null)
            {
                // EditValue를 Id로 매핑
                upperDeptCode.Properties.DataSource = upperDepartments;
                upperDeptCode.Properties.DisplayMember = "UpperDepartmentCode";
                upperDeptCode.Properties.ValueMember = "UpperDepartmentId";

                // 실제 선택값을 Id로 지정하고 화면엔 Code가 보임
                upperDeptCode.EditValue = upperDept.UpperDepartmentId;
            }
            deptCode.Text = dept.DepartmentCode;
            deptName.Text = dept.DepartmentName;
            memo.Text = dept.Memo;
        }

        private void UpperDeptCode_EditValueChanged(object sender, EventArgs e)
        {
            if(upperDeptCode.EditValue is UpperDeptWorkout upperDept)
            {
                upperDeptName.Text = upperDept.UpperDepartmentName;
            }
            else
            {
                upperDeptName.Text = string.Empty;
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                this.Text = "부서 수정";
                deptAddEditLabel.Text = "부서수정";
                addEditBtn.Text = "수정";
                cancel.Text = "닫기";
                cancel.BackColor = Color.FromArgb(171, 171, 171);
            }
            else
            {
                this.Text = "부서 추가";
                addEditBtn.Text = "추가";
            }

            SetTag();
            // 상위부서코드
            var upperDepartments = SqlReposit.GetUpperDepartments()
                .OrderBy(u => u.UpperDepartmentId)
                .ToList();
            upperDeptCode.Properties.DataSource = upperDepartments;
            upperDeptCode.Properties.DisplayMember = "UpperDepartmentCode";
            upperDeptCode.Properties.ValueMember = "UpperDepartmentId";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!UtilClass.Util.Instance.NullCheck(upperDeptCode, deptCode, deptName))
                return;

            try
            {
                var dpt = new DeptWorkout
                {
                    UpperDepartmentId = (long)upperDeptCode.EditValue,
                    DepartmentCode = deptCode.Text.Trim(),
                    DepartmentName = deptName.Text.Trim(),
                    Memo = memo.Text.Trim()
                };

                if (isEditMode)
                {
                    SqlReposit.UpdateDept(dpt);
                    MessageBox.Show("부서가 수정되었습니다.");
                }
                else
                {
                    SqlReposit.InsertDept(dpt);
                    MessageBox.Show("부서가 추가되었습니다.");
                }

                // 저장 로직 추가
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류가 발생했습니다: {ex.Message}");
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
