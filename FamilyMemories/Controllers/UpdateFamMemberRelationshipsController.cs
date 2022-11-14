using FamilyMemories.Data;
using FamilyMemories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FamilyMemories.Controllers
{
    public class UpdateFamMemberRelationshipsController : Controller
    {
        private readonly FamilyMembersDbContext _familyMembersDbContext;
        public UpdateFamMemberRelationshipsController(FamilyMembersDbContext context)
        {
            _familyMembersDbContext = context;
        }
        [HttpGet]
        public IActionResult Index(int famMemId)
        {
            var self = _familyMembersDbContext.FamilyMembers.Find(famMemId);
            var vm = new FamilyMemberRelationshipsViewModel()
            {
                Self = self,
                Options = BindToSelectList()
            };

            return View(vm);
        }

        private List<SelectListItem> BindToSelectList()
        {
            List<SelectListItem> Options;
            Options = _familyMembersDbContext.FamilyMembers.Select(x =>
            new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FirstName + " " + x.LastName

            }).ToList();
            return Options;
        }
    }
}
