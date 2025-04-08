using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        // private readonly IDomainEventDispatcher _dispatcher;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //   // DbContextOptions options, IDomainEventDispatcher dispatcher) : base(options)
        //{
        //   // _dispatcher = dispatcher;
        //}
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Seat> Seats { get; set; }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    var result = await base.SaveChangesAsync(cancellationToken);

        //    var entitiesWithEvents = ChangeTracker.Entries<Entity<Guid>>()
        //        .Select(e => e.Entity)
        //        .Where(e => e.DomainEvents.Any())
        //        .ToArray();

        //    //foreach (var entity in entitiesWithEvents)
        //    //{
        //    //    await _dispatcher.DispatchEventsAsync(entity);
        //    //}

        //    return result;
        //}
    }
}
