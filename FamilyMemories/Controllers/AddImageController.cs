using FamilyMemories.Data;
using FamilyMemories.Models;
using FamilyMemories.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FamilyMemories.Controllers
{
    public class AddImageController : Controller
    {
        private readonly FamilyMembersDbContext familyMembersDbContext;
        private readonly IUploadService _uploadService;
        public AddImageController(FamilyMembersDbContext familyMembersDbContext, IUploadService uploadService)
        {
            this.familyMembersDbContext = familyMembersDbContext;
            _uploadService = uploadService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var options = BindToSelectList();
            var viewModel = new FamilyMemberImageViewModel() { Options = options };
            return View(viewModel);
        }

        [HttpPost]
        public async Task Upload(List<int> selectedFamilyMemberIds)
        {
            List<FamilyMember> peopleInPic;
            //TODO: query for family members in database with selected ids


        }

        private List<SelectListItem> BindToSelectList()
        {
            List<SelectListItem> Options;
            Options = familyMembersDbContext.FamilyMembers.Select(x =>
            new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FirstName + " " + x.LastName

            }).ToList();
            return Options;
        }


        //[HttpPost]
        //public async Task<IActionResult> Add(AddFamilyMemberViewModel addFamMemRequst)
        //{
        //    var famMember = new FamilyMember()
        //    {
        //        FirstName = addFamMemRequst.FirstName,
        //        MiddleName = addFamMemRequst.MiddleName,
        //        LastName = addFamMemRequst.LastName,
        //        SpouseId = addFamMemRequst.SpouseId,
        //        FatherId = addFamMemRequst.FatherId,
        //        MotherId = addFamMemRequst.MotherId,
        //        SiblingIds = addFamMemRequst.SiblingIds,
        //        ChildrenIds = addFamMemRequst.ChildrenIds
        //    };

        //    await familyMembersDbContext.FamilyMembers.AddAsync(famMember);
        //    await familyMembersDbContext.SaveChangesAsync();
        //    return RedirectToAction("Index");

        //}
    }
}
