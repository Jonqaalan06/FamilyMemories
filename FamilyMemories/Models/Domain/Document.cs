using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyMemories.Models.Domain
{
    public class Document
    {
        public int Id { get; set; }
        public string? DocumentLocation { get; set; }
        public string? ShortDescription { get; set; }

        public virtual ICollection<FamilyMember>? FamilyMembers { get; set; }

        //navigation properties
        public List<FamilyMember_Document> FamilyMember_Documents { get; set; }

        //display properties
        [NotMapped]
        public IFormFile DocumentFile { get; set; }
    }
}
