using AutoMapper;
using Project.Model.Models;
using Project.Model.ViewModels;

namespace Project.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Content, ContentViewModel>();
                cfg.CreateMap<Folder, FolderViewModel>();
            });
        }
    }
}