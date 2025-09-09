using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Roster.Models;
using System.IO;

namespace Roster
{
    public partial class RosterEdit : MetroForm
    {
        private long EmployeeId;
        public RosterWorkout SavedModel { get; private set; }
        public RosterWorkout Model;
        private string currentPhotoPath;
        public RosterEdit(RosterWorkout model)
        {
            InitializeComponent();
            EmployeeId = model.EmployeeId;
            Model = model;
            this.Load += RosterEdit_Load;
            this.PartCode.SelectedIndexChanged += PartCode_SelectedIndexChanged;
            this.Male.CheckedChanged += Male_CheckedChanged_1;
            this.Female.CheckedChanged += Female_CheckedChanged_1;
            this.PhoneNum.TextChanged += PhoneNum_TextChanged;
            this.changePhoto.Click += ChangePhoto_Click;
            this.Save.Click += Save_Click;
            this.Exit.Click += Exit_Click_1;

            EmployeeCo.DataBindings.Add("Text", model, nameof(model.EmployeeCode));
            EmployeeName.DataBindings.Add("Text", model, nameof(model.EmployeeName));
            ID.DataBindings.Add("Text", model, nameof(model.ID));
            Pass.DataBindings.Add("Text", model, nameof(model.Password));
            Position.DataBindings.Add("Text", model, nameof(model.Position));
            Form_of_employment.DataBindings.Add("Text", model, nameof(model.Employment));
            Email.DataBindings.Add("Text", model, nameof(model.Email));
            PhoneNum.DataBindings.Add("Text", model, nameof(model.PhoneNum));
            MessengerId.DataBindings.Add("Text", model, nameof(model.MessengerID));
            Memo.DataBindings.Add("Text", model, nameof(model.Memo));

            Male.Checked = (model.Gender == RosterAdd.Gender.Male);
            Female.Checked = (model.Gender == RosterAdd.Gender.Female);

            // 사진
            if (!string.IsNullOrEmpty(model.PhotoPath) && File.Exists(model.PhotoPath))
            {
                photo.Image = Image.FromFile(model.PhotoPath);
                photo.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void RosterEdit_Load(object sender, EventArgs e) // 폼 로드 시 콤보 박스 초기화 및 정렬
        {
            //PartCode.Items.Clear(); // 부서 코드 콤보박스 초기화

            var departments = SqlRepository.GetDepartments() // 부서코드 오름차순 정렬
                .OrderBy(d => d.DepartmentCode).ToList();

            //PartCode.Items.AddRange(departments.ToArray()); // 부서코드 콤보박스에 파싱
            PartCode.DataSource = departments;
            PartCode.DisplayMember = "DepartmentCode";
            PartCode.ValueMember = "DepartmentId";

            PartCode.SelectedValue = (int)Model.DepartmentId;
        }

        private void PartCode_SelectedIndexChanged(object sender, EventArgs e) // 부서 코드
        {
            if (PartCode.SelectedItem is DepartmentWorkout dept)
            {
                DepartName.Text = dept.DepartmentName;
            }
            else
            {
                DepartName.Text = string.Empty;
            }
        }

        private void Male_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Male.Checked) Female.Checked = false;
        }

