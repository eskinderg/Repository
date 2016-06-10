using System.Web;
using Autofac;
using Project.Data;
using Project.Libraries.Fakes;

namespace Project.Libraries.DependencyManagment
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            //register FakeHttpContext when HttpContext is not available
            builder.Register(c => HttpContext.Current != null ? (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) : (new FakeHttpContext("~/") as HttpContextBase))
                                                                .As<HttpContextBase>()
                                                                .InstancePerLifetimeScope();
                                                                        builder.Register(c => c.Resolve<HttpContextBase>().Request)
                                                                            .As<HttpRequestBase>()
                                                                            .InstancePerLifetimeScope();
                                                                        builder.Register(c => c.Resolve<HttpContextBase>().Response)
                                                                            .As<HttpResponseBase>()
                                                                            .InstancePerLifetimeScope();
                                                                        builder.Register(c => c.Resolve<HttpContextBase>().Server)
                                                                            .As<HttpServerUtilityBase>()
                                                                            .InstancePerLifetimeScope();
                                                                        builder.Register(c => c.Resolve<HttpContextBase>().Session)
                                                                            .As<HttpSessionStateBase>()
                                                                            .InstancePerLifetimeScope();


            builder.RegisterType<ProjectDbContext>().As<IDbContext>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

        }

        public int Order
        {
            get { return 0; }
        }
    }
}
