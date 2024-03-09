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
    }
}
