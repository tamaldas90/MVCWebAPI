using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;

namespace WebAPI.Models
{
    public class GoodRepository :IGoodRepository
    {

         private List<Goods> products = new List<Goods>();
        private int _nextId = 1;

        public GoodRepository()
        {
            Add(new Goods { Name = "Chicken Tikka", Category = "Fast Food", Price = 285.765M });
            Add(new Goods { Name = "Kabab", Category = "Restrudent", Price = 350.75M });
            Add(new Goods { Name = "Rasogulla", Category = "Sweet", Price = 16.99M });
        }

        public IEnumerable<Goods> GetAll()
        {
            return products;
        }

        public Goods Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public Goods Add(Goods item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Goods item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }


    }
}