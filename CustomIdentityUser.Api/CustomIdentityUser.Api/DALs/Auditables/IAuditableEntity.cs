namespace CustomIdentityUser.Api.DALs.Auditables
{
    public interface IAuditableEntity : ICreatedAuditableEntity
    {
        DateTime ModifiedDate { get; set; }
        string ModifiedBy { get; set; }
    }
}
