using MediatR;
using Backlog.Cli.Data;
using Backlog.Cli.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Cli.Commands.Blogs
{
    public class ListAuthorsCommandCommand
    {
        public class ListAuthorsCommandRequest : IRequest<ListAuthorsCommandResponse>
        {
            public ListAuthorsCommandRequest()
            {

            }
        }

        public class ListAuthorsCommandResponse
        {
            public ListAuthorsCommandResponse()
            {

            }
        }

        public class ListAuthorsCommandHandler : IAsyncRequestHandler<ListAuthorsCommandRequest, ListAuthorsCommandResponse>
        {
            public ListAuthorsCommandHandler(DataContext dataContext, ICache cache)
            {
                _dataContext = dataContext;
                _cache = cache;
            }

            public async Task<ListAuthorsCommandResponse> Handle(ListAuthorsCommandRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly DataContext _dataContext;
            private readonly ICache _cache;
        }

    }

}
