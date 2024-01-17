using Model.Context;
using Service.Contracts;

namespace Service.Services
{
    public class TransferService : EntityService, ITransferService
    {
        public TransferService(EscuelitaContext context) : base (context)
        {
        }
    }
}
