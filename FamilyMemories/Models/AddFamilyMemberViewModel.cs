namespace FamilyMemories.Models
{
    public class AddFamilyMemberViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public int? SpouseId { get; set; }
        public int? FatherId { get; set; }
        public int? MotherId { get; set; }
        public string? SiblingIds { get; set; }
        public string? ChildrenIds { get; set; }
    }
}
