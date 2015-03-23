using StoreCatalog.Models;
using StoreCatalog.ViewModels;
using System;

namespace StoreCatalog.Services
{
    public interface ICatalogService
    {
        Book FindByArticleNumber(int articleNumber);
        Book Create(CreateBookRequestData data);
        Book Update(int articleNumber, UpdateBookRequestData data);
        bool Remove(int articleNumber);
    }
}