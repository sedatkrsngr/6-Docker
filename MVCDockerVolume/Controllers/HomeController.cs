using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using MVCDockerVolume.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDockerVolume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider _fileProvider;//startupta resim dosyalarını çekmek için oluşturduğum servisi alırım

        public HomeController(ILogger<HomeController> logger,IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Docker Volume->kaydedilecek datalar farklı conteinerlarda alınan dataların ortak bir yerde kaydedilmesini sağlamak ve conteiner silinse dahi kaybolmamasını sağlamk için kullanılır. 3 Method vardır. Normalde ayağa kalkan conteinerlarda eklenen datalar sadece o conteiner için varolur.Bunun önünce geçmek için->
            // 1-bind mount: İşletim sistemi üzerinde bir klasör açar ve tüm conteinerlar oraya kayıt yapar
            // 2-volume: Docker üzerinde bir alan oluşturur ve tüm veriler buraya kaydolur. Bind amounttan artısı uzak sunucuya da kayıt yapabiliriz
            // 3-Memory: İşletim sisteminin hafızasında dataları kaydeder.  Biz 1. ve 2. maddeleri bu eğitimde kullanıcaz


            //1 Bind Amount
            //Masaüstünde images diye bir klasör açtık
            //docker run -d -p 5001:4500 --name mycon2 --mount type=bind,source="C:\Users\sedat.karasungur\Desktop\images",target="/app/wwwroot/images" 9a2
            //kodun notları -d continer oluşurken ekranda göstermesin diye konuldu.  Verdiğimiz adres masaüstünde resimlerin kaydedileceği klasör. Target ise runtime image içerisinde publish çıkılmış dosyadaki images adresi 9a2 ise kullandığımız image id si
            //Bind amount daha önce publish dosyasındaki images klasöründe resim varsa dahi ona bakmaz işletim sistemindeki klasöre bakar

            //2 Volume
            //docker volume create images  // docker üzerinde images adında volume oluşturduk
            //docker run -d -p 5001:4500 --name mycon2 -v images:/app/wwwroot/images 9a2
            //eğer silmek istersek te docker volume rm images  //images adındaki volume silinir
            //kodun notları -v images -> volume images
            //Bind amounttan farklı olarak images klasörü publish içindeki dataları da içerisine kopyalar. Böylece kayıp yaşanmaz


            return View();
        }

        public IActionResult ImageShow()
        {
            var images = _fileProvider.GetDirectoryContents("wwwroot/images").ToList().Select(x=>x.Name);

            return View(images);
        }

        [HttpPost]
        public IActionResult ImageShow(string name)//silme işlemi için kullandık
        {
            var file = _fileProvider.GetDirectoryContents("wwwroot/images").ToList().First(x => x.Name == name);

            System.IO.File.Delete(file.PhysicalPath);
            return RedirectToAction("ImageShow");
        }

        public IActionResult ImageSave()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ImageSave(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length>0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName); //resim1.jpg-> 6sad46-6asd4566-asdasd4.jpg gibi olacak

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
            
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
