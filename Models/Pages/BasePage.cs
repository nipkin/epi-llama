using EPiServer.Web;
using System.ComponentModel.DataAnnotations;
using epiv12demo.Infrastructure;

namespace epiv12demo.Models.Pages
{
    [ContentType(
        DisplayName = "Base Page",
        GUID = "d6d919b1-49c0-4df8-a11b-fcddc2b47f83",
        Description = "The base page type that other pages inherit from"
    )]
    public abstract class BasePage : PageData
    {
        [Display(
            Name = "Meta Title",
            Description = "Title for SEO and browser tab",
            GroupName = GroupNames.MetaData,
            Order = 10)]
        public virtual string? MetaTitle { get; set; }

        [UIHint(UIHint.Textarea)]
        [Display(
            Name = "Meta Description",
            Description = "Description for SEO purposes",
            GroupName = GroupNames.MetaData,
            Order = 20)]
        public virtual string? MetaDescription { get; set; }

        [Display(
            Name = "Hide in Navigation",
            Description = "If checked, this page won't appear in menus",
            GroupName = GroupNames.MetaData,
            Order = 30)]
        public virtual bool HideInNavigation { get; set; }
    }
}