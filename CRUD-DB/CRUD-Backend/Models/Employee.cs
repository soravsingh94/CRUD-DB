using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Backend.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Contact { get; set; }
    }
}