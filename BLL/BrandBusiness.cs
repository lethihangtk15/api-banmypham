using BLL.Interfaces;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class BrandBusiness:IBrandBusiness
    {
        private IBrandRepository _res;
        public BrandBusiness(IBrandRepository BrandRes)
        {
            _res = BrandRes;
        }

        public List<BrandModel> GetData()
        {
            var allBrand = _res.GetData();
            var lstParent = allBrand.Where(ds => ds.parent_brand_id == null).OrderBy(s => s.brand_id).ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allBrand, item);
            }
            return lstParent;
        }
        public List<BrandModel> GetHiearchyList(List<BrandModel> lstAll, BrandModel node)
        {
            var lstChilds = lstAll.Where(ds => ds.parent_brand_id == node.brand_id).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.OrderBy(s => s.brand_id).ToList();
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public BrandModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(BrandModel model)
        {
            return _res.Create(model);
        }
        public bool Update(BrandModel model)
        {
            return _res.Update(model);
        }
        public List<BrandModel> Search(int pageIndex, int pageSize, out long total, string brand_name)
        {
            return _res.Search(pageIndex, pageSize, out total, brand_name);
        }
    }
}
