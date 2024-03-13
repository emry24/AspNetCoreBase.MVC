using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : IdentityDbContext<UserEntity>(options)
    {
        public virtual DbSet<AddressEntity> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<UserEntity>()
                .HasOne(x => x.Address)
                .WithOne(x => x.User)
                .HasForeignKey<AddressEntity>(x => x.UserId);
                //.OnDelete(DeleteBehavior.Restrict);
        }
    }
}
