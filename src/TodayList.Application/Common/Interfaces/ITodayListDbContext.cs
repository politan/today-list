using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodayList.Domain.Entities;

namespace TodayList.Application.Common.Interfaces
{
    public interface ITodayListDbContext
    {
        DbSet<Assignment> Assignments { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}