using BLL;
using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController:ControllerBase
    {
        private IOrderBusiness _OrderBusiness;
        public OrderController(IOrderBusiness OrderBusiness)
        {
            _OrderBusiness = OrderBusiness;
        }

        [Route("create-order")]
        [HttpPost]
        public OrderModel CreateItem([FromBody] OrderModel model)
        {
            model.ma_hoa_don = Guid.NewGuid().ToString();
            if (model.listjson_chitiet != null)
            {
                foreach (var item in model.listjson_chitiet)
                    item.ma_chi_tiet = Guid.NewGuid().ToString();
            }
            _OrderBusiness.Create(model);
            return model;
        }


        [Route("get-all")]
        [HttpGet]
        public IEnumerable<OrderModel> GetDatabAll()
        {
            return _OrderBusiness.GetDataAll();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public OrderModel GetDatabyID(string id)
        {
            return _OrderBusiness.GetDatabyID(id);
        }

        [Route("get-chi-tiet-by-hoa-don/{id}")]
        [HttpGet]
        public OrderModel GetCHitietByHoaDon(string id)
        {
            var kq = _OrderBusiness.GetChiTietByHoaDon(id);
            return kq;
        }

        [Route("search")]
        [HttpPost]
        public ResponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ResponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ho_ten = "";
                if (formData.Keys.Contains("ho_ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ho_ten"]))) { ho_ten = Convert.ToString(formData["ho_ten"]); }

                long total = 0;
                var data = _OrderBusiness.Search(page, pageSize, out total, ho_ten);
                response.TotalItems = total;
                response.Data = data;
                response.Page = page;
                response.PageSize = pageSize;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return response;
        }
    }
}
