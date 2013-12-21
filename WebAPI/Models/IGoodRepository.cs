using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAPI.Models
{
    interface IGoodRepository
    {
        IEnumerable<Goods> GetAll();
        Goods Get(int id);
        Goods Add(Goods item);
        void Remove(int id);
        bool Update(Goods item);


    }
}
