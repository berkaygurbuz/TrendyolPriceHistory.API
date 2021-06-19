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

                        if (item.brand == null)
                        {

                        //getting brand and model
                        var brand= document.DocumentNode.SelectNodes("//h1[contains(@class,'pr-new-br')]");
                        string brandParse = "";
                        string modelParse = "";
                        foreach (var node in brand)
                        {
                            brandParse=node.ChildNodes[0].InnerText;
                            modelParse = node.ChildNodes[1].InnerText;
                        }

                        //getting gender
                        var gender = document.DocumentNode.SelectNodes("//div[contains(@class,'breadcrumb')]");
                        string genderParse = "";
                        string categoryParse = "";
                        foreach(var node in gender)
                        {
                            genderParse = node.ChildNodes[1].FirstChild.InnerText;
                            categoryParse = node.ChildNodes[3].FirstChild.InnerText;
                            
                        }
                        item.category = categoryParse;
                        item.gender = genderParse;
                        //getting image
                        var image = document.DocumentNode.SelectNodes("//div[contains(@style,'position:relative')]");
                        var imageParse = "";
                        foreach (var node in image)
                        {
                            var myImage= node.FirstChild.Attributes.Where(x => x.Name == "src").FirstOrDefault();
                            imageParse = myImage.Value;
                        }
                        item.imageUrl = imageParse;
                        item.brand = brandParse;
                        item.model = modelParse;
                        }
                        //toDo item.resim="item.innertext"
                        string yeniPrice = price.InnerText;
                        int pos = yeniPrice.IndexOf(" ");
                        yeniPrice = yeniPrice.Substring(0, pos);
                        
                        item.price =Convert.ToDouble(yeniPrice);
                        await _productService.updateProduct(item);


                        priceHistories.ProductId = item.Id;
                        priceHistories.date = DateTime.Now;
                        priceHistories.price = Convert.ToDouble(yeniPrice);

                    }
                    else
                    {
                        price = document.DocumentNode.SelectSingleNode("//span[contains(@class,'prc-slg')]");

                        if (item.brand == null)
                        {
                            //getting brand and model
                            var brand = document.DocumentNode.SelectNodes("//h1[contains(@class,'pr-new-br')]");
                            string brandParse = "";
                            string modelParse = "";
                            foreach (var node in brand)
                            {
                                brandParse = node.ChildNodes[0].InnerText;
                                modelParse = node.ChildNodes[1].InnerText;
                            }

                            //getting gender
                            var gender = document.DocumentNode.SelectNodes("//div[contains(@class,'breadcrumb')]");
                            string genderParse = "";
                            string categoryParse = "";
                            foreach (var node in gender)
                            {
                                genderParse = node.ChildNodes[1].FirstChild.InnerText;
                                categoryParse = node.ChildNodes[3].FirstChild.InnerText;

                            }
                            item.category = categoryParse;
                            item.gender = genderParse;
                            //getting image
                            var image = document.DocumentNode.SelectNodes("//div[contains(@style,'position:relative')]");
                            var imageParse = "";
                            foreach (var node in image)
                            {
                                var myImage = node.FirstChild.Attributes.Where(x => x.Name == "src").FirstOrDefault();
                                imageParse = myImage.Value;
                            }
                            item.imageUrl = imageParse;
                            item.brand = brandParse;
                            item.model = modelParse;
                        }
                        string yeniPrice = price.InnerText;
                        int pos = yeniPrice.IndexOf(" ");
                        yeniPrice = yeniPrice.Substring(0, pos);

                        item.price = Convert.ToDouble(yeniPrice);
                        await _productService.updateProduct(item);
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