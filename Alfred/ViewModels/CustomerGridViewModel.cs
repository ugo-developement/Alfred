using System;
using Alfred.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfred.ViewModels
{
    class CustomerGridViewModel
    {
        public IEnumerable<Customer> FillGrid()
        {
            using(DataClasses1DataContext db = new DataClasses1DataContext("Data Source=10.1.10.114,1434;Initial Catalog=TestDB;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                var q = (from x in db.Customers select x).Take(10);
                return q.ToList();
            }
        }
    }
}
