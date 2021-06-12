using Product.Data.Entities;
using Product.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Core
{
    public class ProductService:IProductService
    {
        private readonly Lazy<IProductRepository> _ProductRepository;
        public ProductService(Lazy<IProductRepository> ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }
        private IProductRepository ProductRepository => _ProductRepository.Value;
        public async Task<ServiceResult.ServiceResultList<DTOProductDetails>> GetProductList(int page, int pageSize, string searchText = null){


            var result = await ProductRepository.GetProductsList(page, pageSize, searchText);
            var count = result.TotalCount;
            var createdLst =  result.List.Select(x => new DTOProductDetails(){ Title=x.Title,UnitPrice=x.UnitPrice}).ToList();
            return new ServiceResult.ServiceResultList<DTOProductDetails>()
            {
                Model = createdLst,
                Count = count
            };
        }
        //public async Task<DTOProductDetails> getProdById(string id) {
        //    DTOProductDetails s = new DTOProductDetails { };

        //    var productDetail = await _context.ProductDetails.FindAsync(id);

           

        //    return productDetail;
        //}
    }
}
