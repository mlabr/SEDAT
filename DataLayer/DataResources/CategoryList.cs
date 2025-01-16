using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataResources
{
	internal class CategoryList
	{
        public CategoryList(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<CategoryList> SubCategoryList { get; set; } = new List<CategoryList>();
    }
}
