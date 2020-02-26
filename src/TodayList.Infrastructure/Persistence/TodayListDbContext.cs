using Microsoft.EntityFrameworkCore;
using TodayList.Application.Common.Interfaces;

namespace TodayList.Infrastructure.Persistence
{
    public class TodayListDbContext : DbContext, ITodayListDbContext
    {
        public TodayListDbContext(DbContextOptions<TodayListDbContext> options) : base(options)
        {
            
        }
    }
}