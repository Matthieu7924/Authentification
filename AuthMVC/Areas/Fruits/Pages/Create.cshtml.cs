using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AuthMVC.Data;
using AuthMVC.Models;

namespace AuthMVC.Areas.Fruits.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AuthMVC.Data.ApplicationDbContext _context;

        public CreateModel(AuthMVC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Fruit Fruit { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Fruit.Add(Fruit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
