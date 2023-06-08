using CoolCrafts.WebSite.Models;
using CoolCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolCrafts.WebSite.Pages
{
    /*
    The "PageModel" abstract class that represents its corresponding .cshtml page
    Razor Pages are derived from PageModel. 
    By convention, the PageModel derived class is named PageNameModel. 
    For example, the Index page is named IndexModel.
     */
    public class IndexModel : PageModel
    {
        /*
        Logging:
        ASP.NET Core supports a logging API that works with a variety 
        of built-in and third-party logging providers. 
        Link: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-7.0&tabs=windows#logging
         */
        private readonly ILogger<IndexModel> _logger;

        /*
         * The built-in Model - The default constructor:
        passing the service for logging from the interface "ILogger"
        could be logging to Azure or any cloud services
        */

        /*  public IndexModel(ILogger<IndexModel> logger)
          {
              _logger = logger;
        }*/


        // Adding the public service property:
        public JsonFileProductService ProductService;
        /*
         Since the Index.cshtml will list the products of the json file,
        and it has the code @model IndexModel which should have the list 

        Remember that we declared the products as IEnumerable because it represents any list/collection:

        Adding the code "IEnumerable<Product>" will show an error:
        namespace "Product" cannot be found!

        Click "Show potential fixes" to add the following namespaces:
        - using CoolCrafts.WebSite.Models;
        - using CoolCrafts.WebSite.Services;

        Naming the property "Products" that we need to:
        - get them => get
        - private set to be set by the class itself to avoid messing up our products
         */

        /*
        IMPORTANT NOTE:
        This warning will occur: Warning CS8618	Non-nullable property 'Products'
        'Products' must contain a non-null value when exiting constructor. 
        Consider declaring the property as nullable.	

        Solution adding this syntax:
        = Enumerable.Empty<Product>();

        Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8618)#nonnullable-reference-not-initialized
        */
        public IEnumerable<Product> Products { get; private set; } = Enumerable.Empty<Product>();




        /*
        The constructor uses dependency injection to add the 
        "JsonFileProductService" to the page.

        Modify the constructor by adding our custom services like the JSON file to read:
        with the parameter named "productService" for example

        and we can add more services as we need...
        */

        public IndexModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            _logger = logger;
            /*
             Setting our ProductService
             */
            ProductService = productService;
        }

        /*
        When a GET request is made for the page, 
        the  OnGet returns void but set the "Products"

        What to do when getting into this page:
        - retrieve the products
        */
        public void OnGet()
        {
            /*
            Calling the product service: 
            */
            Products = ProductService.GetProducts();
        }
    } // class
} // namespace