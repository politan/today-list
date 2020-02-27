using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodayList.Application.Common.Interfaces;
using TodayList.Application.DTO;

namespace TodayList.Application.Assignments.Queries.GetAssignments
{
    public class GetAssignmentsQuery : IRequest<IEnumerable<AssignmentDto>>
    {
        public class GetAssignmentQueryHandler : IRequestHandler<GetAssignmentsQuery, IEnumerable<AssignmentDto>>
        {
            private readonly ITodayListDbContext _context;
            private readonly IMapper _mapper;
            
            public GetAssignmentQueryHandler(ITodayListDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<IEnumerable<AssignmentDto>> Handle(GetAssignmentsQuery request, CancellationToken cancellationToken)
            {
                var entities = await _context.Assignments
                    .OrderBy(a => a.Title)
                    .ProjectTo<AssignmentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return await Task.FromResult(entities);
            }
        }
    }
}