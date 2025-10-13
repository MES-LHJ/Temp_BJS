using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roster_Dev.Model;

namespace Roster_Dev.Dpt
{

    public partial class DeptChart : Form
    {
        private readonly long _currentFactoryId; // Factory ID를 저장할 멤버 변수 추가

        public DeptChart(long factoryId)
        {
            InitializeComponent();
            _currentFactoryId = factoryId; // Factory ID 초기화
            this.Load += DeptChart_Load;
        }

        private async void DeptChart_Load(object sender, EventArgs e)
        {
            await LoadChartAsync();
        }

        private async Task LoadChartAsync()
        {
            try
            {
                // 부서/사원 데이터 API 로드
                var departments = await ApiRepository.GetDepartmentsAsync(_currentFactoryId);
                var employees = await ApiRepository.GetEmployeesAsync(_currentFactoryId);

                // 부서별 인원수 계산
                var dataList = (from d in departments
                                join e in employees on d.Id equals e.DepartmentId into empGroup
                                select new
                                {
                                    DepartmentName = d.Name,
                                    EmployeeCount = empGroup.Count()
                                }).ToList();

                // 차트 초기화
                departmentChart.Series.Clear();

                // DevExpress는 Series 생성 시 ViewType 지정
                Series series = new Series("부서별 인원수", ViewType.Bar);
                series.DataSource = dataList;
                series.ArgumentDataMember = "DepartmentName";
                series.ValueDataMembers.AddRange("EmployeeCount");

                // 시각화 옵션
                ((BarSeriesView)series.View).BarWidth = 0.5; // 막대 두께
                departmentChart.Series.Add(series);

                // 축/폰트/제목 설정
                XYDiagram diagram = departmentChart.Diagram as XYDiagram;
                if (diagram != null)
                {
                    diagram.AxisX.Label.TextPattern = "{A}";
                    diagram.AxisX.Label.Angle = -45;
                    diagram.AxisX.Label.Font = new System.Drawing.Font("맑은 고딕", 9);
                    diagram.AxisX.Title.Text = "부서";
                    diagram.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;

                    diagram.AxisY.Title.Text = "인원 수";
                    diagram.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                    diagram.AxisY.Label.TextPattern = "{V}";
                }

                departmentChart.Titles.Clear();
                departmentChart.Titles.Add(new ChartTitle()
                {
                    Text = "부서별 인원수",
                    Font = new System.Drawing.Font("맑은 고딕", 9, System.Drawing.FontStyle.Bold)
                });

                departmentChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"차트 데이터를 불러오는 중 오류가 발생했습니다.\n{ex.Message}");
            }
        }
    }
}