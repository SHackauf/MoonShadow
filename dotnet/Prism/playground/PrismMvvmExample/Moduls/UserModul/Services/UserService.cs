using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UserModul.Models;

namespace UserModul.Services
{
    public sealed class UserService : IUserService
    {
        private readonly List<IUser> _users = new List<IUser>
                {
                    new User(){Id = 0, Firstname = "Donald", Lastname = "Duck"},
                    new User(){Id = 1, Firstname = "Dagobert", Lastname = "Duck"},
                    new User(){Id = 2, Firstname = "Gustav", Lastname = "Gans"},
                    new User(){Id = 3, Firstname = "Minni", Lastname = "Maus"},
                };

        public IEnumerable<IUser> FindUsers()
        {
            return _users;
        }

        public IUser Find(int id)
        {
            return _users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public IUser Save(IUser user)
        {
            if (user.Id < 0)
            {
                var maxId = _users.Max(u => u.Id);
                user.Id = maxId + 1;
                _users.Add(user);
            }
            else
            {
                _users.RemoveAll(u => u.Id.Equals(user.Id));
                _users.Add(user);
            }

            return user;
        }
    }
}
