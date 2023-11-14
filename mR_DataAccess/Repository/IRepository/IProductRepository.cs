using Microsoft.AspNetCore.Mvc.Rendering;
using mR_DataAccess.Data;
using mR_DataAccess.Repository.IRepository;
using mR_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mR_DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);

        IEnumerable<SelectListItem> GetAllDropdownList(string obj);
    }
}
