using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        //dependency injection
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        // return a list of books
        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            //retrieves all the books from the database and stores them inside IEnumerable 
            Books = await _db.Book.ToListAsync();
        }
    }
}