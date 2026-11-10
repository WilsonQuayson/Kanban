using Kanban.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Kanban.Infrastructure.Identity;


namespace Kanban.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Board> Boards { get; set; } = null!;
    public DbSet<BoardColumn> BoardColumns { get; set; } = null!;
    public DbSet<KanbanTask> KanbanTasks { get; set; } = null!;
    public DbSet<BoardMember> BoardMembers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Board
        modelBuilder.Entity<Board>()
            .HasOne<ApplicationUser>()
            .WithMany(u => u.OwnedBoards)
            .HasForeignKey(b => b.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Board>()
            .HasMany(b => b.Columns)
            .WithOne(c => c.Board)
            .HasForeignKey(c => c.BoardId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Board>()
            .HasMany(b => b.Members)
            .WithOne(bm => bm.Board)
            .HasForeignKey(bm => bm.BoardId)
            .OnDelete(DeleteBehavior.Cascade);

        // BoardColumn
        modelBuilder.Entity<BoardColumn>()
            .HasMany(c => c.KanbanTasks)
            .WithOne(t => t.BoardColumn)
            .HasForeignKey(t => t.BoardColumnId)
            .OnDelete(DeleteBehavior.Cascade);

        // BoardMember
        modelBuilder.Entity<BoardMember>()
            .HasKey(bm => new { bm.UserId, bm.BoardId });

        modelBuilder.Entity<BoardMember>()
            .HasOne<ApplicationUser>()
            .WithMany(u => u.BoardMemberships)
            .HasForeignKey(bm => bm.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}