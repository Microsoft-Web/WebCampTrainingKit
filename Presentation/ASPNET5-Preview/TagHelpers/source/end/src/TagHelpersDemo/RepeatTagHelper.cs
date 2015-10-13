using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpersDemo
{
    using System.Threading.Tasks;
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    public class RepeatTagHelper : TagHelper
    {
        public int Count { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            for (int i = 0; i < Count; i++)
            {
                output.Content.Append(await context.GetChildContentAsync());
            }

            output.TagName = null;
        }
    }
}