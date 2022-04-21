using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Logic.Interfaces;
using VNBCC2_HFT_2021222.Models;
using VNBCC2_HFT_2021222.Repository.Interfaces;

namespace VNBCC2_HFT_2021222.Logic.Classes
{
    public class GuitarLogic : IGuitarLogic
    {
        IRepository<Guitar> repo;

        public GuitarLogic(IRepository<Guitar> repo)
        {
            this.repo = repo;
        }
        public void Create(Guitar item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Guitar Read(int id)
        {
            var guitar = this.repo.Read(id);
            if (guitar == null)
            {
                throw new ArgumentException("This Guitar does not exist");
            }
            return guitar;
        }

        public IQueryable<Guitar> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Guitar item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<YearInfo> YearStatistics()
        {
            
        }
        public class YearInfo
        {
            public int Year { get; set; }
            public double? AvgRating { get; set; }
            public int MovieNumber { get; set; }
        }
    }
}
