using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Logic.Interfaces;
using VNBCC2_HFT_2021222.Models;
using VNBCC2_HFT_2021222.Repository.Interfaces;

namespace VNBCC2_HFT_2021222.Logic
{
    public class ShapeLogic : IShapeLogic
    {
        IRepository<Shape> repo;

        public ShapeLogic(IRepository<Shape> repo)
        {
            this.repo = repo;
        }
        public void Create(Shape item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Shape Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Shape> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Shape item)
        {
            this.repo.Update(item);
        }
    }
}
