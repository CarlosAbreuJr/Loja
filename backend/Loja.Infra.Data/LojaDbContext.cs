using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infra.Data
{
    public class LojaDbContext:DbContext
    {
        public DbSet<Product> Produtos { get; set; }
        public DbSet<Grupos> Grupos { get; set; }
        public DbSet<Fabricantes> Fabricantes { get; set; }
        public DbSet<Clients> Clientes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public LojaDbContext(DbContextOptions<LojaDbContext> opt) : base(opt)
        {
            //Database.SetInitializer<LojaDbContext>(new CreateDatabaseIfNotExists<LojaDbContext>());

            ////Database.SetInitializer<LojaDbContext>(new DropCreateDatabaseIfModelChanges<LojaDbContext>());
            ////Database.SetInitializer<LojaDbContext>(new DropCreateDatabaseAlways<LojaDbContext>());
            ////Database.SetInitializer<LojaDbContext>(new SchoolDBInitializer());
            //Database.EnsureCreated();
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        }

        //public override int SaveChanges()
        //{
        //    return base.SaveChanges();
        //}

    }
}
