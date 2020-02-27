using AutoMapper;
using TodayList.Application.DTO;
using TodayList.Domain.Entities;

namespace TodayList.Application.Mappings
{
    public class AssignmentProfile : Profile
    {
        public AssignmentProfile()
        {
            CreateMap<Assignment, AssignmentDto>();
        }
    }
}