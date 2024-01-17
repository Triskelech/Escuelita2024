using Model.Context;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class AccountService : EntityService, IAccountService
    {
        public AccountService(EscuelitaContext context) : base (context)
        {
        }
    }
}
