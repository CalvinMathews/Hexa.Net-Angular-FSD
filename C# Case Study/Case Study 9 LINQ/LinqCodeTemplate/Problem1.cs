using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem1
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            //-->1
            var result = products.Where(p => p.ProCategory=="FMCG").ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //-->2
            var grainz = products.Where(p => p.ProCategory == "Grain").ToList();
            foreach (var item in grainz)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //-->3
            var sorti = products.OrderBy(p=> p.ProCode).ToList();
                foreach (var item in sorti)
                {
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                }
                //-->4
                var ascsorti = products.OrderBy(p => p.ProCategory).ToList();
                foreach (var item in ascsorti)
                {
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                }
                //-->5
                var sortbyMrp = products.OrderBy(p => p.ProMrp).ToList();
                foreach (var item in sortbyMrp)
                {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                 }
            //-->6
            var descsortbyMrp = products.OrderByDescending(p => p.ProMrp).ToList();
            foreach (var item in descsortbyMrp)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //-->7
            var groupcategory = products.GroupBy(p => p.ProCategory).ToList();
            foreach (var grp in groupcategory)
            {
                Console.WriteLine($"Category: {grp.Key}");
                foreach (var item in grp)
                {
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                }
                }
            //-->8
            var groupmrp = products.GroupBy(p => p.ProMrp).ToList();
            foreach (var grp in groupmrp)
            {
                Console.WriteLine($"Category: {grp.Key}");
                foreach (var item in grp)
                {
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                }
            }
            //-->9
            var highmrp = products.Where(p => p.ProCategory == "FMCG").OrderByDescending(p => p.ProMrp).FirstOrDefault() ;
            Console.WriteLine($"Highest cost: {highmrp.ProCode}\t{highmrp.ProName}\t{highmrp.ProMrp}");
            //-->10
            var cnt = products.Count();
            Console.WriteLine($"Total Number of Products: {cnt}");
            //-->11
            var cntfmcg = products.Where((p) => p.ProCategory == "FMCG").Count();
            Console.WriteLine($"Count of FMCG: {cntfmcg}");
            //-->12
            var maxMrp = products.Max(p => p.ProMrp);
            Console.WriteLine($"Max MRP: {maxMrp}");
            //-->13
            var minMrp = products.Min(p => p.ProMrp);
            Console.WriteLine($"Min MRP: {minMrp}");
            //-->14
            var mrpconstraint = products.All(p => p.ProMrp < 30);
            if (mrpconstraint)
            {
                Console.WriteLine("Yes all products less than Rs.30");

            }
            else
            {
                Console.WriteLine("Not all products less than RS. 30");
            }
            //-->15
            var mrpcontraintany= products.Any(p => p.ProMrp < 30);
            if (mrpcontraintany)
            {
                Console.WriteLine(" products below 30 are available ");
            }
            else
            {
                Console.WriteLine("No products are below 30");
            }


            Console.ReadLine();
        }

        }
    }

