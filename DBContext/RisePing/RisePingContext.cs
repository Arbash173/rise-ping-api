
using Microsoft.EntityFrameworkCore;
using RisePingAPIs.Models;
public class RisePingContext : DbContext
{
    public RisePingContext(DbContextOptions<RisePingContext> options) : base(options)
    {
    }

    public DbSet<RoleSetup> RoleSetups { get; set; }
    public DbSet<DeptSetup> DeptSetups { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<NotificatoinType> NotificatoinTypes { get; set; }
    public DbSet<EventRecord> EventRecords { get; set; }
}