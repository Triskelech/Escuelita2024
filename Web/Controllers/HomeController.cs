//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Model.Entities;
using Service.Contracts;
using System.Diagnostics;
using System.Web.Mvc;
using Web.Models;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntityService _entityService;

        public HomeController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        public IActionResult Index()
        {
            var users = _entityService.AsQueryable<User>().ToList();
            return Json(new { users });
        }

        public IActionResult GetAllAccounts()
        {
            var accounts = _entityService.AsQueryable<Account>().ToList();
            return Json(new { accounts });
        }

        public IActionResult GetAllTransfers()
        {
            var transfers = _entityService.AsQueryable<Transfer>().ToList();
            return Json(new { transfers });
        }

        public IActionResult SaveAccount([FromBody] Account account)
        {
            _entityService.Save(account);

            var user = _entityService.Load<User>(account.UserId);
            user.Account = account;
            _entityService.SaveAndFlush(user);

            return Json(new { ok = true });
        }

        public IActionResult SaveUser([FromBody] User user)
        {
            _entityService.SaveAndFlush(user);

            return Json(new { ok = true });
        }

        public IActionResult SaveTransfer([FromBody]Transfer transfer)
        {
            _entityService.Save(transfer);

            var account = _entityService.Load<Account>(transfer.OriginAccountId);

            if(account.Transfers == null)
            {
                account.Transfers = new List<Transfer>();
            }

            account.Transfers.Add(transfer);
            _entityService.SaveAndFlush(account);

            return Json(new { ok = true });
        }
    }
}