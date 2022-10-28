namespace FamilyMemories.Services
{
    public interface IUploadService
    {
        //upload Images
        public Task<bool> UploadImageAsync();

        //uploadFiles
        public Task<bool> UploadFileImageAsync();
    }
}
