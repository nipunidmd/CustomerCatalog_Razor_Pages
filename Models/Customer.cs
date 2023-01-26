using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCatalogue.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Added Date")]
    [DataType(DataType.Date)]
    public DateTime AddedDate { get; set; }
    public string? Company { get; set; }
    public string? ContactNo { get; set; }
    public string? Email { get; set; }
}
