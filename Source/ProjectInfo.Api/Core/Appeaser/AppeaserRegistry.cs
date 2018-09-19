using Appeaser;
using StructureMap;

namespace Veolia.Extranet.Api.Core.Appeaser
{
    public class AppeaserRegistry : Registry
    {
        public AppeaserRegistry()
        {
            For<IMediator>().Use<ApiMediator>();
            For<IMediatorSettings>().Use<MediatorSettings>();
            For<IMediatorHandlerFactory>().Use<MediatorHandlerFactory>();

            Scan(s =>
            {
                s.TheCallingAssembly();
                s.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                s.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                s.ConnectImplementationsToTypesClosing(typeof(ICommandHandler<,>));
                s.ConnectImplementationsToTypesClosing(typeof(IAsyncCommandHandler<,>));
            });
        }
    }
}

