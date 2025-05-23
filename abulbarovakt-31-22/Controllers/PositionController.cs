
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace abulbarovakt_31_22.Controllers
{
    public class PositionController : Controller
    {
        // GET: PositionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PositionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PositionController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PositionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PositionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PositionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PositionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PositionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}