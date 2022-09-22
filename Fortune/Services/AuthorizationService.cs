using Fortune.Context.Model;
using Fortune.Models;
using Fortune.Repository;
using System;
using System.Linq;

namespace Fortune.Services
{
    public interface IAuthorizationService
    {
        string Login(LoginModel loginModel);
        bool CheckToken(string token);
    }
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;
        private readonly IJwtService _jwtService;

        public AuthorizationService(ITokenRepository tokenRepository, IUserRepository userRepository, ISecurityService securityService, IJwtService jwtService)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _securityService = securityService;
            _jwtService = jwtService;
        }


        public string Login(LoginModel loginModel)
        {

            var salt = _securityService.GenerateSalt();
            var user = _userRepository.Get(x => x.Email == loginModel.Email).FirstOrDefault();
            if (user != null)
            {


                var hashPassword = _securityService.Sha256(loginModel.Password, user.PasswordSalt, "fortune");

                if (hashPassword == user.Password)
                {
                    var tokenObject = new UserTokenObject
                    {
                        UserId = user.Id,
                        UserName = user.Name,
                        Phone = user.Phone,
                        Email = user.Email,
                        UserType = user.Type,
                        IsActive = user.IsActive
                    };

                    var token = _jwtService.Encode(tokenObject);

                    var tokens = _tokenRepository.Get(x => x.Identity == user.Id).ToList();
                    if (tokens != null || tokens.Count() > 0)
                    {
                        _tokenRepository.RemoveRange(tokens);

                    }

                    _tokenRepository.Add(new TokenIdentitiy
                    {
                        Identity = user.Id,
                        Expire = DateTime.Now.AddDays(2),
                        Token = token,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    });
                    _tokenRepository.Save();
                    return token;
                }
            }
            return null;
        }



        public bool CheckToken(string token)
        {
            var tokenIdentitiy = _tokenRepository.Get(x => x.IsActive && x.Token == token).FirstOrDefault();
            return (tokenIdentitiy != null && tokenIdentitiy.Expire > DateTime.Now);
        }

    }
}

