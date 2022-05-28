using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Domain.Enum
{
    public enum TipoUsuario
    {
        /// <summary>
        /// Personal que contratou o serviço
        /// </summary>
        PersonalAssinante = 0,

        /// <summary>
        /// O Personal Contrantante pode contem sua equipe de personais,
        /// <para>Este personal pode ter sido contratado pelo personal contratante</para>
        /// </summary>
        Personal = 1,

        /// <summary>
        /// Aluno do personal
        /// </summary>
        AlunoDoPersonal = 2
    }
}
