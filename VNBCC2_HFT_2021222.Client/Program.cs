using System;
using VNBCC2_HFT_2021222.Repository.Data;

namespace VNBCC2_HFT_2021222.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            GuitarShopDbContext ctx = new GuitarShopDbContext();

            foreach (var item in ctx.Guitars)
            {
                Console.WriteLine(item.Brand.Name + "; " + item.Shape.Name + "; " + item.Year);
            }
            Console.ReadLine();
        }
    }
}
