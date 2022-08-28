﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi5shirleyrios.Repositories;
using System.Collections.Generic;
using WebApi5shirleyrios.Model;

namespace WebApi5shirleyrios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public Task<IEnumerable<Book>> GetBooks()
        {
            return _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>>GetBooks(int id)
        {
            return await _bookRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book )
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new {id = newBook.Id}, newBook);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookDelete = await _bookRepository.Get(id);
            if (bookDelete != null)
                return NotFound();

            await _bookRepository.Delete(bookDelete.Id);
            return NoContent();

        }
        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Book book)
        {
            if(id ==book.Id )
                return BadRequest();
            await _bookRepository.update(book);
            return NoContent();
        }
    }
}
