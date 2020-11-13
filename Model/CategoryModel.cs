using System;
using System.Collections.Generic;
//using System.Text;

namespace Model
{
    public class CategoryModel
    {
        public string parent_category_id { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public string desc { get; set; }
        public string url { get; set; }
        public List<CategoryModel> children { get; set; }
        public string type { get; set; }
    }
}
