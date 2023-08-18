using ReportingTool.Data.Repository.IRepository;
using System;
using System.Windows.Forms;

namespace ReportingTool.App
{
    public partial class Form1 : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        public Form1(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dgvProducts.DataSource = _unitOfWork.Product.GetAll();
            txtSearch.Text = "";
        }
    }
}
