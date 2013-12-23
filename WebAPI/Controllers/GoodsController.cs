using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class GoodsController : ApiController
    {

        static readonly IGoodRepository repository = new GoodRepository();

        public IEnumerable<Goods> GetAllProducts()
        {
            return repository.GetAll();
        }



        public Goods GetProduct(int id)
        {
            Goods item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }



        public IEnumerable<Goods> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }


        public HttpResponseMessage PostProduct(Goods item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Goods>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }


        public Goods PutProduct(int id, Goods item)
        {
            item.Id = id;
           /* if (repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }*/

              return repository.Update(item);

        }


        // PUT api/categories/5
      /*  public void Put(int id, Category category)
        {
            _categoriesRepository.Update(category);
        } */



        public void DeleteProduct(int id)
        {
            Goods item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.Remove(id);
        }

        //
        // GET: /Goods/

       
    }
}
