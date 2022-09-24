using BlazorSozluk.Api.Core.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BlazorSozluk.Api.Infrastructure.Persistence.Context;

namespace BlazorSozluk.Api.Infrastructure.Persistence.EntityConfigurations.Entry;

public class EntryFavoriteEntityConfiguration : BaseEntityConfiguration<Core.Domain.Models.EntryFavorite>
{
    public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
    {
        base.Configure(builder);

        builder.ToTable("entryfavorite", BlazorSozlukDbContext.DEFAULT_SCHEMA);

        builder.HasOne(i => i.Entry)
            .WithMany(i => i.EntryFavorites)
            .HasForeignKey(i => i.EntryId);

        builder.HasOne(i => i.CreatedUser)
            .WithMany(i => i.EntryFavorites)
            .HasForeignKey(i => i.CreatedById);
    }
}
