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
    public partial class FormCategory : Form
    {
        private readonly ICategoryService _categoryService;
        public FormCategory()
        {
            InitializeComponent();
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.Status = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _categoryService.TDelete(int.Parse(txtCategoryId.Text));
            MessageBox.Show("Silme işlemi başarılı");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            var value = _categoryService.TGetById(int.Parse(txtCategoryId.Text));
            List<Category> categories = new List<Category>();
            categories.Add(value);
            dataGridView1.DataSource = categories;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedId = int.Parse(txtCategoryId.Text);
            var updatedValues = _categoryService.TGetById(updatedId);
            updatedValues.CategoryName = txtCategoryName.Text;
            updatedValues.Status = true;
            _categoryService.TUpdate(updatedValues);
            MessageBox.Show("Güncelleme işlemi başarılı");
        }
    }
}
