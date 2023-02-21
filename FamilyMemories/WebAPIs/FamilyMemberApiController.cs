using FamilyMemories.Models;
using FamilyMemories.Services;
using System.Web.Http;

namespace FamilyMemories.WebAPIs
{
    public class FamilyMemberApiController : ApiController
    {
        private readonly IFamilyMembersService _familyMembersService;

        public FamilyMemberApiController(IFamilyMembersService familyMembersService)
        {
            _familyMembersService = familyMembersService;
        }

        [HttpGet]
        [Route("FamilyMemberApiController/GetFamilyMembers")]
        public IHttpActionResult GetFamilyMembers()
        {
            var famMembers = _familyMembersService.GetFamilyMembers();
            return Ok(famMembers);
        }

        [HttpGet]
        [Route("FamilyMemberApiController/GetFamilyMemberById/{id}")]
        public IHttpActionResult GetFamilyMemberById(int id)
        {
            var famMember = _familyMembersService.GetFamilyMemberById(id);
            return Ok(famMember);
        }

        [HttpPost]
        [Route("FamilyMemberApiController/AddFamilyMember")]
        public IHttpActionResult AddFamilyMember([FromBody]FamilyMember familyMember)
        {
            _familyMembersService.AddFamilyMember(familyMember);
            return Ok();
        }

        [HttpPost]
        [Route("FamilyMemberApiController/UpdateFamilyMember")]
        public IHttpActionResult UpdateFamilyMember([FromBody]FamilyMember familyMember)
        {
            _familyMembersService.UpdateFamilyMember(familyMember);
            return Ok();
        }

        [HttpDelete]
        [Route("FamilyMemberApiController/DeleteFamilyMember")]
        public IHttpActionResult DeleteFamilyMember(int id)
        {
            _familyMembersService.RemoveFamilyMember(id);
            return Ok();
        }
    }
}
