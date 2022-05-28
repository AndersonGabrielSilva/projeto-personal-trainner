using Personal.Core.DomainObjects;
using Personal.Domain.ValueObjects;

namespace Personal.Domain.Entities
{
    public class Pessoa : EntityTenant
    {
        public Pessoa(Nome nome, string email, Documento documento, ICollection<Endereco> enderecos)
        {
            Nome = nome;
            Email = email;
            Documento = documento;
            Enderecos = enderecos;
        }


        public Nome Nome { get; private set; }

        public string Email { get; private set; }

        public Documento Documento { get; private set; }

        public ICollection<Endereco> Enderecos { get; private set; }


        public override bool EhValido()
        {            
            var result = this.ValidaTenantEmpty();

            return result;
        }
    }
}
