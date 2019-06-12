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
                    twentyToTFive = 0, tFiveToThrity = 0, overThirty = 0;

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
                }

                List<int> countList = new List<int>
                {
                    zeroToTen,
                    tenToFteen,
                    fteenToTwenty,
                    twentyToTFive,
                    tFiveToThrity,
                    overThirty
                };

                return countList;
            }
        }
        public static List<int> BasketAverages()
        {
            using (TheOrderModelDataContext db = new TheOrderModelDataContext("Data Source=10.1.10.114,1434;Initial Catalog=benDover;Persist Security Info=True;User ID=ugoadmin;Password=ugo-2019"))
            {
                var q = (from x in db.theORDERs select x);
                q.ToList();

                int one = 0, two = 0, three = 0,
                    four = 0, five = 0, overFive = 0;

                foreach (var z in q)
                {
                    // if total is less than or equal 9.99
                    if (z.BasketSize.CompareTo(Convert.ToDecimal(1.00)) <= 0)
                    {
                        one++;
                    }
                    else if (z.BasketSize.CompareTo(Convert.ToDecimal(2.00)) <= 0)
                    {
                        two++;
                    }
                    else if (z.BasketSize.CompareTo(Convert.ToDecimal(3.00)) <= 0)
                    {
                        three++;
                    }
                    else if (z.BasketSize.CompareTo(Convert.ToDecimal(4.00)) <= 0)
                    {
                        four++;
                    }
                    else if (z.BasketSize.CompareTo(Convert.ToDecimal(5.00)) <= 0)
                    {
                        five++;
                    }
                    else if (z.BasketSize.CompareTo(Convert.ToDecimal(5.00)) > 0)
                    {
                        overFive++;
                    }
                }

                List<int> countList = new List<int>
                {
                    one,
                    two,
                    three,
                    four,
                    five,
                    overFive
                };

                return countList;
            }
        }
    }
}
