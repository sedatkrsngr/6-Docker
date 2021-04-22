using System;
using System.Threading;

namespace ConsoleDocker
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://hub.docker.com/ sitesine üye olduk ve docker indirdik. Windowsta ubuntu regitryleri ve windows registiryleri çalışıtırabiliyoruz.
            //Varsayılan ubuntu registry gelmekte çünkü daha ufak ama değiştirmek istersek sağ altta switch to windows conteiners diyebiliriz
            //Not:Bir uygulamayı dockerize yapmak için 3 adım var. DOCKERFILE --build--> DOCKER IMAGE --run--> DOCKER CONTAINER
            //Not:Sdk ile runtime arasındaki fark. Sdk uygulama geliştirmek için gerekli ve içinde runtime da var. Runtime ise uygulamayı çalıştırmak için gerekli.Publisg edilmiş çalışılabilir datayı, uzak masaüstünde çalıştırmak için  runtime kurmak yeterlidir, Sdk da çalıştırır ama gereksiz. Bu yüzden  yukardaki siteden https://hub.docker.com/_/microsoft-dotnet-aspnet burdan :net core 3.1 veya 5 için image yolu alırız
            //https://docs.microsoft.com/en-us/windows/wsl/install-win10 siteden wsl 2 update yapmak gerekiyor ubuntu için




            //1-Docker için bu programı relase modda publish ediyorum
            //2-İlk Adım root dosyasında DOCKERFILE dosyasını oluşturmak. Proje->Add->Docker Support->Ubuntu dedikten sonra oluşur. Şuan root içerisinde oluşturduk tek proje olduğu için katmanlı mimari de projelerin dışında da oluşturabiliriz. Oluşan Dockerfile içerisinde kodlar yazılmış hazır olarak fakat bazı yerleri değiştiriyoruz

            // Bizim DockerFile Açıklamalı
            //FROM mcr.microsoft.com/dotnet/core/runtime:3.1 //Docker Image siteden aldık3.1 icin
            //WORKDIR /app // Image icerisinde calisilan klasör adi 
            //COPY /bin/Release/netcoreapp3.1/publish /app/ //publish dosyamın adresi, dosyalari olusturduğum app icine at: publish baska konumdaysa adresi proje>publish->edit->targetlocationdan ogrenebilirsin \yerine / kullan ama
            //ENTRYPOINT ["dotnet", "ConsoleDocker.dll"] #container ayağı kaltığı anda çalisacak komut Projemizin dll'i Bin de bulabiliriz adini
            //#Dockerfile icerisine yazılan her satır bir katmandır

            //3- Proje->open in Terminal->
            //4-Docker build -t consoledockerapp .    //isim kücük olmalı ve biz isteğimiz ismi verdikten sonra Dockerimage oluşur '.' ise o klasör icerisinde demek. Olusturalan imageları göörmek için :
            //docker images

            //5-Conteiner için docker create --name conteinerismi kullanılacak imageismi örn bizimki:
            //docker create --name consoleconteiner consoledockerapp ile conteiner olustu. 
            //Tüm conteinerları görmek için docker ps -a çalışanları görmek için docker ps 
            //6- Conteinerı çalıştırmak için docker start conteinerismi veya id ilk 3 hanesi -> docker start consoleconteiner durdurmak için ise ->docker stop consoleconteiner veya docker stop ilk üc hanesi
            //7-Conteiner icerisinde calisan veriyi görmek icin docker attach dockerismi veya docker id ilk uc hane görmeyi durdurmak icin de ctrl+c
            //8-Conteiner icerisindeki veri calistiği kadar calisir kodda değişiklik yaptıktan sonra publish cıkdıktan sonra yeniden islenmeli kodlar

            //////////////////////////////////////////Ek CLI Komutları///////////////////////////////////////////////////////
            //9-İmage silmek için docker rmi imagename veya imageid ile image silinir fakat önce bağlı dockerlar silinmeli
            //10-Conteineri silmek için ince docker stop conteinerid veya adı ardından docker rm conteineradı veya id
            //11-docker run --name olusacakconteineradı kullanılacakimageadı -> docker create+docker start + docker attach hepsinin birlikte olan halidir.
            //12-docker run --rm --name olusacakconteineradı kullanılacakimageadı ->  rm kullanırsa docker stop conteinername veya id dersek durdurup aynı zamanda siler.
            //13-image etiket atamak için  docker build -t imagename:v1 .  dersek imagename adında tagi v1 olan images oluşur böylelikle aynı image isminden birden fazla fatklı tagli oluşturabiliriz. Eğer imagedan conteiner oluşturmak istersek. docker run --name contname imagename:v1 dersek v1 olan imagenameden oluşturur
            //14-Çalışan bir conteiner silmek istiyorsak docker rm contname --force dersek çalışıyorsa bile silinir.
            //15-Çalışan bir conteinera bağlı image silinemez. Durdursak dahi silmek için docker rmi imagnanem --force komutu ancak silebilir
            //16-örn u projemiz için .net core runtime image dockerfile dosyası ile indirdik ama powershell üzerinden indirmek istersek örn sdk için docker pull docker pull mcr.microsoft.com/dotnet/sdk:3.1 şeklinde image indirebiliriz dockerımıza
            //17-Dockerin sitesinde örn repositoryname adında repository oluşturduk diyelim oraya imageları atmak için bize push adresi verecek ama örn     docker push sedatkrsngr/repositoryname ile push edebiliriz. Fakat image isimleri sedatkrsngr/repositoryname ile aynı olmalı. Sonlarında tag olabilir tabi. O zaman diyelim ki elimde busybox isminde image var ve bunu push etmek istiyorum. O zaman                                      docker tag busybox sedatkrsngr/repositoryname:v1 dersem busybox imagenı referans alan aynı id li sedatkrsngr/repositoryname isimli ve v1 tagli image oluşur. docker push sedatkrsngr/repositoryname:v1 dersek busybox başarılı repositorye iletilmiş olur
            //18




            int i = 1;
            while (i<1000)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i);
                i++;
            }


           


            //Otomatik olusan projemizin dockerfile komutari

            //FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
            //WORKDIR /app

            //FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
            //WORKDIR /src
            //COPY ["ConsoleDocker/ConsoleDocker.csproj", "ConsoleDocker/"]
            //RUN dotnet restore "ConsoleDocker/ConsoleDocker.csproj"
            //COPY . .
            //WORKDIR "/src/ConsoleDocker"
            //RUN dotnet build "ConsoleDocker.csproj" -c Release -o /app/build

            //FROM build AS publish
            //RUN dotnet publish "ConsoleDocker.csproj" -c Release -o /app/publish

            //FROM base AS final
            //WORKDIR /app
            //COPY --from=publish /app/publish .
            //ENTRYPOINT ["dotnet", "ConsoleDocker.dll"]

        }
    }
}







