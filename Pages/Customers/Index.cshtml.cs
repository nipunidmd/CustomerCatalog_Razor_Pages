using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerCatalogue.Data;
using CustomerCatalogue.Models;

namespace CustomerCatalogue.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly CustomerCatalogue.Data.CustomerCatalogueContext _context;

        public IndexModel(CustomerCatalogue.Data.CustomerCatalogueContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customer != null)
            {
                Customer = await _context.Customer.ToListAsync();
            }
        }
    }
}
