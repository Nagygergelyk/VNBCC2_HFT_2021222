using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Logic.Classes;
using VNBCC2_HFT_2021222.Models;

namespace VNBCC2_HFT_2021222.Logic.Interfaces
{
    public interface IGuitarLogic
    {
        void Create(Guitar item);
        void Delete(int id);
        Guitar Read(int id);
        IQueryable<Guitar> ReadAll();
        void Update(Guitar item);
        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByShapes();
        IEnumerable<KeyValuePair<string, int>> NumberOfModelsByBrands();
        IEnumerable<KeyValuePair<int, double>> AVGPriceByYears();


        IEnumerable<GuitarLogic.YearInfo> YearStatistics();

    }
}
