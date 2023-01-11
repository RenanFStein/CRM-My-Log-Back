using Microsoft.EntityFrameworkCore;
using MyLog.Models;

namespace MyLog.Data
{
    public class LogContext : DbContext
    {
        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Frete>()
                .HasOne(frete => frete.Veiculo)
                .WithMany(veiculo => veiculo.Fretes)
                .HasForeignKey(frete => frete.VeiculoId);
        }

        public DbSet<Frete> Fretes { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}