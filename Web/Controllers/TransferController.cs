using LF2_Prueba.NoModelClasses;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Service.Contracts;
using System.Security.Cryptography.Xml;

namespace Web.Controllers
{
    public class TransferController : Controller
    {
        private readonly ITransferService transferService;

        public TransferController(ITransferService transferService)
        {
            this.transferService = transferService;
        }
        public IActionResult Index()
        {
            ViewBag.List = transferService.AsQueryable<Transfer>().ToList();
            ViewBag.ElementType = "Transfer";
            return View("ListAndShow");
        }

        public IActionResult Load(int id)
        {
            ViewBag.Element = transferService.Load<Transfer>(id);
            ViewBag.Action = "show";
            return View("Show");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "add";
            ViewBag.Element = new Transfer();
            return View("ShowPartial");
        }

        public IActionResult Insert([FromBody] Transfer transfer)
        {
            transferService.SaveAndFlush(transfer);
            return Json(new GenericResponse(200, "La transferencia fue insertada"));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var transfer = transferService.Load<Transfer>(id);
            ViewBag.Element = transfer;
            ViewBag.Action = "update";
            return View("ShowPartial");
        }

        [HttpPost]
        public IActionResult Update([FromBody] Transfer transfer)
        {
            transferService.SaveAndFlush(transfer);
            return Json(new GenericResponse(200, "La transferencia fue editada"));
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            var transfer = transferService.Load<Transfer>(id);
            ViewBag.Element = transfer;
            ViewBag.Action = "delete";
            return View("ShowPartial");
        }

        [HttpPost]
        public IActionResult Delete([FromBody] Transfer transfer)
        {
            transferService.Delete(transfer);
            transferService.SaveChanges();
            return Json(new GenericResponse(200, "La transferencia fue eliminada"));
        }
    }
}
