using Microsoft.EntityFrameworkCore;


namespace vpkp.Models.Database
{
    public partial class NBA1Context : DbContext
    {
        public NBA1Context()
        {
        }

        public NBA1Context(DbContextOptions<NBA1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<MatchStatistic> MatchStatistics { get; set; } = null!;
        public virtual DbSet<Player> Players { get; set; } = null!;
        public virtual DbSet<PlayerStatisticInMatch> PlayerStatisticInMatches { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\basar\\Desktop\\NBA1.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId)
                    .ValueGeneratedNever()
                    .HasColumnName("City_ID");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("Club");

                entity.Property(e => e.ClubId)
                    .ValueGeneratedNever()
                    .HasColumnName("Club_ID");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.PlayersAmount).HasColumnName("Players amount");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.CityId);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.MatchId)
                    .ValueGeneratedNever()
                    .HasColumnName("Match_ID");

                entity.Property(e => e.Club1Id).HasColumnName("Club1_ID");

                entity.Property(e => e.Club2Id).HasColumnName("Club2_ID");

                entity.HasOne(d => d.Club1)
                    .WithMany(p => p.MatchClub1s)
                    .HasForeignKey(d => d.Club1Id);

                entity.HasOne(d => d.Club2)
                    .WithMany(p => p.MatchClub2s)
                    .HasForeignKey(d => d.Club2Id);
            });

            modelBuilder.Entity<MatchStatistic>(entity =>
            {
                entity.ToTable("Match statistic");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ClubId).HasColumnName("Club_ID");

                entity.Property(e => e.MatchId).HasColumnName("Match_ID");

                entity.Property(e => e.PointsNumber).HasColumnName("Points number");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.MatchStatistics)
                    .HasForeignKey(d => d.ClubId);

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchStatistics)
                    .HasForeignKey(d => d.MatchId);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.ToTable("Player");

                entity.Property(e => e.PlayerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Player_ID");

                entity.Property(e => e.ClubId).HasColumnName("Club_ID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.ClubId);
            });

            modelBuilder.Entity<PlayerStatisticInMatch>(entity =>
            {
                entity.ToTable("Player statistic in match");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FoulsNumber).HasColumnName("Fouls number");

                entity.Property(e => e.GoalsNumber).HasColumnName("Goals number");

                entity.Property(e => e.MatchId).HasColumnName("Match_ID");

                entity.Property(e => e.PlayerId).HasColumnName("Player_ID");

                entity.Property(e => e.ThrowsNumber).HasColumnName("Throws number ");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.PlayerStatisticInMatches)
                    .HasForeignKey(d => d.MatchId);

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerStatisticInMatches)
                    .HasForeignKey(d => d.PlayerId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
