using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roster_Dev.Model;


namespace Roster_Dev.Dpt
{
    
    public partial class DeptChart : Form
    {
        public DeptChart()
        {
            InitializeComponent();
            this.Load += DeptChart_Load;
        }

        private void DeptChart_Load(object sender, EventArgs e)
        {
            SetupDepartmentChart();
        }

        private void SetupDepartmentChart()
        {
            // 1. 차트 데이터 준비
            var allEmployees = SqlReposit.GetEmployees().ToList();
            var allDepartments = SqlReposit.GetDepartments().ToList();
            var allUpperDepts = SqlReposit.GetUpperDepartments().ToList();

            var chartData = from emp in allEmployees
                            join dept in allDepartments on emp.DepartmentId equals dept.DepartmentId
                            join upperDept in allUpperDepts on dept.UpperDepartmentId equals upperDept.UpperDepartmentId
                            group new { dept, upperDept } by new { upperDept.UpperDepartmentName, dept.DepartmentName } into g
                            select new ChartData
                            {
                                UpperDepartmentName = g.Key.UpperDepartmentName,
                                DepartmentName = g.Key.DepartmentName,
                                EmployeeCount = g.Count()
                            };

            // 2. 차트 컨트롤 초기화
            departmentChart.Series.Clear();

            // 3. 차트 시리즈 생성 및 바인딩
            departmentChart.SeriesTemplate.SeriesDataMember = "DepartmentName";
            departmentChart.SeriesTemplate.ArgumentDataMember = "UpperDepartmentName";
            departmentChart.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "EmployeeCount" });

            departmentChart.SeriesTemplate.View = new StackedBarSeriesView();

            // 4. 데이터 소스 바인딩
            departmentChart.DataSource = chartData.ToList();

            // 5. 차트 축과 제목 설정
            ((XYDiagram)departmentChart.Diagram).AxisX.Label.TextPattern = "{A}";
            ((XYDiagram)departmentChart.Diagram).AxisY.Label.TextPattern = "{V}";

            ChartTitle chartTitle = new ChartTitle();
            chartTitle.Text = "상위 부서별 하위 부서 인원 현황";
            departmentChart.Titles.Clear();
            departmentChart.Titles.Add(chartTitle);

            // 6. 차트 범례 설정
            departmentChart.Legend.MarkerMode = LegendMarkerMode.CheckBoxAndMarker;
            departmentChart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
        }
    }
}
