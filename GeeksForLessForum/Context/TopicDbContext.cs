using GeeksForLessForum.Models;
using Microsoft.EntityFrameworkCore;

namespace GeeksForLessForum.Context
{
    public class TopicDbContext:DbContext
    {
         public TopicDbContext(DbContextOptions<TopicDbContext> options) : base(options)
        {

        }

        public DbSet<Topic> TopicInfo { get; set; }
    }
}
