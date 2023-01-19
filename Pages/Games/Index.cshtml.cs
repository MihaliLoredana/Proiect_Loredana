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
    public class IndexModel : PageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public IndexModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get;set; } = default!;
        public GameData GameD { get; set; }
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            //if (_context.Game != null)
            //{
            GameD = new GameData();
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            AuthorSort = String.IsNullOrEmpty(sortOrder) ? "author_desc" : "";
            CurrentFilter = searchString;

            GameD.Games = await _context.Game
                   
                    .Include(b => b.Author)
                    .Include(b => b.GameCategories)
                    .ThenInclude(b => b.Category)
                    .AsNoTracking()
                    .OrderBy(b => b.Title)
                    .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                GameD.Games = GameD.Games.Where(s => s.Author.CompanyName.Contains(searchString)

               || s.Author.Address.Contains(searchString)
               || s.Title.Contains(searchString));
            }

            if (id != null)
            {
                GameID = id.Value;
                Game Game = GameD.Games
                .Where(i => i.ID == id.Value).Single();
                GameD.Categories = Game.GameCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "title_desc":
                    GameD.Games = GameD.Games.OrderByDescending(s =>
                   s.Title);
                    break;
                case "author_desc":
                    GameD.Games = GameD.Games.OrderByDescending(s =>
                   s.Author.CompanyName);
                    break;
            }
        
                    //}

        }
    }
}
