using BLL.Interfaces;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class CategoryBusiness : ICategoryBusiness
    {
        private ICategoryRepository _res;
        public CategoryBusiness(ICategoryRepository ItemGroupRes)
        {
            _res = ItemGroupRes;
        }

        public List<CategoryModel> GetData()
        {
            var allItemGroups = _res.GetData();
            var lstParent = allItemGroups.Where(ds => ds.parent_category_id == null).OrderBy(s => s.category_id).ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allItemGroups, item);
            }
            return lstParent;
        }
        public List<CategoryModel> GetHiearchyList(List<CategoryModel> lstAll, CategoryModel node)
        {
            var lstChilds = lstAll.Where(ds => ds.parent_category_id == node.category_id).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.OrderBy(s => s.category_id).ToList();
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public CategoryModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(CategoryModel model)
        {
            return _res.Create(model);
        }
        public bool Update(CategoryModel model)
        {
            return _res.Update(model);
        }
        public List<CategoryModel> Search(int pageIndex, int pageSize, out long total, string category_name)
        {
            return _res.Search(pageIndex, pageSize, out total, category_name);
        }
    }
}
