using FamilyMemories.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace FamilyMemories.Models
{
    public class FamilyMemberImageViewModel
    {
        
        public List<SelectListItem>? Options { get; set; }
        public FamilyMember? SelectedFamMember { get; set; }

        // TODO: look at implementing validation on these fields.
        [Required]
        public string ImageDescription { get; set; }
        [Required]
        public string FamMemberIds { get; set; }
        [Required]
        public IFormFile Image { get; set; }
    }
}
