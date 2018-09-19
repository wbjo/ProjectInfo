using StructureMap;
using Veolia.Extranet.Api.Core.Database;

namespace Veolia.Extranet.Api.Core.Appeaser
{
    public class ApiContainer : Container
    {
        public ApiContainer()
        {
            Configure(x => x.AddRegistry<AppeaserRegistry>());
            Configure(x => x.AddRegistry<DatabaseRegistry>());
        }
    }
}
