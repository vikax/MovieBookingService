using Booking.DataRepositories.RepositoryImplementor;
using Booking.DataRepositories.RepositoryInterfaces;
using Booking.Service.Interfaces;
using Booking.Service.Managers;
using MovieBookingService.Interfaces;
using MovieBookingService.Managers;

namespace Booking.Service
{
    public static class RegisterDependencies
    {
        public static IServiceCollection AddDependency(this IServiceCollection services) 
        {
            services.AddSingleton<IMovieBookingManager, MovieBookingManager>();
            services.AddSingleton<IMovieManager, MovieManager>();
            services.AddSingleton<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
