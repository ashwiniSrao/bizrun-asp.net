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
    public class DetailsModel : PageModel
    {
        private readonly AspRazor.Data.AspRazorContext _context;

        public DetailsModel(AspRazor.Data.AspRazorContext context)
        {
            _context = context;
        }

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
    }
}
