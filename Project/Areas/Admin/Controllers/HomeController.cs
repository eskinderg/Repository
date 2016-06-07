using System.Linq;
using Project.Services;
using System.Web.Mvc;

namespace Project.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExpenseService _expenseService;
        private readonly IContentService _contentService;

        public HomeController(IContentService contentService, IExpenseService expenseService)
        {
            _contentService = contentService;
            _expenseService = expenseService;
        }

        public ActionResult Index()
        {
            return View(_contentService.GetAllContents());
        }


        public ActionResult Expired()
        {
            return View();
        }

        public ActionResult UnExpired()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return Content(_contentService.GetContent(id).Summary);
        }
	}
}