using System;
using SistemaFacturacion.Domain.Entities;


namespace SistemaFacturacion.Domain.Contracts
{
    public abstract class AuditableEntity : GenericEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
