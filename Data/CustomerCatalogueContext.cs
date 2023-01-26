using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerCatalogue.Models;

namespace CustomerCatalogue.Data
{
    public class CustomerCatalogueContext : DbContext
    {
        public CustomerCatalogueContext (DbContextOptions<CustomerCatalogueContext> options)
            : base(options)
        {
        }

        public DbSet<CustomerCatalogue.Models.Customer> Customer { get; set; } = default!;
    }
}
