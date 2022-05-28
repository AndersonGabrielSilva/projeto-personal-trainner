using FluentValidation;
using Personal.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal.Domain.ValueObjects
{
    public class Nome : ValueObject
    {
        public string FirsName { get; private set; }
        public string LastName { get; private set; }

        public Nome(string firsName, string lastName)
        {
            if (string.IsNullOrEmpty(firsName))
                throw new DomainException("O nome não pode estar vazio");

            FirsName = firsName;
            LastName = lastName ?? string.Empty;
        }

        public override string ToString()
        {
            return $"{FirsName} {LastName}";
        }
    }
}
