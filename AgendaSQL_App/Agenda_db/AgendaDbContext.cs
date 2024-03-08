using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AgendaSQL_App.Agenda_db;

public partial class AgendaDbContext : DbContext
{
    public AgendaDbContext()
    {
    }

    public AgendaDbContext(DbContextOptions<AgendaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ReseauxMedium> ReseauxMedia { get; set; }

    public virtual DbSet<ReseauxProfile> ReseauxProfiles { get; set; }

    public virtual DbSet<Todolist> Todolists { get; set; }

    public virtual DbSet<Tâch> Tâches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=agenda_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contact");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Addresse)
                .HasMaxLength(45)
                .HasColumnName("addresse");
            entity.Property(e => e.Age).HasColumnName("age");
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
            entity.Property(e => e.Ville)
                .HasMaxLength(45)
                .HasColumnName("ville");
        });

        modelBuilder.Entity<ReseauxMedium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reseaux_media");

            entity.Property(e => e.Id).HasColumnName("id");
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

            entity.ToTable("reseaux_profile");

            entity.HasIndex(e => e.ContactId, "fk_reseaux_profile_contact_idx");

            entity.HasIndex(e => e.ReseauxMediaId, "fk_reseaux_profile_reseaux_media1_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.ReseauxMediaId).HasColumnName("reseaux_media_id");
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

        modelBuilder.Entity<Todolist>(entity =>
        {
            entity.HasKey(e => e.IdTodolist).HasName("PRIMARY");

            entity.ToTable("todolist");

            entity.Property(e => e.IdTodolist).HasColumnName("idTodolist");
            entity.Property(e => e.Genre)
                .HasColumnType("enum('Friends','Voyage','Quotidien')")
                .HasColumnName("genre");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tâch>(entity =>
        {
            entity.HasKey(e => new { e.Idtâches, e.TodolistIdTodolist })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("tâches");

            entity.HasIndex(e => e.TodolistIdTodolist, "fk_tâches_Todolist1_idx");

            entity.Property(e => e.Idtâches)
                .ValueGeneratedOnAdd()
                .HasColumnName("idtâches");
            entity.Property(e => e.TodolistIdTodolist).HasColumnName("Todolist_idTodolist");
            entity.Property(e => e.Fait).HasColumnName("fait");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("nom");
            entity.Property(e => e.Temps)
                .HasColumnType("datetime")
                .HasColumnName("temps");

            entity.HasOne(d => d.TodolistIdTodolistNavigation).WithMany(p => p.Tâches)
                .HasForeignKey(d => d.TodolistIdTodolist)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tâches_Todolist1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
