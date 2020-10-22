using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IProductBusiness
    {
        bool Create(ProductModel model);
        bool Update(ProductModel model);
        bool Delete(string id);
        ProductModel GetDatabyID(string id);
        List<ProductModel> GetDataAll(int page_index, int page_size, out long total);
        List<ProductModel> GetDataNew();
        List<ProductModel> GetSPTuongTu(int product_id);
        List<ProductModel> TK(int pageIndex, int pageSize, out long total, string product_name, decimal product_price);
        List<ProductModel> Search(int pageIndex, int pageSize, out long total, string category);

    }
}
