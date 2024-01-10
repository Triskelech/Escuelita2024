//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
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
            var account = _entityService.Load<Account>(1);
            var accounts = _entityService.AsQueryable<Account>();
            return Json(new { accounts });
        }

        public IActionResult SaveAccountWithUser()
        {
            var account = new Account();
            var user = _entityService.Load<User>(4);
            account.User = user;
            user.Account = account;

            _entityService.Save(user);
            _entityService.SaveAndFlush(account);

            return Json(new { ok = true });
        }

        public IActionResult SaveUser()
        {
            var user = new User();
            user.UserName = "Milo06";
            user.FirstName = "Milo";
            user.LastName = "Tomasin";

            _entityService.SaveAndFlush(user);

            return Json(new { ok = true });
        }

        public IActionResult SaveTransfer([FromBody]Transfer transfer)
        {
            var account = _entityService.Load<Account>(transfer.OriginAccountId);
            
            if(account.Transfers == null)
            {
                account.Transfers = new List<Transfer>();
            }

            account.Transfers.Add(transfer);
            transfer.DateTime = DateTime.Now;

            _entityService.Save(account);
            _entityService.SaveAndFlush(transfer);

            return Json(new { ok = true });
        }
    }
}