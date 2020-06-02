using CRUD_Backend.Models;
using DAL;
using DAL.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CRUD_Backend.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private readonly ICommandHandler _commandHandler;
        public EmployeeController()
        {
            _commandHandler = new DbCommandHandler();
        }

        [HttpGet]
        [Route("getemployee")]
        public IList<Employee> GetEmployeeInfo()
        {
            return _commandHandler.ExecuteStoredProcedureList<Employee>("dbo.USP_Employee_Get").ToList();
        }
    }
}
