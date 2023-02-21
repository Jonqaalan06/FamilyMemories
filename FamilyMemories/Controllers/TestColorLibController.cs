using FamilyMemories.Data;
using FamilyMemories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FamilyMemories.Controllers
{
    public class TestColorLibController : Controller
    {
        private readonly FamilyMembersDbContext _Context;

        public TestColorLibController(FamilyMembersDbContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var options = BindToSelectList();
            var viewModel = new TestColorLibViewModel()
            {
                DisplayedOptions = options,
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(TestColorLibViewModel viewModel)
        {
            //Would like to capture the selected options here
            var selectedOptions = viewModel.SelectedOptions;

            return View(viewModel);
        }

        private List<SelectListItem> BindToSelectList()
        {
            List<SelectListItem> Options;
            Options = _Context.FamilyMembers.Select(x =>
            new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FirstName + " " + x.LastName

            }).ToList();
            return Options;
        }
    }
}
