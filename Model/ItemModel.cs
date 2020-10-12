using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ItemModel
    {
        public string item_id { get; set; }
        public string item_group_id { get; set; }
        public string brand_id { get; set; }
        public string item_name { get; set; }
        public string item_origin { get; set; } //xuất xứ
        public string item_desc { get; set; }
        public string item_weight { get; set; }
        public string item_image { get; set; }
        public decimal? item_price { get; set; }
    }
}
