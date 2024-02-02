using LF2_Prueba.NoModelClasses;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.Contracts;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            ViewBag.List = userService.AsQueryable().ToList();
            ViewBag.ElementType = "User";
            return View("ListAndShow");
        }

        public IActionResult Load(int id)
        {
            ViewBag.Element = userService.Load(id);
            ViewBag.Action = "show";
            return View("Show");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Entity = new User();
            return View("UserEdit");
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Entity = userService.Load(id);
            return View("UserEdit");
        }

        [HttpPost]
        public IActionResult Save([FromBody] User user)
        {
            var message = "El usuario fue editado";

            if (user.IsNew) message = "El usuario fue insertado";

            userService.SaveAndFlush(user);
            return Json(new GenericResponse(200, message));
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var user = userService.Load(id);
            ViewBag.Element = user;
            ViewBag.Action = "delete";
            return View("ShowPartial");
        }

        [HttpPost]
        public IActionResult Delete([FromBody] User user)
        {
            userService.Delete(user);
            userService.SaveChanges();
            return Json(new GenericResponse(200, "El usuario fue eliminado"));
        }
    }
}
