using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllersExampleProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersExampleProject.Controllers
{
    public class PersonNewController : Controller
    {
        [Route("register")]
        public IActionResult Index(PersonNew person)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage).ToList());

                return BadRequest(errors);
            }

            return Content($"{person}");
        }
    }
}

