using System.ComponentModel.DataAnnotations.Schema;
using WebLibraryAPI.Models.Auth;

namespace WebLibraryAPI.Models.Domain;

public class FavouriteBook
{
    public int FavouriteBookId { get; set; }

    [ForeignKey("Member")]
    public int MemberId { get; set; }
    public virtual Member Member { get; set; }
    public int LikedBookId { get; set; }
}
