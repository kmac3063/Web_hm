using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hm_5.Models;

namespace hm_5.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Game> Games { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
