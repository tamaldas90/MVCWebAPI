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


        public void PutProduct(int id, Goods product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }



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
