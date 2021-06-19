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
    public class PriceHistoryController : ControllerBase
    {
        private IProductService _productService;
        private IPriceHistoryService _priceHistoryService;

        public PriceHistoryController(IProductService productService, IPriceHistoryService priceHistoryService)
        {
            _productService = productService;
            _priceHistoryService = priceHistoryService;

        }



        [HttpGet]
        [Route("savePriceHistory")]
        public async Task<IActionResult> savePriceHistory()
        {

            var products = await _productService.getProducts();
            foreach (var item in products)
            {
                if (item.isApprove == true)
                {
                    PriceHistories priceHistories = new PriceHistories();

                    var document = new HtmlWeb().Load(item.linkUrl);
                    var price = document.DocumentNode.SelectSingleNode("//span[contains(@class,'prc-dsc')]");
                    if (price != null)
                    {
                        var brand= document.DocumentNode.SelectNodes("//h1[contains(@class,'pr-new-br')]");
                        string brandParse = "";
                        foreach (var node in brand)
                        {
                            brandParse=node.ChildNodes[0].InnerText;
                        }
                        //string brandParse = brand.InnerText;
                        item.brand = brandParse;
                        await _productService.updateProduct(item);
                        //toDo item.resim="item.innertext"
                        string yeniPrice = price.InnerText;
                        int pos = yeniPrice.IndexOf(" ");
                        yeniPrice = yeniPrice.Substring(0, pos);
                        priceHistories.ProductId = item.Id;
                        priceHistories.date = DateTime.Now;
                        priceHistories.price = Convert.ToDouble(yeniPrice);

                    }
                    else
                    {
                        price = document.DocumentNode.SelectSingleNode("//span[contains(@class,'prc-slg')]");
                        string yeniPrice = price.InnerText;
                        int pos = yeniPrice.IndexOf(" ");
                        yeniPrice = yeniPrice.Substring(0, pos);
                        priceHistories.ProductId = item.Id;
                        priceHistories.date = DateTime.Now;
                        priceHistories.price = Convert.ToDouble(yeniPrice);

                    }

                    await _priceHistoryService.savePriceHistory(priceHistories);
                }
            }
            return Ok("Kaydetme işlemi başarıyla gerçekleşti");//200+data
        }

    }
}