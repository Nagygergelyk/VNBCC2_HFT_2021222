using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Models;
using VNBCC2_HFT_2021222.Repository.Data;
using VNBCC2_HFT_2021222.Repository.GenericRepository;
using VNBCC2_HFT_2021222.Repository.Interfaces;

namespace VNBCC2_HFT_2021222.Repository.ModelRepositories
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(GuitarShopDbContext ctx) : base(ctx)
        {

        }
        public override Brand Read(int id)
        {
            return ctx.Brands.FirstOrDefault(t => t.BrandId == id);
        }

        public override void Update(Brand item)
        {
            var old = Read(item.BrandId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
