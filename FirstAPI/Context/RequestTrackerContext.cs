using FirstAPI.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Context
{
    public class RequestTrackerContext:DbContext
    {
        public RequestTrackerContext(DbContextOptions options):base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data source = TEJAS; Integrated Security = true; Initial catalog = dbRequestTracker");
            
        //}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Request>()
                .HasOne(r => r.Issuer)
                .WithMany(r => r.RaisedRequests)
                .HasForeignKey(r => r.Issuer_Id)
                .IsRequired();


            modelBuilder.Entity<Request>()
                .HasOne(r => r.Resolver)
                .WithMany(r => r.ResolvedRequests)
                .HasForeignKey(r => r.Resolver_Id);

            

        }
    }
}
