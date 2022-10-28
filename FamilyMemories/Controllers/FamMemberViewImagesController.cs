using FamilyMemories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyMemories.Controllers
{
    public class FamMemberViewImagesController : Controller
    {
        private readonly FamilyMembersDbContext _familyMembersDbContext;
        public FamMemberViewImagesController(FamilyMembersDbContext familyMembersDbContext)
        {
            _familyMembersDbContext = familyMembersDbContext;
        }
        public async Task<IActionResult> Index(int FamMemberId)
        {
            var famMember = await _familyMembersDbContext.FamilyMembers.FirstOrDefaultAsync(x => x.Id == FamMemberId);

            return View(famMember);
        }
    }
}
