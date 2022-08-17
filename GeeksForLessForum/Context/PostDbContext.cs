using GeeksForLessForum.Models;
using Microsoft.EntityFrameworkCore;

namespace GeeksForLessForum.Context
{
    public class PostDbContext: DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options):base(options)
        {

        }

        public DbSet<Post> PostsInfo { get; set; }

    }
}
