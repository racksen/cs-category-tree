using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTreeStructure
{
    public class Category
    {
        public int ID { get; set; }
        public int ParentCategoryID { get; set; }
        public string Name { get; set; }
        public string Keywords { get; set; }
    }
}
