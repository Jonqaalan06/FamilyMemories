using FamilyMemories.Data;
using FamilyMemories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

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

        [HttpPost]
        public async Task<IActionResult> Update(FamilyMemberRelationshipsViewModel vm)
        {
            var famMember = await _familyMembersDbContext.FamilyMembers.FindAsync(vm.Self.Id);

            if (famMember != null)
            {
                famMember.SpouseId = ParseStringReturningIntegers(vm.SpouseId).First();
                famMember.FatherId = ParseStringReturningIntegers(vm.FatherId).First();
                famMember.MotherId = ParseStringReturningIntegers(vm.MotherId).First();
                famMember.SiblingIds = ConvertToString(ParseStringReturningIntegers(vm.SiblingIds));
                famMember.ChildrenIds = ConvertToString(ParseStringReturningIntegers(vm.ChildrenIds));

                await _familyMembersDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }


            return RedirectToAction("/FamMembers/index");
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

        private static List<int> ParseStringReturningIntegers(string stringWithIds)
        {
            List<int> ids = new List<int>();
            var messyIds = stringWithIds.Split(',').ToList();
            foreach (var messyId in messyIds)
            {
                ids.Add(int.Parse(Regex.Replace(messyId, "[^.0-9]", "")));
            }
            return ids;
        }

        private static string ConvertToString(List<int> list)
        {
            return string.Join(",", list.Select(x => x.ToString()).ToArray());
        }
    }
}
