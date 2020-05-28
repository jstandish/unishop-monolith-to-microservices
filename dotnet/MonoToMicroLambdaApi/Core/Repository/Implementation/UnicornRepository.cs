using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonoToMicroLambda.Core.Data.Interfaces;
using MonoToMicroLambda.Core.Repository.Interfaces;
using MonoToMicroLambda.Core.Repository.Extensions;
using MonoToMicroLambda.Extensions;
using MonoToMicroLambda.Models;

namespace MonoToMicroLambda.Core.Repository.Implementation
{
    public class UnicornRepository : IUnicornRepository
    {
        private readonly IUnicornData _data;

        public UnicornRepository(IUnicornData data)
        {
            _data = data;
        }

        public async Task<bool> AddUnicornToBasket(string userUuid, string unicornUuid)
        {
            try {
                return await _data.AddUnicornToBasket(userUuid, unicornUuid);
            } catch (Exception e) {
                e.PrintStackTrace();
                return false;
            }
        }

        public async Task<bool> RemoveUnicornFromBasket(string userUuid, string unicornUuid)
        {
            try {
                return await _data.RemoveUnicornFromBasket(userUuid, unicornUuid);
            } catch (Exception e) {
                e.PrintStackTrace();
                return false;
            }
        }

        public async Task<List<UnicornBasket>> GetUnicornBasket(string userUuid)
        {
            try {
                var result = await _data.GetUnicornBasket(userUuid);
                return result.Select( t => t.ToModel()).ToList();
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