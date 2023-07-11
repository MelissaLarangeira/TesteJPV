using JPVApiCrud.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JPVApiCrud.Repository
{
    public class ConfigurationCandidato : IEntityTypeConfiguration<Candidato>
    {
        void IEntityTypeConfiguration<Candidato>.Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.HasKey(x => x.CdCandidato);

            builder
                .Property(nameof(Candidato.CdCandidato))
                .IsRequired()
                .HasColumnName("CD_CANDIDATO")
                .HasColumnType("int");

            builder
             .Property(nameof(Candidato.NmCandidato))
             .IsRequired()
             .HasColumnName("NM_CANDIDATO")
             .HasColumnType("VARCHAR(100)");

            builder
               .Property(nameof(Candidato.DtNascCandidato))
               .IsRequired()
               .HasColumnName("DT_NASC_CANDIDATO")
               .HasColumnType("DATE");

            builder
               .Property(nameof(Candidato.VlRendaCandidato))
               .IsRequired()
               .HasColumnName("VL_RENDA_CANDIDATO")
               .HasColumnType("DECIMAL(10, 2)");

            builder
              .Property(nameof(Candidato.CdCpf))
              .IsRequired()
              .HasColumnName("CD_CPF")
              .HasColumnType("CHAR(11)");

        }
    }
}