/*
The namespace has .Models to refer to the current folder "Models" 
*/
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CoolCrafts.WebSite.Models
{
    public class Product
    {
        /*
         * Marking properties for each item in the JSON file:
         * id, maker, img, url, title, description
         * 
         * The CS class that represents our data
         */

        // type prop then TAB (keep taping for modifying):
        public string? Id { get; set; }
        /*
         public string Id { get; set; }
        warning about Non-nullable property
         */
        public string? Maker { get; set; }

        /* 
         * Note: the property name is "Image" while the property name is "img" in JSON file
         * we need to map the cs file that represents the data with the JSON file
         * > we can use JSON Property as an attribute on the top of the property "Image"
         * 
         * A [DataType] attribute that specifies the type of data in the ReleaseDate property. With this attribute:
         * 
         * Attributes like a posted note that attached to a property
         * CTRL+CLICK = To check this attribute, two things to consider:
         * - namespace System.Text.Json.Serialization => will be added by VS IDE automatically
         * - JsonPropertyNameAttribute(string name) => it needs argument for the name parameter:
         * 
         * We need to pass the text "img" to map it with the img property of the JSON file
         */

        [JsonPropertyName("img")]
        public string? Image { get; set; }
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int[]? Ratings { get; set; }

        /*
         * overriding the ToString() method for every cs class
         * to print a user-friendly message
         *   // Link: https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to?pivots=dotnet-8-0
         */

        // We can use the full version:
        /*        
        public override string ToString()
        {
            // We can have a JSON representation of a product:
            return JsonSerializer.Serialize<Product>(this);
        }
        */

        /*
        JsonSerializer: static partial class:
        *************************************
        Provides functionality to serialize objects or value types to JSON 
        and deserialize JSON into objects or value types.

        partial: 
        Partial type definitions allow for the definition of 
        a class, struct, interface, or record to be split into multiple files.
        Link: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/partial-type

        It is possible to split the definition of a class, a struct, an interface 
        or a method over two or more source files. 
        Each source file contains a section of the type or method definition, 
        and all parts are combined when the application is compiled.
         */
        // Or the short version (the arrow) Rocket Ship:
        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    } // class
} // namespace
