using Autofac;
using Fortune.Repository;
using Fortune.Services;

namespace Fortune.Infrastructure.Configuration
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CardService>().As<ICardService>();
            builder.RegisterType<CardRepository>().As<ICardRepository>();
            builder.RegisterType<CultureRepository>().As<ICultureRepository>();
            builder.RegisterType<JwtService>().As<IJwtService>();
            builder.RegisterType<SecurityService>().As<ISecurityService>();
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();
            builder.RegisterType<TokenRepository>().As<ITokenRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();


        }
    }
}
