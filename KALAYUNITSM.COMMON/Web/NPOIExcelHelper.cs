using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;

namespace KALAYUNITSM.COMMON
{
    public class NPOIExcelHelper
    {
        private string _title;
        private string _sheetName;
        private string _filePath;
        public NPOIExcelHelper()
        {

        }
        public NPOIExcelHelper(string sheetName, string title)
        {
            _sheetName = sheetName;
            _title = title;
        }
        public byte[] ToExcelByte(DataTable table)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buffer = null;
            IWorkbook workBook = new HSSFWorkbook();
            this._sheetName = this._sheetName.IsEmpty() ? "sheet1" : this._sheetName;
            ISheet sheet = workBook.CreateSheet(this._sheetName);

            //处理表格标题
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue(this._title);
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, table.Columns.Count - 1));
            row.Height = 500;

            ICellStyle cellStyle = workBook.CreateCellStyle();
            IFont font = workBook.CreateFont();
            font.FontName = "微软雅黑";
            font.FontHeightInPoints = 17;
            cellStyle.SetFont(font);
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.Alignment = HorizontalAlignment.Center;
            row.Cells[0].CellStyle = cellStyle;

            //处理表格列头
            row = sheet.CreateRow(1);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                row.CreateCell(i).SetCellValue(table.Columns[i].ColumnName);
                row.Height = 350;
                sheet.AutoSizeColumn(i);
            }

            //处理数据内容
            for (int i = 0; i < table.Rows.Count; i++)
            {
                row = sheet.CreateRow(2 + i);
                row.Height = 250;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    row.CreateCell(j).SetCellValue(table.Rows[i][j].ToString());
                    sheet.SetColumnWidth(j, 256 * 15);
                }
            }

            //写入数据流
            workBook.Write(ms);
            buffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(buffer, 0, buffer.Length);
            return buffer;
        }

        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool ToExcel(DataTable table)
        {
            FileStream fs = new FileStream(this._filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            IWorkbook workBook = new HSSFWorkbook();
            this._sheetName = this._sheetName.IsEmpty() ? "sheet1" : this._sheetName;
            ISheet sheet = workBook.CreateSheet(this._sheetName);

            //处理表格标题
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue(this._title);
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, table.Columns.Count - 1));
            row.Height = 500;

            ICellStyle cellStyle = workBook.CreateCellStyle();
            IFont font = workBook.CreateFont();
            font.FontName = "微软雅黑";
            font.FontHeightInPoints = 17;
            cellStyle.SetFont(font);
            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.Alignment = HorizontalAlignment.Center;
            row.Cells[0].CellStyle = cellStyle;

            //处理表格列头
            row = sheet.CreateRow(1);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                row.CreateCell(i).SetCellValue(table.Columns[i].ColumnName);
                row.Height = 350;
                sheet.AutoSizeColumn(i);
            }

            //处理数据内容
            for (int i = 0; i < table.Rows.Count; i++)
            {
                row = sheet.CreateRow(2 + i);
                row.Height = 250;
                for (int j = 0; j < table.Columns.Count; j++)
                {
                    row.CreateCell(j).SetCellValue(table.Rows[i][j].ToString());
                    sheet.SetColumnWidth(j, 256 * 15);
                }
            }
            //写入数据流
            workBook.Write(fs);
            fs.Flush();
            fs.Close();

            return true;
        }
        public bool ToExcel(DataTable table, string title, string sheetName, string filePath)
        {
            this._title = title;
            this._sheetName = sheetName;
            this._filePath = filePath;
            return ToExcel(table);
        }
        public byte[] ToExcel<T>(List<T> datas, string[] cols)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buffer = null;
            IWorkbook workBook = new HSSFWorkbook();
            ISheet sheet = workBook.CreateSheet("导出数据");
            this._sheetName = this._sheetName.IsEmpty() ? "sheet1" : this._sheetName;
            IRow headerRow = sheet.CreateRow(0);

            ICellStyle cellStyle = workBook.CreateCellStyle();
            IFont font = workBook.CreateFont();
            font.FontName = "微软雅黑";
            font.FontHeightInPoints = 10;
            cellStyle.SetFont(font);
            cellStyle.FillBackgroundColor = 26;
            cellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.LightGreen.Index;
            cellStyle.FillPattern = FillPattern.SolidForeground;

            cellStyle.VerticalAlignment = VerticalAlignment.Center;
            cellStyle.Alignment = HorizontalAlignment.Center;

            int rowIndex = 2, piIndex = 0;
            Type type = typeof(T);
            PropertyInfo[] pis = type.GetProperties();
            int pisLen = pis.Length;
            PropertyInfo pi = null;


            //处理表格标题
            IRow row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue(this._title);
            row.Height = 500;
            cellStyle.SetFont(font);

            //处理表格列头
            row = sheet.CreateRow(1);
            for (int i = 0; i < cols.Length; i++)
            {
                row.CreateCell(i).SetCellValue(cols[i]);
                row.Height = 350;
                sheet.AutoSizeColumn(i);
            }
            //处理数据内容
            foreach (T data in datas)
            {
                piIndex = 0;
                IRow dataRow = sheet.CreateRow(rowIndex);
                while (piIndex < pisLen)
                {
                    pi = pis[piIndex];
                    try
                    {
                        dataRow.CreateCell(piIndex).SetCellValue(pi.GetValue(data).ToString());
                    }
                    catch (Exception)
                    {
                        dataRow.CreateCell(piIndex).SetCellValue("");
                    }
                    piIndex++;
                }
                rowIndex++;
            }
            //写入数据流
            workBook.Write(ms);
            buffer = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
}
