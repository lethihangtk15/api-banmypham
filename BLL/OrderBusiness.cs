using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class OrderBusiness:IOrderBusiness
    {
        private IOrderRepository _res;
        private IProductBusiness _rsp;
        public OrderBusiness(IOrderRepository res, IProductBusiness rsp)
        {
            _res = res;
            _rsp = rsp;
        }
        public bool Create(OrderModel model)
        {
            return _res.Create(model);
        }

        public OrderModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public OrderModel GetChiTietByHoaDon(string id)
        {
            var kq = _res.GetDatabyID(id);

            kq.listjson_chitiet = _res.GetChitietbyhoadon(id);
            foreach (var item in kq.listjson_chitiet)
            {
                item.product_name = _rsp.GetDatabyID(item.product_id).product_name;
                item.product_price = _rsp.GetDatabyID(item.product_id).product_price.Value;
            }

            return kq;
        }



        public List<OrderModel> GetDataAll()
        {
            return _res.GetDataAll();
        }

        public List<OrderModel> Search(int pageIndex, int pageSize, out long total, string ho_ten)
        {
            return _res.Search(pageIndex, pageSize, out total, ho_ten);

        }
    }
}
