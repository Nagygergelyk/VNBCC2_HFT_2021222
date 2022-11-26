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
    public class GuitarController : ControllerBase
    {
        IGuitarLogic logic;
        IHubContext<SignalRHub> hub;

        public GuitarController(IGuitarLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Guitar> ReadAll()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Guitar Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Guitar value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("GuitarCreated", value);
        }
        [HttpPut]
        public void Put([FromBody] Guitar value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("GuitarUpdated", value);

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var guitarToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("GuitarDeleted", guitarToDelete);

        }
    }
}
