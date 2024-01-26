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
            ViewBag.Action = "add";
            ViewBag.Element = new User();
            return View("ShowPartial");
        }

        public IActionResult Insert([FromBody] User user)
        {
            userService.SaveAndFlush(user);
            return Json(new GenericResponse(200, "El usuario fue insertado"));
        }
        //[HttpGet]
        public IActionResult Edit(int id)
        {
            var user = userService.Load(id);
            ViewBag.Element = user;
            ViewBag.Action = "update";
            return View("ShowPartial");
        }

        [HttpPost]
        public IActionResult Update([FromBody] User user)
        {
            userService.SaveAndFlush(user);
            return Json(new GenericResponse(200, "El usuario fue editado"));
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
