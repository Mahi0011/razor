using RAZOR_Chat.Models;

namespace RAZOR_Chat.Interface
{
    public interface IAuthRepository
    {
        Task<ResultData<bool>> Register(User user);
        Task<ResultData<User>> GetUserByName(UserLogin user);
    }
}
