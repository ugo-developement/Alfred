using Alfred.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfred.ViewModels
{
    class TheOrderViewModel : BindableBase
    {
        public static List<int> OrderRanges()
        {
            using (TheOrderModelDataContext db = new TheOrderModelDataContext("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                var q = (from x in db.theORDERs select x);
                q.ToList();

                int zeroToTen = 0, tenToFteen = 0, fteenToTwenty = 0,
                    twentyToTFive = 0, tFiveToThrity = 0, overThirty = 0,
                    errorsTotaling = 0;

                foreach (var z in q)
                {
                    // if total is less than or equal 9.99
                    if (z.Total.CompareTo(Convert.ToDecimal(10.00)) <= 0)
                    {
                        zeroToTen++;
                    }
                    else if (z.Total.CompareTo(Convert.ToDecimal(15.00)) <= 0)
                    {
                        tenToFteen++;
                    }
                    else if (z.Total.CompareTo(Convert.ToDecimal(20.00)) <= 0)
                    {
                        fteenToTwenty++;
                    }
                    else if (z.Total.CompareTo(Convert.ToDecimal(25.00)) <= 0)
                    {
                        twentyToTFive++;
                    } 
                    else if (z.Total.CompareTo(Convert.ToDecimal(30.00)) <= 0)
                    {
                        tFiveToThrity++;
                    }
                    else if (z.Total.CompareTo(Convert.ToDecimal(30.00)) > 0)
                    {
                        overThirty++;
                    }
                    else
                    {
                        errorsTotaling++;
                    }
                }

                List<int> countList = new List<int>
                {
                    zeroToTen,
                    tenToFteen,
                    fteenToTwenty,
                    twentyToTFive,
                    tFiveToThrity,
                    overThirty,
                    errorsTotaling
                };

                return countList;
            }
        }
    }
}
