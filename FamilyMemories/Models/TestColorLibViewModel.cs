using Microsoft.AspNetCore.Mvc.Rendering;

namespace FamilyMemories.Models
{
    public class TestColorLibViewModel
    {
        public List<SelectListItem>? DisplayedOptions { get; set; }
        public List<SelectListItem>? SelectedOptions { get; set; }
    }
}
