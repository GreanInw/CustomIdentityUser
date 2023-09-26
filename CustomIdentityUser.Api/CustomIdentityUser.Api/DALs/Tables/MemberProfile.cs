using CustomIdentityUser.Api.DALs.Auditables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomIdentityUser.Api.DALs.Tables
{
    public class MemberProfile : IAuditableEntity
    {
        [Key]
        public Guid MemberId { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }

        [ForeignKey(nameof(MemberId))]
        public virtual Member Member { get; set; }

        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}