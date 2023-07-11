using JPVApiCrud.Model;
using JPVApiCrud.Repository;
using Microsoft.EntityFrameworkCore;

public class JpvContext : DbContext
{
    public DbSet<Candidato> Candidatos { get; set; }
    public JpvContext(DbContextOptions<JpvContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConfigurationCandidato());
        base.OnModelCreating(modelBuilder);
    }
}