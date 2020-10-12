using System;
using System.Collections.Generic;
using System.Text;
using Model;


namespace DAL
{
    public partial interface IItemGroupRepository
    {
        List<ItemGroupModel> GetData();
    }
}
