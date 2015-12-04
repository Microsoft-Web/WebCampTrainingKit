using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using Microsoft.AspNet.Razor.TagHelpers;

namespace TagHelperDemo
{
    // You may need to install the Microsoft.AspNet.Razor.Runtime package into your project
    [HtmlTargetElement("repeat")]
    public class RepeatTagHelper : TagHelper
    {
        public int Count { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            for (int i = 0; i < Count; i++)
            {
                output.Content.Append(await output.GetChildContentAsync());
            }
        }
    }
}
