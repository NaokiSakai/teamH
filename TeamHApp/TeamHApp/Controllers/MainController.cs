using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamHApp.Models;
using System.Web;
using System.Diagnostics;

namespace TeamHApp.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Top()
        {
<<<<<<< HEAD
            DBconnect.Test();
            itemsModel m1 = new itemsModel();
            m1.items_id = 1;
            m1.type = "ふでばこ";
            m1.lost_subscriber.Add( "佐藤");
            m1.lost_subscriber.Add("酒井");


            itemsModel m2 = new itemsModel();
            m2.items_id = 2;
            m2.type = "傘";
            m2.lost_subscriber.Add("小林");
            m2.lost_subscriber.Add("吉田");
            m2.lost_subscriber.Add("新");
=======
            LostModel m1 = new LostModel();
            m1.LostId = 1;
            m1.LostName = "ふでばこ";
            m1.LostType = "筆記用具";
            m1.LostImage = "";
            m1.LostDate = "2022/11/11 14:00";
            m1.LostInfomation = "シャカシャカ　紺色　あああ";
            for(int i = 0; i < 2; i++)
            {
                LostReservationModel lrm = new LostReservationModel();
                lrm.LostId = m1.LostId;
                lrm.reservation_date = "2022-11-30 12:30:20";
                lrm.line_id = "123";
                m1.lost_reservation.Add(lrm);
            }


            LostModel m2 = new LostModel();
            m2.LostId = 2;
            m2.LostName = "スマートフォン";
            m2.LostType = "電子機器";
            m2.LostImage = "";
            m2.LostDate = "2022/9/19 14:00";
            m2.LostInfomation = "プラのごっついケース";

            for (int i = 0; i < 3; i++)
            {
                LostReservationModel lrm = new LostReservationModel();
                lrm.LostId = m2.LostId;
                lrm.reservation_date = "2022-11-30 12:30:20";
                lrm.line_id = "222";
                m2.lost_reservation.Add(lrm);
            }
>>>>>>> a43d2da94c104f0cb71735ca60062d5d67a36398

            LostListlModel ls = new LostListlModel();
            ls.lost_list.Add(m1);
            ls.lost_list.Add(m2);

            return View(ls);
        }

        public ActionResult ReturnPerson()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LostRegist()
        {
            return View();
        }

      


        [HttpPost]
        public ActionResult ConfirmPage(string lostType, string picture, string foundPlace, string feature)
        {
            DBconnect.InsertItem( lostType, "imagepath_test" ,foundPlace, feature, "False");

            return View();
        }
        public ActionResult ConfirmPage()
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
