using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace taask_64
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public virtual List<Perfume> Perfumes { get; set; }
    }
}
