using Invest.Data.Mappings;
using Invest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Invest.Data.Context
{
    public class InvestContext : DbContext
    {
        public InvestContext([NotNull] DbContextOptions<InvestContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());

            ApplyGlobalStandards(modelBuilder);
            SeedData(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        private static void ApplyGlobalStandards(ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade).ToList()
                    .ForEach(fe => fe.DeleteBehavior = DeleteBehavior.Restrict);

                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;

                        case nameof(Entity.UpdatedData):
                            property.IsNullable = true;
                            break;

                        case nameof(Entity.CreatedDate):
                            property.IsNullable = false;
                            property.SetColumnType("datetime");
                            property.SetDefaultValueSql("CURRENT_TIMESTAMP");
                            break;

                        case nameof(Entity.IsActive):
                            property.IsNullable = false;
                            property.SetDefaultValue(true);
                            break;
                    }
                }
            }
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            User[] users = new[]
            {
                new User { Id = 1, Name = "Admin", IsActive = true, Document = "43777579033",
                    IsAuthorised = true, Password = "011c945f30ce2cbafc452f39840f025693339c42", CreatedUser = 1,
                    CreatedDate = DateTime.Now},
                new User { Id = 2, Name = "User", IsActive = true, Document = "17581628809",
                    IsAuthorised = true, Password = "fea7f657f56a2a448da7d4b535ee5e279caf3d9a", CreatedUser = 1,
                    CreatedDate = DateTime.Now}
            };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}