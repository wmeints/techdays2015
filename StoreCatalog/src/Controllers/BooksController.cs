using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Catalog {
  [Route("/api/books/")]
  public class BooksController: Controller {
    private IBookRepository _repository;

    public BooksController(IBookRepository repository) {
      _repository = repository;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<Object> Get(string id) {
      var book = await _repository.FindById(id);

      if(book == null) {
        Context.Response.StatusCode = 404;

        return new {
          message = "The specified book could not be found"
        };
      }

      return book;
    }

    [HttpPost]
    public async Task<Object> Post([FromBody] CreateBookData data) {
      var book = new Book(data.Title, data.Description, data.Genre, data.Author, data.PublicationDate);
      return await _repository.Insert(book);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<Object> Put(string id, [FromBody] UpdateBookData data) {
      var book = await _repository.FindById(id);

      if(book == null) {
        Context.Response.StatusCode = 404;

        return new {
          message = "The specified book could not be found"
        };
      }

      book.Title = data.Title;
      book.Description = data.Description;
      book.Genre = data.Genre;
      book.Author = data.Author;
      book.PublicationDate = data.PublicationDate;

      return await _repository.Update(book);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<Object> Delete(string id) {
      var book = await _repository.FindById(id);

      if(book == null) {
        Context.Response.StatusCode = 404;

        return new {
          message = "The specified book could not be found"
        };
      }

      await _repository.Remove(book);

      Context.Response.StatusCode = 204;

      return null;
    }
  }
}
