using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.Emp
{
    public partial class EmpEdit : Form
    {
        public EmpEdit()
        {
            InitializeComponent();
            AddEvent();
        }
        private void AddEvent()
        {
            this.Load += Form_Load;
            this.addEditBtn.Click += Save_Click;
            this.photo.Click += Photo_Click;
            this.cancel.Click += Cancel_Click;
        }

        private void SetTag()
        {
            upperDeptCode.Tag = upperDeptCodeLayout.Text;
            deptCode.Tag = deptCodeLayout.Text;
            empCode.Tag = empCodeLayout.Text;
            empName.Tag = empNameLayout.Text;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            SetTag();

            //if (_deptWorkout != null)
            //{
            //    foreach (UpperDeptWorkout item in upperDeptCode.Properties.Items)
            //    {
            //        if(item.UpperDepartmentId == _deptWorkout.UpperDepartmentId)
            //        {
            //            upperDeptCode.EditValue = item;
            //            upperDeptName.Text = item.UpperDepartmentName;
            //            break;
            //        }
            //    }
            //}
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (!UtilClass.Util.Instance.NullCheck(upperDeptCode, deptCode, empCode, empName))
            {
                return;
            }
            // Save logic here
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Photo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "사진 선택";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image selectedImage = Image.FromFile(openFileDialog.FileName);
                        photo.Image = selectedImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("이미지를 불러오는 중 오류가 발생했습니다: " + ex.Message);
                    }
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
