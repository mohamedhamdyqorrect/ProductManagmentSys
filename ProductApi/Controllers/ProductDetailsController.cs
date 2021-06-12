using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Product.Core;
using ProductApi.Models;
//using Product.Core;
//using ProductApi.Controllers.Shared;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController :ControllerBase //BaseController
    {
        private readonly ProductContext _context;
       // private readonly Lazy<IProductService> _ProductService;
       
        // private IProductService productService;

        public ProductDetailsController(ProductContext context
           // , Lazy<IProductService> ProductService
            )// IProductService productService
        {
            _context = context;
           // _ProductService = ProductService;
        }
       // private IProductService ProductService => _ProductService.Value;
        // GET: api/ProductDetails
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<ProductDetail>>> GetProductDetails()
        {
            return await _context.ProductDetails.ToListAsync();
        }

        // GET: api/ProductDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetail>> GetProductDetail(int id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return productDetail;
        }
        //public async Task<IActionResult> GetTagsList( int page = 1, int pageSize = 10, string searchText = null)
        //{
        //    var result = await ProductService.GetProductList(page, pageSize,  searchText);
        //    return GetApiResponse(result, page, pageSize );
        //}
        // GET: api/ProductDetails/5
        // [HttpGet("/GetProductByID/{id}")]
        // [Route("getw/{id}")]
        [HttpGet("GetProductByID/{id}", Name = "GetProductByID")]
        public async Task<ActionResult<ProductDetail>> GetProductByID(int id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);

            if (productDetail == null)
            {
                return NotFound();
            }

            return productDetail;
        }
        //// GET: api/ProductDetails/5
        //[HttpGet("{id}")]
        //[Route("getw")]
        //public async Task<ActionResult<ProductDetail>> GetSProductDetail(int id)
        //{
        //    var productDetail = await productService.getProdById(id.ToString());

        //    if (productDetail == null)
        //    {
        //        return NotFound();
        //    }

        //    return productDetail;
        //}

        // PUT: api/ProductDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductDetail(int id, ProductDetail productDetail)
        {
            if (id != productDetail.ProductDetailId)
            {
                return BadRequest();
            }

            _context.Entry(productDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ProductDetail>> PostProductDetail(ProductDetail productDetail)
        {
            _context.ProductDetails.Add(productDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDetail", new { id = productDetail.ProductDetailId }, productDetail);
        }

        // DELETE: api/ProductDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDetail>> DeleteProductDetail(int id)
        {
            var productDetail = await _context.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }

            _context.ProductDetails.Remove(productDetail);
            await _context.SaveChangesAsync();

            return productDetail;
        }

        private bool ProductDetailExists(int id)
        {
            return _context.ProductDetails.Any(e => e.ProductDetailId == id);
        }
    }
}
