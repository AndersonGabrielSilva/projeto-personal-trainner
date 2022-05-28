using Personal.Core.DomainObjects;

namespace Personal.Domain.ValueObjects
{
    public class Documento : ValueObject
    {
        public Documento(string nroDocumento, TipoDocumento tipoDoc)
        {
            if (string.IsNullOrEmpty(NroDocumento))
            {
                var tpDoc = tipoDoc == TipoDocumento.Cpf ? "CPF" : "CNPJ";
                throw new DomainException($"Informe o numero do {tpDoc}");
            }

            NroDocumento = nroDocumento;
            TipoDoc = tipoDoc;
        }

        public string NroDocumento { get; private set; }

        public TipoDocumento TipoDoc { get; private set; }
    }

    public enum TipoDocumento
    {
        Cpf = 0,
        Cnpj = 1
    }
}
