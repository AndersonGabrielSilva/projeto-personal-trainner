using Personal.Core.DomainObjects;
using Personal.Core.Interfaces;
using Personal.Domain.Entities.Cadastros;
using Personal.Domain.Enum;
using Personal.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Domain.Entities
{
    public class Usuario : EntityTenant, IAggregateRoot
    {
        // EF
        protected Usuario(){}

        public Usuario(TipoUsuario tipoUsuario, Guid pessoaId, Pessoa pessoa)
        {
            TipoUsuario = tipoUsuario;
            PessoaId = pessoaId;
            Pessoa = pessoa;
        }

        public TipoUsuario TipoUsuario { get; private set; }

        public Guid PessoaId { get; private set; }

        public Pessoa Pessoa { get; private set; }

        #region Comportamentos
        public void DefineOTenantID(Guid tenantId)
        {
            if (TipoUsuario != TipoUsuario.PersonalAssinante)
                TenantId = tenantId;
        }
        #endregion

        #region Validaçoes
        public override bool EhValido()
        {
            var result = ValidaTenantEmpty();

            return result;
        }

        public bool ValidaDadosPessoa()
        {
            var result = Pessoa?.EhValido() ?? false;
            if (!result)
                throw new DomainException("A entidade pessoa não pode ser nula.");

            return result;
        }
        #endregion

    }
}
