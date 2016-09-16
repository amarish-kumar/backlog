using Backlog.Models;

namespace Backlog.Data
{
    public interface IUow
    {
        IRepository<Epic> Epics { get; }
        IRepository<Story> Stories { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<Tag> Tags { get; }
        IRepository<Sprint> Sprints { get; }
        IRepository<AgileTeam> AgileTeams { get; }
        IRepository<Theme> Themes { get; }

        void SaveChanges();
    }
}