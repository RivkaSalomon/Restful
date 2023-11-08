using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Entities;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private static List<Appointment> li = new List<Appointment>{new Appointment
        { Date = new DateOnly(1020, 12, 23), Subject = "Weigth", Id = 1234 }};
           
           
         
       
        // GET: api/<AppointmentController>
        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            // return new string[] { "value1", "value2" };
            return li;
        }

        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public ActionResult<Appointment> GetById(int id)
        {
            Appointment appo = li.Find(p => p.Id == id);
            if (appo == null)
            {
                return NotFound();
            }
            return appo;
        }
        [HttpGet("{date}")]
        public ActionResult<List<Appointment>> GetByDate(DateOnly d)
        {
            //List<Baby> babies = new List<Baby>();
            List<Appointment> ap = new List<Appointment>();
           // ap = li.FindAll(p => p.Date == d);
            if (d == null)
            {
                return NotFound();
            }
            return li.FindAll(p => p.Date == d);
        }
        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] Appointment app)
        {
            li.Add(app);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Appointment app)
        {
            var appo=li.Find(x=>x.Id == id);
            appo.Subject = app.Subject;
            appo.Date= app.Date;    
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var appo = li.Find(x => x.Id == id);
            li.Remove(appo);
        }

    }
}
