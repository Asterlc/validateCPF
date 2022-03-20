using Microsoft.EntityFrameworkCore;
using cpfSupera.Models;

namespace cpfSupera.Database
{
    public class CPFContext : DbContext
    {
        public CPFContext(DbContextOptions<CPFContext> options) : base(options)
        {

        }
        public DbSet<cpfModel> cpfModel { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var document = modelBuilder.Entity<cpfModel>();
            document.ToTable("tb_document");
            document.HasKey(x => x.Id);
            document.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            document.Property(x => x.Name).HasColumnName("name").ValueGeneratedOnAdd().IsRequired();
            document.Property(x => x.Document).HasColumnName("document").ValueGeneratedOnAdd().IsRequired();
            document.Property(x => x.Register).HasColumnName("register").ValueGeneratedOnAdd();
        }
    }
}