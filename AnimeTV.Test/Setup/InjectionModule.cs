using AnimeTV.Infrastructure.Interface;
using AnimeTV.Infrastructure.Repository;
using AnimeTV.Service.Interface;
using AnimeTV.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AnimeTV.Test.TestSetup
{
    public static class InjectionModule
    {
        public static void BindService(ServiceCollection servicos)
        {
            servicos.AddScoped<IUserService, UserService>();

            servicos.AddScoped<IUserRepository, UserRepository>();
        }
    }
    
}
