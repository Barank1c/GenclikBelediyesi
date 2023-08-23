using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GenclikBelediyesi.Models.Database
{
    public partial class GenclikBelediyesiContext : IdentityDbContext<TblUye>
	{
        public GenclikBelediyesiContext(DbContextOptions<GenclikBelediyesiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblEtkinlikler> TblEtkinlikler { get; set; }
        public virtual DbSet<TblHaberler> TblHaberler { get; set; }
        public virtual DbSet<TblUye> TblUye { get; set; }
        public virtual DbSet<Tbiletisim> Tbiletisim { get; set; }
        public virtual DbSet<TblAdmin> TblAdmin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });

			modelBuilder.Entity<TblEtkinlikler>(entity =>
            {
                entity.HasKey(e => e.EtkinlikId)
                    .HasName("PK_Etkinlikler");

                entity.ToTable("Tbl_Etkinlikler");

                entity.Property(e => e.BasTarih).HasColumnType("datetime");

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.BitTarih).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarih)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Foto1).IsRequired();

                entity.Property(e => e.Foto2).IsRequired();

                entity.Property(e => e.Foto3).IsRequired();

                entity.Property(e => e.Foto4).IsRequired();

                entity.Property(e => e.Foto5).IsRequired();

                entity.Property(e => e.Foto6).IsRequired();

                entity.Property(e => e.Foto7).IsRequired();

                entity.Property(e => e.Foto8).IsRequired();

                entity.Property(e => e.Icerik).IsRequired();

                entity.Property(e => e.Icerik1).IsRequired();

                entity.Property(e => e.Icerik2).IsRequired();
            });

            modelBuilder.Entity<TblHaberler>(entity =>
            {
                entity.HasKey(e => e.HaberId)
                    .HasName("PK_Haberler");

                entity.ToTable("Tbl_Haberler");

                entity.Property(e => e.BasTarih).HasColumnType("datetime");

                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.BitTarih).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarih)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Foto1).IsRequired();

                entity.Property(e => e.Foto2).IsRequired();

                entity.Property(e => e.Foto3).IsRequired();

                entity.Property(e => e.Foto4).IsRequired();

                entity.Property(e => e.Foto5).IsRequired();

                entity.Property(e => e.Foto6).IsRequired();

                entity.Property(e => e.Foto7).IsRequired();

                entity.Property(e => e.Foto8).IsRequired();

                entity.Property(e => e.Icerik).IsRequired();

                entity.Property(e => e.Icerik1).IsRequired();

                entity.Property(e => e.Icerik2).IsRequired();
            });

            modelBuilder.Entity<TblUye>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK_Uye");
                  

                entity.ToTable("Tbl_Uye");

                entity.Property(e => e.DogumTarih).HasColumnType("date");


                

            });

            modelBuilder.Entity<Tbiletisim>(entity =>
            {
                entity.HasKey(e => e.TbiletisimId)
                    .HasName("PK_Tbiletisim");

                entity.ToTable("Tbiletisim");

                entity.Property(e => e.iletisimAdiniz).IsRequired();

                entity.Property(e => e.iletisimSoyadiniz).IsRequired();

                entity.Property(e => e.iletisimMailiniz).IsRequired();

                entity.Property(e => e.iletisimMesaj).HasColumnType("text").IsRequired();

                
            });

            modelBuilder.Entity<TblAdmin>(entity =>
            {
                entity.HasKey(e => e.TblAdminId)
                    .HasName("PK_TblAdmin");

                entity.ToTable("TblAdmin");

                entity.Property(e => e.adminid).IsRequired();

                entity.Property(e => e.Sifre3).IsRequired();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
