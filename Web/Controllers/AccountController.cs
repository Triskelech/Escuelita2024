using LF2_Prueba.NoModelClasses;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.Contracts;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult Index()
        {
            ViewBag.List = accountService.AsQueryable<Account>().ToList();
            ViewBag.ElementType = "Account";
            return View("ListAndShow");
        }

        public IActionResult Load(int id)
        {
            ViewBag.Element = accountService.Load<Account>(id);
            ViewBag.Action = "show";
            return View("Show");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            ViewBag.Element = new Account();
            return View("ShowPartial");
        }

        public IActionResult Insert([FromBody] Account account)
        {
            accountService.SaveAndFlush(account);
            return Json(new GenericResponse(200, "La cuenta fue insertada"));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var account = accountService.Load<Account>(id);
            ViewBag.Element = account;
            ViewBag.Action = "update";
            return View("ShowPartial");
        }

        [HttpPost]
        public IActionResult Update([FromBody] Account account)
        {
            accountService.SaveAndFlush(account);
            return Json(new GenericResponse(200, "La cuenta fue editada"));
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var account = accountService.Load<Account>(id);
            ViewBag.Element = account;
            ViewBag.Action = "delete";
            return View("ShowPartial");
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Account account)
        {
            accountService.Delete(account);
            accountService.SaveChanges();
            return Json(new GenericResponse(200, "La cuenta fue eliminada"));
        }
    }
}
