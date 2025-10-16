using MetroFramework.Forms;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static Roster.Models.DepartmentWorkout;

namespace Roster
{
    public partial class deptChart : MetroForm
    {
        public deptChart()
        {
            InitializeComponent();
            this.Load += Form_Load;
            this.exit.Click += exit_Click;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            List<DepartmentCount> dataList = SqlRepository.GetDepartmentCount();

            // Series 설정
            chart.Series.Clear();
            var series = new Series("부서별 인원수");
            series.ChartType = SeriesChartType.Column; // 막대그래프
            chart.Series.Add(series);

            chart.DataSource = dataList;
            chart.Series[0].XValueMember = "DepartmentName";
            chart.Series[0].YValueMembers = "EmployeeCount";

            // x축 레이블 설정
            var chartArea = chart.ChartAreas[0];
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.LabelStyle.Font = new Font("휴먼편지체", 9);

            chart.DataBind();
        }

        private void exit_Click(object sender, EventArgs e) // 닫기
        {
            this.Close();
        }
    }
}
