using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TodayList.Application.Assignments.Queries;
using TodayList.Application.Assignments.Queries.GetAssignments;

namespace TodayList.Api.Configurations
{
    public static class MediatrConfiguration
    {
        public static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(GetAssignmentsQuery.GetAssignmentQueryHandler).Assembly);
            
            return services;
        }
    }
}