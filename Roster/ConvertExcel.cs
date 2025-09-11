using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Roster
{
    internal class ConvertExcel
    {
        public class ExcelOpen
        {
            private void ConvertExcel(DataGridView view)
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;  //엑셀 바로 띄우기

                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];

                //헤더출력
                for (int i = 0; i < MainRoster.employeeDataGrid.Columns.Count; i++)
                {
                    worksheet.Cells[1, i+1] = DataGridView.Columns[i].HeaderText;
                }

                //데이터 출력
                for (int i = 0; i < DataGridView.Row.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();
                    }
                }
            }
        }
    }
}
