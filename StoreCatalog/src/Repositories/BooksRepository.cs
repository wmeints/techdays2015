using System;
using StoreCatalog.Models;

namespace StoreCatalog.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        public Book FindByArticleNumber(int articleNumber)
        {
            return null;
        }

        public bool Remove(int articleNumber)
        {
            throw new NotImplementedException();
        }

        public Book Save(Book book)
        {
            return null;
        }
    }
}