/*
    @Date           : 25.09.2019
    @Author         : Stein Lundbeck
*/

using SteinLundbeck.Components.Core.Components;
using SteinLundbeck.Components.Core.Repos;
using SteinLundbeck.Components.Core.TagHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Creator.Components.TagHelpers.Icon
{
    /// <summary>
    /// Displays icons from old and new FontAwesome, Friconix, Captain Icon and DevIcons
    /// </summary>
    [HtmlTargetElement("icon", Attributes = "awesome", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("icon", Attributes = "awesome-six", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("icon", Attributes = "material", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("icon", Attributes = "cssgg", TagStructure = TagStructure.WithoutEndTag)]
    [HtmlTargetElement("icon", Attributes = "ionicons", TagStructure = TagStructure.WithoutEndTag)]
    public sealed class IconTagHelper : TagHelperCustom, ITagHelperCustom
    {
        private readonly IIconHelper _iconHelper = new IconHelper();

        public IconTagHelper(IWebHostEnvironment environment, ITagHelperRepo helperRepo, IHtmlHelper htmlHelper) : base(environment, helperRepo, htmlHelper)
        {

        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.PreProcessAsync(context, output);
            
            if (this.AwesomeSymbol != FontAwesomeIcon.None)
            {
                AddContent(_iconHelper.GetFontAwesomeTag(this.AwesomeSymbol));
            }
            else if (this.FontAwesomeSixIcon != FontAwesomeSixIcon.None)
            {
                AddContent((TagBuilderCustom)_iconHelper.GetFontAwesomeSixTag(this.FontAwesomeSixIcon));
            }
            else if (this.GoogleFontsIcons != GoogleFontsIcon.None)
            {
                AddContent((TagBuilderCustom)_iconHelper.GetGoogleFontsIconsTag(this.GoogleFontsIcons));
            }
            else if (this.CssGG != CssGGIcons.None) 
            {
                AddContent((TagBuilderCustom)_iconHelper.GetCssGGIconTag(this.CssGG));
            }
            else if (this.Ionicons != Ionicons.None)
            {
                AddContent((TagBuilderCustom)_iconHelper.GetIoniconsTag(this.Ionicons, this.IoniconsStyle));
            }
            else
            {
                throw new ArgumentException("No symbol property is set");
            }

            await base.ProcessAsync();
        }

        #region Properties
        /// <summary>
        /// Font Awesome
        /// </summary>
        [HtmlAttributeName("awesome")]
        public FontAwesomeIcon AwesomeSymbol { get; set; } = FontAwesomeIcon.None;

        /// <summary>
        /// Font Awesome Six
        /// </summary>
        [HtmlAttributeName("awesome-six")]
        public FontAwesomeSixIcon FontAwesomeSixIcon { get; set; } = FontAwesomeSixIcon.None;

        /// <summary>
        /// Google Material Symbols
        /// </summary>
        [HtmlAttributeName("material")]
        public GoogleFontsIcon GoogleFontsIcons { get; set; } = GoogleFontsIcon.None;

        /// <summary>
        /// CSS GG
        /// </summary>
        [HtmlAttributeName("cssgg")]
        public CssGGIcons CssGG { get; set; } = CssGGIcons.None;

        [HtmlAttributeName("ionicons")]
        public Ionicons Ionicons { get; set; } = Ionicons.None;

        [HtmlAttributeName("ionicons-style")]
        public IoniconsStyle IoniconsStyle { get; set; }
        #endregion
    }
}
