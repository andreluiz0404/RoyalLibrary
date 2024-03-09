using Microsoft.AspNetCore.Mvc;
using RoyalLibrary.Models;
using RoyalLibrary.Services.Abstractions;

namespace RoyalLibrary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController(ILogger<BookController> logger, IBookService bookService) : ControllerBase
    {
        private readonly ILogger<BookController> _logger = logger;
        private readonly IBookService _bookService = bookService;

        /// <summary>
        /// Gets all books
        /// </summary>
        /// <returns>A list of all books</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Book>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Get()
        {
            var data = await _bookService.List();
            return data is null || data.Count == 0 ? NotFound() : new JsonResult(new { data });
        }

        /// <summary>
        /// Searches according to some search criterias
        /// </summary>
        /// <param name="searchType">Search type</param>
        /// <param name="searchTerm">Search term</param>
        /// <returns>A list of books that match search criteria</returns>
        [HttpGet]
        [Route("search")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<Book>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Search(string searchType, string searchTerm)
        {
            var data = await _bookService.List();
            if (data is null || data.Count == 0)
                return NotFound();

            switch (searchType)
            {
                case "author":
                    data = [.. data.Where(b => b.first_name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || b.last_name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))];
                    break;

                case "isbn":
                    data = [.. data.Where(b => b.isbn is not null && b.isbn.StartsWith(searchTerm, StringComparison.OrdinalIgnoreCase))];
                    break;

                case "title":
                    data = [.. data.Where(b => b.title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))];
                    break;
            }

            return new JsonResult(new { data });
        }
    }
}
