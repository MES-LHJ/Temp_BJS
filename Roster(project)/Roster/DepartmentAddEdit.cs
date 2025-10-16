using MetroFramework.Forms;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster
{
    public partial class DepartmentAddEdit : MetroForm
    {
        public DepartmentWorkout SavedModel { get; private set; }
        private bool isEditMode = false;
        public DepartmentAddEdit()
        {
            InitializeComponent();
            this.Save.Click += Save_Click;
            this.Exit.Click += Exit_Click;
        }

        // 수정 모드용 생성자
        public DepartmentAddEdit(DepartmentWorkout model) : this()
        {
            isEditMode = true;
            partCode.Text = model.DepartmentCode;
            departName.Text = model.DepartmentName;
            memo.Text = model.Memo;
            SavedModel = model;
            partCode.Enabled = true;
        }

        private void DepartmentAddEdit_Load(object sender, EventArgs e) // 각 기능별 로드 초기화
        {
            if (isEditMode)
                Save.Text = "수정";
            else
                Save.Text = "저장";
        }


        private void Save_Click(object sender, EventArgs e) // 저장 버튼
        {
            if (string.IsNullOrWhiteSpace(partCode.Text))
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(departName.Text))
            {
                MessageBox.Show("부서명을 입력해주세요.");
                return;
            }

            try
            {
                SavedModel.DepartmentCode = partCode.Text;
                SavedModel.DepartmentName = departName.Text;
                SavedModel.Memo = memo.Text;

                if (isEditMode)
                {
                    SqlRepository.UpdateDepartment(SavedModel);
                    MessageBox.Show("수정되었습니다.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    SqlRepository.InsertDepartment(SavedModel);
                    MessageBox.Show("부서가 추가되었습니다.");
                    this.DialogResult= DialogResult.OK;
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}");
                return;
            }
            //if (DialogResult== DialogResult.OK)
            //{
            //    var dept = new Department();
            //    dept.RefreshDepartmentGrid();
            //}
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
