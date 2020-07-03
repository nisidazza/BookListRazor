using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        //implements HTTP GET
        //this API retrieves the books and passes them back when it's called
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data=_db.Book.ToList()});
        }
    }
}
