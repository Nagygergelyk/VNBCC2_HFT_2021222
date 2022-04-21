using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Models;

namespace VNBCC2_HFT_2021222.Logic.Interfaces
{
    public interface IShapeLogic
    {
        void Create(Shape item);
        void Delete(int id);
        Shape Read(int id);
        IQueryable<Shape> ReadAll();
        void Update(Shape item);
    }
}
