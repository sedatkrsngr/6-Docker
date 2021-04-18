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
            //3- Proje->open in Terminal->
            //4-Docker build -t consoledockerapp .    //isim kücük olmalı ve biz isteğimiz ismi verdikten sonra Dockerimage oluşur . ise o klasör icerisinde demek. Olusturalan imageları göörmek için :
            //docker images

            //5-Conteiner için docker --name conteinerismi kullanılacak imageismi örn bizimki:
            //docker create --name consoleconteiner consoledockerapp ile conteiner olustu. 
            //Tüm conteinerları görmek için docker ps -a çalışanları görmek için docker ps 
            //6- Conteinerı çalıştırmak için docker start conteinerismi veya id ilk 3 hanesi -> docker start consoleconteiner durdurmak için ise ->docker stop consoleconteiner veya docker stop ilk üc hanesi
            //7-Conteiner icerisinde calisan veriyi görmek icin docker attach dockerismi veya docker id ilk uc hane görmeyi durdurmak icin de ctrl+c
            //8-Conteiner icerisindeki veri calistiği kadar calisir kodda değişiklik yaptıktan sonra publish cıkdıktan sonra yeniden islenmeli kodlar

            // Bizim DockerFile Açıklamalı

            //FROM mcr.microsoft.com/dotnet/core/runtime:3.1 //Docker Image siteden aldık3.1 icin
            //WORKDIR /app // Image icerisinde calisilan klasör adi 
            //COPY /bin/Release/netcoreapp3.1/publish /app/ //publish dosyamın adresi, dosyalari olusturduğum app icine at: publish baska konumdaysa adresi proje>publish->edit->targetlocationdan ogrenebilirsin \yerine / kullan ama
            //ENTRYPOINT ["dotnet", "ConsoleDocker.dll"] #container ayağı kaltığı anda çalisacak komut Projemizin dll'i Bin de bulabiliriz adini
            //#Dockerfile icerisine yazılan her satır bir katmandır


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







