using CoolCrafts.WebSite.Models;
using CoolCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// Adding the controller to fetch the JSON data to be connected to the front page view 
// Link: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0
namespace CoolCrafts.WebSite.Controllers
{
    /*
    1. Any custom controller we create in our example "ProductsController",
    must extend the built-in one "ControllerBase"
    
    2. The Microsoft.AspNetCore.Mvc namespace provides attributes 
    These attribute are needed to configure the behavior of web API controllers and action methods:
    
    - [Route] => specifies URL pattern for a specific controller or action.
    - [ApiController] => makes/Adds many features like:
        > Attribute routing requirement
        > Automatic HTTP 400 responses
    Link: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-7.0#apicontroller-attribute
    
    By default, ASP.NET will generate the following attributes: 
    > [Route("api/[controller]")]
    > [ApiController]
    */

    /*
    NOTE:
    =====
    > [Route("api/[controller]")] <= Default Generated Code => api/products
    > for simplicity, we can just make it /[controller] => /products
    
    Reason:
    Because our controller name is "ProductsController" which is "Products" + "Controller",
    ASP will assume that the route [controller] is /products

    > modify it to any route (url) we need:
    */
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
        we need to import "using" them: using CoolCrafts.WebSite.Services;
        */
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        /*
        Adding the property for accessing the "productService" (no need for set)

        NOTE:
        Remember that in ProductList.cshtml.cs file we have the code:
        
        public void OnGet()
        {

        }

        for getting the page contents, so here also just need the getter
        */
        public JsonFileProductService ProductService { get; }

        /*
        1.Adding another method that returns the list of products
        By convention the API request method is named "Get()"
        or starts with Get...

        2.Adding the attribute: [HttpGet]
        when we type Http => VS IDE will give us the type of the HTTP request 
        which is "Get" in our case
        

        NOTES:
        ======
        1. Notice that the attribute [HttpGet] in this example is optional!
        Because WEB API supports naming convention,
        since our method name is Get or starts with Get
        and we only have one "Get" method in this controller
        ASP will assume that we are using HTTP Get Request
        
        2. We are using the class "Product" => <Product>
        so we need to import (using) it from the Models folder:
        VS IDE will suggest: using CoolCrafts.WebSite.Models;
        */

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts(); ;
        }

        /*
        IMPORTANT NOTE:
        ===============
        Problem:
        In case if you have more than one get method and all have this attribute:
        [HttpGet]
        You will receive an error as ASP will be confused which method to call
        for the HTTP Get Request?

        Solution:
        We need to add the routing url string.

        Solution Examples:
        1. In one line:
        [HttpGet("GetAllUsers")]
        
        2. In two lines:
        [HttpGet]
        [Route("GetAllUsers"]
        */
    } // class
} // namespace
