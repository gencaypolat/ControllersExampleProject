using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllersExampleProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersExampleProject.Controllers
{
    public class BookController : Controller
    {
        [Route("bookstore/{bookid?}/{isloggedin?}")]
        // Url: /bookstore?bookid=10&isloggedin=true
        public IActionResult Index([FromQuery] int? bookid, [FromRoute] bool? isloggedin, Book book)
        {
            //Book id should be applied
            if (bookid.HasValue == false)
            {
                return BadRequest("Book id is not supplied");
            }

            //Book id should be between 1 to 1000
            if (bookid <= 0)
            {
                return BadRequest("Book id can't be less than or equal to zero");
            }

            if (bookid > 1000)
            {
                return NotFound("Book id can't be greater than 1000");
            }

            //isloggedin should be true
            if (isloggedin == false)
            {
                return StatusCode(401);
            }

            return Content($"Book id: {bookid}", "text/plain");
        }
    }
}

