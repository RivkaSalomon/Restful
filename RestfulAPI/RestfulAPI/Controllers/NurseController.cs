using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Entities;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private static List<Nurse> ln = new List<Nurse>{new Nurse
        {Id=14854,Name="Chani",Price=45,CountHours=25} };
        // GET: api/<NurseController>
        [HttpGet]
        public IEnumerable<Nurse> Get()
        {
            return ln;
        }

        // GET api/<NurseController>/5
        [HttpGet("{id}")]
        public ActionResult<Nurse> Get(int id)
        {
            Nurse nurs = ln.Find(p => p.Id == id);
            if (nurs == null)
            {
                return NotFound();
            }
            return nurs;
        }

        // POST api/<NurseController>
        [HttpPost]
        public void Post([FromBody] Nurse nurse)
        {
            ln.Add(new Nurse {Name=nurse.Name,CountHours=nurse.CountHours,Price=nurse.Price, Id=nurse.Id });

        }

        // PUT api/<NurseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Nurse nurse)
        {
            var nur = ln.Find(x => x.Id == id);
            nur.Name = nurse.Name;
            nur.CountHours = nurse.CountHours;
            nur.Price = nurse.Price;
        }

        // DELETE api/<NurseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var nurse = ln.Find(x => x.Id == id);
            ln.Remove(nurse);
        }
    }
}
