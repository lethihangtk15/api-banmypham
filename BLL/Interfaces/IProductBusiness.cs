using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IProductBusiness
    {
        bool Create(ProductModel model);
        ProductModel GetDatabyID(string id);
        List<ProductModel> GetDataAll();
        List<ProductModel> GetDataNew();
        List<ProductModel> GetProductRelated(int product_id, string category_id);
        List<ProductModel> Search(int pageIndex, int pageSize, out long total, string category_id);
    }
}
