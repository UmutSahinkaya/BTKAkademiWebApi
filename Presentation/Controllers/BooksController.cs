using Entities.DataTransferObject;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {

            var books = _manager.BookService.GetAllBooks(false);
            return Ok(books);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = _manager.BookService.GetOneBookById(id, false);
            if (book is null)
                throw new BookNotFoundException(id);

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] BookDtoForInsertion bookDto)
        {

            if (bookDto is null)
                return BadRequest();

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var book=_manager.BookService.CreateOneBook(bookDto);

            return StatusCode(201, book);

        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {

            if (bookDto is null)
                return BadRequest(); //400
            _manager.BookService.UpdateOneBook(id, bookDto, true);
            return NoContent(); //204

        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
        {

            _manager.BookService.DeleteOneBook(id, false);
            return NoContent();

        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDto> bookPatch)
        {

            //check entity
            var bookDto = _manager.BookService.GetOneBookById(id, true);
            bookPatch.ApplyTo(bookDto);
            _manager.BookService.UpdateOneBook(id, 
               new BookDtoForUpdate
               {
                   Id= bookDto.Id,
                   Title= bookDto.Title,
                   Price= bookDto.Price
               }, true
            );

            return NoContent(); //204

        }
    }
}
