using CRUD_Backend.Models;
using DAL;
using DAL.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUD_Backend.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ICommandHandler _commandHandler;

        public ValuesController()
        {
            _commandHandler = new DbCommandHandler();
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            var abc = _commandHandler.ExecuteStoredProcedureList<Employee>("dbo.USP_Employee_Get").ToList();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
