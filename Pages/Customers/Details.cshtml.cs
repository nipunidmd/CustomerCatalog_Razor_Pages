using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerCatalogue.Data;
using CustomerCatalogue.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerCatalogue.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerCatalogue.Data.CustomerCatalogueContext _context;

        public DetailsModel(CustomerCatalogue.Data.CustomerCatalogueContext context)
        {
            _context = context;
        }

      public Customer Customer { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Companies { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CustomerGenre { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();

        }
    }
}
