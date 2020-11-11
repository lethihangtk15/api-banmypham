using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class OrderDetailModel
    {
		public string ma_chi_tiet { get; set; }
		public string ma_hoa_don { get; set; }
		public int product_id { get; set; }
		public decimal? product_price { get; set; }
		public string product_name { get; set; }
		public int so_luong { get; set; }
	}
}
