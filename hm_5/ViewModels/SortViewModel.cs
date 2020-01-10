using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hm_5.ViewModels;

namespace hm_5.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState RelSort { get; private set; }    
        public SortState CatSort { get; private set; }  
        public SortState Current { get; private set; }   

        public SortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            RelSort = sortOrder == SortState.RelAsc ? SortState.RelDesc : SortState.RelAsc;
            CatSort = sortOrder == SortState.CatAsc ? SortState.CatDesc : SortState.CatAsc;
            Current = sortOrder;
        }
    }
}
