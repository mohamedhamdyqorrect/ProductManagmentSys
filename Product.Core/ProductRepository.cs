using System;
using System.Collections.Generic;
using System.Text;
using Product.Data.Entities;

using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Product.Data.Models;

namespace Product.Core
{
    public class ProductRepository
    {
        private readonly ProductContext _context;
        public async Task<PagedListWithCountsResult<ProductDetail>> GetProductsList(int page, int pageSize, string searchText = null)
        {
            var data = _context.ProductDetails.AsQueryable();
            // apply searchTextFilter
            if (!string.IsNullOrEmpty(searchText))
                data = data.Where(a => a.Title.ToLower().Trim().Contains(searchText.ToLower().Trim()));

            //total count
            var count = await data.LongCountAsync();
           

            //apply pagination
            var result = await data
            .OrderBy(x => x.Title)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            return new PagedListWithCountsResult<ProductDetail>(result, count);
        }

    }
}
