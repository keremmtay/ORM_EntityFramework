using DbFirst_Tekrar.DbFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbFirst_Tekrar
{
    public partial class Form1 : Form
    {
        Northwnd13EntitiesContext context = new Northwnd13EntitiesContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = context.Employees.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView1.DataSource = context.Employees.Where(x => x.FirstName == "Nancy").ToList();
            }
            if (radioButton2.Checked)
            {
                dataGridView1.DataSource = context.Employees.Where(x => x.FirstName == tbxİsim.Text).ToList();
            }

            if (radioButton3.Checked)
            {
                //dataGridView1.DataSource = context.Employees.Where(x => x.FirstName == tbxİsim.Text && x.LastName == tbxSoyisim.Text).ToList();

                // 2. YOL

                var sonuc = context.Employees.Where(x => x.FirstName == tbxİsim.Text && x.LastName == tbxSoyisim.Text);

                dataGridView1.DataSource = sonuc.ToList();
            }

            if (radioButton4.Checked)
            {
                dataGridView1.DataSource = context.Products.Where(x => x.UnitsInStock > 10).ToList();
            }

            if (radioButton5.Checked)
            {
                dataGridView1.DataSource = context.Products.OrderBy(x => x.ProductName).ToList();
            }

            if (radioButton6.Checked)
            {
                dataGridView1.DataSource = context.Products.OrderByDescending(x => x.ProductName).ToList();
            }

            if (radioButton7.Checked)
            {
                var sonuc = context.Products.OrderBy(x => x.UnitsInStock).ThenByDescending(x => x.ProductName);

                dataGridView1.DataSource = sonuc.ToList();
            }

            if (radioButton8.Checked)
            {
                var sonuc = context.Products.OrderBy(x => x.ProductName).Take(10);

                dataGridView1.DataSource = sonuc.ToList();
            }

            if (radioButton9.Checked)
            {
                dataGridView1.DataSource = context.Orders.OrderBy(x => x.OrderDate).ToList();
            }

            // Like sorguları

            if (radioButton10.Checked)
            {
                dataGridView1.DataSource = context.Products.Where(x => x.ProductName.StartsWith("Si")).ToList();
            }

            if (radioButton11.Checked)
            {
                dataGridView1.DataSource = context.Products.Where(x => x.ProductName.StartsWith(tbxHarf.Text)).ToList();
            }

            if (radioButton12.Checked)
            {
                dataGridView1.DataSource = context.Products.Where(x => x.ProductName.EndsWith(tbxHarf.Text)).ToList();
            }

            if (radioButton13.Checked)
            {
                dataGridView1.DataSource = context.Products.Where(x => x.ProductName.Contains(tbxHarf.Text)).ToList();
            }

            // Select sorgularında seçilen alanları listeleme

            if (radioButton14.Checked)
            {
                dataGridView1.DataSource = context.Employees.Select(x => new
                {
                    //Adi= x.FirstName,
                    //Soyadi = x.LastName,
                    Adi_Ve_Soyadi = x.FirstName + " " + x.LastName,
                    DogumTarihi = x.BirthDate
                }).ToList();
            }

            if (radioButton15.Checked)
            {
                var sonuc = context.Employees.Select(x => new
                {
                    Adi_Ve_Soyadi = x.FirstName + " " + x.LastName,
                    DogumTarihi = x.BirthDate,
                    Sehir = x.City
                }).Where(x => x.Sehir == "London");
                dataGridView1.DataSource = sonuc.ToList();
            }

            // Textbox'a girdiğim ProductName'e göre, Products tablosundan ProductName, CategoryId, UnitPrice, UnitsInStock bilgilerini listeleyen sorguyu yazın:

            if (radioButton16.Checked)
            {
                dataGridView1.DataSource = context.Products.Select(x => new
                {
                    Adi = x.ProductName,
                    KategoriId = x.CategoryID,
                    Fiyati = x.UnitPrice,
                    StokAdedi = x.UnitsInStock
                }).Where(x => x.Adi == tbxHarf.Text).ToList();
            }

            // Birden fazla tablodan kayıt getirme
            // SelectMany

            if (radioButton17.Checked)
            {
                // Category ve Product tablosunu birleştirerek aşağıdaki gibi sorguyu hazırlayabiliriz.

                dataGridView1.DataSource = context.Categories.SelectMany(x => context.Products.Where(y => x.CategoryID == y.CategoryID), (x, y) => new {
                x.CategoryName, y.ProductName, y.UnitPrice
                }).ToList();
            }

            if (radioButton18.Checked)
            {
                int sonuc = context.Products.Count();

                MessageBox.Show("Products tablosundaki kayıt sayısı : " + sonuc);
            }

            if (radioButton19.Checked)
            {
                var sonuc = context.Products.Sum(x => x.UnitsInStock);

                MessageBox.Show("Toplam ürün adedi : " + sonuc);
            }

            if (radioButton21.Checked)
            {
                var sonuc = context.Products.Average(x => x.UnitPrice);

                MessageBox.Show("Ürünlerin fiyat ortalaması : " + sonuc);
            }

            if (radioButton22.Checked)
            {
                var sonuc = context.Products.Max(x => x.UnitPrice);

                MessageBox.Show("En yüksek fiyatlı ürün : " + sonuc);
            }

            if (radioButton23.Checked)
            {
                var sonuc = context.Products.Min(x => x.UnitPrice);

                MessageBox.Show("En düşük fiyatlı ürün : " + sonuc);
            }

            if (radioButton20.Checked)
            {
                // Any() Metodu = Kayıt var ise true, yok ise false döndüren bir metot.

                var sonuc = context.Products.Where(x => x.ProductID == 1000).Any();

                MessageBox.Show("Sonuc : " + sonuc.ToString());
            }

            if (radioButton24.Checked)
            {
                var sorgu = from item in context.Products
                            select new
                            {
                                item.ProductName,
                                item.CategoryID,
                                item.UnitPrice,
                                item.UnitsInStock
                            };


                dataGridView1.DataSource = sorgu.ToList();
            }

            if (radioButton25.Checked)
            {
                var sorgu = from item in context.Categories
                            where item.CategoryID == 3
                            select new
                            {
                                item.CategoryID,
                                item.CategoryName,
                                item.Description
                            };

                dataGridView1.DataSource = sorgu.ToList();
            }

            if (radioButton26.Checked)
            {
                // Product ve Categories tablolarını birleştirerek sorgulama

                var sorgu = from kategori in context.Categories
                            join urun in context.Products
                            on kategori.CategoryID equals urun.CategoryID
                            select new
                            {
                                kategori.CategoryName,
                                urun.ProductName,
                            };

                dataGridView1.DataSource = sorgu.ToList();
            }

            if (radioButton27.Checked)
            {
                // OrderID'si verilen kaydın Order Details tablosundaki verileri listeleyen sorguyu yazın. CustomerId, ProductID, EmployeeID istemiyorum.

                int orderId = Convert.ToInt32(tbxOrderId.Text);

                var sorgu = from x in context.Order_Details
                            join y in context.Orders
                            on x.OrderID equals y.OrderID
                            join z in context.Employees
                            on y.EmployeeID equals z.EmployeeID
                            join c in context.Customers
                            on y.CustomerID equals c.CustomerID
                            join p in context.Products
                            on x.ProductID equals p.ProductID
                            where y.OrderID == orderId
                            select new
                            {
                                x.OrderID,
                                p.ProductName,                                
                                x.UnitPrice,
                                x.Quantity,
                                y.OrderDate,
                                y.ShipCountry,
                                Employee_FullName = z.FirstName + " " + z.LastName,
                                c.ContactName,
                                c.CompanyName,
                            };

                dataGridView1.DataSource = sorgu.ToList();




            }

            // GroupBy Sorguları

            if (radioButton28.Checked)
            {
                // Metot Yöntemi

                // Her bir ülkede kaçar tane müşterimiz var

                var sorgu = context.Customers.GroupBy(x => x.Country).Select(y => new
                {
                    Ulke = y.Key, // hangi alana göre gruplandırdıysak Key o alanı temsil ediyor
                    Toplam = y.Count()
                });

                dataGridView1.DataSource = sorgu.ToList();
            }

            if (radioButton29.Checked)
            {
                // Query yöntemi ile GroupBy

                var sorgu = from musteri in context.Customers
                            group musteri by musteri.Country into x
                            select new
                            {
                                Ulke = x.Key,
                                Toplam = x.Count() 
                            };

                dataGridView1.DataSource = sorgu.ToList();
            }

            // her bir kategoride kaç tane ürün olduğunu listeleyen sorguyu yazın

            if (radioButton30.Checked)
            {
                var sorgu = context.Products.GroupBy(x => x.CategoryID).Select(y => new
                {
                    KategoriID = y.Key,
                    Toplam_Urun_Sayisi = y.Count()
                });

                dataGridView1.DataSource = sorgu.ToList();
            }
        }
    }
}
