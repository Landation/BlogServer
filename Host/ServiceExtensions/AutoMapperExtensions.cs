using AutoMapper;
using Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Host.ServiceExtensions
{
    public static class AutoMapperServiceExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            Mapper.Initialize(y =>y.AddProfile(new AutoMapperProfile()) );
            return services;
        }
    }
}