using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspRazor.Data;
using AspRazor.Models;

namespace AspRazor
{
    public class CreateModel : PageModel
    {
        private readonly AspRazor.Data.AspRazorContext _context;

        public CreateModel(AspRazor.Data.AspRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public register register { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.register.Add(register);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
