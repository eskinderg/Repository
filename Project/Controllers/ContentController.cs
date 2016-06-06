using System.Web.Http;
using Project.Services;
using System.Web.Mvc;
using System.Web.UI;
using Project.Extentions;


namespace Project.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [OutputCache(Duration = 3600, VaryByParam = "none", Location = OutputCacheLocation.ServerAndClient)]
        public ActionResult Index()
        {
            var contentList = _contentService.GetAllContents();
            return View(contentList);
        }

        public ActionResult DeleteExpired()
        {
            return Content("Reponse Completed Sucsussfully");
        }

        public ActionResult Content(int id)
        {
            var content = _contentService.GetContent(id).ToModel();
            return Content(content.Title);
        }
    }
}