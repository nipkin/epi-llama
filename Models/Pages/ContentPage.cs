using System.ComponentModel.DataAnnotations;
using EPiServer.Web;

namespace epiv12demo.Models.Pages
{
    [ContentType(
        DisplayName = "Content Page",
        GUID = "f4b2c9a1-8d3e-4c9b-9a2d-1e6f7b5c2a90",
        Description = "Simple content page with a header, preamble."
    )]
    public class ContentPage : BasePage
    {
        [CultureSpecific]
        [Display(
            Name = "Header",
            Description = "Primary header for the page",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string? Header { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "Preamble",
            Description = "Short introductory text shown above the main content",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string? Preamble { get; set; }

        [CultureSpecific]
        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "Index questions",
            Description = "Check this to save question and answers in the index.",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual bool IndexQuestion { get; set; }
    }
}
