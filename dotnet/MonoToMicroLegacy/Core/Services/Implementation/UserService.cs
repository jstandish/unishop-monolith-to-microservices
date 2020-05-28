using System;
using MonoToMicroLegacy.Core.Events;
using MonoToMicroLegacy.Core.Repository.Interfaces;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Services.Implementation
{
    public class UserService : Interfaces.IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        
        public UserCreatedEvent Create(CreateUserEvent createUserEvent)
        {
            User user = createUserEvent.User;
            user.Active = true;
            //user.setCreationDate(DateTime.now());
            user.CreatedByUserId = 1L;
            user.Uuid = Guid.NewGuid().ToString();		

            user = _repository.Create(user);

            if (user != null) {			
                return new UserCreatedEvent(user, State.Success);
            } else {
                return new UserCreatedEvent(State.Failed);
            }
        }

        public UserReadEvent GetByEmail(ReadUserEvent readUserEvent)
        {
            User user = _repository.GetByEmail(readUserEvent.User.Email);		
            if (user!=null) {			
                UserReadEvent userReadEvent = new UserReadEvent(user, State.Success);
                return userReadEvent;
            }
            else{
                return new UserReadEvent(State.Failed);
            }
        }
    }
}