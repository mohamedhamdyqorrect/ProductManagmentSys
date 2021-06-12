using Product.Data.Entities;
using Product.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core
{
    public interface IProductRepository
    {
        Task<PagedListWithCountsResult<DTOProductDetails>> GetProductsList(int page, int pageSize, string searchText = null);
    }
}
