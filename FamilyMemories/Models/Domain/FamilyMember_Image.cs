namespace FamilyMemories.Models.Domain
{
    public class FamilyMember_Image
    {
        public int Id { get; set; }
        public int FamilyMemberId { get; set; }
        public FamilyMember FamilyMember { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
