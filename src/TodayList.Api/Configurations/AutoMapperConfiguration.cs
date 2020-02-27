using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TodayList.Application.Mappings;

namespace TodayList.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AssignmentProfile).Assembly);
            
            return services;
        }
    }
}