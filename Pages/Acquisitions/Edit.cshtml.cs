﻿using System;
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
    public class EditModel : PageModel
    {
        private readonly Proiect_Loredana.Data.Proiect_LoredanaContext _context;

        public EditModel(Proiect_Loredana.Data.Proiect_LoredanaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Acquisition Acquisition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Acquisition == null)
            {
                return NotFound();
            }

            var Acquisition =  await _context.Acquisition.FirstOrDefaultAsync(m => m.ID == id);
            if (Acquisition == null)
            {
                return NotFound();
            }
            Acquisition = Acquisition;
            var GameList = _context.Game
                .Include(b => b.Author)
                .Select(x => new { x.ID, GameFullName = x.Title + " - " + x.Author.Address + " " + x.Author.CompanyName });
            ViewData["GameID"] = new SelectList(GameList, "ID", "GameFullName");
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Acquisition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowingExists(Acquisition.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BorrowingExists(int id)
        {
          return _context.Acquisition.Any(e => e.ID == id);
        }
    }
}
