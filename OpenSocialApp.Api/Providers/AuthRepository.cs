using System;
using System.Collections.Generic;
using System.Linq;
using OpenSocialApp.Api.Models;

namespace OpenSocialApp.Api.Providers
{
    public class AuthRepository
    {
        private List<User> _users;

        public AuthRepository()
        {
            _users = new List<User>()
            {

            };
        }

        public User SignUp(string emailAddress, string password)
        {
            var user = new User();
            user.Id = Guid.NewGuid();
            user.CreatedOn = DateTime.Now;
            user.IsActive = true;
            user.EmailAddress = emailAddress;
            user.Password = password;
            _users.Add(user);
            return user;
        }

        public bool IsUniqueEmail(string emailAddress)
        {
            return _users.Count(x => x.EmailAddress == emailAddress) > 0;
        }

        public User SignIn(string emailAddress, string password)
        {
            return _users.FirstOrDefault(x => x.EmailAddress == emailAddress && x.Password == password);
        }
    }
}