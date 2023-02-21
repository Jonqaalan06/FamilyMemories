using Microsoft.AspNetCore.Mvc.Rendering;
namespace FamilyMemories.Models
{
    public class FamilyMemberRelationshipsViewModel
    {
        public FamilyMember Self { get; set; }
        public FamilyMember? Spouse { get; set; }
        public string? SpouseId { get; set; }
        public FamilyMember? Father { get; set; }
        public string? FatherId { get; set; }
        public FamilyMember? Mother { get; set; }
        public string? MotherId { get; set; }
        public IEnumerable<FamilyMember>? Siblings { get; set; }
        public string? SiblingIds { get; set; }
        public IEnumerable<FamilyMember>? Children { get; set; }
        public string? ChildrenIds { get; set; }
        public List<SelectListItem>? Options { get; set; }

    }
}
