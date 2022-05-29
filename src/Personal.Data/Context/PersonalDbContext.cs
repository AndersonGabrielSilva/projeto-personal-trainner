using Microsoft.EntityFrameworkCore;
using Personal.Domain.Entities;
using Personal.Domain.Entities.Cadastros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Data.Context
{
    public class PersonalDbContext :DbContext
    {
        public PersonalDbContext(DbContextOptions<DbContext> options):base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get;set; }
        public DbSet<Pessoa> Pessoas { get;set; }
        public DbSet<Endereco> Enderecos { get;set; }
        public DbSet<PersonalTrainner> PersonalTrainners { get;set; }
        public DbSet<Aluno> Alunos { get;set; }


        #region Override - SaveChanges
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.UtcNow;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;                    
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.UtcNow;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;                   
                }
            }

            return base.SaveChanges();
        }
        #endregion
    }
}
