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
                    worksheet.Columns(3, 8).Width = 10;
                    workbook.SaveAs(tempPath);
                }

                Process.Start(new ProcessStartInfo(tempPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        public static class GlobalSettings
        {
            // 현재 로그인한 사용자가 선택하거나 접속한 공장의 ID
            public static long CurrentFactoryId { get; private set; } = 0;

            // Factory ID를 설정하는 메서드 (로그인 성공 시 호출)
            public static void SetFactoryId(long factoryId)
            {
                if (factoryId <= 0)
                {
                    // 유효하지 않은 Factory ID 처리 로직 (예외 발생 등)
                    throw new ArgumentException("유효한 Factory ID가 아닙니다.");
                }
                CurrentFactoryId = factoryId;
            }

            // Factory ID를 가져오는 속성 (부서 조회 시 호출)
            public static long GetFactoryId()
            {
                if (CurrentFactoryId <= 0)
                {
                    // 로그인이나 공장 선택이 안 된 경우의 예외 처리
                    // 실제 앱에서는 로그인 화면으로 돌아가게 해야 합니다.
                    throw new InvalidOperationException("현재 선택된 Factory ID가 없습니다. 로그인 또는 공장 선택을 먼저 진행하세요.");
                }
                return CurrentFactoryId;
            }
        }
    }
}
