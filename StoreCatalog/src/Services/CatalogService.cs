using System;
using StoreCatalog.Models;
using StoreCatalog.ViewModels;
using StoreCatalog.Repositories;
using System.Linq;

namespace StoreCatalog.Services
{
    public class CatalogService : ICatalogService
    {
        private IBooksRepository _booksRepository;

        public Book FindByArticleNumber(int articleNumber)
        {
            return _booksRepository.FindByArticleNumber(articleNumber);
        }

        public Book Create(CreateBookRequestData data)
        {
            return _booksRepository.Save(new Book()
            {
                Title = data.Title,
                Description = data.Description,
                Authors = data.Authors.Select(author => new Author { Name = author.Name, Biography = author.Biography }).ToList(),
                Format = data.Format,
                Genre = data.Genre,
                Language = data.Language
            });
        }

        public bool Remove(int articleNumber)
        {
            throw new NotImplementedException();
        }

        public Book Update(int articleNumber, UpdateBookRequestData data)
        {
            var book = _booksRepository.FindByArticleNumber(articleNumber);

            if(book == null)
            {
                return null;
            }

            book.Title = data.Title;
            book.Description = data.Description;
            book.Price = data.Price;
            book.Genre = data.Genre;
            book.Description = data.Description;
            book.Authors = data.Authors.Select(author => new Author() { Name = author.Name, Biography = author.Biography }).ToList();
            book.Format = data.Format;
            data.Language = data.Language;

            _booksRepository.Save(book);

            return book;
        }
    }
}