using System.Collections.Generic;
using Backlog.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backlog.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class BrandTemplate
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        [ForeignKey("Template")]
        public int? TemplateId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Template Template { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}
