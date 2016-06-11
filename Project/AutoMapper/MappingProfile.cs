using AutoMapper;
using Project.Model.Models;
using Project.Model.ViewModels;

namespace Project.AutoMapper
{
    public class MappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Content, ContentViewModel>();
            CreateMap<Folder, FolderViewModel>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}