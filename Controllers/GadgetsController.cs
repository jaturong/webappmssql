using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webappmssql.Data;
using webappmssql.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace webappmssql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GadgetsController : ControllerBase
    {
        private readonly MyWorldDBContext _myWorldDBContext;

        public GadgetsController(MyWorldDBContext myWorldDBContext)
        {
            _myWorldDBContext = myWorldDBContext;
        }

        // Method Get All Gedgets

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllGedgets()
        {
            var allGadgets = _myWorldDBContext.Gadgets.ToList();
            return Ok(allGadgets);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult CreateGadgets(Gadgets gadgets)
        {
            _myWorldDBContext.Gadgets.Add(gadgets);
            _myWorldDBContext.SaveChanges();
            return Ok(gadgets.Id);
        }

        // สร้าง Method Update Gadgets()
        // https://localhost:5001/Gadgets/update
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateGadget(Gadgets gadgets)
        {
            _myWorldDBContext.Update(gadgets);
            _myWorldDBContext.SaveChanges();
            return NoContent();
        }

        // สร้าง Method Delete Gadgets()
        // https://localhost:5001/Gadgets/delete
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteGadget(int id)
        {
            var gadgetToDelete = _myWorldDBContext.Gadgets.Where(_ => _.Id == id).FirstOrDefault();
            if (gadgetToDelete == null)
            {
                return NotFound();
            }

            _myWorldDBContext.Gadgets.Remove(gadgetToDelete);
            _myWorldDBContext.SaveChanges();
            return NoContent();
        }
    }
}