using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDockerVolume.Controllers
{
    public class KatmanlıController : Controller
    {
        public IActionResult Index()
        {
            //Katmanlı mimaride docker  continer çalıştırma
            //Dockerda conteiner çıkınca localdeki veritabanı adresini versek dahi onu görmez. O yüzden uzak sunucu adresi vermek gerekiyor

            //1-Dockerfile dosyası tüm katmanların dışında oluştururuz 
            //Örn: MVC adında projemiz olsun ve katmanları
            //MVC ->solition Name
            //MVC.Core
            //MVC.Data
            //MVC.Service
            //MVC.Web // yayınlanacak projemiz diğerleri dll görevi görüyor
            //Dockerfile

            //Dockerfile kodumuz-> Baştan yazayım Copy *.csproj . yazmak yerine her katmanı ayrı ayrı yazmanın nedeni değişiklik olduğunda sadece o dockerfile katmanı yeniden derlenecek diğerleri cacheden hızlıca derlenecek

            //FROM mcr.microsoft.com/dotnet/sdk:3.1 as sdk
            //WORKDIR /app
            //COPY ./MVC.Core/*.csproj ./MVC.Core/          //app içerisine MVC.Core adında klasör oluşturup MVC.Core.csproj dosyasını atarız
            //COPY ./MVC.Data/*.csproj ./MVC.Data/          //app içerisine MVC.Data adında klasör oluşturup MVC.Data.csproj dosyasını atarız
            //COPY ./MVC.Service/*.csproj ./MVC.Service/    //app içerisine MVC.Service adında klasör oluşturup MVC.Service.csproj dosyasını atarız
            //COPY ./MVC.Web/*.csproj ./MVC.Web/            //app içerisine MVC.Web adında klasör oluşturup MVC.Web.csproj dosyasını atarız
            //COPY *.sln .  //app içerisine solitionu direkt atarız
            //RUN dotnet restore
            //COPY . .
            //RUN dotnet publish ./MVC.Web/*.csproj - c Release - o /publish/      //app içerisindeki MVC.Web içindeki MVC.Web.csproj /publish app içinde değil
            //FROM mcr.microsoft.com/dotnet/aspnet:3.1
            //WORKDIR /app
            //COPY --from =/publish .    
            //ENV ASPNETCORE_URLS "http://*:4500"
            //ENTRYPOINT ["dotnet", "MVC.Web.dll"]


            return View();
        }
    }
}
