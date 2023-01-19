using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Loredana.Data;
using Proiect_Loredana.Models;

namespace Proiect_Loredana.Pages.Acquisitions
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public IndexModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

        public IList<Acquisition> Acquisition { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Acquisition != null)
            {
                Acquisition = await _context.Acquisition
                .Include(b => b.Game)
                .ThenInclude(b => b.Author)
                .Include(b => b.Client).ToListAsync();
            }
        }
    }
}
