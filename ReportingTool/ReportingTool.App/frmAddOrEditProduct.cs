using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReportingTool.App
{
    public partial class frmAddOrEditProduct : Form
    {
        public bool isEdit = false;

        public frmAddOrEditProduct()
        {
            InitializeComponent();
        }

        private void frmAddOrEditProduct_Load(object sender, EventArgs e)
        {
            if(isEdit)
            {
                lblAddOrEditProduct.Text = "Edit Product";
                btnSubmit.Text = "Update";
                btnSubmit.BackColor = Color.Gold;
                btnSubmit.ForeColor = Color.Black;
            }
            else
            {
                lblAddOrEditProduct.Text = "Add Product";
                btnSubmit.Text = "Add";
                btnSubmit.BackColor = Color.Green;
                btnSubmit.ForeColor = Color.White;
            }
        }
    }
}
