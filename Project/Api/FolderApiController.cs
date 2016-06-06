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

        public FolderApiController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpGet]
        [Route("folders")]
        public IEnumerable<FolderViewModel> Folders()
        {
            IEnumerable<FolderViewModel> folders = Mapper.Map<IEnumerable<FolderViewModel>>(_folderService.GetAllFolders());
            
            return folders;
        }


    }
}
