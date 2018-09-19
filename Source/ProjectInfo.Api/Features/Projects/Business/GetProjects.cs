using System.Collections.Generic;
using Appeaser;
using Dapper;
using ProjectInfo.Api.Features.Projects.Entities;
using Veolia.Extranet.Api.Core.Database.Transaction;

namespace ProjectInfo.Api.Features.Projects.Business
{
    public class GetProjects
    {
        public class Query : IQuery<Result>
        {
            public Query() { }
        }

        public class Handler : IQueryHandler<Query, Result>
        {
            public readonly ITransactionSession _session;
            public Handler(ITransactionSession session)
            {
                _session = session;
            }

            public Result Handle(Query query)
            {
                return new Result { Projects = _session.Connection.Query<Project>("SELECT * FROM Project") };
            }
        }

        public class Result
        {
            public IEnumerable<Project> Projects { get; set; }
        }
    }
}
