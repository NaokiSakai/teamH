using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeamHApp.Models;
using System.Web;
using System.Diagnostics;
using Azure.Storage.Blobs;

namespace TeamHApp.Controllers
{
    public class MainController : Controller


    {

        IConfiguration Configuration { get; }

        public MainController(IConfiguration configuration)
        {
            // テスト処理　あとで消す
            DBconnect.GetImgFilename();
            Configuration = configuration;
        }

        public ActionResult Top()
        {
            itemsModel m1 = new itemsModel();
            m1.items_id = 1;
            m1.type = "ふでばこ";



            itemsModel m2 = new itemsModel();
            m2.items_id = 2;
            m2.type = "傘";
            
            /*
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
            */
            LostListlModel ls = new LostListlModel();
            ls.lost_list = DBconnect.GetItems();

            for(int i = 0; i < ls.lost_list.Count; i++)
            {
                ls.lost_list[i].lost_reservation = DBconnect.GetReserve(ls.lost_list[i].items_id);
            }

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
        public async Task<IActionResult> LostRegist([FromForm] UploadModel upload)
        {
            if (!ModelState.IsValid)
            {
                return View(upload);
            }

            // 設定ファイルからストレージアカウントの接続文字列を取得
            var connectionString = Configuration.GetConnectionString("AzureStorage");

            // Blob Storageのコンテナ名（確実に一意にするためにGUIDを連結）
            var containerName = $"sample{Guid.NewGuid()}";

            try
            {
                // BlobServiceClientクラスのインスタンスを作成
                var blobServiceClient = new BlobServiceClient(connectionString);

                // コンテナを作成する
                BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

                // BlobClientクラスのインスタンスを取得
                var blobClient = containerClient.GetBlobClient(upload.File.FileName);

                // ファイルをBLOBにアップロードする
                await blobClient.UploadAsync(upload.File.OpenReadStream());

                ViewData["Result"] = "ファイルをアップロードしました！";
            }
            catch
            {
                ViewData["Result"] = "ファイルのアップロードに失敗しました。";
            }

            return View();
        }




        [HttpPost]
        public ActionResult ConfirmPage(string lostType, IFormFile picture,string foundPlace, string feature)
        {
            // アップロードファイル名の取得
            string up_filename = picture.FileName;
            string up_file_ext = Path.GetExtension(up_filename);
            // 拡張子のチェック
            string[] accept_ext = new string[] { "jpg", "png" }; // 許可する拡張子のリスト
            bool is_accept_ext = false;                         // 許可する拡張子かどうかのフラグ
            foreach (string extensions in accept_ext)
            {
                // 許可された拡張子であればフラグをtrue
                if (extensions == up_file_ext)
                {
                    is_accept_ext = true;
                }
            }

            // 許可されてない拡張子の場合の処理
            if (is_accept_ext)
            {
                ViewData["up_file_name"] = null;
                return View("Index", "Home");
            }

            // アップロードファイルの保存、事前に/wwwroot/img/productフォルダを作成しておく。
            // なおproductフォルダに何か入ってないとプロジェクトで認識されないので、
            // 適当なテキストファイル「none.txt」など入れて置く。

            // 保存するファイルの名前の生成、ファイル名の数字をDBの主キーにするなど被らないようにしてください。
            Random r = new Random();
            string save_filename = r.Next(1000) + up_file_ext; // 保存するファイル名

            using (var stream = System.IO.File.Create("./wwwroot/image/" + save_filename))
            {
                ViewData["up_file_name"] = save_filename;
                // 保存
                picture.CopyTo(stream);
            }


            DBconnect.InsertItem( lostType, save_filename, foundPlace, feature, "False");
            ViewData["lost_type"] = lostType;
        　　ViewData["foundPlace"] = foundPlace;
            ViewData["feature"] = feature;

            return View();
        }


        public ActionResult ConfirmPage()

        {
           itemsModel m = new itemsModel();
           //m.classify= DBconnect.GetItems();
           


            return View();
        }
        
        // GET: MainController
     

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
