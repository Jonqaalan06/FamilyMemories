using FamilyMemories.Data;
using FamilyMemories.Models;
using System.Linq;

namespace FamilyMemories.Services
{
    public class FamilyMemberService : IFamilyMembersService
    {
        private readonly FamilyMembersDbContext _context;
        public FamilyMemberService(FamilyMembersDbContext context)
        {
            _context = context;
        }
        public void AddFamilyMember(FamilyMember familyMember)
        {
            _context.FamilyMembers.Add(familyMember);
        }

        public FamilyMember GetFamilyMemberById(int id)
        {
            return _context.FamilyMembers.FirstOrDefault(x => x.Id == id);
        }

        public List<FamilyMember> GetFamilyMembers()
        {
            return _context.FamilyMembers.ToList();
        }

        public void RemoveFamilyMember(int id)
        {
            var famMemToDelete = GetFamilyMemberById(id);
            _context.FamilyMembers.Remove(famMemToDelete);
        }

        public void UpdateFamilyMember(FamilyMember updatedFamMemberData)
        {
            var dataToUpdate = GetFamilyMemberById(updatedFamMemberData.Id);
            if (dataToUpdate != null)
            {
                dataToUpdate.FirstName = updatedFamMemberData.FirstName;
                dataToUpdate.LastName = updatedFamMemberData.LastName;
                dataToUpdate.MiddleName = updatedFamMemberData.MiddleName;

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception) { }
                
            }
        }
    }
}
