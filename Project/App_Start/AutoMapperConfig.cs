using Autofac;
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Project.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMappings(ContainerBuilder builder)
        {
            var profiles = from t in Assembly.GetExecutingAssembly().GetTypes()
                           where typeof(Profile).IsAssignableFrom(t)
                           select (Profile)Activator.CreateInstance(t);


            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();
            

        }
    }
}