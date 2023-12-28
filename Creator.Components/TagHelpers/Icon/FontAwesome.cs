/*
    @Date                 : 25.02.2023
    @Author               : Stein Lundbeck
    @Description          : null
*/

using LundbeckConsulting.Components.Core.Components;
using LundbeckConsulting.Components.Core.Components.Repos;
using LundbeckConsulting.Components.Core.Components.TagHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Creator.Components.TagHelpers.Icon
{
    /// <summary>
    /// Displays new icons from Font Awesome 6
    /// </summary>
    [HtmlTargetElement("fa", Attributes = "icon", TagStructure = TagStructure.WithoutEndTag)]
    public sealed class FontAwesomeTagHelper : TagHelperCustom, ITagHelperCustom, ITagHelper
    {
        public FontAwesomeTagHelper(IWebHostEnvironment environment, ITagHelperRepo helperRepo, IHtmlHelper htmlHelper) : base(environment, helperRepo, htmlHelper)
        {

        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.PreProcessAsync(context, output);

            if (this.Icon != FontAwesomeIcon.None)
            {
                ITagBuilderCustom tag = new TagBuilderCustom("i");
                tag.AddAttribute("class", $"fa-{this.IconStyle.ToString().ToLower()} fa-{this.Icon.ToString().ToLower()}");

                this.AddContent((TagBuilderCustom)tag);
            }

            await base.ProcessAsync();
        }

        /// <summary>
        /// Name of the icon to use with Type equal FontAwesome
        /// </summary>
        [HtmlAttributeName("icon")]
        public FontAwesomeIcon Icon { get; set; } = FontAwesomeIcon.None;

        /// <summary>
        /// Style type
        /// </summary>
        [HtmlAttributeName("icon-style")]
        public FontAwesomeStyle IconStyle { get; set; } = FontAwesomeStyle.Regular;
    }

    public enum FontAwesomeStyle
    {
        Solid,
        Regular,
        Light,
        Thing,
        DuoTone
    }
}
