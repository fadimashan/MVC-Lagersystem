using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace MVC_Lagersystem.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("stars")]
    public class StarsTagHelper : TagHelper
    {
        public float Rating { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {


            output.TagName = "span";
            output.AddClass("star", HtmlEncoder.Default);

            var ratingD = Rating;

            var stars = (int)ratingD / 2;
            var isHalf = ratingD % 2 == 1;

            var commons = "https://www.svgrepo.com/show/";
            //var starImg = commons + "e/e5/Full_Star_Yellow.svg";
            //var halfImg = commons + "d/d6/Half_Star_Yellow.svg";
            //var commons = "https://upload.wikimedia.org/wikipedia/commons/";
            var starImg = commons + "7320/favourite.svg";
            var halfImg = commons + "102729/half-star.svg";

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < stars; i++)
            {
                stringBuilder.Append($"<img src='{starImg}'/>");
            }
            if (isHalf) stringBuilder.Append($"<img src='{halfImg}'/>");

            output.Content.SetHtmlContent(stringBuilder.ToString());
        }

    }
}

