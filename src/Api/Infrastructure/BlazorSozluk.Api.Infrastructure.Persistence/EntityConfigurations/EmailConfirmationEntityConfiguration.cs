using BlazorSozluk.Api.Core.Domain.Models;
using BlazorSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Infrastructure.Persistence.EntityConfigurations
{
    public class EmailConfirmationEntityConfiguraition : BaseEntityConfiguration<Core.Domain.Models.EmailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            base.Configure(builder);

            builder.ToTable("emailconfirmation", BlazorSozlukDbContext.DEFAULT_SCHEMA);
        }
    }
}
