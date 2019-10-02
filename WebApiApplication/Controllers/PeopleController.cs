using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiApplication.Models;

namespace WebApiApplication.Controllers
{
    public class PeopleController : ApiController
    {
        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await Person.GetAllAsync());
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await Person.GetByIdAsync(id));
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post(Person person)
        {
            return Ok(await new Person(person).CreateAsync());
        }

        // PUT api/<controller>
        public async Task<IHttpActionResult> Put(Person person)
        {
            return Ok(await new Person(person).UpdateAsync());
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}