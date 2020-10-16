using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class ProductBusiness : IProductBusiness
    {
        private IProductRepository _res;
        public ProductBusiness(IProductRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }
        public bool Create(ProductModel model)
        {
            return _res.Create(model);
        }
        public ProductModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ProductModel> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public List<ProductModel> GetDataNew()
        {
            return _res.GetDataNew();
        }
        public List<ProductModel> GetProductRelated(int product_id, string category_id)
        {
            return _res.GetProductRelated(product_id, category_id);
        }

        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string category_id)
        {
            return _res.Search(pageIndex, pageSize, out total, category_id);
        }
    }
}
