using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboEsaj.Domain.Utilities
{
    public class ExportarExcel
    {
        //public void GerarExcel()
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
