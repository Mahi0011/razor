using Dapper;
using RAZOR_Chat.Interface;
using RAZOR_Chat.Models;
using RAZOR_Chat.Service;
using System.Data;

namespace RAZOR_Chat.Repository
{
    public class AuthRepository:IAuthRepository
    {
        private IConnectionmanager _connectionmanager;
        public AuthRepository(IConnectionmanager connectionmanager)
        {
            _connectionmanager = connectionmanager;
        }

        public async Task<ResultData<bool>> Register(User user)
        {
            ResultData<bool> resultData = new ResultData<bool>();
            try
            {
                using (IDbConnection dbconnection = _connectionmanager.getNewConnection())
                {
                    string Query = "INSERT INTO Users(username,email,password) VALUES (@username,@email,@Hashedpassword)";
                    var result = await dbconnection.ExecuteAsync(Query, user);
                    resultData.Success = true;
                    return resultData;
                }
            }
            catch (Exception ex)
            {
                resultData.Messege=ex.Message;
                return resultData;
            }
        }
        public async Task<ResultData<User>> GetUserByName(UserLogin user)
        {
            ResultData<User> resultData = new ResultData<User>();
            try
            {
                using (IDbConnection dbconnection = _connectionmanager.getNewConnection())
                {
                    string Query = "select * from Users where email = @email";
                    var result = await dbconnection.QueryAsync<User>(Query, user);

                    resultData.Data = result.FirstOrDefault();
                    return resultData;
                }
            }
            catch (Exception ex)
            {
                resultData.Messege = ex.Message;
                return resultData;
            }
        }
    }
}
