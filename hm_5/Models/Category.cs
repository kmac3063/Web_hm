using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hm_5.Models
{
    public class Category
    {
        public List<Game> Games { get; set; }
        public Category()
        {
             Games = new List<Game>();
        }
        public int Id { get; set; }
        public string Name { get; set; }



    }
}
