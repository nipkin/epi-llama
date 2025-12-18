using System.ComponentModel.DataAnnotations;

namespace epiv12demo.Infrastructure
{
    [GroupDefinitions]
    public static class GroupNames
    {
        [Display(Name = "Metadata", Order = 40)]
        public const string MetaData = "Metadata";
    }
}
