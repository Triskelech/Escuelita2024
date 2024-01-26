using Model.Context;
using Model.Entities;
using Service.Contracts;

namespace Service.Services
{
    public class AccountService : EntityService<Account>, IAccountService
    {
        public AccountService(EscuelitaContext context) : base (context)
        {
        }
    }
}
