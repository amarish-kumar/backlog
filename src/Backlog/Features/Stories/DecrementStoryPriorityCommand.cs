using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.Stories
{
    public class DecrementStoryPriorityCommand
    {
        public class DecrementStoryPriorityRequest : IRequest<DecrementStoryPriorityResponse>
        {
            public DecrementStoryPriorityRequest()
            {

            }
        }

        public class DecrementStoryPriorityResponse
        {
            public DecrementStoryPriorityResponse()
            {

            }
        }

        public class DecrementStoryPriorityHandler : IAsyncRequestHandler<DecrementStoryPriorityRequest, DecrementStoryPriorityResponse>
        {
            public DecrementStoryPriorityHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<DecrementStoryPriorityResponse> Handle(DecrementStoryPriorityRequest request)
            {
				throw new System.NotImplementedException();
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
