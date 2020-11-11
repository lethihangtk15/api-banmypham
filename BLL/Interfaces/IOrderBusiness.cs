using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial interface IOrderBusiness
    {
        bool Create(OrderModel model);
        List<OrderModel> GetDataAll();
        OrderModel GetDatabyID(string id);
        OrderModel GetChiTietByHoaDon(string id);
        List<OrderModel> Search(int pageIndex, int pageSize, out long total, string ho_ten);
    }
}
