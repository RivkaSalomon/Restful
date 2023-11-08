using Microsoft.AspNetCore.Mvc;
using RestfulAPI.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyController : ControllerBase
    {
        private static List<Baby> lbaby = new List<Baby>{ };
      //  new Baby{Id=14854,Name="Chani" ,Age=6}
    // GET: api/<BabyController>
    [HttpGet]
        public IEnumerable<Baby> Get()
        {
            return lbaby;
        }

        // GET api/<BabyController>/5
        [HttpGet("{id}")]
        public ActionResult<Baby> Get(int id)
        {
            Baby baby = lbaby.Find(p => p.Id == id);
            if (baby == null)
            {
                return NotFound();
            }
            return baby;
        }

        // POST api/<BabyController>
        [HttpPost]
        public void Post([FromBody] Baby b)
        {
            lbaby.Add(new Baby { Id = b.Id, Name = b.Name, Age = b.Age });
        }

        // PUT api/<BabyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Baby b)
        {
            var ba = lbaby.Find(x => x.Id == id);
            ba.Name = b.Name;
            ba.Age = b.Age;
        }

        // DELETE api/<BabyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var baby = lbaby.Find(x => x.Id == id);
            lbaby.Remove(baby);
        }
    }
}
