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
    public partial class UpperDeptAddEdit : Form
    {
        private bool isEditMode = false;
        private UpperDeptWorkout upperDpt;
        public UpperDeptAddEdit()
        {
            InitializeComponent();
            AddEvent();
            upperDpt = new UpperDeptWorkout();
        }
        internal UpperDeptAddEdit(UpperDeptWorkout dept) : this()
        {
            isEditMode = true;
            this.upperDpt = dept;
        }
        private void AddEvent()
        {
            this.Load += Form_Load;
            this.addEditBtn.Click += Save_Click;
            this.cancel.Click += Cancel_Click;
        }
        private void SetTag()
        {
            upperDeptCode.Tag = upperDeptCodeLayout.Text;
            upperDeptName.Tag = upperDeptNameLayout.Text;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                this.Text = "상위 부서 수정";
                upperDeptAddEditLabel.Text = "상위 부서 수정";
                addEditBtn.Text = "수정";
                cancel.Text = "닫기";
                cancel.BackColor = Color.FromArgb(171, 171, 171,255);
            }
            else
            {
                this.Text = "부서 추가";
                addEditBtn.Text = "추가";
            }
            SetTag();

            if (isEditMode && upperDpt != null)
            {
                upperDeptCode.Text = upperDpt.UpperDepartmentCode;
                upperDeptName.Text = upperDpt.UpperDepartmentName;
                memo.Text = upperDpt.Memo;
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (!UtilClass.Util.Instance.NullCheck(upperDeptCode, upperDeptName))
                return;
            try
            {
                var upperDept = new UpperDeptWorkout
                {
                    UpperDepartmentId = upperDpt.UpperDepartmentId,
                    UpperDepartmentCode = upperDeptCode.Text.Trim(),
                    UpperDepartmentName = upperDeptName.Text.Trim(),
                    Memo = memo.Text
                };

                if (isEditMode)
                {
                    SqlReposit.UpdateUpperDept(upperDept);
                    MessageBox.Show("수정 되었습니다");
                }
                else
                {
                    SqlReposit.InsertUpperDept(upperDept);
                    MessageBox.Show("추가 되었습니다");
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"오류가 발생했습니다.: {ex.Message}");
            }
            return;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
