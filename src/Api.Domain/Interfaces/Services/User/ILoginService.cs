using System.Threading.Tasks;
using Api.Domain.Dtos;

namespace Api.Domain.Services.User
{
    public interface ILoginService
    {
       Task<object> FindByLogin(LoginDto user);
    }
}