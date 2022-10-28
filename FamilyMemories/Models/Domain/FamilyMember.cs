using FamilyMemories.Models.Domain;
namespace FamilyMemories.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public int? SpouseId { get; set; }
        public int? FatherId { get; set; }
        public int? MotherId { get; set; }
        public string? SiblingIds { get; set; }
        public string? ChildrenIds { get; set; }
        public List<FamilyMember_Image> FamilyMember_Images { get; set; }

    }
}
