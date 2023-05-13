using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region ORM Nedir?

            // ORM : Object Relational Mapping : Nesne ilişkisel Eşleştirme şeklinde çevirebiliriz...

            // ORM, Nesne Tabanlı Programlama dillerinde kullanılır, Veritabanı işlemleri yapmamıza olanak sağlar.

            // Nesneler üzerinde çalışır ve OOP'ye bağımlıdır. Çalışma şekli, Veritabanındaki tablo ile buna karşılık gelen nesne ile eşleştirilmesi sonucu sadece kod yazarak sorgulama yaptığımız bir yapıdır.

            // ORM'de herhangi bir SQL kodu bilmemize gerek yoktur. ORM için kullandığımız framework'ler bu işi bizim için arka planda yaparlar... Biz sadece kullandığımız programlama dili üzerinde kodlarımızı yazarız.

            // SQL kodları yazmadığımız için onlarca satır kodun yapmış olduğu işi bir iki satır ile yapmamıza olanak sağlayan yapılardır ORM'ler..

            // Popüler olan ORM'ler : EntityFramework, NHibernate (.Net), Hibernate, SpringFramework (Java)

            // ORM'de 3 farklı yaklaşım vardır.
            // Database First, Code First, Model First

            // Database First kısmında açmak için projeye sağ tık > Add Component > Data kısmında ADO.NET Entity Data Model > EF Designer from Database dedikten sonra server adı ve database seçimlerini yapıyoruz. Almak istediğimiz tablo, view seçtikten sonra kurulumu bitiriyoruz.

            #endregion

        }
    }
}
