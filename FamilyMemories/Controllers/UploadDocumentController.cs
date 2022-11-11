using FamilyMemories.Data;
using FamilyMemories.Models;
using FamilyMemories.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FamilyMemories.Controllers
{
    public class UploadDocumentController : Controller
    {
        private readonly FamilyMembersDbContext _familyMembersDbContext;
        private readonly IUploadService _uploadService;

        public UploadDocumentController(FamilyMembersDbContext familyMembersDbContext, IUploadService uploadService)
        {
            _familyMembersDbContext = familyMembersDbContext;
            _uploadService = uploadService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var options = BindToSelectList();
            var viewModel = new FamilyMemberDocumentViewModel() { Options = options };
            return View(viewModel);
        }

        [HttpPost]
        public async Task Upload(FamilyMemberImageViewModel familyImage)
        {
            List<FamilyMember> documentOwners;
            //TODO: query for family members in database with selected ids


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
