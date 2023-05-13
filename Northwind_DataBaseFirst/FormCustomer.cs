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
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }

        Northwnd13Entities db = new Northwnd13Entities();

        private void btnMusteriListele_Click(object sender, EventArgs e)
        {
            MusteriListele();
        }

        private void MusteriListele()
        {
            dataGridView1.DataSource = db.Customers.ToList();
        }

        private void FormTemizle()
        {
            FormuTemizle();
        }

        private void FormuTemizle()
        {
            tbxID.Clear();
            tbxAd.Clear();
            tbxSirket.Clear();
            tbxUlke.Clear();
            tbxUnvan.Clear();
            tbxAdres.Clear();
            tbxSehir.Clear();
            tbxBolge.Clear();
            tbxPostaKodu.Clear();
            tbxTelefon.Clear();
            tbxFax.Clear();
        }

        private void btnMusteriKaydet_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();

            customer.ContactName = tbxAd.Text;
            customer.CompanyName = tbxSirket.Text;
            customer.ContactTitle = tbxUnvan.Text;
            customer.Address = tbxAdres.Text;
            customer.City = tbxSehir.Text;
            customer.Region = tbxBolge.Text;
            customer.PostalCode = tbxPostaKodu.Text;
            customer.Country = tbxUlke.Text;
            customer.Phone = tbxTelefon.Text;
            customer.Fax = tbxFax.Text;

            db.Customers.Add(customer);

            db.SaveChanges();

            MessageBox.Show("Müşteri eklendi.");

            MusteriListele();

            FormTemizle();
        }

        private void btnFormTemizle_Click(object sender, EventArgs e)
        {
            FormTemizle();
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(tbxID.Text);

            Customer silinecekID = db.Customers.Find();

            db.Customers.Remove(silinecekID);

            db.SaveChanges();

            MessageBox.Show("Müşteri silindi.");

            MusteriListele();

            FormTemizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxID.Text = dataGridView1.CurrentRow.Cells[0].ToString();
            tbxSirket.Text = dataGridView1.CurrentRow.Cells[1].ToString();
            tbxAd.Text = dataGridView1.CurrentRow.Cells[2].ToString();
            tbxUnvan.Text = dataGridView1.CurrentRow.Cells[3].ToString();
            tbxAdres.Text = dataGridView1.CurrentRow.Cells[4].ToString();
            tbxSehir.Text = dataGridView1.CurrentRow.Cells[5].ToString();
            tbxBolge.Text = dataGridView1.CurrentRow.Cells[6].ToString();
            tbxPostaKodu.Text = dataGridView1.CurrentRow.Cells[7].ToString();
            tbxUlke.Text = dataGridView1.CurrentRow.Cells[8].ToString();
            tbxTelefon.Text = dataGridView1.CurrentRow.Cells[9].ToString();
            tbxFax.Text = dataGridView1.CurrentRow.Cells[10].ToString();
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(tbxID.Text);

            Customer customer = db.Customers.Find(customerID);

            customer.CompanyName = tbxSirket.Text;
            customer.ContactName = tbxAd.Text;
            customer.ContactTitle = tbxUnvan.Text;
            customer.Address = tbxAdres.Text;
            customer.City = tbxSehir.Text;
            customer.Region = tbxBolge.Text;
            customer.PostalCode = tbxPostaKodu.Text;
            customer.Country = tbxUlke.Text;
            customer.Phone = tbxTelefon.Text;
            customer.Fax = tbxFax.Text;

            db.SaveChanges();

            MessageBox.Show("Müşteri güncellendi.");

            MusteriListele();

            FormTemizle();
        }
    }
}
