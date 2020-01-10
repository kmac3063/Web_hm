using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using hm_5.Models;

namespace hm_5.Models
{
    public enum SortState
    {
        NameAsc,
        NameDesc,

        RelAsc,
        RelDesc,

        CatAsc,
        CatDesc
    }

    public class FilterViewModel
    {
        public FilterViewModel(List<Category> categories, int? categoryId, string name)
        {
            categories.Insert(0, new Category { Name = "Any", Id = 0 });

            Categories = new SelectList(categories, "Id", "Name", categoryId);
            SelectedCategory = categoryId;
            SelectedName = name;
        }
        public SelectList Categories { get; private set; } 
        public int? SelectedCategory { get; private set; }  
        public string SelectedName { get; private set; }  
    }
}
