using CoolCrafts.WebSite.Models;
using System.Text.Json;

/*
 Copying the code from the GitHub repo:
https://github.com/dotnet-presentations/ContosoCrafts/blob/master/src/Services/JsonFileProductService.cs
 */
namespace CoolCrafts.WebSite.Services
{
    public class JsonFileProductService
    {
        /*
        the class constructor: 
        IWebHostEnvironment interface type: 
        the hosting environment for running our ASP application
        
        like a Console app! ASP.NET is acting like a Console Application
        having the Main() method to launch the app
        */
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            /*
             WebHostEnvironment for grabbing the product.json file 
            from "data" folder which is inside the "wwwroot" folder

            instead of hard coding this: wwwroot => data => product.json

            ASP.NET will just hand the path for us!
             */
            WebHostEnvironment = webHostEnvironment;
        }

        /*
        WebHostEnvironment Property:
        ---------------------------
        Just keep/get the WebHostEnvironment for getting the data from the JSON file
        
        Again instead of hard coding this: wwwroot => data => product.json
         */
        public IWebHostEnvironment WebHostEnvironment { get; }

        /*
        JsonFileName Property:
        ---------------------
        We make a property named "JsonFileName" to return the path for our JSON file
        
        The property "JsonFileName" will retrieve the location
        to the variable "WebHostEnvironment" using the short version
        
        WebRootPath property will take care of changing the path dynamically
        based on the location for our data source in any drive in computer or platform

        Finally combining the three parts together:
        - WebHostEnvironment => your full local project path or the online url
        - WebRootPath => wwwroot
        - data => the data folder
        - "products.json" => the JSON file inside "data"
         */
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

        
        // NOTE: The long one: Normal Property Block:
        /*
        private string JsonFileName
        {
            get { 
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); 
            }
        }*/


        /*
        Getting/retrieving the data (products) from the JSON file:
        adding a public method "GetProducts()"

        IEnumerable => Is the root "interface" for all the lists/collections that we have in CS
        so any collection that we can loop over using foreach is coming from "IEnumerable"
        IEnumerable => refers to any type/kind of these: array, list, collections,...
        */
        public IEnumerable<Product> GetProducts()
        {
            // (File I/O) => Open the text file 
            // C:\My-VS2022-Projects\ASP.NET-Projects\CoolCrafts\CoolCrafts.WebSite\data
            using var jsonFileReader = File.OpenText(JsonFileName);

            // With JSON Serialize (TO JSON) and Deserialize (FROM JSON)
            /*
            > first parameter: returning an array of type "Product" by reading the JSON file to the end
            > second parameter (optional): for ignoring the upper/lower case

            Using "Deserialize" to return a normal object from the JSON object 
            The new returned object will be an array of products:
             */
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                })!;
            /*
            NOTE: We will receive a warning if we omit the symbol "!":
            CS8603 - Possible null reference return.
            
            Solution: add the null forgiving operator, ! to the right-hand side "!"
            Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8603)#possible-null-assigned-to-a-nonnullable-reference
             */
        }



        // Another code for AddRating for the final part:
        /*
        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            if (products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = products.First(x => x.Id == productId).Ratings.ToList();
                
                ratings.Add(rating);
                
                products.First(x => x.Id == productId).Ratings = ratings.ToArray();
            }

            using var outputStream = File.OpenWrite(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<Product>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                products
            );
        }
        */
    }
}