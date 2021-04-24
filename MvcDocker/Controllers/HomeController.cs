using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcDocker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcDocker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            //Notları yazmak için burayı kullanıyorum. Docker file oluşturma ve versiyon çıkma adımları,image oluşturma, listeleme console ile aynı fakat conteiner oluşturma farklı  docker run --name dockername -p 5000:80 imagename  uygulamamızı 5000 portundan çalıştırır ve dockerin 80 portu ile eşitler -p portu belirtmek için kullanılır. docker run -> docker create + docker start + docker attash di mormalde ama attach işlemi yapmasın yani ekranda göstermesin sadece çalışsın diyorsak docker run -d --name conteinername -p 5000:80 imagename   -d ile detach ederiz ve başlarken ekranda çalışmaz bunun dışındaki conteiner işlemleri image işlemleri aynı

            //runtime image için kodlar CLI kodlar yok Sdk olmadan CLI çalışmaz ayrıca güncelleme için sürekli manuel publish çıkmak gerekiyor base image kodu

            //FROM mcr.microsoft.com / dotnet / core / aspnet:3.1
            //WORKDIR / app
            //COPY / bin / Release / netcoreapp3.1 / publish.
            //ENTRYPOINT["dotnet", "MvcDocker.dll"]



            //eğer publish işlemlerini yapmak istemiyorsak dockerfile sdk yükleriz. Base Image Kodu->

            //FROM mcr.microsoft.com/dotnet/sdk:3.1 as sdk  //ismini sdk olarak verelim, ilerde lazım olur bu kullanım
            //WORKDIR /app
            //COPY. .  //ilk .  dockerfile dosyasının bulunduğu dizini belirler ikinci . ise çalışılacak dosyayı app yi belirtir.
            //RUN dotnet restore  //publish çıkmadan önce güncellemeleri alırız
            //RUN dotnet publish MvcDocker.csproj -c Release -o out   //publish için proje adı publish modu ve app içerisine çıkılacak dosyayı belirtiriz out adı
            //WORKDIR out  //çıkılacak dosyayı belirtiyoruz
            //ENV ASPNETCORE_URLS "http://*:4500" //docker run --name conteinername -p 5000:4500 imagename bu portu belirterek çıkarız. * ise herhangi bir uygulama portu olabilir. 4500 ise docker portudur bunu biz belirleriz normalde varsayılan 80 portudur  burada uygulamanın portu ile docker portunu birbirlerine tanıtırız
            //ENTRYPOINT["dotnet", "MvcDocker.dll"]

            //Sdk image boyutu çok fazla olduğu için publish işlemlerini sdk ile ama conteiner oluşturmayı runtime ile yapıp  daha ufak boyut elde ederiz.   MultiStage Build adı ve Base Code 2 tane kullanıcaz ve bu haliyle kullanmak daha mantıklı kodu ise->

            //FROM mcr.microsoft.com/dotnet/sdk:3.1 as sdk  //sdk image takma isim kullanarak aşağıda kullanıcaz
            //WORKDIR /app
            //COPY *.csproj .  //işlem yükünü azaltmak için projemizin proj uzantılı dosyasını app içerisine kopyalarız
            //RUN dotnet restore //restore işlemleri yaparak güncel hali alacağız
            //COPY. .  //ilk .  dockerfile dosyasının bulunduğu dizini belirler ikinci . ise çalışılacak dosyayı app yi belirtir.
            //RUN dotnet publish MvcDocker.csproj -c Release -o out  //app klasörü içerisinde out isimli dosyaya publish çıktık        
            //FROM mcr.microsoft.com/dotnet/aspnet:3.1 //sdk'dan kurtulmak için 2. base image oluşturduk runtime olarak
            //WORKDIR /app //runtime image içerisine app adında klasör açtık
            //COPY --from = sdk /app/out .  //Burada sdk/app/out içerisindeki publish dosyasını runtime/app içerisine kopyaladık
            //ENV ASPNETCORE_URLS "http://*:4500"  //ardından 4500 portu docker için oluşturuldu
            //ENTRYPOINT["dotnet", "MvcDocker.dll"]

            //.dockerignore dosyası oluşturmak: Kopyalanma ile taşınmasını istemediğimiz dosyaları belirtiriz. Örn: bin,obj klasörleri taşınmasına gerek yok
            //dockerfile dosyası oluşturulurken varsayılan olarak geliyor ama gelmezse. Dockerfile dosyasının bulunduğu konum .dockerignore şeklinde uzantısız eklersek kodda Dockerfile dosyasının altına oluşur 
            //örnek .dockerignore kodyazımı aşğıdadır. Bin,obj,,dockerfile,.dockerignore copy komutunda atlanacak dosya ve klasörlerdir.

            //**/bin/
            //**/obj/
            //**/Dockerfile*
            //**/.dockerignore*




            //.Net Core CLI Komutları
            //dotnet build ->build eder
            //dotnet run -> uygulamayı çalıştırır
            //dotnet publish ....
            //manuel işlemleri komutlarla daha hızlı yapmak için kullanılır Dockerfile dosyasında kullanabiliriz ama bunun içinde dockerfile içerisindeki base image runtime değil de sdk olmalı clı komutları sdk ile geliyor.
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
