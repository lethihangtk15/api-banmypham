using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ProductModel
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string product_desc { get; set; }
        public string product_content { get; set; }
        public int quantity { get; set; }
        public decimal? product_price { get; set; }
        public int sale { get; set; }
        public string product_image { get; set; }
        public int product_status { get; set; }
        public string category_id { get; set; }
        public string brand_id { get; set; }

    }
}
