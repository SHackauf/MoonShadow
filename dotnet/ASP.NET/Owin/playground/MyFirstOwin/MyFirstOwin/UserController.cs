using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyFirstOwin
{
    public class UserController : ApiController
    {
        private IList<User> _users = new List<User>
        {
            new User {Id = "1", Name = "Donald Duck" },
            new User {Id = "2", Name = "Mickey Maus" },
            new User {Id = "3", Name = "Gustav Gans" }
        };

        [Route("users")]
		public IHttpActionResult GetUser()
		{
            return this.Json<IEnumerable<User>>(this._users, new Newtonsoft.Json.JsonSerializerSettings(), Encoding.UTF8);
		}

        [Route("user/{id}")]
		public IHttpActionResult GetUser(string id)
		{
            if (this._users.Any(user => user.Id.Equals(id)))
            {
                return this.Json<User>(this._users.First(user => user.Id.Equals(id)), new Newtonsoft.Json.JsonSerializerSettings(), Encoding.UTF8);
            }
			
            return this.BadRequest();
		}
    }

    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
