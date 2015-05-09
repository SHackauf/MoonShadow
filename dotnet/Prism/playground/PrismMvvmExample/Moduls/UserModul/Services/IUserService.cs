using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UserModul.Models;

namespace UserModul.Services
{
    public interface IUserService
    {
        IEnumerable<IUser> FindUsers();
        IUser Find(int id);

        IUser Save(IUser user);
    }
}
