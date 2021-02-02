using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;

namespace Api.Domain.Services.User
{
    public interface IUserService
    {
         Task<UserDto> Get(Guid id);
         Task<IEnumerable<UserDto>> getAll();
         Task<UserDtoCreateResult> Post(UserDtoCreate user);
         Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
         Task<bool> Delete(Guid id);

    }
}