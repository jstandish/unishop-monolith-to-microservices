using System;
using System.Collections.Generic;
using MonoToMicroLegacy.Core.Data.Interfaces;
using MonoToMicroLegacy.Core.Data.Models;
using MonoToMicroLegacy.Core.Repository.Extensions;
using MonoToMicroLegacy.Core.Repository.Interfaces;
using MonoToMicroLegacy.Extensions;
using MonoToMicroLegacy.Models;

namespace MonoToMicroLegacy.Core.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserData _data;

        public UserRepository(IUserData data)
        {
            _data = data;
        }

        public User Create(User user)
        {
            try
            {
                
                var obj = new UnicornUser()
                {
                    Email = user.Email.ToLower(),
                    Uuid = user.Uuid,
                    Active = user.Active.GetValueOrDefault(false) ? (byte)0 : (byte)1, 
                    CreationDate = user.CreationDate,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    LastModifiedDate = user.LastModifiedDate,
                    CreatedByUserId = user.CreatedByUserId,
                    LastModifiedByUserId = user.LastModifiedByUserId
                };

                var rowsAffected = _data.Create(obj);
                if (rowsAffected > 0)
                {
                    user.Id = rowsAffected;
                    return user;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        public User GetByEmail(string email)
        {
            try
            {
                return _data.GetByEmail(email).ToModel();
            }
            catch (Exception e)
            {
                e.PrintStackTrace();
                return null;
            }
        }
    }
}