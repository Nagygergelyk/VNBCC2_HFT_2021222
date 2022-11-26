using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VNBCC2_HFT_2021222.Endpoint.Services;
using VNBCC2_HFT_2021222.Logic.Interfaces;
using VNBCC2_HFT_2021222.Models;

namespace VNBCC2_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic logic;
        IHubContext<SignalRHub> hub;

        public BrandController(IBrandLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Brand value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("BrandCreated", value);
        }
        [HttpPut]
        public void Put([FromBody] Brand value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("BrandUpdated", value);

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brandToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BrandDeleted", brandToDelete);

        }
    }
}
