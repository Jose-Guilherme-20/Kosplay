
namespace Kosplay.Domain.Interfaces.HttpService
{
    public interface IImageKitService
    {
        Task<string> UploadFileAsync(byte[] fileBytes, string fileName, string folder = null);
    }
}
