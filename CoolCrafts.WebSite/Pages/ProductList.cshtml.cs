using CoolCrafts.WebSite.Models;
using CoolCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoolCrafts.WebSite.Pages
{
    public class ProductListModel : PageModel
    {
        // Below is the default content: just empty OnGet() method:
        /*
        public void OnGet()
        {
        }
        */
        // Adding the public service property of type "JsonFileProductService":
        public JsonFileProductService ProductService;

        /*
         Since the ProductList.cshtml will list the products of the json file,
        and it has the code @model ProductListModel which should have the list 

        Remember that we declared the products as IEnumerable 
        because it represents any list/collection in C#:

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

        Reason: 
        Because this property "Products" is defined as a non-nullable reference type
        It has to be instantiate it when it's created.
        But since we don't want to instantiate any value for this property as the razor page .cs file will do the job,
        The compiler tries to warn us that we might a have a null value for a non-nullable property!
        So in such case, we can use one of the following solutions:

        Solution#1: 
        ***********
        adding this syntax after the closing brace:
        = Enumerable.Empty<Product>();

        Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8618)#nonnullable-reference-not-initialized


        Solution#2: 
        ***********
        adding this special syntax of C# called "Null safety" after the closing brace:
        = default!;

        Link: https://learn.microsoft.com/en-us/training/modules/csharp-null-safety/
        */
        public IEnumerable<Product> Products { get; private set; } = default!;


        /*
        The constructor uses dependency injection to add the 
        "JsonFileProductService" to the page.

        Modify the constructor by adding our custom services like the JSON file to read:
        with the parameter named "productService" for example

        and we can add more services as we need...
        */

        public ProductListModel(ILogger<IndexModel> logger, JsonFileProductService productService)
        {
            /*
             Setting our ProductService:
             */
            ProductService = productService;
        }

        /*
        When a GET request is made for the page (when a razor page is requested), 
        The "OnGet()" method will be called/run before rendering the page
        
        The OnGet method returns void but set the "Products"

        What to do when getting into this page:
        - retrieve the products
        */
        public void OnGet()
        {
            /*
            Calling the product service: 

            Getting the property "Products" that we created above 
            and instantiate it to (fill it with) the service call:

            Notice the following:
            1- "ProductService" is an object of type "JsonFileProductService" class
            2- "JsonFileProductService" class has a public method "GetProducts()"
            3- accessing "GetProducts()" method that returns "IEnumerable<Product>"
            4- assign the returned value of type "IEnumerable<Product>" to "Products" property
            */
            Products = ProductService.GetProducts();
        }
    } // class
} // namespace
