using FamilyMemories.Models.Domain;

namespace FamilyMemories.Models.Dtos
{
    public class UploadServiceDto
    {
        public Image Image { get; set; }
        public List<FamilyMember> FamilyMembers { get; set; }
    }
}
