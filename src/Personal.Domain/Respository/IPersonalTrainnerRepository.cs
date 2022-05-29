using Personal.Core.Interfaces;
using Personal.Domain.Entities.Cadastros;

namespace Personal.Domain.Respository
{
    public interface IPersonalTrainnerRepository : IRepository<PersonalTrainner>
    {
        /// <summary>
        /// Obtem registros por pagina
        /// </summary>
        /// <param name="skip">Pagina</param>
        /// <param name="take">Quantidade por pagina</param>
        /// <returns></returns>
        Task<IEnumerable<Aluno>> ObterAlunos(int skip = 0, int size = 25);        
    }
}
