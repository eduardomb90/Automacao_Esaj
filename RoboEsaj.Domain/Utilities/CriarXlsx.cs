using System.Reflection;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using SQL = System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System;
using System.IO;

namespace RoboEsaj.Domain.Utilities
{
    public class CriarXlsx
    {
        public void OpenExcel(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                Excel.Application excelApp;
                Workbook excelWorkBook;
                ExportToExcel(dgv, out excelApp, out excelWorkBook);

                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        public void SaveXlsx(DataGridView dgv, string fileName)
        {
            if (dgv.Rows.Count > 0)
            {
                Excel.Application excelApp;
                Workbook excelWorkBook;
                ExportToExcel(dgv, out excelApp, out excelWorkBook);

                var folderPath = @"C:\Documentos\Excel\";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = $"{folderPath}{fileName}.xlsx";

                excelApp.Columns.AutoFit();

                try
                {
                    excelWorkBook.SaveAs(filePath);
                }
                catch (Exception)
                {
                    MessageBox.Show("Não foi possível salvar o arquivo!\nArquivo com o mesmo nome já existe.", "Ops...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    throw;
                }
                
                excelWorkBook.Close();
                excelApp.Quit();
            }
        }

        private static void ExportToExcel(DataGridView dgv, out Excel.Application excelApp, out Workbook excelWorkBook)
        {
            excelApp = new Excel.Application();
            excelWorkBook = excelApp.Application.Workbooks.Add(Type.Missing);
            _Worksheet excelWorkSheet = excelWorkBook.Sheets[1];
            Range xlRange = excelWorkSheet.UsedRange;

            for (int i = 1; i < dgv.Columns.Count + 1; i++)
            {
                excelWorkSheet.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    excelWorkSheet.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                }
            }
        }

        //Código Velho
        //if (dgvEsaj.Rows.Count > 0)
        //{
        //    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
        //    xcelApp.Application.Workbooks.Add(Type.Missing);

        //    for (int i = 1; i < dgvEsaj.Columns.Count + 1; i++)
        //    {
        //        xcelApp.Cells[1, i] = dgvEsaj.Columns[i - 1].HeaderText;
        //    }

        //    for (int i = 0; i < dgvEsaj.Rows.Count; i++)
        //    {
        //        for (int j = 0; j < dgvEsaj.Columns.Count; j++)
        //        {
        //            xcelApp.Cells[i + 2, j + 1] = dgvEsaj.Rows[i].Cells[j].Value?.ToString() ?? "";
        //        }
        //    }
        //    xcelApp.Columns.AutoFit();
        //    xcelApp.Visible = true;
        //}
    }
}
