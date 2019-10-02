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
    public class PhonesController : ApiController
    {
        // GET api/<controller>
        public async Task<IHttpActionResult> Get()
        {
            return Ok(await Phone.GetAllAsync());
        }

        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(int id)
        {
            return Ok(await Phone.GetByIdAsync(id));
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post(Phone phone)
        {
            return Ok(await new Phone(phone).CreateAsync());
        }

        // PUT api/<controller>
        public async Task<IHttpActionResult> Put(Phone phone)
        {
            return Ok(await new Phone(phone).UpdateAsync());
        }

        // DELETE api/<controller>/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            var phone = new Phone { Id = id };
            return Ok(await new Phone(phone).RemoveAsync());
        }
    }
}