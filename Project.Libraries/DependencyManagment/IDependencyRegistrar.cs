using Autofac;

namespace Project.Libraries.DependencyManagment
{

    public interface IDependencyRegistrar
    {
        
        void Register(ContainerBuilder builder);

        int Order { get; }

    }
}
