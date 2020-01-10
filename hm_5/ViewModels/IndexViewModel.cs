using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hm_5.Models;

namespace hm_5.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<Game> Games { get; set; }
    }
}
