using System;
using System.Collections.Generic;
using System.Text;
using Model;


namespace DAL
{
    public partial interface ICategoryRepository
    {
        List<CategoryModel> GetData();
        bool Delete(string id);
        CategoryModel GetDatabyID(string id);
        bool Create(CategoryModel model);
        bool Update(CategoryModel model);
        List<CategoryModel> Search(int pageIndex, int pageSize, out long total, string category_name);
    }
}
