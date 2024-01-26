using Model.Context;
using Model.Entities;
using Service.Contracts;

namespace Service.Services
{
    public class TransferService : EntityService<Transfer>, ITransferService
    {
        public TransferService(EscuelitaContext context) : base (context)
        {
        }
    }
}
