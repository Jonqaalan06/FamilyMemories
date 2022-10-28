namespace FamilyMemories.Models
{
    public class FamilyMemberRelationshipsViewModel
    {
        public FamilyMember Self { get; set; }
        public FamilyMember? Spouse { get; set; }
        public FamilyMember? Father { get; set; }
        public FamilyMember? Mother { get; set; }
        public IEnumerable<FamilyMember>? Siblings { get; set; }
        public IEnumerable<FamilyMember>? Children { get; set; }

    }
}
