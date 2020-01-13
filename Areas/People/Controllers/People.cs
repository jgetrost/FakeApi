using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shuttle.Models;

namespace Shuttle.Controllers
{
    

    [ApiController]
    [Route("api/People/[controller]")]
    public class PeopleController : ControllerBase
    {
        public static List<Person> People {get; set;}

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            List<Person> people = null;

            people = PeopleController.People.ToList();

            return people;
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id){
            Person person = PeopleController.People.SingleOrDefault(p => p.Id == id);

            if(person != null){
                return person;
            }else{
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create(Person person){
            PeopleController.People.Add(person);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){

            PeopleController.People = PeopleController.People.Where(p => p.Id != id).ToList();

            return Ok();
        }
    }


}