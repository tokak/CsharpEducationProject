using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class FormProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FormProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        //ProductManager productManager = new ProductManager(new EfProductDal());
        

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductsWithCategory();
            dataGridView1.DataSource = values;
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            var values = _categoryService.TGetAll();
            comboBoxCategory.DataSource = values;
            comboBoxCategory.DisplayMember = "CategoryName";
            comboBoxCategory.ValueMember = "Id";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            { 
                ProductName = txtProductName.Text,
                Description = txtDescription.Text,
                Price = decimal.Parse(txtPrice.Text),
                CategoryId =int.Parse(comboBoxCategory.SelectedValue.ToString()),
                ProductStock = byte.Parse(txtProductStock.Text)
            };
            _productService.TInsert(product);
            MessageBox.Show("Kayıt Eklendi");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtProductId.Text);
            _productService.TDelete(id);
            MessageBox.Show("Kayıt Silindi");
        }

        
        private void btnGetById_Click(object sender, EventArgs e)
        {
            var value = _productService.TGetById(int.Parse(txtProductId.Text));
            List<Product> products = new List<Product>();
            products.Add(value);
            dataGridView1.DataSource = products;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value = _productService.TGetById(int.Parse(txtProductId.Text));
            value.Price = decimal.Parse(txtPrice.Text);
            value.ProductStock = int.Parse(txtProductStock.Text);
            value.ProductName = txtProductName.Text;
            value.Description = txtDescription.Text;
            value.CategoryId = comboBoxCategory.SelectedIndex;
            _productService.TUpdate(value);
            MessageBox.Show("Kayıt Güncelle");

        }
    }
}
