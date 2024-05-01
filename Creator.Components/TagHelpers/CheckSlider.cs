/*
    @Date                 : 27.12.2023
    @Author               : Stein Lundbeck
    @Description          : null
*/

using SteinLundbeck.Components.Core.Components;
using SteinLundbeck.Components.Core.Repos;
using SteinLundbeck.Components.Core.TagHelpers;
using SteinLundbeck.Components.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Creator.Components.TagHelpers
{
    [HtmlTargetElement("checkslider", Attributes = "id", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CheckSlider : TagHelperCustom, ITagHelperCustom
    {
        public CheckSlider(IWebHostEnvironment environment, ITagHelperRepo helperRepo, IHtmlHelper htmlHelper) : base(environment, helperRepo, htmlHelper)
        { }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await base.PreProcessAsync(context, output);

            ITagBuilderCustom container = new TagBuilderCustom("div");
            ITagBuilderCustom label = new TagBuilderCustom("label");
            ITagBuilderCustom checkbox = new TagBuilderCustom("input");
            ITagBuilderCustom slider = new TagBuilderCustom("div");

            label.AddCssClass("switch");
            label.AddAttribute("for", this.Id);
            checkbox.AddAttribute("type", "checkbox");
            checkbox.AddAttribute("id", this.Id);
            slider.AddCssClassRange("slider", "round");
            container.AddCssClass($"checkslider-{this.ColorProfile.Lower()}");

            label.ApplyContent((TagBuilderCustom)checkbox);
            label.ApplyContent((TagBuilderCustom)slider);
            checkbox.AddAttribute("value", "true");
            container.ApplyContent((TagBuilderCustom)label);
            container.AttachBaseAttributes = false;

            AddContent(container);

            await base.ProcessAsync();
        }

        /// <summary>
        /// Color profile
        /// </summary>
        [HtmlAttributeName("color")]
        public CreatorColorProfiles ColorProfile { get; set; } = CreatorColorProfiles.Success;
    }
}
