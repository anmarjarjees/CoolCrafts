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
        The built-in Model - The default constructor:
        passing the service for logging from the interface "ILogger"
        could be logging to Azure or any cloud services
        */

        // The default constructor: 
        public IndexModel(ILogger<IndexModel> logger)
        {
            // from the boilerplate (doesn't do anything in our current example):
            _logger = logger; 
        }

        // Below is the default content: just empty OnGet() method:
        /*
        public void OnGet()
        {
        }
        */

    } // class
} // namespace