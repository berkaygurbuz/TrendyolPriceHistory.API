using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceHistory.Business.Abstract;
using PriceHistory.Entities;

namespace PriceHistory.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private  IProductService _productService;

        public ProductController(IProductService priceHistoryService)
        {
            _productService = priceHistoryService;
        }

        [HttpGet]
        [Route("getAllProducts")]
        public async Task<IActionResult> getProducts()
        {

            var products = await _productService.getProducts();
            foreach (var item in products)
            {
                var document = new HtmlWeb().Load(item.name);
                var price = document.DocumentNode.SelectSingleNode("//span[contains(@class,'prc-dsc')]");
                Product yeni = new Product();
                string yeniPrice = price.InnerText;
                int pos = yeniPrice.IndexOf(" ");
                yeniPrice = yeniPrice.Substring(0, pos);
                yeni.name = "yeni";
                yeni.price = float.Parse(yeniPrice);
                var newProduct = await _productService.createProduct(yeni);

            }
            return Ok(products);//200+data
        }

        public async Task<IActionResult> getParseHtml()
        {
            var products = await _productService.getProducts();
            foreach (var item in products)
            {
                var document = new HtmlWeb().Load(item.name);
                dynamic price = document.DocumentNode.SelectSingleNode("//span[contains(@class,'prc-dsc')]");
                Product yeni = new Product();

                yeni.name = "yeni";
                yeni.price = float.Parse(price);
                var newProduct = await _productService.createProduct(price);

            }
            //ViewBag.myTitle = price.InnerText;
            return Ok("hello");
        }
        [HttpGet]
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
        public async Task<IActionResult> createProduct(Product product)
        {
            var newProduct = await _productService.createProduct(product);
            return Ok(newProduct);
        }
        public async Task<IActionResult> updateProduct(Product product)
        {
            if (_productService.getProduct(product.Id) != null)
            {

                return Ok(await _productService.updateProduct(product)); 
            }
            return NotFound();
        }


    }
}