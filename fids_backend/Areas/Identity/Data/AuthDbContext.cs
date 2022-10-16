using fids_backend.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace fids_backend.Areas.Identity.Data;

public class AuthDbContext : IdentityDbContext<UserAuth>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserAuthEntityConfiguration());
    }
}

public class UserAuthEntityConfiguration : IEntityTypeConfiguration<UserAuth> {
    public void Configure(EntityTypeBuilder<UserAuth> builder)
    {
        builder.Property(u => u.Agency).HasMaxLength(50);
        builder.Property(u => u.Short).HasMaxLength(40);
    }
}