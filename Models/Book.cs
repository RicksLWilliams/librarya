  
using System.ComponentModel.DataAnnotations;

namespace librarya.Models
{
  public class Book
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(80)]
    public string Title { get; set; }
    public string Auther { get; set; }
    public bool isAvailable  { get; set; }
  }
}