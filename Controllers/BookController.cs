using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersExampleProject.Controllers
{
    public class BookController : Controller
    {
        [Route("bookstore")]
        public IActionResult Index()
        {
            //Book id should be applied
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied");

                //return new BadRequestResult();
                return BadRequest("Book id is not supplied");
            }

            //Book id can't be empty
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400;
                //return Content("Book id  can't be null or empty");

                return BadRequest("Book id  can't be null or empty");
            }

            //Book id should be between 1 to 1000
            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
            if (bookId <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be less than or equal to zero");

                return BadRequest("Book id can't be less than or equal to zero");
            }
            if (bookId > 1000)
            {
                // Response.StatusCode = 400;
                // return Content("Book id can't be greater than 1000");

                return NotFound("Book id can't be greater than 1000");
            }

            //isloggedin should be true
            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
            {
                // Response.StatusCode = 401;
                // return Content("User must be authenticated");

                //return Unauthorized("User must be authenticated");

                return StatusCode(401);
            }

            // return new RedirectToActionResult("Books", "Store", new {});  //302 - Found

            return new RedirectToActionResult("Books", "Store", new { }, true); //301 - Moved Permanently
        }
    }
}

