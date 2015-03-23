using System;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using StoreCatalog.Models;
using StoreCatalog.Repositories;
using StoreCatalog.ViewModels;
using System.Linq;
using StoreCatalog.Services;

namespace StoreCatalog.Controllers
{
    [Route("api/books/{id}")]
    public class BooksController : Controller
    {
        private ICatalogService _catalogService;

        /// <summary>
        /// Retrieves a single item from the catalog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]   
        public IActionResult Get(int id)
        {
            var book = _catalogService.FindByArticleNumber(id);

            if(book == null)
            {
                return RenderBookNotFoundError();
            }

            return Json(book);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody]CreateBookRequestData data)
        {
            if(!ModelState.IsValid)
            {
                Context.Response.StatusCode = 400;
                return Json(this.ModelState.Values);
            }

            return Json(_catalogService.Create(data));
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] UpdateBookRequestData data)
        {
            var book = _catalogService.Update(id, data);

            if(book == null)
            {
                return RenderBookNotFoundError();
            }
            
            return Json(book);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(!_catalogService.Remove(id))
            {
                return RenderBookNotFoundError();
            }

            return new NoContentResult();
        }

        private IActionResult RenderBookNotFoundError()
        {
            Context.Response.StatusCode = 404;

            return Json(new
            {
                message = "We could not find the book you requested."
            });
        }
    }
}