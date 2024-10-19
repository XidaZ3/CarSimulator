using CarSimulator.Models.Cars.Bodies;
using Microsoft.EntityFrameworkCore;

namespace CarSimulator.Models.Cars
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Wheel> Wheels { get; set; }
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Body> SteeringWheel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(c => c.Wheels)
                .WithOne(w => w.Car)
                .HasForeignKey(w => w.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
               .HasOne(c => c.Body)
               .WithOne(b => b.Car)
               .HasForeignKey<Body>(b => b.CarId)
               .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Body>()
               .HasOne(b => b.SteeringWheel)
               .WithOne(s => s.Body)
               .HasForeignKey<SteeringWheel>(s => s.BodyId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Body>()
              .HasOne(b => b.Accelerator) 
              .WithOne(a => a.Body) 
              .HasForeignKey<Accelerator>(a => a.BodyId)
              .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Body>()
            .HasOne(bo => bo.Brake)
            .WithOne(br => br.Body) 
            .HasForeignKey<Brake>(a => a.BodyId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Body>()
            .HasOne(b => b.Tank)
            .WithOne(t => t.Body)
            .HasForeignKey<Tank>(t => t.BodyId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Body>()
           .HasOne(b => b.Engine)
           .WithOne(e => e.Body)
           .HasForeignKey<Engine>(e => e.BodyId)
           .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
