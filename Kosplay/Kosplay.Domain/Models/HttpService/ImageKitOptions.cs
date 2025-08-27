
namespace Kosplay.Domain.Models.HttpService
{
    public class ImageKitOptions
    {
        public required string Url { get; set; }
        public required string PublicKey { get; set; }
        public required string PrivateKey { get; set; }
        public required string Folder { get; set; }
    }
}
