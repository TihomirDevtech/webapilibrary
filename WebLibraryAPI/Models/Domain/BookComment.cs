using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebLibraryAPI.Models.Domain;

[Table("BookComments")]
public class BookComment
{
    [Key]
    public int CommentId { get; set; }

    [Display(Name = "Author")]
    public int AuthorId { get; set; }

    [Display(Name = "Headline")]
    [Required(ErrorMessage = "Please enter headline")]
    [StringLength(30, ErrorMessage = "Minimum 5 and maximum 30 characters", MinimumLength = 5)]
    public string Headline { get; set; } = string.Empty;

    [Display(Name = "Comment")]
    [Required(ErrorMessage = "Please enter comment")]
    [StringLength(100, ErrorMessage = "Minimum 10 and maximum 100 characters", MinimumLength = 10)]
    public string Comment { get; set; } = string.Empty;

    public DateOnly DateCommented { get; set; }
}
