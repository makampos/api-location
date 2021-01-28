using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Services.User
{
    public interface IUserService
    {
         Task<UserEntity> Get(Guid id);
         Task<IEnumerable<UserEntity>> getAll();
         Task<UserEntity> Post(UserEntity user);
         Task<UserEntity> Put(UserEntity user);
         Task<bool> Delete(Guid id);

    }
}