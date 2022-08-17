using GeeksForLessForum.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeeksForLessForum.Areas.Identity.Data;

public class UserDbContext : IdentityDbContext<ForumUser>
{
    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ForumUserEntityConfiguration());
    }
}

public class ForumUserEntityConfiguration : IEntityTypeConfiguration<ForumUser>
{
    public void Configure(EntityTypeBuilder<ForumUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u=>u.LastName).HasMaxLength(255);
    }
}