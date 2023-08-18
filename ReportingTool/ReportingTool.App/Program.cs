using ReportingTool.Data.Repository;
using ReportingTool.Data.Repository.IRepository;
using ReportingTool.Data;
using System;
using System.Windows.Forms;

namespace ReportingTool.App
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IUnitOfWork _unitOfWork = new UnitOfWork(new ReportingTool_DbEntities());
            Application.Run(new Form1(_unitOfWork));
        }
    }
}
