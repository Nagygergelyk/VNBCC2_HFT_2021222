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
    public class ShapeRepository : Repository<Shape>, IRepository<Shape>
    {
        public ShapeRepository(GuitarShopDbContext ctx) : base(ctx)
        {

        }
        public override Shape Read(int id)
        {
            return ctx.Shapes.FirstOrDefault(t => t.ShapeId == id);
        }

        public override void Update(Shape item)
        {
            var old = Read(item.ShapeId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
