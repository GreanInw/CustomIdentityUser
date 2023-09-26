using CustomIdentityUser.Api.DALs.Auditables;
using Microsoft.AspNetCore.Identity;

namespace CustomIdentityUser.Api.DALs.Tables
{
    public class Role : IdentityRole<Guid>, IAuditableEntity
    {
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
