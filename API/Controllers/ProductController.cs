using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusiness _productBusiness;
        private string _path;

        public ProductController(IProductBusiness itemBusiness, IConfiguration configuration)
        {
            _productBusiness = itemBusiness;
            _path = configuration["AppSettings:PATH"];

        }

        public string SaveFileFromBase64String(string RelativePathFileName, string dataFromBase64String)
        {
            if (dataFromBase64String.Contains("base64,"))
            {
                dataFromBase64String = dataFromBase64String.Substring(dataFromBase64String.IndexOf("base64,", 0) + 7);
            }
            return WriteFileToAuthAccessFolder(RelativePathFileName, dataFromBase64String);
        }
        public string WriteFileToAuthAccessFolder(string RelativePathFileName, string base64StringData)
        {
            try
            {
                string result = "";
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                System.IO.File.WriteAllBytes(fullPathFile, Convert.FromBase64String(base64StringData));
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        [Route("create-product")]
        [HttpPost]
        public ProductModel CreateProduct([FromBody] ProductModel model)
        {
            if (model.product_image != null)
            {
                var arrData = model.product_image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"assets/images/product/{arrData[0]}";
                    model.product_image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _productBusiness.Create(model);
            return model;
        }

        [Route("update-product")]
        [HttpPost]
        public ProductModel UpdateProduct([FromBody] ProductModel model)
        {
            if (model.product_image != null)
            {
                var arrData = model.product_image.Split(';');
                if (arrData.Length == 3)
                {
                    var savePath = $@"{arrData[0]}";
                    model.product_image = $"{savePath}";
                    SaveFileFromBase64String(savePath, arrData[2]);
                }
            }
            _productBusiness.Update(model);
            return model;
        }

        [Route("delete-product")]
        [HttpPost]
        public IActionResult DeleteUser([FromBody] Dictionary<string, object> formData)
        {
            string product_id = "";
            if (formData.Keys.Contains("product_id") && !string.IsNullOrEmpty(Convert.ToString(formData["product_id"]))) { product_id = Convert.ToString(formData["product_id"]); }
            _productBusiness.Delete(product_id);
            return Ok();
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public ProductModel GetDatabyID(string id)
        {
            return _productBusiness.GetDatabyID(id);
        }
        [Route("get-all/{page_index}/{page_size}")]
        [HttpGet]
        public IEnumerable<ProductModel> GetDatabAll(int page_index, int page_size)
        {
            long total = 0;
            var kq = _productBusiness.GetDataAll(page_index, page_size, out total);
            foreach (var item in kq)
            {
                item.total = total;
            }
            return kq;
        }
        [Route("get-new")]
        [HttpGet]
        public IEnumerable<ProductModel> GetDataNew()
        {
            return _productBusiness.GetDataNew();
        }

        [Route("get-sptuongtu/{id}")]
        [HttpGet]
        public IEnumerable<ProductModel> GetSPTuongTu(int id)
        {
            return _productBusiness.GetSPTuongTu(id);
        }

        [Route("search-product")]
        [HttpPost]
        public ReponseModel TK([FromBody] Dictionary<string, object> formData)
        {
            var response = new ReponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string product_name = "";
                if (formData.Keys.Contains("product_name") && !string.IsNullOrEmpty(Convert.ToString(formData["product_name"]))) { product_name = Convert.ToString(formData["product_name"]); }
                decimal product_price = 0;
                if (formData.Keys.Contains("product_price") && (formData["product_price"]) != null) { product_price = Convert.ToDecimal(formData["product_price"]); }
                long total = 0;
                var data = _productBusiness.TK(page, pageSize, out total, product_name, product_price);
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
        [Route("search")]
        [HttpPost]
        public ReponseModel Search([FromBody] Dictionary<string, object> formData)
        {
            var response = new ReponseModel();
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string category_id = "";
                if (formData.Keys.Contains("category_id") && !string.IsNullOrEmpty(Convert.ToString(formData["category_id"]))) { category_id = Convert.ToString(formData["category_id"]); }
                long total = 0;
                var data = _productBusiness.Search(page, pageSize, out total, category_id);
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
