using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Catalog {
    public interface IBookRepository {
      Task<PagedResultSet<Book>> FindAll(int pageIndex, int pageSize);
      Task<Book> FindById(String bookId);
      Task<Book> Insert(Book book);
      Task<Book> Update(Book book);
      Task Remove(Book book);
    }

    public class BookRepositoryImpl: IBookRepository {
      private IMongoCollection<Book> _collection;

      public BookRepositoryImpl(string url, string databaseName) {
        var client = new MongoClient(url);
        var database = client.GetDatabase(databaseName);

        _collection = database.GetCollection<Book>("books");
      }

      public async Task<PagedResultSet<Book>> FindAll(int pageIndex, int pageSize) {
        var filter = new BsonDocument();
        var records = await _collection.Find(filter).Skip(pageIndex * pageSize).Limit(pageSize).ToListAsync();
        var itemCount = await _collection.CountAsync(filter);

        return new PagedResultSet<Book>(records, pageIndex, pageSize, itemCount);
      }

      public Task<Book> FindById(String id) {
        return _collection.Find(book => book.Id == ObjectId.Parse(id)).FirstOrDefaultAsync();
      }

      public async Task<Book> Insert(Book book) {
        try {
          await _collection.InsertOneAsync(book);
        } catch(Exception ex) {
          throw ex;
        }

        return book;
      }

      public async Task<Book> Update(Book book) {
        await _collection.ReplaceOneAsync(b => b.Id == book.Id,book);
        return book;
      }

      public async Task Remove(Book book) {
        await _collection.DeleteOneAsync(b => b.Id == book.Id);
      }
    }
}
