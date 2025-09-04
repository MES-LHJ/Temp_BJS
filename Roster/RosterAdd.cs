using MaterialSkin;
using MetroFramework.Forms;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Roster.RosterAdd;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Roster
{
    public partial class RosterAdd : MetroForm
    {
        public RosterAdd()
        {
            InitializeComponent();
            this.AcceptButton = this.Save;
            this.Load +=RosterAdd_Load;
            this.PartCode.SelectedIndexChanged += PartCode_SelectedIndexChanged;
            this.Save.Click += Save_Click;
            this.Exit.Click += Exit_Click;
            this.Pass.KeyPress += Pass_KeyPress;
            this.PhoneNum.TextChanged += PhoneNum_TextChanged;
            this.Male.CheckedChanged += Male_CheckedChanged;
            this.Female.CheckedChanged += Female_CheckedChanged;
            this.insertPhoto.Click += InsertPhoto_Click;
        }

        private string tempPhotoPath;

        public enum Gender
        {
            Male,
            Female,
        }

        private void RosterAdd_Load(object sender, EventArgs e) // 폼 로드 시 콤보 박스 초기화 및 정렬
        {
            // 부서 코드 콤보박스 초기화
            //PartCode.Items.Clear();

            // 부서코드 오름차순 정렬
            var departments = SqlRepository.GetDepartments()
                .OrderBy(d => d.DepartmentCode).ToList();

            // 부서코드 콤보박스에 파싱
            //PartCode.Items.AddRange(departments.ToArray());
            PartCode.DataSource = null;
            PartCode.DataSource = departments;
            PartCode.DisplayMember = "DepartmentCode";
            PartCode.ValueMember = "DepartmentId";

            PartCode.SelectedIndex = -1;
        }

        private void PartCode_SelectedIndexChanged(object sender, EventArgs e) // 부서 코드
        {
            DepartmentWorkout departmentWorkout = PartCode.SelectedItem as DepartmentWorkout;
            if (departmentWorkout != null)
            {
                DepartName.Text = departmentWorkout.DepartmentName;
            }
            else
            {
                DepartName.Text = string.Empty;
            }
        }

        //private bool IsValidPassword(string password) // 비밀번호 형식 검증
        //{
        //    // 영문, 숫자 포함 8자리 이상
        //    return Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
        //}

        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            if (Male.Checked) Female.Checked = false;
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            if (Female.Checked) Male.Checked = false;
        }


        private void Pass_KeyPress(object sender, KeyPressEventArgs e) // 비밀번호 형식
        {
            // 영문(대소문자) 또는 숫자가 아니면 입력x
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true; // 입력 차단
            }
        }

        private bool isFormatting = false;

        private void PhoneNum_TextChanged(object sender, EventArgs e)
        {
            if (isFormatting) return;
            isFormatting = true;

            int oldSelectionStart = PhoneNum.SelectionStart;

            string digits = new string(PhoneNum.Text.Where(char.IsDigit).ToArray());
            if (digits.Length > 11)
                digits = digits.Substring(0, 11);

            string formatted = digits;
            if (digits.StartsWith("010"))
            {
                if (digits.Length > 7)
                    formatted = $"{digits.Substring(0, 3)}-{digits.Substring(3, 4)}-{digits.Substring(7)}";
                else if (digits.Length > 3)
                    formatted = $"{digits.Substring(0, 3)}-{digits.Substring(3)}";
            }

            if (PhoneNum.Text != formatted)
            {
                PhoneNum.Text = formatted;
                PhoneNum.SelectionStart = Math.Min(oldSelectionStart, PhoneNum.Text.Length);
            }

            isFormatting = false;
        }

        public static bool IsValidEmail(string email) // 이메일 형식 검증
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        private void InsertPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                dialog.Title = "사원 이미지 선택";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    photo.Image = Image.FromFile(dialog.FileName);
                    photo.SizeMode = PictureBoxSizeMode.StretchImage;

                    tempPhotoPath = dialog.FileName;
                }
            }
        }

        public RosterWorkout SavedModel { get; private set; }
        private void Save_Click(object sender, EventArgs e) // 저장 버튼
        {
            if (string.IsNullOrWhiteSpace(PartCode.Text))
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                PartCode.Focus();
                PartCode.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(EmployeeCode.Text))
            {
                MessageBox.Show("사원코드를 입력해주세요.");
                EmployeeCode.Focus();
                EmployeeCode.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(EmployeeName.Text))
            {
                MessageBox.Show("사원명을 입력해주세요.");
                EmployeeName.Focus();
                EmployeeName.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(ID.Text))
            {
                MessageBox.Show("로그인 ID를 입력해주세요.");
                ID.Focus();
                ID.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(Pass.Text))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                Pass.Focus();
                Pass.SelectAll();
                return;
            }

            // 이메일 형식 검증
            //if (!IsValidEmail(Email.Text))
            //{
            //    MessageBox.Show("올바른 이메일 형식이 아닙니다.");
            //    Email.Focus();
            //    Email.SelectAll();
            //    return;
            //}

            //if (!IsValidPassword(Pass.Text))
            //{
            //    // 비밀번호 규칙 x
            //    MessageBox.Show("비밀번호는 영문, 숫자를 포함하여 8자리 이상이어야 합니다.");
            //    Pass.Focus();
            //    Pass.SelectAll();
            //    return;
            //}

            if (photo.Image != null && !string.IsNullOrEmpty(tempPhotoPath))
            {
                try
                {
                    // 저장 폴더 (exe 실행 경로\picture)
                    string imagesFolder = Path.Combine(Application.StartupPath, "picture");
                    if (!Directory.Exists(imagesFolder))
                        Directory.CreateDirectory(imagesFolder);

                    // 원본 파일명 그대로 유지
                    string fileName = Path.GetFileName(tempPhotoPath);
                    string newPhotoPath = Path.Combine(imagesFolder, fileName);

                    // 폴더에 복사 (이미 있으면 덮어쓰기)
                    File.Copy(tempPhotoPath, newPhotoPath, true);

                    var newModel = new RosterWorkout
                    {
                        DepartmentId = (int)PartCode.SelectedValue,
                        EmployeeCode = EmployeeCode.Text,
                        EmployeeName = EmployeeName.Text,
                        ID = ID.Text,
                        Password = Pass.Text,
                        Email = Email.Text,
                        PhoneNum = PhoneNum.Text,
                        Position = Position.Text,
                        Employment = Employment.Text,
                        Gender = Male.Checked ? Gender.Male : (Female.Checked ? Gender.Female : (Gender?)null),
                        MessengerID = MessengerId.Text,
                        Memo = Memo.Text,
                        PhotoPath = newPhotoPath
                    };


                    SavedModel = SqlRepository.InsertEmployee(newModel);

                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("사원이 추가되었습니다.");
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("사진을 선택해주세요");
            }
        }

        private void Exit_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
