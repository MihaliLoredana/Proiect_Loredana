using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_Loredana.Data;
using Proiect_Loredana.Models;

namespace Proiect_Loredana.Pages.Games
{
    [Authorize(Roles = "Admin")]
    public class EditModel :  GameCategoriesPageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public EditModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Game Game { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Game == null)
            {
                return NotFound();
            }

            Game = await _context.Game
                
                .Include(b => b.GameCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

           // var Game =  await _context.Game.FirstOrDefaultAsync(m => m.ID == id);
            if (Game == null)
            {
                return NotFound();
            }
            //Game = Game;
            PopulateAssignedCategoryData(_context, Game);

            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "CompanyName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var GameToUpdate = await _context.Game
      
            .Include(i => i.GameCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (GameToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Game>(
            GameToUpdate,
            "Game",
            i => i.Title, i => i.Author,
            i => i.Price, i => i.PublishingDate, i => i.Description))
            {
                UpdateGameCategories(_context, selectedCategories, GameToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateGameCategories pentru a aplica informatiile din checkboxuri la entitatea Games care
            //este editata
            UpdateGameCategories(_context, selectedCategories, GameToUpdate);
            PopulateAssignedCategoryData(_context, GameToUpdate);
            return Page();

            // if (!ModelState.IsValid)
            // {
            //    return Page();
            // }

            //  _context.Attach(Game).State = EntityState.Modified;

            // try
            // {
            //   await _context.SaveChangesAsync();
            //  }
            // catch (DbUpdateConcurrencyException)
            // {
            //  if (!GameExists(Game.ID))
            //  {
            //     return NotFound();
            // }
            //  else
            //  {
            //  throw;
            // }
            // }

            // return RedirectToPage("./Index");
        }

        private bool GameExists(int id)
        {
          return _context.Game.Any(e => e.ID == id);
        }
    }
}
