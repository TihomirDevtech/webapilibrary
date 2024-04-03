using System.ComponentModel.DataAnnotations;

namespace WebLibraryAPI.Dtos.Domain;

public class BookCreationDto
{
    public string Title { get; set; } = string.Empty;
    public int NumOfPages { get; set; }
    public string Author { get; set; } = string.Empty;

    [DataType(DataType.MultilineText)]
    public string BookDesc { get; set; }
    public IFormFile BookCover { get; set; }
}
