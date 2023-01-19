using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_Loredana.Data;
using Proiect_Loredana.Models;

namespace Proiect_Loredana.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public DetailsModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

      public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            var game = await _context.Game.FirstOrDefaultAsync(m => m.ID == id);
            if (game == null)
            {
                return NotFound();
            }
            else 
            {
                Game = game;
            }
            return Page();
        }
    }
}
