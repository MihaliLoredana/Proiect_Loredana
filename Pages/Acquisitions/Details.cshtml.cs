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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public DetailsModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

      public Acquisition Acquisition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Acquisition == null)
            {
                return NotFound();
            }

            var Acquisition = await _context.Acquisition.Include(b=>b.Client).Include(b=>b.Game).FirstOrDefaultAsync(m => m.ID == id);
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
    }
}
