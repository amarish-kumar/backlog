using Backlog.Data.Helpers;
using Backlog.Data.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace Backlog.Data
{    
    public interface IBacklogContext
    {
        DbSet<AgileTeam> AgileTeams { get; set; }
        DbSet<AgileTeamMember> AgileTeamMembers { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<DigitalAsset> DigitalAssets { get; set; }
        DbSet<Epic> Epics { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Feedback> Feedbacks { get; set; }
        DbSet<HtmlContent> HtmlContents { get; set; }
        DbSet<Ip> Ips { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ReusableStoryGroup> ReusableStoryGroups { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Sprint> Sprints { get; set; }
        DbSet<Story> Stories { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Data.Model.Task> Tasks { get; set; }
        DbSet<Data.Model.TaskStatus> TaskStatuses { get; set; }
        DbSet<Template> Templates { get; set; }
        DbSet<Tenant> Tenants { get; set; }
        DbSet<Theme> Themes { get; set; }
        DbSet<UserSettings> UserSettings { get; set; }
        DbSet<User> Users { get; set; }
        Task<int> SaveChangesAsync();
    }

    public class BacklogContext: DbContext, IBacklogContext
    {
        public BacklogContext()
            : base(nameOrConnectionString: "BacklogContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public virtual DbSet<AgileTeam> AgileTeams { get; set; }
        public virtual DbSet<AgileTeamMember> AgileTeamMembers { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DigitalAsset> DigitalAssets { get; set; }        
        public virtual DbSet<Epic> Epics { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<HtmlContent> HtmlContents { get; set; }
        public virtual DbSet<Ip> Ips { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ReusableStoryGroup> ReusableStoryGroups { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Data.Model.Task> Tasks { get; set; }
        public virtual DbSet<Data.Model.TaskStatus> TaskStatuses { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        
        public override int SaveChanges()
        {
            UpdateLoggableEntries();
            return base.SaveChanges();
        }
        
        public override Task<int> SaveChangesAsync()
        {
            UpdateLoggableEntries();
            return base.SaveChangesAsync();
        }

        public void UpdateLoggableEntries()
        {
            foreach (var entity in ChangeTracker.Entries()
                .Where(e => e.Entity is ILoggable && ((e.State == EntityState.Added || (e.State == EntityState.Modified))))
                .Select(x => x.Entity as ILoggable))
            {
                entity.CreatedOn = entity.CreatedOn == default(DateTime) ? DateTime.UtcNow : entity.CreatedOn;
                entity.LastModifiedOn = DateTime.UtcNow;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().
                HasMany(u => u.Tags).
                WithMany(r => r.Articles).
                Map(
                    m =>
                    {
                        m.MapLeftKey("Article_Id");
                        m.MapRightKey("Tag_Id");
                        m.ToTable("ArticleTags");
                    });

            modelBuilder.Entity<Article>().
                HasMany(u => u.Categories).
                WithMany(r => r.Articles).
                Map(
                    m =>
                    {
                        m.MapLeftKey("Article_Id");
                        m.MapRightKey("Category_Id");
                        m.ToTable("ArticleCategories");
                    });

            modelBuilder.Entity<User>().
                HasMany(u => u.Roles).
                WithMany(r => r.Users).
                Map(
                    m =>
                    {
                        m.MapLeftKey("User_Id");
                        m.MapRightKey("Role_Id");
                        m.ToTable("UserRoles");
                    });

            var convention = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                "SoftDeleteColumnName",
                (type, attributes) => attributes.Single().ColumnName);

            modelBuilder.Conventions.Add(convention);
        } 
    }
}