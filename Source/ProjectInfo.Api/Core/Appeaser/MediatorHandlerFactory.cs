using System;
using Appeaser;
using StructureMap;


namespace Veolia.Extranet.Api.Core.Appeaser
{
    public class MediatorHandlerFactory : IMediatorHandlerFactory
    {
        private readonly IContainer _container;

        public MediatorHandlerFactory(IContainer container)
        {
            _container = container;
        }

        public object GetHandler(Type handlerType)
        {
            return _container.TryGetInstance(handlerType);
        }
    }
}
