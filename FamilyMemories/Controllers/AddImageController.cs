using FamilyMemories.Data;
using FamilyMemories.Models;
using FamilyMemories.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            List<SelectListItem> Options;
            Options = familyMembersDbContext.FamilyMembers.Select(x => 
            new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FirstName + " " + x.LastName

            }).ToList();
            var viewModel = new FamilyMemberImageViewModel() { Options = Options };
            return View(viewModel);
        }

        //[HttpPost]
        //public async Task<IActionResult> Upload(FamilyMemberImageViewModel viewModel)
        //{
            
        //}


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
