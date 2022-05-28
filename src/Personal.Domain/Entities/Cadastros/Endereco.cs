using Personal.Core.DomainObjects;
using Personal.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Domain.Entities.Cadastros
{
    public class Endereco : Entity
    {
        // EF
        protected Endereco()
        {

        }

        public Endereco(Guid pessoaId, 
                        string logadouro, 
                        string numero, 
                        string bairro, 
                        string cidade, 
                        string uf, 
                        string pais, 
                        string cep) : this()
        {
            PessoaId = pessoaId;
            Logadouro = logadouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Pais = pais;
            Cep = cep;

            TipoEndereco = TipoEndereco.Residencial;
        }
        
        public string Logadouro { get; private set; }
        public string Numero { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public string Pais { get; private set; }
        public string Cep { get; private set; }
        public TipoEndereco TipoEndereco { get; private set; }


        public Guid PessoaId { get; private set; }
        // EF
        public Pessoa Pessoa { get; private set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
