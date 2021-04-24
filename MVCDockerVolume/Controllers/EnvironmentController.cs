using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDockerVolume.Controllers
{
    public class EnvironmentController : Controller
    {
        public IActionResult Index()
        {
            //Conteiner için Environment belirleme

            //Normalde publish çıktığımızda ortamımız varsayılan olarak productiondur ama publish çıkarken development ortam da veya daha farklı kendi oluşturduğumuz ortamda çıksın istersek
            //docker run -d -p 5001:4500 --env ASPNETCORE_ENVIRONMENT=OrtamAdı --name mycon2  9a2
            //örn: docker run -d -p 5001:4500 --env ASPNETCORE_ENVIRONMENT=DEVELOPMENT --name mycon2  9a2
            //ya da dockerfile içerisinde ENV ASPNETCORE_ENVIRONMENT="DEVELOPMENT" diye satır da atabiliriz


            //<none> image nedir-> her image oluşturduğumuzda none image oluşur. Güncel versiyonda yok ama olursa eğer listelemek için->
            //docker images -f "dangling=true" silinmeleri içinse(genellikle işe  yaramazlar)-> docker rmi $(docker images -f "dangling=true" -q)
            //-q id lerini dönderir

            return View( );
        }
    }
}
