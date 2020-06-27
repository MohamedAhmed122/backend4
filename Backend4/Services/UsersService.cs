using System;
using System.Collections.Generic;
using System.Linq;

using Backend4.Models.Users;

using Microsoft.Extensions.Logging;

namespace Backend4.Services
{

    public class UsersService : IUsersService
    {

        private readonly List<UserCredential> users = new List<UserCredential>();
        private readonly ILogger<IUsersService> logger;

        public UsersService(ILogger<IUsersService> logger) 
        {
            this.logger = logger;
        }

        public void Create(UserCredential user)
        {
            logger.LogInformation("Adding new user to store.");
            users.Add(user);
        }

        public UserCredential FindByFullName(string firstName, string lastName)
        {
            return users.FirstOrDefault(u => u.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
                u.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        }

    }
}
