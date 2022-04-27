using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Logic.Classes;
using VNBCC2_HFT_2021222.Logic.Interfaces;

namespace VNBCC2_HFT_2021222.Endpoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        private IGuitarLogic logic;

        public StatController(IGuitarLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return this.logic.AVGPriceByBrands();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByShapes()
        {
            return this.logic.AVGPriceByShapes();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceOfGuitarsByBrands()
        {
            return this.logic.AVGPriceOfGuitarsByBrands();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<int, double>> AVGPriceByYears()
        {
            return this.logic.AVGPriceByYears();
        }
        [HttpGet]
        public IEnumerable<KeyValuePair<int, double>> AllPriceByYears()
        {
            return this.logic.AllPriceByYears();
        }

    }
}
