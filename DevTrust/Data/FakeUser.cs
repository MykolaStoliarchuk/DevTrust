using AutoBogus;
using Bogus;
using DevTrust.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;

namespace DevTrust.Data
{
    internal class FakeUser : IFakeUser
    {
        public Faker<User> Faker { get; set; }

        public List<User> GenerateUsers()
        {
            return Faker.Generate(new Random().Next(10,15));
        }

        public FakeUser()
        {
            Faker = new Faker<User>().RuleFor(u => u.Id, f => Guid.NewGuid())
            .RuleFor(u => u.FirstName, f => f.Name.FirstName())
            .RuleFor(u => u.LastName, f => f.Name.LastName())
            .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(u => u.Gender, f => f.PickRandom<Gender>());
        }

        
    }
}
