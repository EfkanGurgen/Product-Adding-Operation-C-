using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdonetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
            dgwProducts.DataSource = _productDal.GetAll();

        }

        private void dgwProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            _productDal.Add(new Product {
            
            Name= tbxName.Text,
            UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
            StockAmount= Convert.ToInt32(tbxStockAmount.Text),

            });
            dgwProducts.DataSource=_productDal.GetAll();
            MessageBox.Show("Product Added!");

        }
    }
}
