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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddOrEditProduct frm = new frmAddOrEditProduct(_unitOfWork);
            if (frm.ShowDialog() == DialogResult.OK)
                BindGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddOrEditProduct frm = new frmAddOrEditProduct(_unitOfWork);
            frm.productId = Convert.ToInt32(dgvProducts.CurrentRow.Cells[0].Value.ToString());
            if (frm.ShowDialog() == DialogResult.OK)
                BindGrid();
        }
    }
}
