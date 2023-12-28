/*
    @Date			              : 23.06.2020
    @Author                       : Stein Lundbeck
*/

namespace Creator.Components.TagHelpers.Icon.Models
{
    public interface IIconRecordModel
    {
        /// <summary>
        /// Icon name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Prefix for FontAwesome icons
        /// </summary>
        string FontAwesomePrefix { get; set; }

        /// <summary>
        /// FontAwesome icon
        /// </summary>
        FontAwesomeIcon FontAwesomeIcon { get; set; }

        /// <summary>
        /// CSS GG icon
        /// </summary>
        CssGGIcons CssGGIcon { get; set; }

        /// <summary>
        /// New style of Font Awesome
        /// </summary>
        FontAwesomeSixIcon FontAwesomeSixIcon { get; set; }

        /// <summary>
        /// Prefix for Font Awesome 6
        /// </summary>
        FontAwesomeSixPrefix FontAwesomeSixPrefix { get; set; }

        Ionicons Ionicons { get; set; }

        /// <summary>
        /// The Font Awesome 6 prefix as string
        /// </summary>
        string FontAwesomeSixPrefixAsString { get; }

        /// <summary>
        /// Google Fonts Icons
        /// </summary>
        GoogleFontsIcon GoogleFontsIcon { get; set; }
    }

    /// <summary>
    /// Contains information about either a FontAwesome or Friconix icon
    /// </summary>
    public sealed class IconRecordModel : IIconRecordModel
    {
        /// <summary>
        /// Creates a new FontAwesome record
        /// </summary>
        /// <param name="icon">Type of icon</param>
        /// <param name="name">Name of icon</param>
        public IconRecordModel(FontAwesomeSixIcon icon, string name, FontAwesomeSixPrefix prefix = FontAwesomeSixPrefix.Solid)
        {
            this.Name = name;
            this.FontAwesomeSixIcon = icon;
            this.FontAwesomeSixPrefix = prefix;
        }

        /// <summary>
        /// Creates a new FontAwesome record
        /// </summary>
        /// <param name="icon">Type of icon</param>
        /// <param name="name">Name of icon</param>
        /// <param name="fontAwesomePrefix">Icon prefix</param>
        public IconRecordModel(FontAwesomeIcon icon, string name, string fontAwesomePrefix = "fas")
        {
            this.Name = name;
            this.FontAwesomePrefix = fontAwesomePrefix;
            this.FontAwesomeIcon = icon;
        }

        public IconRecordModel(GoogleFontsIcon icon, string name)
        {
            this.GoogleFontsIcon = icon;
            this.Name = name;
        }

        public IconRecordModel(CssGGIcons icon, string name)
        {
            this.CssGGIcon = icon;
            this.Name = name;
        }

        public IconRecordModel(Ionicons icon, string name)
        {
            this.Ionicons = icon;
            this.Name = name;
        }

        public string FontAwesomeSixPrefixAsString 
        { 
            get
            {
                string result = string.Empty;

                switch(this.FontAwesomeSixPrefix)
                {
                    case FontAwesomeSixPrefix.Solid:
                        result = "fa-solid";
                        break;

                    case FontAwesomeSixPrefix.Regular:
                        result = "fa-regular";
                        break;

                    case FontAwesomeSixPrefix.Brands:
                        result = "fa-brands";
                        break;
                }

                return result;
            }
        }

        public string Name { get; set; }
        public string FontAwesomePrefix { get; set; } = IconStatics.FontAwesomePrefix;
        public FontAwesomeIcon FontAwesomeIcon { get; set; } = FontAwesomeIcon.None;
        public FontAwesomeSixIcon FontAwesomeSixIcon { get; set; } = FontAwesomeSixIcon.None;
        public GoogleFontsIcon GoogleFontsIcon { get; set; }
        public CssGGIcons CssGGIcon { get; set; }
        public Ionicons Ionicons { get; set; }
        public FontAwesomeSixPrefix FontAwesomeSixPrefix { get; set; } = FontAwesomeSixPrefix.Solid;
    }
}
