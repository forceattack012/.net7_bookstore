using BookApi.Domain.Entities;
using BookApi.Infrastructure.Context.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookApi.Infrastructure.Context
{
    public class BookAppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<Book> Book { get; set; }

        public BookAppDbContext(){

        }

        public BookAppDbContext(DbContextOptions<BookAppDbContext> options): base(options)
        {
     
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //For Migration
            //var connectionString = "server=localhost;database=bookstore;user=root;password=123456789";
            //options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 29)));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
        }
    }
}
