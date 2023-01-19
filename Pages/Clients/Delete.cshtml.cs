using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Loredana.Data;
using Proiect_Loredana.Models;

namespace Proiect_Loredana.Pages.Clients
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public DeleteModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var Client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
            {
                return NotFound();
            }
            else 
            {
                Client = Client;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }
            var Client = await _context.Client.FindAsync(id);

            if (Client != null)
            {
                Client = Client;
                _context.Client.Remove(Client);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
