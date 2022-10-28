using FamilyMemories.Models.Domain;

namespace FamilyMemories.Models
{
    public class FamilyMemberImageViewModel
    {
        public IEnumerable<FamilyMember>? FamMembers { get; set; }
        public Image? Image { get; set; }
    }
}
