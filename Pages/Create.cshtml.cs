using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WolManagerApp;
using WolManagerApp.Models;

namespace WolManagerApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly WolManagerApp.WolDBContext _context;

        public CreateModel(WolManagerApp.WolDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WolData WolData { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WolData.Add(WolData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
