using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind_DataBaseFirst
{
    public partial class Form1 : Form
    {

        Northwnd13Entities db = new Northwnd13Entities(); // Veritabanı bağlantısı için kullandığımız context nesnemiz

        public Form1()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            KategoriListele();
        }

        private void KategoriListele()
        {
            var query = from item in db.Categories
                        select new { item.CategoryID, item.CategoryName, item.Description };

            dataGridView1.DataSource = query.ToList();

            //dataGridView1.DataSource = db.Categories.ToList();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Category category = new Category();

            category.CategoryName = tbxCategoryName.Text;

            category.Description = tbxDescription.Text;

            db.Categories.Add(category);

            db.SaveChanges();

            MessageBox.Show("Kategori eklendi.");

            KategoriListele();

            FormTemizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int kategoriId = Convert.ToInt32(tbxID.Text);

            Category silinecekKategori = db.Categories.Find(kategoriId);

            db.Categories.Remove(silinecekKategori);

            db.SaveChanges();

            MessageBox.Show("Kategori silindi.");

            KategoriListele();

            FormTemizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbxCategoryName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbxDescription.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnFormTemizle_Click(object sender, EventArgs e)
        {
            FormTemizle();
        }

        private void FormTemizle()
        {
            tbxID.Clear();
            tbxCategoryName.Clear();
            tbxDescription.Clear();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int kategoriId = Convert.ToInt32(tbxID.Text);

            Category category = db.Categories.Find(kategoriId);

            category.CategoryName = tbxCategoryName.Text;

            category.Description = tbxDescription.Text;

            db.SaveChanges();

            MessageBox.Show("Kategori güncellendi.");

            KategoriListele();

            FormTemizle();
        }

        private void btnUrunleriListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.ToList();
        }

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Customers.ToList();
        }
    }
}
