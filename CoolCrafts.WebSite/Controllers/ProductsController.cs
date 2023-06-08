using CoolCrafts.WebSite.Models;
using CoolCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// Adding the controller to fetch the JSON data to be connected to the front page view 
// Link: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0
namespace CoolCrafts.WebSite.Controllers
{
    /*
    The Microsoft.AspNetCore.Mvc namespace provides attributes 
    that can be used to configure the behavior of web API controllers and action methods:
    
    - [Route] => specifies URL pattern for a controller or action.
    - [ApiController] => makes attribute routing a requirement.
    
    By default, ASP.NET will generate: [Route("api/[controller]")]
    */
    // [Route("api/[controller]")]
    // modify it to any route (url) we need:
    [Route("[controller]")]
    [ApiController]
    /*
    Using Controller-Based API
    Inherits from "Controller-Base" abstract class
    Link: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-7.0
     */
    public class ProductsController : ControllerBase
    {
        // Adding our custom code below:

        // Adding a constructor for our class "ProductsController":
        /*
        we have the service JsonFileProductsService.cs 
        which where all our products come from

        so we can pass the "JsonFileProductService" as an argument to the constructor:
        we need to import "using" them
         */
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        /*
        Adding the property for accessing the "productService" (no need for set)
        remember that in index.cshtml.cs file we added the code:
        
        public void OnGet()
        {

        }
        */
        public JsonFileProductService ProductService { get; }

        /*
        Adding another method that returns the list of products
        adding the attribute: HttpGet

        NOTE:
        we are using the class "Product" => <Product>
        so we need to import (using) it from the Models folder:
        VSIDE will suggest: using CoolCrafts.WebSite.Models;

        */

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts(); ;
        }
    } // class
} // namespace
