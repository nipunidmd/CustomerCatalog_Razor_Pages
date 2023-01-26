using Microsoft.EntityFrameworkCore;
using CustomerCatalogue.Data;

namespace CustomerCatalogue.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CustomerCatalogueContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CustomerCatalogueContext>>()))
        {
            if (context == null || context.Customer == null)
            {
                throw new ArgumentNullException("Null CustomerCatalogueContext");
            }

            // Look for any movies.
            if (context.Customer.Any())
            {
                return;   // DB has been seeded
            }

            context.Customer.AddRange(
                new Customer
                {
                    Name = "Marie Buke",
                    AddedDate = DateTime.Parse("2022-09-20"),
                    Company = "IT Solutions",
                    ContactNo = "07365478952",
                    Email = "marieb@its.co.uk"
                },

                new Customer
                {
                    Name = "Anton Drail",
                    AddedDate = DateTime.Parse("2022-10-20"),
                    Company = "Jonas brothers",
                    ContactNo = "07365478952",
                    Email = "jon@jon.co.uk"
                },

                new Customer
                {
                    Name = "Marie Buke",
                    AddedDate = DateTime.Parse("2022-09-20"),
                    Company = "IT Solutions",
                    ContactNo = "07365478952",
                    Email = "marieb@its.co.uk"
                }
            );
            context.SaveChanges();
        }
    }
}
