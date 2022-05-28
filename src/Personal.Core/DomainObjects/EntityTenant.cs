using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Core.DomainObjects
{
    public abstract class EntityTenant : Entity
    {        
        protected EntityTenant()
        {

        }

        public EntityTenant(Guid tenancyId)
        {
            TenantId = tenancyId;
        }

        public Guid TenantId { get; set; }

        protected bool ValidaTenantEmpty()
        {
            if (Guid.Empty == TenantId)
                throw new DomainException($"É necessario informar o TenantId Trace:[{GetType().Name}]");

            return true;
        }
    }
}
