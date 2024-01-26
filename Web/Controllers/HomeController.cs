//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Service.Contracts;
using Controller = Microsoft.AspNetCore.Mvc.Controller;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IEntityService<Entity> _entityService;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly ITransferService _transferService;

        public HomeController(IUserService userService, IAccountService accountService, ITransferService transferService)
        {
            _userService = userService;
            _accountService = accountService;
            _transferService = transferService;
    }

        public IActionResult Index()
        {
            //var users = _userService.AsQueryable().ToList();
            //return Json(new { users });

            return View();
        }

        public IActionResult GetAllAccounts()
        {
            var accounts = _accountService.AsQueryable().ToList();
            return Json(new { accounts });
        }

        public IActionResult GetAllTransfers()
        {
            var transfers = _transferService.AsQueryable().ToList();
            return Json(new { transfers });
        }

        public IActionResult SaveAccount([FromBody] Account account)
        {
            _accountService.Save(account);

            var user = _userService.Load(account.UserId);
            user.Account = account;
            _userService.SaveAndFlush(user);

            return Json(new { ok = true });
        }

        public IActionResult SaveUser([FromBody] User user)
        {
            _userService.SaveAndFlush(user);

            return Json(new { ok = true });
        }

        public IActionResult SaveTransfer([FromBody]Transfer transfer)
        {
            _transferService.Save(transfer);

            var account = _accountService.Load(transfer.OriginAccountId);

            if(account.Transfers == null)
            {
                account.Transfers = new List<Transfer>();
            }

            account.Transfers.Add(transfer);
            _accountService.SaveAndFlush(account);

            return Json(new { ok = true });
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}