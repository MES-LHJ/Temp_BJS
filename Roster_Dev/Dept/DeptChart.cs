using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roster_Dev.Model;
using static Roster_Dev.UtilClass.Util; // GlobalSettings 접근을 위해 추가

namespace Roster_Dev.Dpt
{

    public partial class DeptChart : Form
    {
        private readonly long _currentFactoryId; // Factory ID를 저장할 멤버 변수 추가

        // ⭐ 수정 1: 생성자에 factoryId 인자를 추가하고 초기화합니다.
        public DeptChart(long factoryId)
        {
            InitializeComponent();
            _currentFactoryId = factoryId; // Factory ID 초기화
            this.Load += DeptChart_Load;
        }

        // ⭐ 수정 2: Form_Load 이벤트 핸들러를 async로 변경하고 await를 사용합니다.
        private async void DeptChart_Load(object sender, EventArgs e)
        {
            await SetupDepartmentChart();
        }

        // ⭐ 수정 3: SetupDepartmentChart를 async Task로 변경하고 내부에서 await를 사용합니다.
        private async Task SetupDepartmentChart()
        {
            // 차트 데이터 준비
            // ⭐ 핵심 수정 4: ApiRepository의 비동기 호출에 await를 사용하고, factoryId를 전달합니다.
            // Task.WhenAll을 사용하여 세 가지 데이터 로딩 작업을 동시에 시작하고 완료를 기다려 성능을 개선합니다.
            var allEmployeesTask = ApiRepository.GetEmployeesAsync(_currentFactoryId);
            var allDepartmentsTask = ApiRepository.GetDepartmentsAsync(_currentFactoryId);
            var allUpperDeptsTask = ApiRepository.GetUpperDepartmentAsync(_currentFactoryId);

            try
            {
                await Task.WhenAll(allEmployeesTask, allDepartmentsTask, allUpperDeptsTask);

                var allEmployees = allEmployeesTask.Result;
                var allDepartments = allDepartmentsTask.Result;
                var allUpperDepts = allUpperDeptsTask.Result;

                // ⭐ 핵심 수정 5: LINQ 조인 필드 수정 (DepartmentWorkout 모델에 맞게)
                // Model에 따라 dept.DepartmentId -> dept.Id, dept.DepartmentName -> dept.Name 으로 수정합니다.
                var chartData = from emp in allEmployees
                                join dept in allDepartments on emp.DepartmentId equals dept.Id // emp.DepartmentId와 dept.Id 조인
                                join upperDept in allUpperDepts on dept.UpperDepartmentId equals upperDept.Id // 상위 부서 ID와 Id 조인
                                group new { dept, upperDept } by new { upperDept.UpperDepartmentName, deptName = dept.Name } into g // 하위 부서 이름은 Name 필드 사용
                                select new ChartData
                                {
                                    UpperDepartmentName = g.Key.UpperDepartmentName,
                                    DepartmentName = g.Key.deptName,
                                    EmployeeCount = g.Count()
                                };

                // 차트 컨트롤 초기화
                departmentChart.Series.Clear();

                // 차트 시리즈 생성 및 바인딩
                // StackedBar 차트 구성을 위해 SeriesDataMember와 ArgumentDataMember를 적절히 설정합니다.
                departmentChart.SeriesTemplate.SeriesDataMember = "DepartmentName"; // 하위 부서별로 막대가 쌓이도록
                departmentChart.SeriesTemplate.ArgumentDataMember = "UpperDepartmentName"; // 인자(X축)는 상위 부서 이름
                departmentChart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "EmployeeCount" });

                departmentChart.SeriesTemplate.View = new StackedBarSeriesView();

                // 데이터 소스 바인딩
                departmentChart.DataSource = chartData.ToList();

                // ... (나머지 차트 설정은 동일)
                ((XYDiagram)departmentChart.Diagram).AxisX.Label.TextPattern = "{A}";
                ((XYDiagram)departmentChart.Diagram).AxisY.Label.TextPattern = "{V}";

                ChartTitle chartTitle = new ChartTitle();
                chartTitle.Text = "부서별 인원 현황";
                departmentChart.Titles.Clear();
                departmentChart.Titles.Add(chartTitle);

                // 차트 범례 설정
                departmentChart.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
                departmentChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 불러오는 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}