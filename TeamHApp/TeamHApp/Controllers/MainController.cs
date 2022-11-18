using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamHApp.Models;

namespace TeamHApp.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Top()
        {
            LostModel m1 = new LostModel();
            m1.id = 1;
            m1.name = "ふでばこ";
            m1.lost_subscriber.Add( "佐藤");
            m1.lost_subscriber.Add("酒井");


            LostModel m2 = new LostModel();
            m2.id = 2;
            m2.name = "傘";
            m2.lost_subscriber.Add("小林");
            m2.lost_subscriber.Add("吉田");
            m2.lost_subscriber.Add("新");

            LostListlModel ls = new LostListlModel();
            ls.lost_list.Add(m1);
            ls.lost_list.Add(m2);

            return View(ls);
        }

        public ActionResult ReturnPerson()
        {
            return View();
        }

        public ActionResult LostRegist ()
        {
            return View();
        }
        public ActionResult Confirm()
        {
            return View();
        }


        // GET: MainController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MainController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MainController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainController/Create
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

        // GET: MainController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainController/Edit/5
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

        // GET: MainController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainController/Delete/5
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
