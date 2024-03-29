using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgendaSQL_App.Agenda_db;

public partial class AgendaSuzukidbContext : DbContext
{
    public AgendaSuzukidbContext()
    {
    }

    public AgendaSuzukidbContext(DbContextOptions<AgendaSuzukidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ReseauxMedium> ReseauxMedia { get; set; }

    public virtual DbSet<ReseauxProfile> ReseauxProfiles { get; set; }

    public virtual DbSet<Tach> Taches { get; set; }

    public virtual DbSet<Todolist> Todolists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=andreraspberrypi.local;port=3306;user=admin;password=dj2005;database=agenda_suzukidb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.21-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("contact")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Addresse)
                .HasMaxLength(45)
                .HasColumnName("addresse");
            entity.Property(e => e.Age)
                .HasColumnType("int(11)")
                .HasColumnName("age");
            entity.Property(e => e.Codepostal)
                .HasMaxLength(45)
                .HasColumnName("codepostal");
            entity.Property(e => e.Dateofbirth)
                .HasMaxLength(45)
                .HasColumnName("dateofbirth");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Entreprise)
                .HasMaxLength(45)
                .HasColumnName("entreprise");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");
            entity.Property(e => e.Prenom)
                .HasMaxLength(45)
                .HasColumnName("prenom");
            entity.Property(e => e.Relationship)
                .HasColumnType("enum('Famille','Amis','Travail')")
                .HasColumnName("relationship");
            entity.Property(e => e.Ville)
                .HasMaxLength(45)
                .HasColumnName("ville");
        });

        modelBuilder.Entity<ReseauxMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reseaux_media")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Logourl)
                .HasColumnType("text")
                .HasColumnName("logourl");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ReseauxProfile>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.ContactId, e.ReseauxMediaId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity
                .ToTable("reseaux_profile")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ContactId, "fk_reseaux_profile_contact_idx");

            entity.HasIndex(e => e.ReseauxMediaId, "fk_reseaux_profile_reseaux_media1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ContactId)
                .HasColumnType("int(11)")
                .HasColumnName("contact_id");
            entity.Property(e => e.ReseauxMediaId)
                .HasColumnType("int(11)")
                .HasColumnName("reseaux_media_id");
            entity.Property(e => e.Followers)
                .HasMaxLength(45)
                .HasColumnName("followers");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
            entity.Property(e => e.Url)
                .HasMaxLength(45)
                .HasColumnName("url");

            entity.HasOne(d => d.Contact).WithMany(p => p.ReseauxProfiles)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reseaux_profile_contact");

            entity.HasOne(d => d.ReseauxMedia).WithMany(p => p.ReseauxProfiles)
                .HasForeignKey(d => d.ReseauxMediaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reseaux_profile_reseaux_media1");
        });

        modelBuilder.Entity<Tach>(entity =>
        {
            entity.HasKey(e => new { e.Idtaches, e.TodolistId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("taches")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.TodolistId, "fk_tâches_todolist1_idx");

            entity.Property(e => e.Idtaches)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)")
                .HasColumnName("idtaches");
            entity.Property(e => e.TodolistId)
                .HasColumnType("int(11)")
                .HasColumnName("todolist_id");
            entity.Property(e => e.Fait)
                .HasColumnType("tinyint(4)")
                .HasColumnName("fait");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
            entity.Property(e => e.Temps)
                .HasColumnType("datetime")
                .HasColumnName("temps");

            entity.HasOne(d => d.Todolist).WithMany(p => p.Taches)
                .HasForeignKey(d => d.TodolistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tâches_todolist1");
        });

        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("todolist")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Genre)
                .HasColumnType("enum('Famille','Amis','Travail')")
                .HasColumnName("genre");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
