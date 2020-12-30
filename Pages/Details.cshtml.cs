using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WolManagerApp;
using WolManagerApp.Models;

namespace WolManagerApp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly WolManagerApp.WolDBContext _context;

        public DetailsModel(WolManagerApp.WolDBContext context)
        {
            _context = context;
        }

        public WolData WolData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WolData = await _context.WolData.FirstOrDefaultAsync(m => m.Id == id);

            if (WolData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
