using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Models;

namespace VNBCC2_HFT_2021222.Logic.Interfaces
{
    public interface IBrandLogic
    {
        void Create(Brand item);
        void Delete(int id);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
        void Update(Brand item);
    }
}
