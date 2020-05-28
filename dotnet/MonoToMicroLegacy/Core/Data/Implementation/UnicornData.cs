using System;
using System.Collections.Generic;
using System.Linq;
using MonoToMicroLegacy.Core.Data.Interfaces;
using MonoToMicroLegacy.Core.Data.Models;

namespace MonoToMicroLegacy.Core.Data.Implementation
{
    public class UnicornData : IUnicornData
    {
        public List<Unicorn> GetUnicorns()
        {
            using (var db = new UnicornContext())
            {
                var query = from u in db.Unicorns select u;
                Console.WriteLine(query.ToString());
                return query.ToList();
            }
        }

        public bool AddUnicornToBasket(string userUuid, string unicornUuid)
        {
            using (var db = new UnicornContext())
            {
                db.UnicornBaskets.Add(new UnicornBasket()
                {
                    Uuid = userUuid,
                    UnicornUuid = unicornUuid
                });
                db.SaveChanges();
                return true;
            }
            throw new System.NotImplementedException();
        }

        public bool RemoveUnicornFromBasket(string userUuid, string unicornUuid)
        {
            using (var db = new UnicornContext())
            {
                var query = from u in db.UnicornBaskets where u.Uuid == userUuid && u.UnicornUuid == unicornUuid select u;

                var result = query.FirstOrDefault();

                if (result != null)
                {
                    db.UnicornBaskets.Remove(result);
                    db.SaveChanges();
                }
                    
                return true;
            }
            
            throw new System.NotImplementedException();
        }

        public List<Unicorn> GetUnicornBasket(string userUuid)
        {
            using (var db = new UnicornContext())
            {
                var query = from u in db.UnicornBaskets where u.Uuid == userUuid join d in db.Unicorns on u.UnicornUuid equals d.Uuid select d;
                Console.WriteLine(query.ToString());
                return query.ToList();
            }
        }

        public List<UnicornBasket> GetAllBaskets()
        {
            throw new System.NotImplementedException();
        }
    }
}