﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.MF1793.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadWriteController : ControllerBase
    {
        // GET: api/<ReadWriteController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ReadWriteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReadWriteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReadWriteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReadWriteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
