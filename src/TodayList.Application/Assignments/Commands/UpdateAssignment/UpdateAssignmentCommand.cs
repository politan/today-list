using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodayList.Application.Common.Interfaces;
using TodayList.Application.Exceptions;
using TodayList.Domain.Entities;

namespace TodayList.Application.Assignments.Commands.UpdateAssignment
{
    public class UpdateAssignmentCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
        public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand>
        {
            private readonly ITodayListDbContext _context;
            
            public UpdateAssignmentCommandHandler(ITodayListDbContext context)
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Assignments.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new EntityNotFoundException(nameof(Assignment), request.Id);
                }

                entity.Title = request.Title;
                entity.Body = request.Body;

                await _context.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;
            }
        }
    }
}