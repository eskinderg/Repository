using Project.Services;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContentService _contentService;

        public HomeController(IContentService contentService )
        {
            _contentService = contentService;

        }

        public ActionResult Index()
        {
            return View("Index",_contentService.GetAllContents());
        }

	}
}