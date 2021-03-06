﻿using DAL;
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
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public bool Update(ProductModel model)
        {
            return _res.Update(model);
        }

        public ProductModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ProductModel> GetDataAll(int page_index, int page_size, out long total)
        {
            return _res.GetDataAll(page_index, page_size, out total);
        }
        public List<ProductModel> GetDataNew()
        {
            return _res.GetDataNew();
        }
        public List<ProductModel> GetSPTuongTu(int product_id)
        {
            return _res.GetSPTuongTu(product_id);
        }

        public List<ProductModel> TK(int pageIndex, int pageSize, out long total, string product_name, decimal product_price)
        {
            return _res.TK(pageIndex, pageSize, out total, product_name, product_price);
        }

        public List<ProductModel> Search(int pageIndex, int pageSize, out long total, string category_id)
        {
            return _res.Search(pageIndex, pageSize, out total, category_id);
        }
        public List<ProductModel> SearchCategory(int pageIndex, int pageSize, out long total, string category_id)
        {
            return _res.SearchCategory(pageIndex, pageSize, out total, category_id);
        }
        public List<ProductModel> SearchBrand(int pageIndex, int pageSize, out long total, string brand_id)
        {
            return _res.SearchBrand(pageIndex, pageSize, out total, brand_id);
        }
    }
}
