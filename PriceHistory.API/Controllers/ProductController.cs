using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceHistory.Business.Abstract;
using PriceHistory.DataAcces;
using PriceHistory.Entities;

namespace PriceHistory.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService priceHistoryService)
        {
            _productService = priceHistoryService;
        }

        [HttpGet]
        [Route("getProductSearch")]
        public async Task<IActionResult> getProductSearch(string search)
        {
            return Ok(await _productService.getProductSearch(search));
        }

        [HttpGet]
        [Route("getProductBySearch")]
        public async Task<IActionResult> getProductBySearch(string search)
        {
            var product=await _productService.getProductBySearch(search);
            return Ok(product);
        }

        [HttpGet]
        [Route("getFilterByCategoryAndGender")]
        public async Task<IActionResult> getFilterByCategoryAndGender(string category,string gender)
        {
            return Ok(await _productService.getFilterByCategoryAndGender(category, gender));
        }

        [HttpGet]
        [Route("getByPage/{page}")]
        public async Task<IActionResult> getByPage(int page)
        {
            using (var priceHistoryDbContext = new PriceHistoryDbContext())
            {
                var product= priceHistoryDbContext.Products.ToList().Skip(page*10).Take(10).ToList();
                return Ok(product);
            }

        }

        [HttpGet]
        [Route("getRequests")]
        public async Task<IActionResult> getRequests()
        {
            var request = await _productService.getRequests();
            return Ok(request); //200+data
        }

        [HttpGet]
        [Route("getAllProducts")]
        public async Task<IActionResult> getProducts()
        {

            var products = await _productService.getProducts();
            return Ok(products);//200+data
        }

        [HttpGet]
        [Route("getProduct")]
        public async Task<IActionResult> getProduct(int id)
        {
            var product = await _productService.getProduct(id);
            if (product != null)
            {
                return Ok(product);//200+data
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("deleteById")]
        public async Task<IActionResult> deleteProduct(int id)
        {
            if (_productService.getProduct(id) != null)
            {
                await _productService.deleteProduct(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("createProduct")]
        public async Task<IActionResult> createProduct(Product product)
        {
            var newProduct = await _productService.createProduct(product);
            return Ok(newProduct);
        }
        [HttpPut]
        [Route("updateProduct")]
        public async Task<IActionResult> updateProduct([FromBody]Product product)
        {
            if (_productService.getProduct(product.Id) != null)
            {

                return Ok(await _productService.updateProduct(product));
            }
            return NotFound();
        }

        [HttpPut]
        [Route("acceptRequest/{id}")]
        public async Task<IActionResult> acceptRequest(int id)
        {
            await _productService.acceptRequest(id);
            return Ok();
        }
    }
}