using System.Threading.Tasks;
using System.Web.Http;
using MonoToMicroLegacy.Core.Events;
using MonoToMicroLegacy.Core.Services.Interfaces;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        public async Task<User> CreateUser(User request)
        {
            if (request != null)
            {
                UserCreatedEvent userCreatedEvent = _service.Create(new CreateUserEvent(request));

                if (userCreatedEvent.IsCreated)
                {
                    request = userCreatedEvent.User;
                    return await Task.FromResult(request);
                }
            }

            return await Task.FromResult<User>(null);
        }

        [HttpPost]
        [Route("login")]
        public async Task<User> Login(User request)
        {
            if (request != null)
            {
                var userReadEvent = _service.GetByEmail(new ReadUserEvent(request));
                if (userReadEvent.IsReadOk)
                {
                    request = userReadEvent.User;
                    return await Task.FromResult(request);
                }
            }

            return await Task.FromResult<User>(null);
        }
    }
}