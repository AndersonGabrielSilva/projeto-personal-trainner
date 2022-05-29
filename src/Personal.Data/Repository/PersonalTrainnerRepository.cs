using System;
using System.Collections.Generic;
using System.Linq;
using Personal.Domain.Respository;
using System.Threading.Tasks;
using Personal.Domain.Entities.Cadastros;
using System.Linq.Expressions;
using Personal.Data.Context;
using Personal.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace Personal.Data.Repository
{
    public class PersonalTrainnerRepository : Repository<PersonalTrainner>, IPersonalTrainnerRepository
    {
        public PersonalTrainnerRepository(PersonalDbContext personalDb, 
                                         IUser userLogado) : base(personalDb, userLogado)
        {
        }

        public async Task<IEnumerable<Aluno>> ObterAlunos(int skip = 0, int size = 25)
        {
            return await contexto.Alunos
                                 .Where(x => x.TenantId == _userLogado.GetTenentId())
                                 .Skip(skip)
                                 .Take(size)
                                 .ToListAsync();
        }
    }
}
