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
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public DeleteModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Acquisition Acquisition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Acquisition == null)
            {
                return NotFound();
            }

            var Acquisition = await _context.Acquisition.Include(b => b.Client).Include(b => b.Game).FirstOrDefaultAsync(m => m.ID == id);

            if (Acquisition == null)
            {
                return NotFound();
            }
            else 
            {
                Acquisition = Acquisition;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Acquisition == null)
            {
                return NotFound();
            }
            var Acquisition = await _context.Acquisition.FindAsync(id);

            if (Acquisition != null)
            {
                Acquisition = Acquisition;
                _context.Acquisition.Remove(Acquisition);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
