using System;
using StoreCatalog.Models;

namespace StoreCatalog.Repositories
{
    public interface IBooksRepository
    {
        /// <summary>
        /// Find a single book by its article number
        /// </summary>
        /// <param name="articleNumber"></param>
        /// <returns></returns>
        Book FindByArticleNumber(int articleNumber);

        /// <summary>
        /// Saves a book in the database
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Book Save(Book book);

        /// <summary>
        /// Tries to remove an existing book from the books catalog.
        /// </summary>
        /// <param name="articleNumber">ID of the book to remove</param>
        /// <returns>Returns true when the book is removed; Otherwise false.</returns>
        bool Remove(int articleNumber);
    }
}