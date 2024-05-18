using Microsoft.AspNetCore.Mvc;

namespace Tutorial_02.Controllers
{
    public class ExampleController : Controller
    {
        //É uma ação HTTP GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] //Este é um atributo que especifica que o método de ação a
                   //seguir deve responder a solicitações HTTP POST

        public IActionResult Index(IFormCollection formData)
        {

            //Ação para processar dados submetidos no formulário
            ViewData["text_inserted"] = formData["nome"];//Transferir dados para a view
            ViewData["other_Text_inserted"] = formData["age"];//Transferir dados para a view

            return View("Index2");//Usa outra view em vez de usar o nome padrão da view
                                  //Normalmente tem o mesmo nome que o método - index
        }
    }
}
