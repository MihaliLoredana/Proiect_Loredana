using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_Loredana.Data;
using Proiect_Loredana.Models;

namespace Proiect_Loredana.Pages.Games
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : GameCategoriesPageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public CreateModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "ID", "CompanyName");

            var Game = new Game();
            Game.GameCategories = new List<GameCategory>();
            PopulateAssignedCategoryData(_context, Game);
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            //var newGame = new Game();
            var newGame = Game;
            if (selectedCategories != null)
            {
                newGame.GameCategories = new List<GameCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new GameCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newGame.GameCategories.Add(catToAdd);
                }
            }
           // if (await TryUpdateModelAsync<Game>(
            //newGame,
            //"Game",
            //i => i.Title, i => i.Author,
           // i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            //{
                _context.Game.Add(newGame);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            //}
            PopulateAssignedCategoryData(_context, newGame);
            return Page();

            //if (!ModelState.IsValid)
            // {
            //  return Page();
            //}

            // _context.Game.Add(Game);
            // await _context.SaveChangesAsync();

            // return RedirectToPage("./Index");
        }
    }
}
