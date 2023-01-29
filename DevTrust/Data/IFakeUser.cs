using Bogus;
using DevTrust.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DevTrust.Data
{
    public interface IFakeUser
    {
        List<User> GenerateUsers();
    }
}
