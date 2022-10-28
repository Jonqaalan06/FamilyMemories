using FamilyMemories.Data;
using FamilyMemories.Models;
using FamilyMemories.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var famMembers = await familyMembersDbContext.FamilyMembers.ToListAsync();
            var famMemberImages = new FamilyMemberImageViewModel() { FamMembers = famMembers };
            return View(famMemberImages);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(FamilyMemberImageViewModel viewModel)
        {
            var famMemberSelected = new FamilyMember()
            {
                foreach (var member in viewModel.FamMembers.Where(m => m.FirstName.selected));
            }
            var fmivm = new FamilyMemberImageViewModel()
            {
                Image = viewModel.Image,

            };
            await _uploadService.UploadImageAsync();
            return RedirectToAction("Index");
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
