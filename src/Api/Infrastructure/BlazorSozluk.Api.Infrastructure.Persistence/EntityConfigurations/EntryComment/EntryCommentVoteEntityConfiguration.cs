using BlazorSozluk.Api.Core.Domain.Models;
using BlazorSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Infrastructure.Persistence.EntityConfigurations.EntryComment
{
    public class EntryCommentVoteEntityConfiguration : BaseEntityConfiguration<Core.Domain.Models.EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentvote", BlazorSozlukDbContext.DEFAULT_SCHEMA);

            builder.HasOne(i => i.EntryComments)
                .WithMany(i => i.EntryCommentVotes)
                .HasForeignKey(i => i.EntryCommentId);
        }
    }
}
