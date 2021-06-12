using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Product.Data;
using Product.Data.Entities;
using Product.Data.Models;

namespace Product.Core
{
    public interface IProductService
    {  
        //Task<DTOProductDetails> getProdById(string Id);
        Task<ServiceResult.ServiceResultList<DTOProductDetails>> GetProductList(int page, int pageSize, string searchText = null);
    }
   
}
