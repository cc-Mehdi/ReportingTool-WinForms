using ReportingTool.Data;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow.Cells[0].Value.ToString() != "0")
            {
                //get product id
                int productId = int.Parse(dgvProducts.CurrentRow.Cells[0].Value.ToString());

                //create product model
                Product product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == productId);

                if(MessageBox.Show($"Are you sure for delete '{product.ProductName}' ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    //do remove
                    _unitOfWork.Product.Remove(product);

                    //save database
                    _unitOfWork.Save();

                    //success message
                    MessageBox.Show("Update Product Completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //refresh process
                    BindGrid();
                }
            }
            else
                MessageBox.Show("Please select a record!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text != "")
            {
               // dgvProducts.DataSource = _unitOfWork.Product.GetAll(u=> u.ProductName.Contain(txtSearch.Text) || u.Price.Contain(txtSearch.Text));
            }
        }
    }
}
