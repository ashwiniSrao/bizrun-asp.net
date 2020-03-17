using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspRazor.Data;
using AspRazor.Models;

namespace AspRazor
{
    public class DeleteModel : PageModel
    {
        private readonly AspRazor.Data.AspRazorContext _context;

        public DeleteModel(AspRazor.Data.AspRazorContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            register = await _context.register.FindAsync(id);

            if (register != null)
            {
                _context.register.Remove(register);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
