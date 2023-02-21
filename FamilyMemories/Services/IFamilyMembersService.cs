using FamilyMemories.Models;

namespace FamilyMemories.Services
{
    public interface IFamilyMembersService
    {
        List<FamilyMember> GetFamilyMembers();
        FamilyMember GetFamilyMemberById(int id);
        void AddFamilyMember(FamilyMember familyMember);
        void UpdateFamilyMember(FamilyMember familyMember);
        void RemoveFamilyMember(int id);
    }
}
