using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    public class ETicaretContext : DbContext
    {
        // Bir sınıfımızın Context sınıfı olabilmesi için mutlaka DbContext sınıfını inherit etmesi gerekir.

        // Projemizdeki Entity sınıfı ile tablo arasındaa bir eşleştirme yapmak iççin DbSet<> ile property'i oluşturmamız gerekecek.

        public DbSet<Product> Products { get; set; }



    }
}
