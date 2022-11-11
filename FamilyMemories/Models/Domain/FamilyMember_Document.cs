namespace FamilyMemories.Models.Domain
{
    public class FamilyMember_Document
    {
        public int Id { get; set; }
        public int FamilyMemberId { get; set; }
        public FamilyMember FamilyMember { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
    }
}