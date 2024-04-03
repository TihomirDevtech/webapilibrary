using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IdentityModel.Tokens.Jwt;
using WebLibraryAPI.Data;
using WebLibraryAPI.Dtos.Domain;
using WebLibraryAPI.Models.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController(LibraryDbContext libraryDbContext) : ControllerBase
    {
        private readonly LibraryDbContext _libraryDbContext = libraryDbContext;

        // GET: api/<BookController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _libraryDbContext.Books;
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {

            var book = await _libraryDbContext.Books.FirstOrDefaultAsync(x => x.BookId == id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookCreationDto bookCreationDto)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var jti = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value;

            var book = new Book()
            {
                Author = bookCreationDto.Author,
                Title = bookCreationDto.Title,
                NumOfPages = bookCreationDto.NumOfPages,
                BookDesc = bookCreationDto.BookDesc,
            };

            book.MemberId = Convert.ToInt32(jti);
            try
            {
                using MemoryStream ms = new();
                await bookCreationDto.BookCover.CopyToAsync(ms);

                // Load the image using SixLabors.ImageSharp
                using (Image image = Image.Load(ms.ToArray()))
                {
                    // Resize the image to reduce its dimensions (adjust as needed)
                    int targetWidth = 400;
                    int targetHeight = 300;
                    image.Mutate(x => x.Resize(targetWidth, targetHeight));

                    // Reduce image quality (adjust as needed)
                    var encoder = new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder { Quality = 50 };

                    // Save the processed image to a new memory stream
                    using MemoryStream resizedImageStream = new();
                    image.Save(resizedImageStream, encoder);

                    // Assign the resized and compressed image to book.Picture
                    book.Picture = resizedImageStream.ToArray();
                }
                book.TypeOfFile = bookCreationDto.BookCover.ContentType;
                book.DateAdded = DateOnly.FromDateTime(DateTime.UtcNow);

                _libraryDbContext.Books.Add(book);
                await _libraryDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong.");
            }
            return NoContent();
        }

        // PUT api/<BookController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<BookController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
