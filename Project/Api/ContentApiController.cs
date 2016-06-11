using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Project.Model;
using Project.Model.Models;
using Project.Model.ViewModels;
using Project.Attribute;
using Project.Services;

namespace Project.Api
{
    [RoutePrefix("Api")]
    public class ContentApiController : ApiController
    {
        private readonly IContentService _contentService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ContentApiController(IContentService contentService, 
                                    ICategoryService categoryService,
                                    IMapper mapper)
        {
            _contentService = contentService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("contents")]
        [CacheClient(Duration =20)]
        public IEnumerable<ContentViewModel> GetAllContents()
        {
            var cvm = _mapper.Map<IEnumerable<ContentViewModel>>(_contentService.GetAllContents());
            return cvm;
        }

        [HttpGet]
        [Route("content/{id}")]
        public ContentViewModel GetContent(int id)
        {
            return _mapper.Map<ContentViewModel>(_contentService.GetContent(id));
        }

        [HttpGet]
        [Route("getallcategories")]
        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryService.GetAllCategories();
        }

        [HttpPost]
        [Route("content/add")]
        public ContentViewModel Add(Content content)
        {
            return ModelState.IsValid ? _mapper.Map<ContentViewModel>(_contentService.AddContent(content)) : null;
        }
    }
}