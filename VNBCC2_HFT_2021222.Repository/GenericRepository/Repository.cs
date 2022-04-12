using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Repository.Data;
using VNBCC2_HFT_2021222.Repository.Interfaces;

namespace VNBCC2_HFT_2021222.Repository.GenericRepository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected GuitarShopDbContext ctx;
        public Repository(GuitarShopDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
            
        }

        public abstract T Read(int id);
        public abstract void Update(T item);
        
    }
}
