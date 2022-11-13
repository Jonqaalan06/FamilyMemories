using FamilyMemories.Data;
using FamilyMemories.Models;
using FamilyMemories.Models.Domain;
using FamilyMemories.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text.RegularExpressions;

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
        public async Task<RedirectToActionResult> Upload(FamilyMemberImageViewModel familyImage)
        {
            //Collect data from view
            FamilyMemberImageViewModel fmivm = new FamilyMemberImageViewModel()
            {
                Options = familyImage.Options,
                ImageDescription = familyImage.ImageDescription,
                FamMemberIds = familyImage.FamMemberIds,
                Image = familyImage.Image
            };
            //convert raw SelectedFamilyId string to a list of Family Members
            List<FamilyMember> peopleInPic = await GetFamilyMembersAsync(fmivm.FamMemberIds);

            //Upload the Picture to the FTP site
            var imageLocation = UploadToFtpSite(fmivm.Image, peopleInPic.First());

            //Update Image Table
            var storedImage = new Image()
            {
                ImageLocation = imageLocation,
                ShortDescription = fmivm.ImageDescription

            };
            await _familyMembersDbContext.Images.AddAsync(storedImage);
            await _familyMembersDbContext.SaveChangesAsync();
            int imageId = storedImage.Id;


            //Update FamilyMember_Image table
            foreach (var person in peopleInPic)
            {
                var fmImage = new FamilyMember_Image()
                {
                    FamilyMemberId = person.Id,
                    FamilyMember = person,
                    ImageId = imageId,
                    Image = storedImage
                };

                _familyMembersDbContext.FamilyMembers_Images.Add(fmImage);
                _familyMembersDbContext.SaveChanges();

            }

            return RedirectToAction("Index");


        }

        private static string UploadToFtpSite(IFormFile image, FamilyMember familyMember)
        {
            // FTP Server URL
            string ftp = "ftp://192.168.86.240/";

            // FTP Folder name. Leave blank if you want to upload to root folder
            // (really blank, not "/" !)
            string ftpFolder = @$"Documents\{familyMember.DirectoryName}\";
            byte[] fileBytes = null;
            string ftpUserName = "FileUploadAdmin";
            string ftpPassword = "TheSchowFamilyHasCrazyC00lPeople";

            // read the File and convert it to Byte array.
            string fileName = Path.GetFileName(image.FileName);
            using (BinaryReader br = new(image.OpenReadStream()))
            {
                fileBytes = br.ReadBytes((int)image.Length);
            }

            try
            {
                // create FTP Request
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + ftpFolder + fileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // enter FTP Server credentials
                request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                request.ContentLength = fileBytes.Length;
                request.UsePassive = true;
                request.UseBinary = true;   // or FALSE for ASCII files
                request.ServicePoint.ConnectionLimit = fileBytes.Length;
                request.EnableSsl = false;

                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(fileBytes, 0, fileBytes.Length);
                    requestStream.Close();
                }
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (WebException ex)
            {
                throw new Exception((ex.Response as FtpWebResponse).StatusDescription);
            }
            return ftp + ftpFolder + fileName;
        }

        private async Task<List<FamilyMember>> GetFamilyMembersAsync(string stringWithIds)
        {
            List<int> ids = ParseStringReturningIntegers(stringWithIds);
            var result = new List<FamilyMember>();
            foreach (var id in ids)
            {
                result.Add(await _familyMembersDbContext.FamilyMembers.FindAsync(id));
            }
            return result;
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
