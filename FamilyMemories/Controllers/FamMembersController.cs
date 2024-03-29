﻿using FamilyMemories.Data;
using FamilyMemories.Models.Domain;
using FamilyMemories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FamilyMemories.Controllers
{
    public class FamMembersController : Controller
    {
        private readonly FamilyMembersDbContext familyMembersDbContext;
        public FamMembersController (FamilyMembersDbContext familyMembersDbContext)
        {
            this.familyMembersDbContext = familyMembersDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var famMembers = await familyMembersDbContext.FamilyMembers.ToListAsync();
            return View(famMembers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddFamilyMemberViewModel addFamMemRequst)
        {
            var famMember = new FamilyMember()
            {
                FirstName = addFamMemRequst.FirstName,
                MiddleName = addFamMemRequst.MiddleName,
                LastName = addFamMemRequst.LastName,
                SpouseId = addFamMemRequst.SpouseId,
                FatherId = addFamMemRequst.FatherId,
                MotherId = addFamMemRequst.MotherId,
                SiblingIds = addFamMemRequst.SiblingIds,
                ChildrenIds = addFamMemRequst.ChildrenIds
            };

            try
            {
                famMember.DirectoryName = await CreateFtpFolderAsync(famMember);
            }
            catch (Exception)
            {

            }
            
            await familyMembersDbContext.FamilyMembers.AddAsync(famMember);
            await familyMembersDbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var famMember = await familyMembersDbContext.FamilyMembers.FirstOrDefaultAsync(x => x.Id == id);

            if (famMember != null)
            {
                var viewModel = new UpdateFamilyMemberViewModel()
                {
                    Id = famMember.Id,
                    FirstName = famMember.FirstName,
                    LastName = famMember.LastName,
                    MiddleName = famMember.MiddleName,
                    SpouseId = famMember.SpouseId,
                    FatherId = famMember.FatherId,
                    MotherId = famMember.MotherId,
                    SiblingIds = famMember.SiblingIds,
                    ChildrenIds = famMember.ChildrenIds,
                    Directory = famMember.DirectoryName
                };
                return await Task.Run(() => View("View", viewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateFamilyMemberViewModel updateFamMemRequst)
        {
            var famMember = await familyMembersDbContext.FamilyMembers.FindAsync(updateFamMemRequst.Id);

            if (famMember.DirectoryName is null || famMember.DirectoryName == string.Empty)
            {
                try
                {
                    famMember.DirectoryName = await CreateFtpFolderAsync(famMember);
                }
                catch (Exception)
                {
                }
            }

            if (famMember != null)
            {
                famMember.FirstName = updateFamMemRequst.FirstName;
                famMember.LastName = updateFamMemRequst.LastName;
                famMember.MiddleName = updateFamMemRequst.MiddleName;

                await familyMembersDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateFamilyMemberViewModel model)
        {
            var familyMember = await familyMembersDbContext.FamilyMembers.FindAsync(model.Id);
            if (familyMember != null)
            {
                familyMembersDbContext.FamilyMembers.Remove(familyMember);
                await familyMembersDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Memories(int id)
        {
            var famMember = await familyMembersDbContext.FamilyMembers.FindAsync(id);
            var relationships = GetKnownRelationships(famMember);
            return View(relationships);
        }

        private Task<string> CreateFtpFolderAsync(FamilyMember famMember)
        {
            string[] rootAddressses = new string[] { "ftp://192.168.86.240/Pictures/", "ftp://192.168.86.240/Documents/", "ftp://192.168.86.240/ProfilePicture/" };
            string newAddresses = (famMember.FirstName + famMember.MiddleName + famMember.LastName);

            foreach (var root in rootAddressses)
            {
                WebRequest request = WebRequest.Create(root + famMember.FirstName + famMember.MiddleName + famMember.LastName);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.Credentials = new NetworkCredential("FileUploadAdmin", "TheSchowFamilyHasCrazyC00lPeople");

                using var response = (FtpWebResponse)request.GetResponse();
            }
            return Task.FromResult(newAddresses);
        }

        private FamilyMemberRelationshipsViewModel GetKnownRelationships(FamilyMember? famMember)
        {
            return new FamilyMemberRelationshipsViewModel()
            {
                Self = famMember,
                Spouse = GetSpouse(famMember),
                Father = GetFather(famMember),
                Mother = GetMother(famMember),
                Siblings = GetSiblings(famMember),
                Children = GetChildren(famMember)

            };
        }

        private IEnumerable<FamilyMember> GetChildren(FamilyMember? famMember)
        {
            var children = new List<FamilyMember>();
            if (famMember.ChildrenIds != null)
            {
                var idList = famMember.ChildrenIds.Split(',').ToList();
                foreach(var id in idList)
                {

                    children.Add(familyMembersDbContext.FamilyMembers.Find(int.Parse(id)));
                }
            }
            return children;
        }

        private IEnumerable<FamilyMember> GetSiblings(FamilyMember? famMember)
        {
            var siblings = new List<FamilyMember>();
            if (famMember.SiblingIds != null)
            {
                var idList = famMember.SiblingIds.Split(',').ToList();
                foreach (var id in idList)
                {
                    siblings.Add(familyMembersDbContext.FamilyMembers.Find(int.Parse(id)));
                }
            }
            return siblings;
        }

        private FamilyMember GetMother(FamilyMember? famMember)
        {
            var mother = new FamilyMember();
            if (famMember.MotherId != null)
            {
                mother = familyMembersDbContext.FamilyMembers.Find(famMember.MotherId);
            }
            return mother;
        }

        private FamilyMember GetFather(FamilyMember? famMember)
        {
            var father = new FamilyMember();
            if (famMember.FatherId != null)
            {
                father = familyMembersDbContext.FamilyMembers.Find(famMember.FatherId);
            }
            return father;
        }

        private FamilyMember GetSpouse(FamilyMember? famMember)
        {
            var spouse = new FamilyMember();
            if (famMember.SpouseId != null)
            {
                spouse = familyMembersDbContext.FamilyMembers.Find(famMember.SpouseId);
            }
            return spouse;
        }
    }
}
