using Microsoft.EntityFrameworkCore;
using user_app.Models;

namespace user_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<TagModel> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .HasMany(user => user.posts)
                .WithOne(post => post.User)
                .HasForeignKey(post => post.UserId);

            modelBuilder.Entity<PostModel>()
                .HasMany(post => post.Tags)
                .WithMany(tags => tags.Posts)
                .UsingEntity(j => j.ToTable("PostTags"));
        }
    }
}
