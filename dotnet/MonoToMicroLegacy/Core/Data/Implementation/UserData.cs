using System.Collections.Generic;
using System.Linq;
using MonoToMicroLegacy.Core.Data.Interfaces;
using MonoToMicroLegacy.Core.Data.Models;
using MonoToMicroLegacy.Core.Repository.Interfaces;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Data.Implementation
{
    public class UserData : IUserData
    {
        public long Create(UnicornUser user)
        {
            using (var db = new UnicornContext())
            {
                db.Users.Add(user);

                db.SaveChanges();
                return user.Id.GetValueOrDefault(0);
            }
        }

        public UnicornUser GetByEmail(string email)
        {
            using (var db = new UnicornContext())
            {
                var query = from u in db.Users where u.Email == email.ToLower() select u;
                
                return query.FirstOrDefault();
            }
        }
    }
}