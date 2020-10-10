using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace SiteContagem.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly Contador _CONTADOR = new Contador();

        public void OnGet([FromServices]ILogger<IndexModel> logger,
            [FromServices]IConfiguration configuration)
        {
            lock (_CONTADOR)
            {
                _CONTADOR.Incrementar();
                logger.LogInformation($"Contador - Valor atual: {_CONTADOR.ValorAtual}");

                TempData["Contador"] = _CONTADOR.ValorAtual;
                TempData["Local"] = _CONTADOR.Local;
                TempData["Kernel"] = _CONTADOR.Kernel;
                TempData["TargetFramework"] = _CONTADOR.TargetFramework;
            }
            
            TempData["MensagemFixa"] = "Teste";
            TempData["Saudacao"] = configuration["Saudacao"];
            TempData["UrlMinicursoKubernetes"] = configuration["UrlMinicursoKubernetes"];
            TempData["UrlMinicursoBDs"] = configuration["UrlMinicursoBDs"];
            TempData["UrlMinicursoDocker"] = configuration["UrlMinicursoDocker"];
            TempData["UrlMinicursoAzureDevOps"] = configuration["UrlMinicursoAzureDevOps"];
            TempData["UrlMinicursoInfra"] = configuration["UrlMinicursoInfra"];
            TempData["UrlBrindesMicrosoft"] = configuration["UrlBrindesMicrosoft"];
            TempData["UrlSorteio"] = configuration["UrlSorteio"];
            TempData["MensagemVariavel"] = configuration["MensagemVariavel"];
        }
    }
}