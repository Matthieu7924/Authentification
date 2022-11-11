using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AuthMVC.Data;
using AuthMVC.Models;

namespace AuthMVC.Areas.Fruits.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly AuthMVC.Data.ApplicationDbContext _context;

        public DetailsModel(AuthMVC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Fruit Fruit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Fruit == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruit.FirstOrDefaultAsync(m => m.Id == id);
            if (fruit == null)
            {
                return NotFound();
            }
            else 
            {
                Fruit = fruit;
            }
            return Page();
        }
    }
}
