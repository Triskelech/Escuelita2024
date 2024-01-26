using Model.Context;
using Model.Entities;
using Service.Contracts;

namespace Service.Services
{
    public class UserService : EntityService<User>, IUserService
    {
        public UserService(EscuelitaContext context) : base (context)
        {
        }
    }
}
