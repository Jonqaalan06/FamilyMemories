using FamilyMemories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FamilyMemories.Controllers
{
    public class FamMemberViewDocController : Controller
    {
        private readonly FamilyMembersDbContext _familyMembersDbContext;

        public FamMemberViewDocController(FamilyMembersDbContext familyMembersDbContext)
        {
            _familyMembersDbContext = familyMembersDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int FamMemberId)
        {
            var famMember = await _familyMembersDbContext.FamilyMembers.FirstOrDefaultAsync(x => x.Id == FamMemberId);
            return View(famMember);
        }
    }
}
