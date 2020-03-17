using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspRazor.Data;
using AspRazor.Models;

namespace AspRazor
{
    public class EditModel : PageModel
    {
        private readonly AspRazor.Data.AspRazorContext _context;

        public EditModel(AspRazor.Data.AspRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public register register { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            register = await _context.register.FirstOrDefaultAsync(m => m.Id == id);

            if (register == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!registerExists(register.Id))
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

        private bool registerExists(int id)
        {
            return _context.register.Any(e => e.Id == id);
        }
    }
}
