using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public partial interface IOrderRepository
    {
        bool Create(OrderModel model);
        List<OrderModel> GetDataAll();
        OrderModel GetDatabyID(string id);
        List<OrderModel> Search(int pageIndex, int pageSize, out long total, string ho_ten);
        List<OrderDetailModel> GetChitietbyhoadon(string id);
    }
}
