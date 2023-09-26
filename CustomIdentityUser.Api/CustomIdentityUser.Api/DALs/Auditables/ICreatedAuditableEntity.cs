namespace CustomIdentityUser.Api.DALs.Auditables
{
    public interface ICreatedAuditableEntity
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
    }
}