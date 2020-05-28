using System;
using MonoToMicroLegacy.Core.Data.Interfaces;
using MonoToMicroLegacy.Extensions;

namespace MonoToMicroLegacy.Core.Repository.Implementation
{
    public class HealthRepository : Interfaces.IHealthRepository
    {
        private readonly IHealthData _data;

        public HealthRepository(IHealthData data)
        {
            _data = data;
        }
        public bool IsReachable()
        {
            try {
                var res = _data.IsReachable();			
                return true;			
            } catch (Exception e) {
                e.PrintStackTrace();
            }
            return false;
        }
    }
}