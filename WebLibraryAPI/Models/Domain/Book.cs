using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebLibraryAPI.Models.Auth;

namespace WebLibraryAPI.Models.Domain;

public class Book
{
    [Key]
    public int BookId { get; set; }

    [ForeignKey("Member")]
    public int MemberId { get; set; }
    public virtual Member Member { get; set; }

    [Required(ErrorMessage = "Please enter the name")]
    [StringLength(60, ErrorMessage = "Maximum 60 characters, and minimum 3", MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the number of pages")]
    public int NumOfPages { get; set; }

    [Display(Name = "Cover")]
    [MaxLength]
    public byte[] Picture { get; set; }

    [StringLength(20)]
    public string TypeOfFile { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the author")]
    public string Author { get; set; } = string.Empty;

    [StringLength(500, ErrorMessage = "Minimum 5 and maximum 500 characters", MinimumLength = 5)]
    [Required(ErrorMessage = "Please enter the description")]
    [DataType(DataType.MultilineText)]
    public string BookDesc { get; set; }

    public DateOnly DateAdded { get; set; }
}
