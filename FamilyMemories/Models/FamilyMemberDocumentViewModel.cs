using FamilyMemories.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace FamilyMemories.Models
{
    public class FamilyMemberDocumentViewModel
    {
        public List<SelectListItem>? Options { get; set; }

        // TODO: look at implementing validation on these fields.
        [Required]
        public string DocumentDescription { get; set; }
        [Required]
        public string FamMemberIds { get; set; }
        [Required]
        public IFormFile Document { get; set; }
    }
}
