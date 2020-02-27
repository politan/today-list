using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TodayList.Application.Common.Interfaces;
using TodayList.Application.Exceptions;
using TodayList.Domain.Entities;

namespace TodayList.Application.Assignments.Commands.DeleteAssignment
{
    public class DeleteAssignmentCommand : IRequest
    {
        public Guid Id { get; set; }
        
        public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand>
        {
            private readonly ITodayListDbContext _context;
            
            public DeleteAssignmentCommandHandler(ITodayListDbContext context)
            {
                _context = context;
            }
            
            public async Task<Unit> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Assignments.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new EntityNotFoundException(nameof(Assignment), request.Id);
                }

                _context.Assignments.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;
            }
        }
    }
}