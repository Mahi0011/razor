using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using RAZOR_Chat.Interface;
using RAZOR_Chat.Models;
using RAZOR_Chat.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RAZOR_Chat.Service
{
    public class AuthService: IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository authRepository,IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }
        public async Task<ResultData<bool>> Register(User user)
        {
            var resultData = new ResultData<bool>();
            resultData.Success = false;
            try
            {
                user.Hashedpassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                var resp = await _authRepository.Register(user);
                resultData.Success = resp.Success;
                return resultData;

            }catch (Exception ex)
            {
                resultData.Messege = ex.Message;
                return resultData;
            }
        }

        public async Task<ResultData<string>> Login(UserLogin user)
        {
            var resultData = new ResultData<string>();
            resultData.Success = false;
            try
            {
                var resp = await _authRepository.GetUserByName(user);
                if(resp.Data != null)
                {
                    var verify = BCrypt.Net.BCrypt.Verify(user.Password, resp.Data.Password);
                    if (verify)
                    {
                        resultData.Success = true;
                        resultData.Messege = "User LoggedIn successfully";
                        var token = CreateToken(user);
                        resultData.Data=token;
                    }
                }
                return resultData;

            }
            catch (Exception ex)
            {
                resultData.Messege = ex.Message;
                return resultData;
            }
        }
        private string CreateToken(UserLogin user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Email),
                new Claim(ClaimTypes.Role,"admin")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("jwtkey").Value));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(claims: claims, expires:DateTime.Now.AddDays(1),signingCredentials:credentials );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
