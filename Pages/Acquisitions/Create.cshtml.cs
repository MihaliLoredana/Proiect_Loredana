using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Loredana.Data;
using Proiect_Loredana.Models;

namespace Proiect_Loredana.Pages.Acquisitions
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public CreateModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var GameList = _context.Game
                .Include(b => b.Author)
                .Select(x => new { x.ID, GameFullName = x.Title + " - " + x.Author.Address + " " + x.Author.CompanyName });
            ViewData["GameID"] = new SelectList(GameList, "ID", "GameFullName");
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Acquisition Acquisition { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Acquisition.Add(Acquisition);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
