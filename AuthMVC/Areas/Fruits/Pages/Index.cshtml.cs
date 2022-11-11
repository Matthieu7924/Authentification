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
    public class IndexModel : PageModel
    {
        private readonly AuthMVC.Data.ApplicationDbContext _context;

        public IndexModel(AuthMVC.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Fruit> Fruit { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Fruit != null)
            {
                Fruit = await _context.Fruit.ToListAsync();
            }
        }
    }
}
