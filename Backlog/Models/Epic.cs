using System.Collections.Generic;

namespace Backlog.Models
{
    public class Epic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
        public int? Priority { get; set; }
        public ICollection<Story> Stories { get; set; } = new HashSet<Story>();
        public ICollection<EpicTheme> EpicThemes { get; set; } = new HashSet<EpicTheme>();
        public bool IsDeleted { get; set; }
    }
}