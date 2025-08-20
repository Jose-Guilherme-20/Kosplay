
using Imagekit.Sdk;
using Kosplay.Domain.Interfaces.HttpService;
using Kosplay.Domain.Models.HttpService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Kosplay.Infra.Services
{
    public class ImageKitService : IImageKitService
    {
        private readonly ImagekitClient _client;

        public ImageKitService(IOptions<ImageKitOptions> options)
        {
            var opts = options.Value;
            _client = new ImagekitClient(opts.PublicKey, opts.PrivateKey, opts.Url);
        }

        public async Task<string> UploadFileAsync(byte[] fileBytes, string fileName, string folder = null)
        {
            var uploadParams = new FileCreateRequest()
            {
                file = Convert.ToBase64String(fileBytes),
                fileName = fileName,
                folder = folder,
                useUniqueFileName = true
            };

            var uploadResponse = await _client.UploadAsync(uploadParams);
            if (uploadResponse != null && !string.IsNullOrEmpty(uploadResponse.url))
            {
                return uploadResponse.url;
            }
            else
            {
                throw new Exception("Erro ao fazer upload da imagem no ImageKit.");
            }
        }
    }
}
