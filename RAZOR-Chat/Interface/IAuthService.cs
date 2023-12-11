using RAZOR_Chat.Models;

namespace RAZOR_Chat.Interface
{
    public interface IAuthService
    {
        Task<ResultData<bool>> Register(User user);
        Task<ResultData<string>> Login(UserLogin user);
    }
}
