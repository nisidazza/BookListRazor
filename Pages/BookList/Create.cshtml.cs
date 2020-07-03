using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        //Model
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {

        }

        /*instead of passing a Book "bookObj" to the OnPost method (=> OnPost(Book bookObj)), 
         * I can use the BindProperty annotation on the property Book I already have */ 
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //adds the book to a queue
                await _db.Book.AddAsync(Book);
                //then the book is pushed to the database
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}