        private void Female_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Female.Checked) Male.Checked = false;
        }

        private void PhoneNum_TextChanged(object sender, EventArgs e) // 휴대전화 번호 포맷팅
        {
            // 현재 커서 위치 저장
            int oldSelectionStart = PhoneNum.SelectionStart;
            int oldLength = PhoneNum.Text.Length;

            // 숫자만 추출 (최대 11자리로 제한)
            string digits = new string(PhoneNum.Text.Where(char.IsDigit).ToArray());
            if (digits.Length > 11)
                digits = digits.Substring(0, 11);

            // 010으로 시작하고 11자리 이하일 때만 포맷 적용
            string formatted = digits;
            if (digits.StartsWith("010"))
            {
                if (digits.Length > 7)
                    formatted = $"{digits.Substring(0, 3)}-{digits.Substring(3, 4)}-{digits.Substring(7)}";
                else if (digits.Length > 3)
                    formatted = $"{digits.Substring(0, 3)}-{digits.Substring(3)}";
            }
            else
            {
                formatted = digits;
            }

            // 값이 다를 때만 갱신 (무한루프 방지)
            if (PhoneNum.Text != formatted)
            {
                // 하이픈 개수 차이 계산
                int oldHyphenCount = PhoneNum.Text.Take(oldSelectionStart).Count(c => c == '-');
                int newHyphenCount = formatted.Take(oldSelectionStart).Count(c => c == '-');

                PhoneNum.Text = formatted;

                // 커서 위치 보정
                int newSelectionStart = oldSelectionStart + (newHyphenCount - oldHyphenCount);
                PhoneNum.SelectionStart = Math.Max(0, Math.Min(newSelectionStart, PhoneNum.Text.Length));
            }
        }

        private void ChangePhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.bmp";
                dialog.Title = "사원 이미지 변경";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    photo.Image = Image.FromFile(dialog.FileName);
                    photo.SizeMode = PictureBoxSizeMode.StretchImage;
                    currentPhotoPath = dialog.FileName;
                }
            }
        }

        private void Save_Click(object sender, EventArgs e) // 저장 버튼
        {
            if (string.IsNullOrWhiteSpace(PartCode.Text))
            {
                MessageBox.Show("부서코드를 입력해주세요.");
                PartCode.Focus();
                PartCode.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(EmployeeCo.Text))
            {
                MessageBox.Show("사원코드를 입력해주세요.");
                EmployeeCo.Focus();
                EmployeeCo.SelectAll();
                return;
            }
            if (string.IsNullOrWhiteSpace(EmployeeName.Text))
            {
                MessageBox.Show("사원명을 입력해주세요.");
                EmployeeName.Focus();
                EmployeeName.SelectAll();
                return;
            }

            //if (!RosterAdd.IsValidEmail(Email.Text))
            //{
            //    MessageBox.Show("올바른 이메일 형식이 아닙니다.");
            //    Email.Focus();
            //    Email.SelectAll();
            //    return;
            //}

            try
            {
                // 저장 폴더
                string imagesFolder = @"C:\work\Roster\picture";

                // 원본 파일이 있다면 삭제
                if (!string.IsNullOrEmpty(Model.PhotoPath) && File.Exists(Model.PhotoPath))
                {
                    if (photo.Image != null)
                    {
                        photo.Image.Dispose();
                        photo.Image = null;
                    }
                    File.Delete(Model.PhotoPath);
                }

                // 변경할 이미지 경로를 기존 이미지 경로로 설정
                string newPhotoPath = Model.PhotoPath;

                if (!string.IsNullOrEmpty(currentPhotoPath))  //변경할 이미지가 있을 경우 실행
                {
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(currentPhotoPath)}";  //중복 방지를 위해 GUID를 이용 -> 새로운 파일명 생성
                    newPhotoPath = Path.Combine(imagesFolder, fileName);

                    //if (!Directory.Exists(imagesFolder))
                    //    Directory.CreateDirectory(imagesFolder); //로컬로 수동 작업하는 이상 불필요한 코드(사진 폴더가 존재하지 않으면 폴더 생성)

                    File.Copy(currentPhotoPath, newPhotoPath);
                }

                SavedModel = new RosterWorkout
                {
                    DepartmentId = (int)PartCode.SelectedValue,
                    EmployeeId = EmployeeId,
                    EmployeeCode = EmployeeCo.Text,
                    EmployeeName = EmployeeName.Text,
                    ID = ID.Text,
                    Password = Pass.Text,
                    Position = Position.Text,
                    Employment = Form_of_employment.Text,
                    Email = Email.Text,
                    PhoneNum = PhoneNum.Text,
                    Gender = Male.Checked ? RosterAdd.Gender.Male : (Female.Checked ? RosterAdd.Gender.Female : (RosterAdd.Gender?)null),
                    MessengerID = MessengerId.Text,
                    Memo = Memo.Text,
                    PhotoPath = newPhotoPath
                };

                SqlRepository.UpdateEmployee(SavedModel);

                MessageBox.Show("수정 되었습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close(); // 폼 닫기
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void Exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
