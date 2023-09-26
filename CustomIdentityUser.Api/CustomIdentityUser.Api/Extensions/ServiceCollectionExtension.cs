using CustomIdentityUser.Api.DALs.DbContexts;
using CustomIdentityUser.Api.DALs.Tables;

namespace CustomIdentityUser.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers();

            services.AddDbContext<MembershipDbContext>(options =>
            {

            });
            services.AddIdentity<Member, Role>();

            return services;
        }
    }
}
