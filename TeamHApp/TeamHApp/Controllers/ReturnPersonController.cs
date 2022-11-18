using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeamHApp.Controllers
{
    public class ReturnPersonController : Controller
    {
        // GET: ReturnPersonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReturnPersonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReturnPersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReturnPersonController/Create
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

        // GET: ReturnPersonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReturnPersonController/Edit/5
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

        // GET: ReturnPersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReturnPersonController/Delete/5
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
