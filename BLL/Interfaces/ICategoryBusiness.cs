using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface ICategoryBusiness
    {
        List<CategoryModel> GetData();
        CategoryModel GetDatabyID(string id);
        bool Create(CategoryModel model);
        bool Update(CategoryModel model);
        bool Delete(string id);
        List<CategoryModel> Search(int pageIndex, int pageSize, out long total, string category_name);
    }
}
