using Microsoft.AspNetCore.Antiforgery;
using AccountingV03.Controllers;

namespace AccountingV03.Web.Host.Controllers
{
    public class AntiForgeryController : AccountingV03ControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
