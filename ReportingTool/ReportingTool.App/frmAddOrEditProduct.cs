using ReportingTool.Data;
using ReportingTool.Data.Repository.IRepository;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReportingTool.App
{
    public partial class frmAddOrEditProduct : Form
    {
        public int productId = 0;
        Product product = new Product();
        private readonly IUnitOfWork _unitOfWork;

        public frmAddOrEditProduct(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void frmAddOrEditProduct_Load(object sender, EventArgs e)
        {
            if (productId != 0)
            {
                //some config if edit button was clicked
                lblAddOrEditProduct.Text = "Edit Product";
                btnSubmit.Text = "Update";
                btnSubmit.BackColor = Color.Gold;
                btnSubmit.ForeColor = Color.Black;

                //get selected product with id
                product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == productId);

                txtProductName.Text = product.ProductName;
                numQuantityInStock.Value = product.QuantityInStock;
                numPrice.Value = product.Price;
            }
            else
            {
                //some config if add button was clicked
                lblAddOrEditProduct.Text = "Add Product";
                btnSubmit.Text = "Add";
                btnSubmit.BackColor = Color.Green;
                btnSubmit.ForeColor = Color.White;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //client side validation
            if(txtProductName.Text != "" && numQuantityInStock.Value != 0)
            {
                if (productId == 0)
                {
                    //add product

                    //create new product
                    Product newProduct = new Product()
                    {
                        ProductName = txtProductName.Text,
                        QuantityInStock = Convert.ToInt32(numQuantityInStock.Value),
                        Price = numPrice.Value
                    };

                    //add to database
                    _unitOfWork.Product.Add(newProduct);

                    //Success message
                    MessageBox.Show("Create new Product Completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //edit product

                    //change rew product value with old product
                    product.ProductName = txtProductName.Text;
                    product.QuantityInStock = Convert.ToInt32(numQuantityInStock.Value);
                    product.Price = numPrice.Value;

                    //do update
                    _unitOfWork.Product.Update(product);

                    //Success message
                    MessageBox.Show("Update Product Completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //send ok status to main form
                DialogResult = DialogResult.OK;

                //save database
                _unitOfWork.Save();
            }
            else
                MessageBox.Show("Please fill all field!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
