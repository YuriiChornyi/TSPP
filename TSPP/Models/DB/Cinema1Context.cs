using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TSPP.Models.DB
{
    public partial class Cinema1Context : DbContext
    {
        public virtual DbSet<Cinema> Cinema { get; set; }
        public virtual DbSet<CinemaSession> CinemaSession { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Hall> Hall { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public Cinema1Context(DbContextOptions<Cinema1Context> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.Property(e => e.CinemaId).HasColumnName("Cinema_Id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.SessionId).HasColumnName("Session_Id");
            });

            modelBuilder.Entity<CinemaSession>(entity =>
            {
                entity.ToTable("Cinema_Session");

                entity.Property(e => e.CinemaSessionId).HasColumnName("Cinema_Session_Id");

                entity.Property(e => e.CinemaId).HasColumnName("Cinema_Id");

                entity.Property(e => e.SessionId).HasColumnName("Session_Id");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.CinemaSession)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("Cinema_Session_Cinema_Id_TO_Cinema_Cinema_Id");

                entity.HasOne(d => d.CinemaNavigation)
                    .WithMany(p => p.CinemaSession)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("Cinema_Session_Session_Id_TO_Session_Session_Id");
            });

            modelBuilder.Entity<Comments>(entity =>
            {
                entity.HasKey(e => e.CommentId);

                entity.Property(e => e.CommentId).HasColumnName("Comment_Id");

                entity.Property(e => e.CinemaId).HasColumnName("Cinema_Id");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.MovieId).HasColumnName("Movie_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Cinema)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.CinemaId)
                    .HasConstraintName("Comments_Cinema_Id_TO_Cinema_Cinema_Id");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("Comments_Movie_Id_TO_Movie_Movie_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Comments_User_Id_TO_User_User_Id");
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.Property(e => e.HallId).HasColumnName("Hall_Id");

                entity.Property(e => e.SeatsCount).HasColumnName("Seats_Count");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.MovieId).HasColumnName("Movie_Id");

                entity.Property(e => e.Discription)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Img).HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(65);

                entity.Property(e => e.Tecnology)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.Property(e => e.SessionId).HasColumnName("Session_Id");

                entity.Property(e => e.DateTime)
                    .HasColumnName("Date_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.HallId).HasColumnName("Hall_Id");

                entity.Property(e => e.MovieId).HasColumnName("Movie_Id");

                entity.HasOne(d => d.Hall)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.HallId)
                    .HasConstraintName("Session_Hall_Id_TO_Hall_Hall_Id");

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Session)
                    .HasForeignKey(d => d.MovieId)
                    .HasConstraintName("Session_Movie_Id_TO_Movie_Movie_Id");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(55);

                entity.Property(e => e.IsAdmin).HasColumnName("Is_Admin");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }
}
