using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IT_Projektas_Backend.Models
{
    public partial class it_projektasContext : DbContext
    {
        public it_projektasContext()
        {
        }

        public it_projektasContext(DbContextOptions<it_projektasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ataskaitos> Ataskaitos { get; set; }
        public virtual DbSet<Darbuotojai> Darbuotojai { get; set; }
        public virtual DbSet<Gyvunai> Gyvunai { get; set; }
        public virtual DbSet<InventoriausRezervacijos> InventoriausRezervacijos { get; set; }
        public virtual DbSet<Inventorius> Inventorius { get; set; }
        public virtual DbSet<Klientai> Klientai { get; set; }
        public virtual DbSet<Paslaugos> Paslaugos { get; set; }
        public virtual DbSet<PaslaugosRezervacija> PaslaugosRezervacija { get; set; }
        public virtual DbSet<Profiliai> Profiliai { get; set; }
        public virtual DbSet<ProfilioNuotraukos> ProfilioNuotraukos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;user id=root;database=it_projektas");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ataskaitos>(entity =>
            {
                entity.ToTable("ataskaitos");

                entity.HasIndex(e => e.FkKlientaiidKlientai)
                    .HasName("fk_klientaiid_klientai")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ApsilankymuSarasa)
                    .HasColumnName("apsilankymu_sarasa")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Dokumentai)
                    .HasColumnName("dokumentai")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkKlientaiidKlientai)
                    .HasColumnName("fk_klientaiid_klientai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GyvunuIsrasai)
                    .HasColumnName("gyvunu_israsai")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.GyvunuIstorija)
                    .HasColumnName("gyvunu_istorija")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.RegsitracijosData)
                    .HasColumnName("regsitracijos_data")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkKlientaiidKlientaiNavigation)
                    .WithOne(p => p.Ataskaitos)
                    .HasForeignKey<Ataskaitos>(d => d.FkKlientaiidKlientai)
                    .HasConstraintName("generuoja");
            });

            modelBuilder.Entity<Darbuotojai>(entity =>
            {
                entity.HasKey(e => e.IdDarbuotojai)
                    .HasName("PRIMARY");

                entity.ToTable("darbuotojai");

                entity.HasIndex(e => e.FkProfiliaiid)
                    .HasName("fk_profiliaiid")
                    .IsUnique();

                entity.Property(e => e.IdDarbuotojai)
                    .HasColumnName("id_darbuotojai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkProfiliaiid)
                    .HasColumnName("fk_profiliaiid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsAdmin)
                    .HasColumnName("is_admin")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Pozicija)
                    .IsRequired()
                    .HasColumnName("pozicija")
                    .HasMaxLength(255);

                entity.HasOne(d => d.FkProfiliai)
                    .WithOne(p => p.Darbuotojai)
                    .HasForeignKey<Darbuotojai>(d => d.FkProfiliaiid)
                    .HasConstraintName("turi_1");
            });

            modelBuilder.Entity<Gyvunai>(entity =>
            {
                entity.ToTable("gyvunai");

                entity.HasIndex(e => e.FkKlientaiidKlientai)
                    .HasName("priklauso_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Amzius)
                    .HasColumnName("amzius")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkKlientaiidKlientai)
                    .HasColumnName("fk_klientaiid_klientai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lytis)
                    .HasColumnName("lytis")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Rusis)
                    .HasColumnName("rusis")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Svoris)
                    .HasColumnName("svoris")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Vardas)
                    .HasColumnName("vardas")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Veisle)
                    .HasColumnName("veisle")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkKlientaiidKlientaiNavigation)
                    .WithMany(p => p.Gyvunai)
                    .HasForeignKey(d => d.FkKlientaiidKlientai)
                    .HasConstraintName("priklauso_2");
            });

            modelBuilder.Entity<InventoriausRezervacijos>(entity =>
            {
                entity.ToTable("inventoriaus_rezervacijos");

                entity.HasIndex(e => e.FkDarbuotojaiidDarbuotojai)
                    .HasName("registruoja");

                entity.HasIndex(e => e.FkInventoriusid)
                    .HasName("itraukia_1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasMaxLength(255);

                entity.Property(e => e.FkDarbuotojaiidDarbuotojai)
                    .HasColumnName("fk_darbuotojaiid_darbuotojai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkInventoriusid)
                    .HasColumnName("fk_inventoriusid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LaikasIki)
                    .IsRequired()
                    .HasColumnName("laikas_iki")
                    .HasMaxLength(255);

                entity.Property(e => e.LaikasNuo)
                    .IsRequired()
                    .HasColumnName("laikas_nuo")
                    .HasMaxLength(255);

                entity.HasOne(d => d.FkDarbuotojaiidDarbuotojaiNavigation)
                    .WithMany(p => p.InventoriausRezervacijos)
                    .HasForeignKey(d => d.FkDarbuotojaiidDarbuotojai)
                    .HasConstraintName("registruoja");

                entity.HasOne(d => d.FkInventorius)
                    .WithMany(p => p.InventoriausRezervacijos)
                    .HasForeignKey(d => d.FkInventoriusid)
                    .HasConstraintName("itraukia_1");
            });

            modelBuilder.Entity<Inventorius>(entity =>
            {
                entity.ToTable("inventorius");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GaliojimoLaikasIki)
                    .HasColumnName("galiojimo_laikas_iki")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.GaliojimoLaikasNuo)
                    .HasColumnName("galiojimo_laikas_nuo")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.KabinetoNumeris)
                    .HasColumnName("kabineto_numeris")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Kiekis)
                    .HasColumnName("kiekis")
                    .HasColumnType("int(11)");

                entity.Property(e => e.KiekisLaisvu)
                    .HasColumnName("kiekis_laisvu")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Pavadinimas)
                    .IsRequired()
                    .HasColumnName("pavadinimas")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Klientai>(entity =>
            {
                entity.HasKey(e => e.IdKlientai)
                    .HasName("PRIMARY");

                entity.ToTable("klientai");

                entity.HasIndex(e => e.FkProfiliaiid)
                    .HasName("fk_profiliaiid")
                    .IsUnique();

                entity.Property(e => e.IdKlientai)
                    .HasColumnName("id_klientai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkProfiliaiid)
                    .HasColumnName("fk_profiliaiid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GyvunuKiekis)
                    .HasColumnName("gyvunu_kiekis")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkProfiliai)
                    .WithOne(p => p.Klientai)
                    .HasForeignKey<Klientai>(d => d.FkProfiliaiid)
                    .HasConstraintName("turi_2");
            });

            modelBuilder.Entity<Paslaugos>(entity =>
            {
                entity.ToTable("paslaugos");

                entity.HasIndex(e => e.FkDarbuotojaiidDarbuotojai)
                    .HasName("fk_darbuotojaiid_darbuotojai")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aprasymas)
                    .HasColumnName("aprasymas")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkDarbuotojaiidDarbuotojai)
                    .HasColumnName("fk_darbuotojaiid_darbuotojai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kaina)
                    .HasColumnName("kaina")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Narkoze)
                    .HasColumnName("narkoze")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Rizika)
                    .HasColumnName("rizika")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Trukme)
                    .HasColumnName("trukme")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkDarbuotojaiidDarbuotojaiNavigation)
                    .WithOne(p => p.Paslaugos)
                    .HasForeignKey<Paslaugos>(d => d.FkDarbuotojaiidDarbuotojai)
                    .HasConstraintName("atsakingas_uz");
            });

            modelBuilder.Entity<PaslaugosRezervacija>(entity =>
            {
                entity.ToTable("paslaugos_rezervacija");

                entity.HasIndex(e => e.FkDarbuotojaiidDarbuotojai)
                    .HasName("priskirta");

                entity.HasIndex(e => e.FkKlientaiidKlientai)
                    .HasName("pasirenka");

                entity.HasIndex(e => e.FkPaslaugaid)
                    .HasName("itraukia_2");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasMaxLength(255);

                entity.Property(e => e.FkDarbuotojaiidDarbuotojai)
                    .HasColumnName("fk_darbuotojaiid_darbuotojai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkKlientaiidKlientai)
                    .HasColumnName("fk_klientaiid_klientai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPaslaugaid)
                    .HasColumnName("fk_paslaugaid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LaikasIki)
                    .IsRequired()
                    .HasColumnName("laikas_iki")
                    .HasMaxLength(255);

                entity.Property(e => e.LaikasNuo)
                    .IsRequired()
                    .HasColumnName("laikas_nuo")
                    .HasMaxLength(255);

                entity.HasOne(d => d.FkDarbuotojaiidDarbuotojaiNavigation)
                    .WithMany(p => p.PaslaugosRezervacija)
                    .HasForeignKey(d => d.FkDarbuotojaiidDarbuotojai)
                    .HasConstraintName("priskirta");

                entity.HasOne(d => d.FkKlientaiidKlientaiNavigation)
                    .WithMany(p => p.PaslaugosRezervacija)
                    .HasForeignKey(d => d.FkKlientaiidKlientai)
                    .HasConstraintName("pasirenka");

                entity.HasOne(d => d.FkPaslauga)
                    .WithMany(p => p.PaslaugosRezervacija)
                    .HasForeignKey(d => d.FkPaslaugaid)
                    .HasConstraintName("itraukia_2");
            });

            modelBuilder.Entity<Profiliai>(entity =>
            {
                entity.ToTable("profiliai");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Adresas)
                    .IsRequired()
                    .HasColumnName("adresas")
                    .HasMaxLength(255);

                entity.Property(e => e.AsmensKodas)
                    .IsRequired()
                    .HasColumnName("asmens_kodas")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Pastas)
                    .IsRequired()
                    .HasColumnName("pastas")
                    .HasMaxLength(255);

                entity.Property(e => e.Pavarde)
                    .IsRequired()
                    .HasColumnName("pavarde")
                    .HasMaxLength(255);

                entity.Property(e => e.TelefonoNr)
                    .IsRequired()
                    .HasColumnName("telefono_nr")
                    .HasMaxLength(255);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(255);

                entity.Property(e => e.Vardas)
                    .IsRequired()
                    .HasColumnName("vardas")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ProfilioNuotraukos>(entity =>
            {
                entity.ToTable("profilio_nuotraukos");

                entity.HasIndex(e => e.FkProfiliaiid)
                    .HasName("fk_profiliaiid")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FailoDydis)
                    .HasColumnName("failo_dydis")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.FkProfiliaiid)
                    .HasColumnName("fk_profiliaiid")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Formatas)
                    .HasColumnName("formatas")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Kelias)
                    .HasColumnName("kelias")
                    .HasMaxLength(255)
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.FkProfiliai)
                    .WithOne(p => p.ProfilioNuotraukos)
                    .HasForeignKey<ProfilioNuotraukos>(d => d.FkProfiliaiid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("priklauso_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
