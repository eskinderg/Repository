using Project.Services;
using System.Web.Mvc;
using System.Web.UI;
using AutoMapper;
using Project.Model.ViewModels;

namespace Project.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ContentController(IContentService contentService, IMapper mapper)
        {
            _contentService = contentService;
            _mapper = mapper;
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
            var content = _mapper.Map<ContentViewModel>(_contentService.GetContent(id));
            return Content(content.Title);
        }
    }
}