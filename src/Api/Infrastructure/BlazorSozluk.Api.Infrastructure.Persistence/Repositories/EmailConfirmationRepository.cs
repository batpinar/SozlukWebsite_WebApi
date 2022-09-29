using BlazorSozluk.Api.Core.Application.Interfaces.Repositories;
using BlazorSozluk.Api.Core.Domain.Models;
using BlazorSozluk.Api.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Infrastructure.Persistence.Repositories;

public class EmailConfirmationRepository : GenericRepository<EmailConfirmation>, IEmailConfirmationRepository
{
    public EmailConfirmationRepository(BlazorSozlukDbContext context) : base(context)
    {
    }
}
