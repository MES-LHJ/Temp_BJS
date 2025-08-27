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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Roster
{
    public partial class DepartmentAddEdit : MetroForm
    {
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
            PartCode.Text = model.DepartmentCode;
            DepartName.Text = model.DepartmentName;
            Memo.Text = model.Memo;
            PartCode.Enabled = true;
        }

        private void DepartmentAddEdit_Load(object sender, EventArgs e) // 각 기능별 로드 초기화
        {
            if (isEditMode)
                Save.Text = "수정";
            else
                Save.Text = "저장";
        }

        public DepartmentWorkout SavedModel { get; private set; }
        private void Save_Click(object sender, EventArgs e) // 저장 버튼
        {
            if (string.IsNullOrWhiteSpace(PartCode.Text))
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(DepartName.Text))
            {
                MessageBox.Show("부서명을 입력해주세요.");
                return;
            }

            try
            {
                SavedModel = DepartmentValue.FromFormConstrols(this);

                if (isEditMode)
                {
                    DepartmentValue.UpdateDepartment(SavedModel);
                    MessageBox.Show("수정되었습니다.");
                    this.Close();
                }
                else
                {
                    DepartmentValue.InsertDepartment(SavedModel);
                    MessageBox.Show("부서가 추가되었습니다.");
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}");
                return;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
