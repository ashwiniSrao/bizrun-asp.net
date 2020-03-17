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
    public class IndexModel : PageModel
    {
        private readonly AspRazor.Data.AspRazorContext _context;

        public IndexModel(AspRazor.Data.AspRazorContext context)
        {
            _context = context;
        }

        public IList<register> register { get;set; }

        public async Task OnGetAsync()
        {
            register = await _context.register.ToListAsync();
        }
    }
}
