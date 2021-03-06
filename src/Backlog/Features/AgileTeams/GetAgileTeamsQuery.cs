using MediatR;
using Backlog.Data;
using Backlog.Features.Core;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Features.AgileTeams
{
    public class GetAgileTeamsQuery
    {
        public class GetAgileTeamsRequest : IRequest<GetAgileTeamsResponse> { }

        public class GetAgileTeamsResponse
        {
            public ICollection<AgileTeamApiModel> AgileTeams { get; set; } = new HashSet<AgileTeamApiModel>();
        }

        public class GetAgileTeamsHandler : IAsyncRequestHandler<GetAgileTeamsRequest, GetAgileTeamsResponse>
        {
            public GetAgileTeamsHandler(IBacklogContext context, ICache cache)
            {
                _context = context;
                _cache = cache;
            }

            public async Task<GetAgileTeamsResponse> Handle(GetAgileTeamsRequest request)
            {
                var agileTeams = await _context.AgileTeams.ToListAsync();
                return new GetAgileTeamsResponse()
                {
                    AgileTeams = agileTeams.Select(x => AgileTeamApiModel.FromAgileTeam(x)).ToList()
                };
            }

            private readonly IBacklogContext _context;
            private readonly ICache _cache;
        }

    }

}
