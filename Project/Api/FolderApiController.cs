using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Project.Model.ViewModels;
using Project.Services;

namespace Project.Api
{
    [RoutePrefix("Api")]
    public class FolderApiController : ApiController
    {
        private readonly IFolderService _folderService;
        private readonly IMapper _mapper;

        public FolderApiController(IFolderService folderService, IMapper mapper)
        {
            _folderService = folderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("folders")]
        public IEnumerable<FolderViewModel> Folders()
        {
            IEnumerable<FolderViewModel> folders = _mapper.Map<IEnumerable<FolderViewModel>>(_folderService.GetAllFolders());
            
            return folders;
        }


    }
}
