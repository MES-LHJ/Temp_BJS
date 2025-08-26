using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }
        // 수정 모드용 생성자
        public DepartmentAddEdit(string partCode, string departName, string memo) : this()
        {
            isEditMode = true;
            PartCode.Text = partCode;
            DepartName.Text = departName;
            Memo.Text = memo;
            PartCode.Enabled = true;
        }

        private void DepartmentAddEdit_Load(object sender, EventArgs e) // 각 기능별 로드 초기화
        {
            if (isEditMode)
                button1.Text = "수정";
            else
                button1.Text = "저장";
        }

        //public event Action<string, string, string> OnSave;

        private void button1_Click(object sender, EventArgs e) // 저장 버튼
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
            //OnSave?.Invoke(
            //    PartCode.Text,
            //    DepartName.Text,
            //    Memo.Text
            //);

            MessageBox.Show(isEditMode ? "수정되었습니다." : "부서가 추가되었습니다.");
            this.Close(); // 폼 닫기
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
