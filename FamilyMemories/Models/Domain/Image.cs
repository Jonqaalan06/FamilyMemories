using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyMemories.Models.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public string? ImageLocation { get; set; }
        public string? ShortDescription { get; set; }

        public virtual ICollection<FamilyMember>? FamilyMembers { get; set; }

        //navigation properties
        public List<FamilyMember_Image> FamilyMember_Images { get; set; }

        //display properties
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
