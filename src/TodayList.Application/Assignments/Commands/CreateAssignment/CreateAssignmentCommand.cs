using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TodayList.Application.Common.Interfaces;
using TodayList.Domain.Entities;

namespace TodayList.Application.Assignments.Commands.CreateAssignment
{
    public class CreateAssignmentCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        
        public class CreateAssignmentCommandHandler : IRequestHandler<CreateAssignmentCommand, Guid>
        {
            private readonly ITodayListDbContext _context;
            private readonly IMapper _mapper;
            
            public CreateAssignmentCommandHandler(ITodayListDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            
            public async Task<Guid> Handle(CreateAssignmentCommand request, CancellationToken cancellationToken)
            {
                var entity = new Assignment
                {
                    Title = request.Title,
                    Body = request.Body
                };

                _context.Assignments.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
        }
    }
}