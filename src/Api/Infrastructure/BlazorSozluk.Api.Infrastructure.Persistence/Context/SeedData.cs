using BlazorSozluk.Api.Core.Domain.Models;
using BlazorSozluk.Common.Infrastructure;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Infrastructure.Persistence.Context
{
    internal  class SeedData
    {
        private static List<User> GetUsers()
        {
            var result = new Faker<User>("tr")
                .RuleFor(i => i.Id, i => Guid.NewGuid())
            .RuleFor(i => i.CreateDate, i =>
                     i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.FirstName, i => i.Person.FirstName)
            .RuleFor(i => i.LastName, i => i.Person.LastName)
            .RuleFor(u => u.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            //.RuleFor(i => i.EmailAddress, i => i.Internet.Email())
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            //.RuleFor(i => i.UserName, i => i.Internet.UserName())
            .RuleFor(i => i.Password, i => PasswordEncryptor.Encrypt(i.Internet.Password()))
            .RuleFor(i => i.EmailConfirmed, i => i.PickRandom(true, false))
                .Generate(500);

            return result;
        }

        public async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder();
            dbContextBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

            var context = new BlazorSozlukDbContext(dbContextBuilder.Options);

            if(context.Users.Any())
            {
                await Task.CompletedTask;
                return;
            }

            var users = GetUsers();
            var userIds = users.Select(i => i.Id);

            await context.Users.AddRangeAsync(users);

            var guids = Enumerable.Range(0,150).Select(i => Guid.NewGuid()).ToList();
            int counter = 0;

            var entries = new Faker<Entry>("tr")
                .RuleFor(i => i.Id, i => guids[counter++])
                .RuleFor(i => i.CreateDate, i => i.Date.Between(DateTime.Now.AddDays(-99), DateTime.Now))
                .RuleFor(i => i.Subject, i => i.Lorem.Sentence(5, 5))
                .RuleFor(i => i.Content, i => i.Lorem.Paragraph(2))
                .RuleFor(i => i.CreatedById, i => i.PickRandom(userIds))
                .Generate(150);

            await context.Entries.AddRangeAsync(entries);

            var entryComments = new Faker<EntryComment>("tr")
                 .RuleFor(i => i.Id, i => Guid.NewGuid())
                 .RuleFor(i => i.CreateDate, i => i.Date.Between(DateTime.Now.AddDays(-98), DateTime.Now))
                 .RuleFor(i => i.Content, i => i.Lorem.Paragraph(3))
                 .RuleFor(i => i.CreatedById, i => i.PickRandom(userIds))
                 .RuleFor(i => i.EntryId, i => i.PickRandom(guids))
                 .Generate(2000);

            await context.EntryComments.AddRangeAsync(entryComments);

            await context.SaveChangesAsync();
        }
    }
}
