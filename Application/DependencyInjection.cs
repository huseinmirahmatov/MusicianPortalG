using Application.Services;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBaseService<Track>, TrackService>();
            services.AddScoped<IBaseService<Artist>, ArtistService>();
            services.AddScoped<IBaseService<Genre>, GenreService>();
            services.AddScoped<IBaseService<User>, UserService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
