using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Wordprocessing;
using Roster_Dev.Dpt;
using Roster_Dev.Model;
using Roster_Dev.UtilClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using Point = System.Drawing.Point;

namespace Roster_Dev
{
    public partial class Main : Form
    {
        private readonly ApiMethod apiMethod = new ApiMethod();
        //private Timer tokenCheckTimer;
        public Main()
        {
            InitializeComponent();
            AddEvent();
            empGrid.ToolTipController = photoToolTip;

            //SetupTokenCheckTimer();
        }

        public void AddEvent()
        {
            this.Load += Form_Load;
            this.deptBtn.Click += Dept_Click;
            this.referenceBtn.Click += Reference_Click;
            this.addBtn.Click += Add_Click;
            this.multiAddBtn.Click += MultiAdd_Click;
            this.editBtn.Click += Edit_Click;
            this.loginInfoBtn.Click += LoginInfo_Click;
            this.deleteBtn.Click += Delete_Click;
            this.convertBtn.Click += Convert_Click;
            this.exitBtn.Click += Exit_Click;
            //this.FormClosing += Main_FormClosing;
            var view = empGrid.MainView as GridView;
            view.CustomColumnDisplayText += EmpGrid_CellFormatting;
        }

        //private void SetupTokenCheckTimer()
        //{
        //    tokenCheckTimer = new Timer();
        //    tokenCheckTimer.Interval = 60000;
        //    tokenCheckTimer.Tick += TokenCheckTimer_Tick;
        //    tokenCheckTimer.Start();
        //}

        //private void TokenCheckTimer_Tick(object sender, EventArgs e)
        //{
        //    if (CurrentToken.IsExpired)
        //    {
        //        tokenCheckTimer.Stop();

        //        CurrentToken.NeedsRelogin = true;
        //        this.Close();
        //    }
        //}

        //private void Main_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (!CurrentToken.NeedsRelogin)
        //    {
        //        tokenCheckTimer?.Stop();
        //        tokenCheckTimer?.Dispose();
        // 여기에 필요한 정리 코드 (예: 데이터 저장)
        //    }
        // 토큰 만료로 닫힐 경우 (NeedsRelogin=true), Program.cs에서 타이머 정리를 처리할 수도 있습니다.

        // 기존 Exit_Click 로직의 this.Close()와 충돌 방지를 위해 주석 처리하거나 로직 조정 필요
        // 현재 Program.cs 로직 상 Main 폼이 닫히면 루프가 돌기 때문에 이대로 두어도 됩니다.
        //}

        private void EmpGrid_CellFormatting(object sender, CustomColumnDisplayTextEventArgs e)
        {
            // Password * 마킹
            if (e.Column.FieldName == "Password" && e.Value != null)
            {
                string password = e.Value.ToString();
                if (!string.IsNullOrEmpty(password))
                {
                    e.DisplayText = new string('*', password.Length);
                }
            }

            // 이미지 컬럼 파일명으로 표시
            if (e.Column.FieldName == "PhotoPath" && e.Value != null)
            {
                e.DisplayText = Path.GetFileName(e.Value.ToString());
            }
        }

        //private void RefreshGrid()
        //{
        //    var emp = SqlReposit.GetEmployees().OrderBy(e => e.EmployeeCode).ToList();

        //    empGrid.DataSource = emp;
        //}

        private async Task RefreshGridAsync()
        {
            // 사원 목록 조회 (GET)
            string jsonResponse = await apiMethod.GetAsync("employees"); // ⭐ API 엔드포인트 가정

            if (jsonResponse != null)
            {
                try
                {
                    // TODO: API 응답을 List<EmpWorkout>으로 역직렬화
                    // var emp = JsonSerializer.Deserialize<List<EmpWorkout>>(jsonResponse); 

                    // ⭐ 임시 데이터 가정 (실제 구현 시 역직렬화 로직으로 대체)
                    var emp = new List<EmpWorkout> { /* Load data from JSON */ };

                    empGrid.DataSource = emp.OrderBy(e => e.EmployeeCode).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("데이터 처리 오류: " + ex.Message, "오류");
                }
            }
            else if (CurrentToken.NeedsRelogin)
            {
                // 401 오류 발생 시 Main 폼을 닫아서 Program.cs의 재로그인 루프로 제어권 이양
                this.Close();
            }
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            await RefreshGridAsync();
        }

        private void Dept_Click(object sender, EventArgs e)
        {
            using (var Form = new Department())
            {
                Form.ShowDialog();
            }
        }

        private async void Reference_Click(object sender, EventArgs e)
        {
            await RefreshGridAsync();
        }

        private async void Add_Click(object sender, EventArgs e)
        {
            var dept = new DeptWorkout();
            using (var Form = new Emp.EmpAdd(dept))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGridAsync();
                }
            }
        }

        private void MultiAdd_Click(object sender, EventArgs e)
        {
            using (var Form = new MultiAdd())
            {
                Form.ShowDialog();
            }
        }

        private async void Edit_Click(object sender, EventArgs e)
        {
            var view = empGrid.MainView as GridView;
            if (view == null || view.FocusedRowHandle < 0)
            {
                MessageBox.Show("수정할 행을 선택하세요.");
                return;
            }

            // 현재 선택된 행의 EmployeeId 가져오기
            var empId = Convert.ToInt32(view.GetFocusedRowCellValue("EmployeeId"));

            using (var Form = new Emp.EmpEdit(empId))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGridAsync();
                }
            }
        }

        private void LoginInfo_Click(object sender, EventArgs e)
        {
            var loginInfoForm = new Login();
            loginInfoForm.ShowDialog();
        }

        private async void Delete_Click(object sender, EventArgs e)
        {
            var view = empGrid.MainView as GridView;
            var employee = view?.GetFocusedRow() as EmpWorkout;

            if (employee == null)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }

            using (var Form = new Emp.EmpDelete(employee))
            {
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    await RefreshGridAsync();
                }
            }
        }

        private void Convert_Click(object sender, EventArgs e)
        {
            if (empGrid.DataSource == null)
            {
                MessageBox.Show("변환할 데이터가 없습니다.");
                return;
            }
            Util.Instance.Convert(empGrid, "Employee.xlsx");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            CurrentToken.NeedsRelogin = false;
            this.Close();
        }
    }
}
