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
    public class ShapeController : ControllerBase
    {
        IShapeLogic logic;
        IHubContext<SignalRHub> hub;


        public ShapeController(IShapeLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }
        [HttpGet]
        public IEnumerable<Shape> ReadAll()
        {
            return this.logic.ReadAll();
        }
        [HttpGet("{id}")]
        public Shape Read(int id)
        {
            return this.logic.Read(id);
        }
        [HttpPost]
        public void Create([FromBody] Shape value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ShapeCreated", value);
        }
        [HttpPut]
        public void Put([FromBody] Shape value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ShapeUpdated", value);

        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var shapeToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ShapeDeleted", shapeToDelete);

        }
    }
}
