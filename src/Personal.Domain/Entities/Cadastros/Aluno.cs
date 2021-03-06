using Personal.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Domain.Entities.Cadastros
{
    public class Aluno : EntityTenant
    {


        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


        public ICollection<PersonalTrainner> PersonaisTrainers { get; set; }


        public override bool EhValido()
        {
            var result = this.ValidaTenantEmpty();

            return result;
        }


    }
}
