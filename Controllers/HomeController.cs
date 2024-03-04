using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControllersExampleProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExampleProject.Controllers
{
    [Controller]
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            //return new ContentResult()
            //{
            //    Content = "Hello from Index",
            //    ContentType = "text/plain"
            //};

            // return Content("Hello from Index", "text/plain");

            return Content("<h1>Welcome</h1> <h2>Hello from Index</h2>", "text/html");
        }

        [Route("person")]
        public JsonResult Person()
        {
            Person person = new Person()
            {
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Smith",
                Age = 25
            };

            return new JsonResult(person);
            //return new Json(person);
            //return "{ \"key\": \"value\" }";
        }

        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            // return new VirtualFileResult("/samplePDF.pdf", "application/pdf");
            return File("/samplePDF.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            // return new PhysicalFileResult("/Users/gencaypolat/Desktop/samplePDF.pdf", "application/pdf");
            return PhysicalFile("/Users/gencaypolat/Desktop/samplePDF.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {

            byte[] bytes = System.IO.File.ReadAllBytes("/Users/gencaypolat/Desktop/samplePDF.pdf");

            // return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}