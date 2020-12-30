using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WolManagerApp.Models;

namespace WolManagerApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WolManagerApp.WolDBContext _context;

        public IndexModel(WolDBContext context)
        {
            _context = context;
        }

        public IList<WolData> WolData { get;set; }

        public async Task OnGetAsync()
        {
            WolData = await _context.WolData.ToListAsync();
        }

        public async Task OnPostTurnOnPC(string macaddress)
        {
            await WolManager.WakeOnLan(macaddress);
        }
    }
}
