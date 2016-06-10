using System.Web.Mvc;
using Project.Services;

namespace Project.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService =  categoryService;
        }

        public ActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
        }
    }
}