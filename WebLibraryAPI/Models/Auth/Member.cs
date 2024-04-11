using System.ComponentModel.DataAnnotations;
using WebLibraryAPI.Models.Domain;

namespace WebLibraryAPI.Models.Auth;

public class Member
{
    [Key]
    public int MemberId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [MinLength(7)]
    public string Password { get; set; } = string.Empty;

    public DateOnly DateJoined { get; set; }

    public virtual ICollection<Book> MyBooks { get; set; }
    public virtual ICollection<FavouriteBook> FavouriteBooks { get; set; }
}
