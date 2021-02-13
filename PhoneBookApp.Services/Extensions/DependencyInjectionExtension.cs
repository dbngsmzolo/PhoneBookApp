using PhoneBookApp.Data.Ef.Repository;
using PhoneBookApp.Data.Ef.Repository.Interfaces;
using PhoneBookApp.Services.Concrete;
using PhoneBookApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace PhoneBookApp.Services.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IEntryService, EntryService>();
            services.AddScoped<IEntryRepository, EfEntryRepository>();
            services.AddScoped<IPhoneBookService, PhoneBookService>();
            services.AddScoped<IPhoneBookRepository, EfPhoneBookRepository>();

            return services;
        }
    }
}
