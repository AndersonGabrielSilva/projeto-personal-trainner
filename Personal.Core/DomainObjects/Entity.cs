using Personal.Core.Messages.MensagensComuns.Notifications;

namespace Personal.Core.DomainObjects
{
    public abstract class Entity
    {
        private List<DomainNotification> _notifications;

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }


        /// <summary>
        /// Para uma Entidade ser igual a outra não basta ela ser do mesmo tipo.
        /// <para>E uma boa pratica alterar o metodo Equals para validar tambem o ID da Entidade</para>
        /// <para>Uma entidade vai ser igual a outra se o tipo e o ID for o mesmo</para>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            //Valida o Id
            return Id.Equals(compareTo.Id);
        }

        /// <summary>
        /// Aplica a mesma regra do equals para o operador de ==
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        /*
         * O método GetHashCode() é um método de Object que é herdado por todos os objetos na linguagem C#.
           Este método basicamente serve como função de hash padrão.
           
           Um código hash é um valor numérico que é usado para inserir e identificar um objeto
           em uma coleção baseada em hash, como a classe Dictionary<Key,Value>, a classe
           HashTable ou um tipo derivado da classe DictionaryBase classe.

           Link: https://www.macoratti.net/20/11/c_ghashcd1.htm#:~:text=O%20m%C3%A9todo%20GetHashCode()%20%C3%A9,como%20fun%C3%A7%C3%A3o%20de%20hash%20padr%C3%A3o.
         */
        /// <summary>
        /// É uma boa pratica tambem alterar o HashCode, para caso em algum momento.
        /// <para>Um dos fatores utilizados para comprar duas classes é o HashCode</para>
        /// <para>É uma boa pratica alterar a geração do hashcode para garantir que NUNCA seja igual</para>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            //O Numero 907 é um numero completamente aleatorio
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public abstract bool EhValido();
    }
}
