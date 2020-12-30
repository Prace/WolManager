using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WolManagerApp;
using WolManagerApp.Models;

namespace WolManagerApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly WolManagerApp.WolDBContext _context;

        public EditModel(WolManagerApp.WolDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WolData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WolDataExists(WolData.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WolDataExists(int id)
        {
            return _context.WolData.Any(e => e.Id == id);
        }
    }
}
