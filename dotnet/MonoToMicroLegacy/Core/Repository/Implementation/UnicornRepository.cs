using System;
using System.Linq;
using System.Collections.Generic;
using MonoToMicroLegacy.Core.Data.Interfaces;
using MonoToMicroLegacy.Core.Repository.Interfaces;
using MonoToMicroLegacy.Core.Repository.Extensions;
using MonoToMicroLegacy.Extensions;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Repository.Implementation
{
    public class UnicornRepository : IUnicornRepository
    {
        private readonly IUnicornData _data;

        public UnicornRepository(IUnicornData data)
        {
            _data = data;
        }
        
        public List<Unicorn> GetUnicorns()
        {
            try {
                return _data.GetUnicorns().Select( t => t.ToModel()).ToList();
            } catch (Exception e) {
                e.PrintStackTrace();
                return null;
            }
        }

        public bool AddUnicornToBasket(string userUuid, string unicornUuid)
        {
            try {
                return _data.AddUnicornToBasket(userUuid, unicornUuid);
            } catch (Exception e) {
                e.PrintStackTrace();
                return false;
            }
        }

        public bool RemoveUnicornFromBasket(string userUuid, string unicornUuid)
        {
            try {
                return _data.RemoveUnicornFromBasket(userUuid, unicornUuid);
            } catch (Exception e) {
                e.PrintStackTrace();
                return false;
            }
        }

        public List<Unicorn> GetUnicornBasket(string userUuid)
        {
            try {
                return _data.GetUnicornBasket(userUuid).Select( t => t.ToModel()).ToList();
            } catch (Exception e) {
                e.PrintStackTrace();
                return null;
            }
        }

        public List<UnicornBasket> GetAllBaskets()
        {
            try {
                return _data.GetAllBaskets().Select( t => t.ToModel()).ToList();
            } catch (Exception e) {
                e.PrintStackTrace();
                return null;
            }
        }
    }
}