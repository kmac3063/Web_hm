using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6._4
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Game> Games { get; set; }
    }
}
