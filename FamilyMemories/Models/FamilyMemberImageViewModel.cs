using FamilyMemories.Models.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FamilyMemories.Models
{
    public class FamilyMemberImageViewModel
    {
        public List<SelectListItem>? Options { get; set; }
        //public IEnumerable<FamilyMember>? FamMembers { get; set; }
        public Image? Image { get; set; }
    }
}
