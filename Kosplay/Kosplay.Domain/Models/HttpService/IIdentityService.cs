
namespace Kosplay.Domain.Models.HttpService
{
    public interface IIdentityService
    {
        bool IsAuthenticated();
  
        string GetUserId();

        string GetUserName();
    }
}
