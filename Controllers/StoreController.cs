using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ControllersExampleProject.Controllers
{
    public class StoreController : Controller
    {
        [Route("store/books")]
        public IActionResult Books()
        {
            return Content("<h1>Book Store</h1>", "text/html");
        }
    }
}

