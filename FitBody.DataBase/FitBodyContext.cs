using FitBody.Models;
using Microsoft.EntityFrameworkCore;

namespace FitBody.DataBase
{
    public class FitBodyContext : DbContext
    {
        public FitBodyContext(DbContextOptions<FitBodyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostLiked>().HasKey(table => new
            {
                table.PostId,
                table.UserId
            });
            builder.Entity<PostSaved>().HasKey(table => new
            {
                table.PostId,
                table.UserId
            });
            builder.Entity<PostTag>().HasKey(table => new
            {
                table.PostId,
                table.TagId
            });
            builder.Entity<UserFollow>().HasKey(table => new
            {
                table.UserFollowingId,
                table.UserFollowedId
            });
            builder.Entity<PostComment>().HasKey(table => new
            {
                table.PostId,
                table.CommentId
            });
            builder.Entity<ThreadComment>().HasKey(table => new
            {
                table.ThreadId,
                table.CommentId
            });
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLiked> LikedPosts { get; set; }
        public DbSet<PostSaved> SavedPosts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Subcategory> SubCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<TopicSuggested> TopicsSugested { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFollow> UsersFollows { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<ThreadComment> ThreadComments { get; set; }

    }
}
