using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceHistory.Business.Abstract;
using PriceHistory.Entities;

namespace PriceHistory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private  IPriceHistoryService _priceHistoryService;

        public ProductController(IPriceHistoryService priceHistoryService)
        {
            _priceHistoryService = priceHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> getProducts()
        {

            var products = await _priceHistoryService.getProducts();
            return Ok(products);//200+data
        }
        [HttpGet]
        public async Task<IActionResult> getProduct(int id)
        {
            var product = await _priceHistoryService.getProduct(id);
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
        public async Task<IActionResult> deleteProduct(int id)
        {
            if (_priceHistoryService.getProduct(id) != null)
            {
                await _priceHistoryService.deleteProduct(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> createProduct(Product product)
        {
            var newProduct = await _priceHistoryService.createProduct(product);
            return Ok(newProduct);
        }
        public async Task<IActionResult> updateProduct(Product product)
        {
            if (_priceHistoryService.getProduct(product.Id) != null)
            {

                return Ok(await _priceHistoryService.updateProduct(product)); 
            }
            return NotFound();
        }


    }
}