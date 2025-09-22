using ClosedXML.Excel;
using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roster_Dev.UtilClass
{
    public sealed class Util
    {
        private static readonly Util instance = new Util();
        public static Util Instance { get { return instance; } }
        private Util() { }
        public bool NullCheck(params Control[] texts)
        {
            foreach (var text in texts)
            {
                if (string.IsNullOrWhiteSpace(text.Text))
                {
                    string labelName = text.Tag?.ToString() ?? text.Name;
                    MessageBox.Show($"{labelName}을(를) 입력해주세요");
                    text.Focus();
                    return false;
                }
            }
            return true;
        }

        public enum Gender
        {
            Male,
            Female
        }

        public void Convert(GridControl grid, string filePath)
        {
            //grid.ExportToXlsx(filePath);
            try
            {
                string tempPath = Path.Combine(Path.GetTempPath(), $"Export_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add(grid.Name ?? "Sheet1");
                    var view = grid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
                    if (view == null)
                    {
                        MessageBox.Show("GridView가 아닙니다.");
                        return;
                    }

                    // 컬럼 헤더 추가
                    for (int col = 0; col < view.Columns.Count; col++)
                        worksheet.Cell(1, col + 1).Value = view.Columns[col].Caption;

                    // 데이터 추가
                    for (int row = 0; row < view.DataRowCount; row++)
                    {
                        int rowHandle = view.GetVisibleRowHandle(row);
                        for (int col = 0; col < view.Columns.Count; col++)
                        {
                            var cellValue = view.GetRowCellValue(rowHandle, view.Columns[col]);
                            worksheet.Cell(row + 2, col + 1).Value =
                                (cellValue == null || cellValue == DBNull.Value) ? "" : cellValue.ToString();
                        }
                    }

                    var range = worksheet.RangeUsed();
                    if (range != null)
                    {
                        range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        range.Style.Border.InsideBorder  = XLBorderStyleValues.Thin;
                    }

                    worksheet.Columns().AdjustToContents();
                    worksheet.Column(1).Width = 13;
                    worksheet.Column(2).Width = 11;
                    worksheet.Columns(3,8).Width = 10;
                    workbook.SaveAs(tempPath);
                }

                Process.Start(new ProcessStartInfo(tempPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
