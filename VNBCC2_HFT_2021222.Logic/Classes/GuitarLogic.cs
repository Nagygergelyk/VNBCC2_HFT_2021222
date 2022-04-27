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

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return from guitar in repo.ReadAll()
                   group guitar by guitar.Brand.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.BasePrice) ?? -1);
        }

        public IEnumerable<KeyValuePair<string, double>> AVGPriceByShapes()
        {
            return from guitar in repo.ReadAll()
                   group guitar by guitar.Shape.Name into g
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(t => t.BasePrice) ?? -1);
        }

        public IEnumerable<KeyValuePair<int, double>> AVGPriceByYears()
        {
            return from guitar in repo.ReadAll()
                   group guitar by guitar.Year into g
                   select new KeyValuePair<int, double>
                   (g.Key, g.Sum(t => t.BasePrice) ?? -1);
        }

        public void Create(Guitar item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public IEnumerable<KeyValuePair<string, int>> NumberOfModelsByBrands()
        {
            /*return from guitar in repo.ReadAll()
                   group guitar by guitar.Brand.Name into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count(t => t.Id)?? -1);*/

            return null;
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
            return from x in this.repo.ReadAll()
                   group x by x.Year into g
                   select new YearInfo()
                   {
                       Year = g.Key,
                       BasePrice = g.Average(t => t.BasePrice),
                       Number = g.Count()
                   };
        }
        public class YearInfo
        {
            public int Year { get; set; }
            public double? BasePrice { get; set; }
            public int Number { get; set; }
        }
    }
}
