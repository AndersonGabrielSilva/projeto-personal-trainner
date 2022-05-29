using Personal.Core.DomainObjects;
using System.Linq.Expressions;

namespace Personal.Core.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity, new()
    {
        Task AdicionarAsync(TEntity entity);
        Task<TEntity> ObterPorIdAsync(Guid id);

        /// <summary>
        /// Obtem registros por pagina
        /// </summary>
        /// <param name="skip">Pagina</param>
        /// <param name="take">Quantidade por pagina</param>
        /// <returns></returns>
        Task<List<TEntity>> ObterPorPaginaAsync(int skip = 0, int take = 25);
        Task AtualizarAsync(TEntity entity);
        Task RemoverAsync(Guid id, Guid usuarioID);
        Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChangesAsync();
    }
}
