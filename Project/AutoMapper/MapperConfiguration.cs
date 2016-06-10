using AutoMapper;
using Project.Model.Models;
using Project.Model.ViewModels;

namespace Project.AutoMapper
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Content, ContentViewModel>();
            CreateMap<Folder, FolderViewModel>();
        }

        protected override void Configure()
        {
            throw new System.NotImplementedException();
        }
    }
}