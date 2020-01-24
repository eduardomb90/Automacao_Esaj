using System.Windows.Forms;

namespace RoboEsaj.Domain.Utilities
{
    public interface ICreateXlsx
    {
        void OpenExcel(DataGridView dgv);
        void SaveXlsx(DataGridView dgv, string fileName);
    }
}