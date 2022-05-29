using Microsoft.EntityFrameworkCore;
using Personal.Core.DomainObjects;
using Personal.Core.Interfaces;
using Personal.Data.Context;
using Personal.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly PersonalDbContext contexto;
        private readonly IUser _userLogado;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(PersonalDbContext personalDb,
                          IUser userLogado)
        {
            this.contexto = personalDb;
            this._userLogado = userLogado;
            this.DbSet = personalDb.Set<TEntity>();
        }

        public virtual async Task AdicionarAsync(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task AtualizarAsync(TEntity entity)
        {
            entity.RegistraAlteracao(_userLogado.GetUserId());
            DbSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
            => await DbSet.AsNoTracking().Where(predicate).ToListAsync(); 

        public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
            => await DbSet.FindAsync(id);

        public virtual async Task<List<TEntity>> ObterPorPaginaAsync(int skip = 0, int take = 25)
        {
            return await DbSet.AsNoTracking()
                              .Skip(skip)
                              .Take(take)
                              .ToListAsync();
        }

        public virtual async Task RemoverAsync(Guid id, Guid usuarioID = new Guid())
        {
            var entity = await ObterPorIdAsync(id);
            entity.Desativar(_userLogado.GetUserId());
            contexto.Entry(entity).State = EntityState.Modified;

            await SaveChangesAsync();
        }

        public virtual async Task<int> SaveChangesAsync() =>
            await contexto.SaveChangesAsync();

        public virtual void Dispose()
        {
            contexto?.Dispose();
        }
    }
}
