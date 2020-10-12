using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryBusiness _itemGroupBusiness;
        public CategoryController(ICategoryBusiness itemGroupBusiness)
        {
            _itemGroupBusiness = itemGroupBusiness;
        }

        [Route("get-menu")]
        [HttpGet]
        public IEnumerable<CategoryModel> GetAllMenu()
        {
            return _itemGroupBusiness.GetData();
        }
    }
}
