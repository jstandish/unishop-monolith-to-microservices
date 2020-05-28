using MonoToMicroLegacy.Core.Repository.Interfaces;

namespace MonoToMicroLegacy.Core.Services.Implementation
{
    public class HealthService : Interfaces.IHealthService
    {
        private readonly IHealthRepository _repository;

        public HealthService(IHealthRepository repository)
        {
            _repository = repository;
        }
        
        public bool IsReachable()
        {
            return _repository.IsReachable();
        }
    }
}