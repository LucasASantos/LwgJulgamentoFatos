using System;
using LDSI.Lwg.Apresentacao.Data.Mappings;
using LDSI.Lwg.Apresentacao.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;

namespace LDSI.Lwg.Apresentacao.Data.Context
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id).HasMaxLength(80));
      builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(80));
      builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(80));
      builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(80));
      builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(80));
      builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(80));
      builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(80));
      builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(80));
      builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(80));
      builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(80));
      builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(80));
      builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(80));
      builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id).HasMaxLength(80));
      builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(80));

      Mappings.Models.MappingModels(builder);
      Relations.MappingRelations(builder);
      builder.Entity<ApplicationUser>(i => {
        i.Property(o => o.EmailConfirmed).HasConversion<int>();
        i.Property(o => o.LockoutEnabled).HasConversion<int>();
        i.Property(o => o.PhoneNumberConfirmed).HasConversion<int>();
        i.Property(o => o.TwoFactorEnabled).HasConversion<int>();
      });
      base.OnModelCreating(builder);
    }
  }
}
