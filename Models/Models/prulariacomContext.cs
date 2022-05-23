using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Models.Models
{
    public partial class prulariacomContext : DbContext
    {
        public prulariacomContext()
        {
        }

        public prulariacomContext(DbContextOptions<prulariacomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actiecode> Actiecodes { get; set; }
        public virtual DbSet<Adressen> Adressens { get; set; }
        public virtual DbSet<Artikelcategorieen> Artikelcategorieens { get; set; }
        public virtual DbSet<Artikelen> Artikelens { get; set; }
        public virtual DbSet<Artikelleveranciersinfolijnen> Artikelleveranciersinfolijnens { get; set; }
        public virtual DbSet<Bestellijnen> Bestellijnens { get; set; }
        public virtual DbSet<Bestellingen> Bestellingens { get; set; }
        public virtual DbSet<Bestellingsstatussen> Bestellingsstatussens { get; set; }
        public virtual DbSet<Betaalwijze> Betaalwijzes { get; set; }
        public virtual DbSet<Categorieen> Categorieens { get; set; }
        public virtual DbSet<Chatgesprekken> Chatgesprekkens { get; set; }
        public virtual DbSet<Chatgespreklijnen> Chatgespreklijnens { get; set; }
        public virtual DbSet<Contactpersonen> Contactpersonens { get; set; }
        public virtual DbSet<Eventmessage> Eventmessages { get; set; }
        public virtual DbSet<Eventwachtrijartikelen> Eventwachtrijartikelens { get; set; }
        public virtual DbSet<Gebruikersaccount> Gebruikersaccounts { get; set; }
        public virtual DbSet<Inkomendeleveringen> Inkomendeleveringens { get; set; }
        public virtual DbSet<Inkomendeleveringslijnen> Inkomendeleveringslijnens { get; set; }
        public virtual DbSet<Klanten> Klantens { get; set; }
        public virtual DbSet<Klantenreview> Klantenreviews { get; set; }
        public virtual DbSet<Leverancier> Leveranciers { get; set; }
        public virtual DbSet<Magazijnplaatsen> Magazijnplaatsens { get; set; }
        public virtual DbSet<Natuurlijkepersonen> Natuurlijkepersonens { get; set; }
        public virtual DbSet<Personeelsleden> Personeelsledens { get; set; }
        public virtual DbSet<Personeelslidaccount> Personeelslidaccounts { get; set; }
        public virtual DbSet<Personeelslidsecuritygroepen> Personeelslidsecuritygroepens { get; set; }
        public virtual DbSet<Plaatsen> Plaatsens { get; set; }
        public virtual DbSet<Rechtspersonen> Rechtspersonens { get; set; }
        public virtual DbSet<Securitygroepen> Securitygroepens { get; set; }
        public virtual DbSet<Uitgaandeleveringen> Uitgaandeleveringens { get; set; }
        public virtual DbSet<Uitgaandeleveringsstatussen> Uitgaandeleveringsstatussens { get; set; }
        public virtual DbSet<Veelgesteldevragenartikel> Veelgesteldevragenartikels { get; set; }
        public virtual DbSet<Wishlistitem> Wishlistitems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=Celeste;database=prulariacom");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actiecode>(entity =>
            {
                entity.ToTable("actiecodes");

                entity.Property(e => e.ActiecodeId).HasColumnName("actiecodeId");

                entity.Property(e => e.GeldigTotDatum)
                    .HasColumnType("date")
                    .HasColumnName("geldigTotDatum");

                entity.Property(e => e.GeldigVanDatum)
                    .HasColumnType("date")
                    .HasColumnName("geldigVanDatum");

                entity.Property(e => e.IsEenmalig).HasColumnName("isEenmalig");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");
            });

            modelBuilder.Entity<Adressen>(entity =>
            {
                entity.HasKey(e => e.AdresId)
                    .HasName("PRIMARY");

                entity.ToTable("adressen");

                entity.HasIndex(e => e.PlaatsId, "fk_Adressen_Plaatsen_idx");

                entity.Property(e => e.AdresId).HasColumnName("adresId");

                entity.Property(e => e.Actief)
                    .IsRequired()
                    .HasColumnName("actief")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Bus)
                    .HasMaxLength(5)
                    .HasColumnName("bus");

                entity.Property(e => e.HuisNummer)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("huisNummer");

                entity.Property(e => e.PlaatsId).HasColumnName("plaatsId");

                entity.Property(e => e.Straat)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("straat");

                entity.HasOne(d => d.Plaats)
                    .WithMany(p => p.Adressens)
                    .HasForeignKey(d => d.PlaatsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Adressen_Plaatsen");
            });

            modelBuilder.Entity<Artikelcategorieen>(entity =>
            {
                entity.HasKey(e => new { e.CategorieId, e.ArtikelId })
                    .HasName("PRIMARY");

                entity.ToTable("artikelcategorieen");

                entity.HasIndex(e => e.ArtikelId, "fk_ArtikelCategorieen_Artikelen1_idx");

                entity.Property(e => e.CategorieId).HasColumnName("categorieId");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Artikelcategorieens)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ArtikelCategorieen_Artikelen1");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Artikelcategorieens)
                    .HasForeignKey(d => d.CategorieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ArtikelCategorieen_Categorieen1");
            });

            modelBuilder.Entity<Artikelen>(entity =>
            {
                entity.HasKey(e => e.ArtikelId)
                    .HasName("PRIMARY");

                entity.ToTable("artikelen");

                entity.HasIndex(e => e.Ean, "ean_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.AantalBesteldLeverancier).HasColumnName("aantalBesteldLeverancier");

                entity.Property(e => e.Beschrijving)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("beschrijving");

                entity.Property(e => e.Bestelpeil).HasColumnName("bestelpeil");

                entity.Property(e => e.Ean)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("ean");

                entity.Property(e => e.GewichtInGram).HasColumnName("gewichtInGram");

                entity.Property(e => e.Levertijd)
                    .HasColumnName("levertijd")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MaxAantalInMagazijnPlaats).HasColumnName("maxAantalInMagazijnPLaats");

                entity.Property(e => e.MaximumVoorraad).HasColumnName("maximumVoorraad");

                entity.Property(e => e.MinimumVoorraad).HasColumnName("minimumVoorraad");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");

                entity.Property(e => e.Prijs)
                    .HasColumnType("decimal(18,5)")
                    .HasColumnName("prijs");

                entity.Property(e => e.Voorraad).HasColumnName("voorraad");
            });

            modelBuilder.Entity<Artikelleveranciersinfolijnen>(entity =>
            {
                entity.HasKey(e => new { e.ArtikelLeveranciersInfoLijnId, e.ArtikelId })
                    .HasName("PRIMARY");

                entity.ToTable("artikelleveranciersinfolijnen");

                entity.HasIndex(e => e.ArtikelId, "fk_ArtikelLeveranciersInfoLijnen_Artikelen1_idx");

                entity.Property(e => e.ArtikelLeveranciersInfoLijnId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("artikelLeveranciersInfoLijnId");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.Antwoord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("antwoord");

                entity.Property(e => e.Vraag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("vraag");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Artikelleveranciersinfolijnens)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ArtikelLeveranciersInfoLijnen_Artikelen1");
            });

            modelBuilder.Entity<Bestellijnen>(entity =>
            {
                entity.HasKey(e => e.BestellijnId)
                    .HasName("PRIMARY");

                entity.ToTable("bestellijnen");

                entity.HasIndex(e => e.ArtikelId, "fk_Bestellijnen_Artikelen1_idx");

                entity.HasIndex(e => e.BestelId, "fk_Bestellijnen_Bestellingen1_idx");

                entity.Property(e => e.BestellijnId).HasColumnName("bestellijnId");

                entity.Property(e => e.AantalBesteld).HasColumnName("aantalBesteld");

                entity.Property(e => e.AantalGeannuleerd).HasColumnName("aantalGeannuleerd");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.BestelId).HasColumnName("bestelId");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Bestellijnens)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Bestellijnen_Artikelen1");

                entity.HasOne(d => d.Bestel)
                    .WithMany(p => p.Bestellijnens)
                    .HasForeignKey(d => d.BestelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Bestellijnen_Bestellingen1");
            });

            modelBuilder.Entity<Bestellingen>(entity =>
            {
                entity.HasKey(e => e.BestelId)
                    .HasName("PRIMARY");

                entity.ToTable("bestellingen");

                entity.HasIndex(e => e.FacturatieAdresId, "fk_Bestellingen_Adressen1_idx");

                entity.HasIndex(e => e.LeveringsAdresId, "fk_Bestellingen_Adressen2_idx");

                entity.HasIndex(e => e.BestellingsStatusId, "fk_Bestellingen_BestellingsStatussen1_idx");

                entity.HasIndex(e => e.BetaalwijzeId, "fk_Bestellingen_Betaalwijzes1_idx");

                entity.HasIndex(e => e.KlantId, "fk_Bestellingen_Klanten1_idx");

                entity.Property(e => e.BestelId).HasColumnName("bestelId");

                entity.Property(e => e.ActiecodeGebruikt).HasColumnName("actiecodeGebruikt");

                entity.Property(e => e.Annulatie).HasColumnName("annulatie");

                entity.Property(e => e.Annulatiedatum)
                    .HasColumnType("date")
                    .HasColumnName("annulatiedatum");

                entity.Property(e => e.Bedrijfsnaam)
                    .HasMaxLength(45)
                    .HasColumnName("bedrijfsnaam");

                entity.Property(e => e.BestellingsStatusId).HasColumnName("bestellingsStatusId");

                entity.Property(e => e.Betaald).HasColumnName("betaald");

                entity.Property(e => e.BetaalwijzeId).HasColumnName("betaalwijzeId");

                entity.Property(e => e.Betalingscode)
                    .HasMaxLength(45)
                    .HasColumnName("betalingscode");

                entity.Property(e => e.BtwNummer)
                    .HasMaxLength(45)
                    .HasColumnName("btwNummer");

                entity.Property(e => e.FacturatieAdresId).HasColumnName("facturatieAdresId");

                entity.Property(e => e.Familienaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("familienaam");

                entity.Property(e => e.KlantId).HasColumnName("klantId");

                entity.Property(e => e.LeveringsAdresId).HasColumnName("leveringsAdresId");

                entity.Property(e => e.Terugbetalingscode)
                    .HasMaxLength(45)
                    .HasColumnName("terugbetalingscode");

                entity.Property(e => e.Voornaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("voornaam");

                entity.HasOne(d => d.BestellingsStatus)
                    .WithMany(p => p.Bestellingens)
                    .HasForeignKey(d => d.BestellingsStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Bestellingen_BestellingsStatussen1");

                entity.HasOne(d => d.Betaalwijze)
                    .WithMany(p => p.Bestellingens)
                    .HasForeignKey(d => d.BetaalwijzeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Bestellingen_Betaalwijzes1");

                entity.HasOne(d => d.FacturatieAdres)
                    .WithMany(p => p.BestellingenFacturatieAdres)
                    .HasForeignKey(d => d.FacturatieAdresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Bestellingen_Adressen1");

                entity.HasOne(d => d.Klant)
                    .WithMany(p => p.Bestellingens)
                    .HasForeignKey(d => d.KlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Bestellingen_Klanten1");

                entity.HasOne(d => d.LeveringsAdres)
                    .WithMany(p => p.BestellingenLeveringsAdres)
                    .HasForeignKey(d => d.LeveringsAdresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Bestellingen_Adressen2");
            });

            modelBuilder.Entity<Bestellingsstatussen>(entity =>
            {
                entity.HasKey(e => e.BestellingsStatusId)
                    .HasName("PRIMARY");

                entity.ToTable("bestellingsstatussen");

                entity.Property(e => e.BestellingsStatusId).HasColumnName("bestellingsStatusId");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");
            });

            modelBuilder.Entity<Betaalwijze>(entity =>
            {
                entity.ToTable("betaalwijzes");

                entity.Property(e => e.BetaalwijzeId).HasColumnName("betaalwijzeId");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");
            });

            modelBuilder.Entity<Categorieen>(entity =>
            {
                entity.HasKey(e => e.CategorieId)
                    .HasName("PRIMARY");

                entity.ToTable("categorieen");

                entity.HasIndex(e => e.HoofdCategorieId, "fk_Categorieen_Categorieen1_idx");

                entity.Property(e => e.CategorieId).HasColumnName("categorieId");

                entity.Property(e => e.HoofdCategorieId).HasColumnName("hoofdCategorieId");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");

                entity.HasOne(d => d.HoofdCategorie)
                    .WithMany(p => p.InverseHoofdCategorie)
                    .HasForeignKey(d => d.HoofdCategorieId)
                    .HasConstraintName("fk_Categorieen_Categorieen1");
            });

            modelBuilder.Entity<Chatgesprekken>(entity =>
            {
                entity.HasKey(e => e.ChatgesprekId)
                    .HasName("PRIMARY");

                entity.ToTable("chatgesprekken");

                entity.HasIndex(e => e.GebruikersAccountId, "fk_ChatGesprekken_GebruikersAccounts1_idx");

                entity.Property(e => e.ChatgesprekId).HasColumnName("chatgesprekId");

                entity.Property(e => e.GebruikersAccountId).HasColumnName("gebruikersAccountId");

                entity.HasOne(d => d.GebruikersAccount)
                    .WithMany(p => p.Chatgesprekkens)
                    .HasForeignKey(d => d.GebruikersAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ChatGesprekken_GebruikersAccounts1");
            });

            modelBuilder.Entity<Chatgespreklijnen>(entity =>
            {
                entity.HasKey(e => e.ChatgesprekLijnId)
                    .HasName("PRIMARY");

                entity.ToTable("chatgespreklijnen");

                entity.HasIndex(e => e.ChatgesprekId, "fk_ChatgesprekLijnen_ChatGesprekken1_idx");

                entity.HasIndex(e => e.GebruikersAccountId, "fk_ChatgesprekLijnen_GebruikersAccounts1_idx");

                entity.HasIndex(e => e.PersoneelslidAccountId, "fk_ChatgesprekLijnen_PersoneelslidAccounts1_idx");

                entity.Property(e => e.ChatgesprekLijnId).HasColumnName("chatgesprekLijnId");

                entity.Property(e => e.Bericht)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("bericht");

                entity.Property(e => e.ChatgesprekId).HasColumnName("chatgesprekId");

                entity.Property(e => e.GebruikersAccountId)
                    .HasColumnName("gebruikersAccountId")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PersoneelslidAccountId)
                    .HasColumnName("personeelslidAccountId")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Chatgesprek)
                    .WithMany(p => p.Chatgespreklijnens)
                    .HasForeignKey(d => d.ChatgesprekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ChatgesprekLijnen_ChatGesprekken1");

                entity.HasOne(d => d.GebruikersAccount)
                    .WithMany(p => p.Chatgespreklijnens)
                    .HasForeignKey(d => d.GebruikersAccountId)
                    .HasConstraintName("fk_ChatgesprekLijnen_GebruikersAccounts1");

                entity.HasOne(d => d.PersoneelslidAccount)
                    .WithMany(p => p.Chatgespreklijnens)
                    .HasForeignKey(d => d.PersoneelslidAccountId)
                    .HasConstraintName("fk_ChatgesprekLijnen_PersoneelslidAccounts1");
            });

            modelBuilder.Entity<Contactpersonen>(entity =>
            {
                entity.HasKey(e => e.ContactpersoonId)
                    .HasName("PRIMARY");

                entity.ToTable("contactpersonen");

                entity.HasIndex(e => e.GebruikersAccountId, "fk_Contactpersonen_GebruikersAccounts_idx");

                entity.HasIndex(e => e.KlantId, "fk_Contactpersonen_Rechtspersonen1_idx");

                entity.Property(e => e.ContactpersoonId).HasColumnName("contactpersoonId");

                entity.Property(e => e.Familienaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("familienaam");

                entity.Property(e => e.Functie)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("functie");

                entity.Property(e => e.GebruikersAccountId).HasColumnName("gebruikersAccountId");

                entity.Property(e => e.KlantId).HasColumnName("klantId");

                entity.Property(e => e.Voornaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("voornaam");

                entity.HasOne(d => d.GebruikersAccount)
                    .WithMany(p => p.Contactpersonens)
                    .HasForeignKey(d => d.GebruikersAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Contactpersonen_GebruikersAccounts1");

                entity.HasOne(d => d.Klant)
                    .WithMany(p => p.Contactpersonens)
                    .HasForeignKey(d => d.KlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Contactpersonen_Rechtspersonen1");
            });

            modelBuilder.Entity<Eventmessage>(entity =>
            {
                entity.ToTable("eventmessages");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("message");
            });

            modelBuilder.Entity<Eventwachtrijartikelen>(entity =>
            {
                entity.HasKey(e => e.ArtikelId)
                    .HasName("PRIMARY");

                entity.ToTable("eventwachtrijartikelen");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.Aantal).HasColumnName("aantal");

                entity.Property(e => e.MaxAantalInMagazijnPlaats).HasColumnName("maxAantalInMagazijnPlaats");
            });

            modelBuilder.Entity<Gebruikersaccount>(entity =>
            {
                entity.ToTable("gebruikersaccounts");

                entity.HasIndex(e => e.Emailadres, "gebrukersnaam_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.GebruikersAccountId).HasColumnName("gebruikersAccountId");

                entity.Property(e => e.Disabled).HasColumnName("disabled");

                entity.Property(e => e.Emailadres)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("emailadres");

                entity.Property(e => e.Paswoord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("paswoord");
            });

            modelBuilder.Entity<Inkomendeleveringen>(entity =>
            {
                entity.HasKey(e => e.InkomendeLeveringsId)
                    .HasName("PRIMARY");

                entity.ToTable("inkomendeleveringen");

                entity.HasIndex(e => e.LeveranciersId, "fk_InkomendeLeveringen_Leveranciers1");

                entity.HasIndex(e => e.OntvangerPersoneelslidId, "fk_InkomendeLeveringen_Personeelsleden1_idx");

                entity.Property(e => e.InkomendeLeveringsId).HasColumnName("inkomendeLeveringsId");

                entity.Property(e => e.LeverDatum)
                    .HasColumnType("date")
                    .HasColumnName("leverDatum");

                entity.Property(e => e.LeveranciersId).HasColumnName("leveranciersId");

                entity.Property(e => e.LeveringsbonNummer)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("leveringsbonNummer");

                entity.Property(e => e.Leveringsbondatum)
                    .HasColumnType("date")
                    .HasColumnName("leveringsbondatum");

                entity.Property(e => e.OntvangerPersoneelslidId).HasColumnName("ontvangerPersoneelslidId");

                entity.HasOne(d => d.Leveranciers)
                    .WithMany(p => p.Inkomendeleveringens)
                    .HasForeignKey(d => d.LeveranciersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringen_Leveranciers1");

                entity.HasOne(d => d.OntvangerPersoneelslid)
                    .WithMany(p => p.Inkomendeleveringens)
                    .HasForeignKey(d => d.OntvangerPersoneelslidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringen_Personeelsleden1");
            });

            modelBuilder.Entity<Inkomendeleveringslijnen>(entity =>
            {
                entity.HasKey(e => new { e.InkomendeLeveringsId, e.ArtikelId, e.MagazijnPlaatsId })
                    .HasName("PRIMARY");

                entity.ToTable("inkomendeleveringslijnen");

                entity.HasIndex(e => e.ArtikelId, "fk_InkomendeLeveringsLijnen_Artikelen1_idx");

                entity.HasIndex(e => e.MagazijnPlaatsId, "fk_InkomendeLeveringsLijnen_MagazijnPlaatsen1_idx");

                entity.Property(e => e.InkomendeLeveringsId).HasColumnName("inkomendeLeveringsId");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.MagazijnPlaatsId).HasColumnName("magazijnPlaatsId");

                entity.Property(e => e.AantalGoedgekeurd).HasColumnName("aantalGoedgekeurd");

                entity.Property(e => e.AantalTeruggestuurd).HasColumnName("aantalTeruggestuurd");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Inkomendeleveringslijnens)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringsLijnen_Artikelen1");

                entity.HasOne(d => d.InkomendeLeverings)
                    .WithMany(p => p.Inkomendeleveringslijnens)
                    .HasForeignKey(d => d.InkomendeLeveringsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringsLijnen_InkomendeLeveringen1");

                entity.HasOne(d => d.MagazijnPlaats)
                    .WithMany(p => p.Inkomendeleveringslijnens)
                    .HasForeignKey(d => d.MagazijnPlaatsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_InkomendeLeveringsLijnen_MagazijnPlaatsen1");
            });

            modelBuilder.Entity<Klanten>(entity =>
            {
                entity.HasKey(e => e.KlantId)
                    .HasName("PRIMARY");

                entity.ToTable("klanten");

                entity.HasIndex(e => e.FacturatieAdresId, "fk_Klanten_Adressen1_idx");

                entity.HasIndex(e => e.LeveringsAdresId, "fk_Klanten_Adressen2_idx");

                entity.Property(e => e.KlantId).HasColumnName("klantId");

                entity.Property(e => e.FacturatieAdresId).HasColumnName("facturatieAdresId");

                entity.Property(e => e.LeveringsAdresId).HasColumnName("leveringsAdresId");

                entity.HasOne(d => d.FacturatieAdres)
                    .WithMany(p => p.KlantenFacturatieAdres)
                    .HasForeignKey(d => d.FacturatieAdresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Klanten_Adressen1");

                entity.HasOne(d => d.LeveringsAdres)
                    .WithMany(p => p.KlantenLeveringsAdres)
                    .HasForeignKey(d => d.LeveringsAdresId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Klanten_Adressen2");
            });

            modelBuilder.Entity<Klantenreview>(entity =>
            {
                entity.ToTable("klantenreviews");

                entity.HasIndex(e => e.BestellijnId, "fk_KlantenReviews_Bestellijnen1_idx");

                entity.Property(e => e.KlantenReviewId).HasColumnName("klantenReviewId");

                entity.Property(e => e.BestellijnId).HasColumnName("bestellijnId");

                entity.Property(e => e.Commentaar)
                    .HasMaxLength(255)
                    .HasColumnName("commentaar");

                entity.Property(e => e.Datum)
                    .HasColumnType("date")
                    .HasColumnName("datum");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nickname");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.HasOne(d => d.Bestellijn)
                    .WithMany(p => p.Klantenreviews)
                    .HasForeignKey(d => d.BestellijnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_KlantenReviews_Bestellijnen1");
            });

            modelBuilder.Entity<Leverancier>(entity =>
            {
                entity.HasKey(e => e.LeveranciersId)
                    .HasName("PRIMARY");

                entity.ToTable("leveranciers");

                entity.HasIndex(e => e.PlaatsId, "fk_Leveranciers_Plaatsen1_idx");

                entity.Property(e => e.LeveranciersId).HasColumnName("leveranciersId");

                entity.Property(e => e.BtwNummer)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("btwNummer");

                entity.Property(e => e.Bus)
                    .HasMaxLength(5)
                    .HasColumnName("bus");

                entity.Property(e => e.FamilienaamContactpersoon)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("familienaamContactpersoon");

                entity.Property(e => e.HuisNummer)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("huisNummer");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");

                entity.Property(e => e.PlaatsId).HasColumnName("plaatsId");

                entity.Property(e => e.Straat)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("straat");

                entity.Property(e => e.VoornaamContactpersoon)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("voornaamContactpersoon");

                entity.HasOne(d => d.Plaats)
                    .WithMany(p => p.Leveranciers)
                    .HasForeignKey(d => d.PlaatsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Leveranciers_Plaatsen1");
            });

            modelBuilder.Entity<Magazijnplaatsen>(entity =>
            {
                entity.HasKey(e => e.MagazijnPlaatsId)
                    .HasName("PRIMARY");

                entity.ToTable("magazijnplaatsen");

                entity.HasIndex(e => e.ArtikelId, "fk_MagazijnPlaatsen_Artikelen1_idx");

                entity.HasIndex(e => new { e.Rij, e.Rek }, "uinx_rijrek")
                    .IsUnique();

                entity.Property(e => e.MagazijnPlaatsId).HasColumnName("magazijnPlaatsId");

                entity.Property(e => e.Aantal).HasColumnName("aantal");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.Rek).HasColumnName("rek");

                entity.Property(e => e.Rij)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("rij")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Magazijnplaatsens)
                    .HasForeignKey(d => d.ArtikelId)
                    .HasConstraintName("fk_MagazijnPlaatsen_Artikelen1");
            });

            modelBuilder.Entity<Natuurlijkepersonen>(entity =>
            {
                entity.HasKey(e => e.KlantId)
                    .HasName("PRIMARY");

                entity.ToTable("natuurlijkepersonen");

                entity.HasIndex(e => e.GebruikersAccountId, "fk_NatuurlijkePersonen_gebruikersAccountId_idx");

                entity.HasIndex(e => e.KlantId, "fk_PrivateKlanten_Klanten1_idx");

                entity.Property(e => e.KlantId).HasColumnName("klantId");

                entity.Property(e => e.Familienaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("familienaam");

                entity.Property(e => e.GebruikersAccountId).HasColumnName("gebruikersAccountId");

                entity.Property(e => e.Voornaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("voornaam");

                entity.HasOne(d => d.GebruikersAccount)
                    .WithMany(p => p.Natuurlijkepersonens)
                    .HasForeignKey(d => d.GebruikersAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_NatuurlijkePersonen_Gebruikersnamen1");

                entity.HasOne(d => d.Klant)
                    .WithOne(p => p.Natuurlijkepersonen)
                    .HasForeignKey<Natuurlijkepersonen>(d => d.KlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PrivateKlanten_Klanten1");
            });

            modelBuilder.Entity<Personeelsleden>(entity =>
            {
                entity.HasKey(e => e.PersoneelslidId)
                    .HasName("PRIMARY");

                entity.ToTable("personeelsleden");

                entity.HasIndex(e => e.PersoneelslidAccountId, "fk_Personeelsleden_PersoneelslidAccounts1_idx");

                entity.Property(e => e.PersoneelslidId).HasColumnName("personeelslidId");

                entity.Property(e => e.Familienaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("familienaam");

                entity.Property(e => e.InDienst)
                    .IsRequired()
                    .HasColumnName("inDienst")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.PersoneelslidAccountId).HasColumnName("personeelslidAccountId");

                entity.Property(e => e.Voornaam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("voornaam");

                entity.HasOne(d => d.PersoneelslidAccount)
                    .WithMany(p => p.Personeelsledens)
                    .HasForeignKey(d => d.PersoneelslidAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Personeelsleden_PersoneelslidAccounts1");
            });

            modelBuilder.Entity<Personeelslidaccount>(entity =>
            {
                entity.ToTable("personeelslidaccounts");

                entity.HasIndex(e => e.Emailadres, "emailadres_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PersoneelslidAccountId).HasColumnName("personeelslidAccountId");

                entity.Property(e => e.Disabled).HasColumnName("disabled");

                entity.Property(e => e.Emailadres)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("emailadres");

                entity.Property(e => e.Paswoord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("paswoord");
            });

            modelBuilder.Entity<Personeelslidsecuritygroepen>(entity =>
            {
                entity.HasKey(e => new { e.PersoneelslidId, e.SecurityGroepId })
                    .HasName("PRIMARY");

                entity.ToTable("personeelslidsecuritygroepen");

                entity.HasIndex(e => e.SecurityGroepId, "fk_PersoneelslidSecurityGroepen_SecurityGroepen1_idx");

                entity.Property(e => e.PersoneelslidId).HasColumnName("personeelslidId");

                entity.Property(e => e.SecurityGroepId).HasColumnName("securityGroepId");

                entity.HasOne(d => d.Personeelslid)
                    .WithMany(p => p.Personeelslidsecuritygroepens)
                    .HasForeignKey(d => d.PersoneelslidId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PersoneelslidSecurityGroepen_Personeelsleden1");

                entity.HasOne(d => d.SecurityGroep)
                    .WithMany(p => p.Personeelslidsecuritygroepens)
                    .HasForeignKey(d => d.SecurityGroepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PersoneelslidSecurityGroepen_SecurityGroepen1");
            });

            modelBuilder.Entity<Plaatsen>(entity =>
            {
                entity.HasKey(e => e.PlaatsId)
                    .HasName("PRIMARY");

                entity.ToTable("plaatsen");

                entity.Property(e => e.PlaatsId).HasColumnName("plaatsId");

                entity.Property(e => e.Plaats)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("plaats");

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("postcode");
            });

            modelBuilder.Entity<Rechtspersonen>(entity =>
            {
                entity.HasKey(e => e.KlantId)
                    .HasName("PRIMARY");

                entity.ToTable("rechtspersonen");

                entity.Property(e => e.KlantId).HasColumnName("klantId");

                entity.Property(e => e.BtwNummer)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("btwNummer");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");

                entity.HasOne(d => d.Klant)
                    .WithOne(p => p.Rechtspersonen)
                    .HasForeignKey<Rechtspersonen>(d => d.KlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rechtspersonen_Klanten1");
            });

            modelBuilder.Entity<Securitygroepen>(entity =>
            {
                entity.HasKey(e => e.SecurityGroepId)
                    .HasName("PRIMARY");

                entity.ToTable("securitygroepen");

                entity.Property(e => e.SecurityGroepId).HasColumnName("securityGroepId");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");
            });

            modelBuilder.Entity<Uitgaandeleveringen>(entity =>
            {
                entity.HasKey(e => e.UitgaandeLeveringsId)
                    .HasName("PRIMARY");

                entity.ToTable("uitgaandeleveringen");

                entity.HasIndex(e => e.BestelId, "fk_UitgaandeLeveringen_Bestellingen1_idx");

                entity.HasIndex(e => e.KlantId, "fk_UitgaandeLeveringen_Klanten1_idx");

                entity.HasIndex(e => e.UitgaandeLeveringsStatusId, "fk_UitgaandeLeveringen_UitgaandeLeveringsStatussn1_idx");

                entity.Property(e => e.UitgaandeLeveringsId).HasColumnName("uitgaandeLeveringsId");

                entity.Property(e => e.AankomstDatum)
                    .HasColumnType("date")
                    .HasColumnName("aankomstDatum");

                entity.Property(e => e.BestelId).HasColumnName("bestelId");

                entity.Property(e => e.KlantId).HasColumnName("klantId");

                entity.Property(e => e.Trackingcode)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("trackingcode");

                entity.Property(e => e.UitgaandeLeveringsStatusId).HasColumnName("uitgaandeLeveringsStatusId");

                entity.Property(e => e.VertrekDatum)
                    .HasColumnType("date")
                    .HasColumnName("vertrekDatum");

                entity.HasOne(d => d.Bestel)
                    .WithMany(p => p.Uitgaandeleveringens)
                    .HasForeignKey(d => d.BestelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UitgaandeLeveringen_Bestellingen1");

                entity.HasOne(d => d.Klant)
                    .WithMany(p => p.Uitgaandeleveringens)
                    .HasForeignKey(d => d.KlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UitgaandeLeveringen_Klanten1");

                entity.HasOne(d => d.UitgaandeLeveringsStatus)
                    .WithMany(p => p.Uitgaandeleveringens)
                    .HasForeignKey(d => d.UitgaandeLeveringsStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UitgaandeLeveringen_UitgaandeLeveringsStatussn1");
            });

            modelBuilder.Entity<Uitgaandeleveringsstatussen>(entity =>
            {
                entity.HasKey(e => e.UitgaandeLeveringsStatusId)
                    .HasName("PRIMARY");

                entity.ToTable("uitgaandeleveringsstatussen");

                entity.Property(e => e.UitgaandeLeveringsStatusId).HasColumnName("uitgaandeLeveringsStatusId");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("naam");
            });

            modelBuilder.Entity<Veelgesteldevragenartikel>(entity =>
            {
                entity.ToTable("veelgesteldevragenartikels");

                entity.HasIndex(e => e.ArtikelId, "fk_VeelgesteldeVragenArtikels_Artikelen1_idx");

                entity.Property(e => e.VeelgesteldeVragenArtikelId).HasColumnName("veelgesteldeVragenArtikelId");

                entity.Property(e => e.Antwoord)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("antwoord");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.Vraag)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("vraag");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Veelgesteldevragenartikels)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_VeelgesteldeVragenArtikels_Artikelen1");
            });

            modelBuilder.Entity<Wishlistitem>(entity =>
            {
                entity.HasKey(e => new { e.WishListItemId, e.GebruikersAccountId })
                    .HasName("PRIMARY");

                entity.ToTable("wishlistitems");

                entity.HasIndex(e => e.ArtikelId, "fk_WishListItems_Artikelen1_idx");

                entity.HasIndex(e => e.GebruikersAccountId, "fk_WishListItems_GebruikersAccounts1_idx");

                entity.Property(e => e.WishListItemId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("wishListItemId");

                entity.Property(e => e.GebruikersAccountId).HasColumnName("gebruikersAccountId");

                entity.Property(e => e.Aantal)
                    .HasColumnName("aantal")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.AanvraagDatum)
                    .HasColumnType("date")
                    .HasColumnName("aanvraagDatum");

                entity.Property(e => e.ArtikelId).HasColumnName("artikelId");

                entity.Property(e => e.EmailGestuurdDatum)
                    .HasColumnType("date")
                    .HasColumnName("emailGestuurdDatum");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.Wishlistitems)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_WishListItems_Artikelen1");

                entity.HasOne(d => d.GebruikersAccount)
                    .WithMany(p => p.Wishlistitems)
                    .HasForeignKey(d => d.GebruikersAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_WishListItems_GebruikersAccounts1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
