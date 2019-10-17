using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LDI.BusinessLogic.Abstract;
using LDI.Model;
using Microsoft.AspNetCore.Mvc;

namespace LDI.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public IUnitOfWork service;

        public ValuesController(IUnitOfWork _service)
        {
            service = _service;

        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return service.User.GetList().ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<List<int>> Get(int id)
        {
            return service.User.GetRoles(id).Select(x=> x.ID).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
