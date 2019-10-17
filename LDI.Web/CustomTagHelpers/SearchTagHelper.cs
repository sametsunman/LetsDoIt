using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDI.Web.CustomTagHelpers
{
    [HtmlTargetElement("search-box")]
    public class SearchTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "form";
            output.Attributes.Add("method","post");
            output.Attributes.Add("action", "/video/search");
            output.TagMode = TagMode.StartTagAndEndTag;

            StringBuilder sb = new StringBuilder();
            sb.Append("<input type='search' placeholder='Ara' name='search' id='search' />");
            sb.Append("<button><i class='fa fa-search' aria-hidden='true'></i></button>");
            output.Content.SetHtmlContent(sb.ToString());
            base.Process(context, output);
        }

    }

    [HtmlTargetElement("custom-search-box")]
    public class CustomSearchTagHelper : SearchTagHelper
    {
        [HtmlAttributeName]
        public int value { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class","form-group row"+ value);

            base.Process(context, output);
        }


    }

}
