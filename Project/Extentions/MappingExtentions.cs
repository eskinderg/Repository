using AutoMapper;
using Project.Model.Models;
using Project.Model.ViewModels;

namespace Project.Extentions
{
    public static class MappingExtensions
    {
        private static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        private static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return Mapper.Map(source, destination);
        }

#region Folder

        public static FolderViewModel ToModel(this Folder entity)
        {
            return entity.MapTo<Folder, FolderViewModel>();
        }

        public static Folder ToEntity(this FolderViewModel model)
        {
            return model.MapTo<FolderViewModel, Folder>();
        }

        public static Folder ToEntity(this FolderViewModel model, Folder destination)
        {
            return model.MapTo(destination);
        }

#endregion


#region Content

        public static ContentViewModel ToModel(this Content entity)
        {
            return entity.MapTo<Content, ContentViewModel>();
        }

        public static Content ToEntity(this ContentViewModel model)
        {
            return model.MapTo<ContentViewModel, Content>();
        }

        public static Content ToEntity(this ContentViewModel model, Content destination)
        {
            return model.MapTo(destination);
        }

#endregion

    }
}