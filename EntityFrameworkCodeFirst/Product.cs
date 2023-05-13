using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCodeFirst
{
    public class Product
    {
        // Bu class'ımız Entity Class olarak adlandırılır. Burada tablodaki kolonlara karşılık gelen property'ler tanımlanacak.

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }


    }
}
