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
    public class GuitarRepository : Repository<Guitar>, IRepository<Guitar>
    {
        public GuitarRepository(GuitarShopDbContext ctx) : base(ctx)
        {

        }
        public override Guitar Read(int id)
        {
            return ctx.Guitars.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Guitar item)
        {
            var old = Read(item.Id);
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
