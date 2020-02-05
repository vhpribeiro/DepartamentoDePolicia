using System;
using System.Linq.Expressions;

namespace DepartamentoDePolicia.Dominio._Comum
{
    public abstract class Specification<T> : ISpecification<T> where T : class
    {
        public abstract Expression<Func<T, bool>> EhAtendidaPor();

        public Specification<T> E(Specification<T> specification)
        {
            return new ESpecification<T>(this, specification);
        }

        public Specification<T> Ou(Specification<T> specification)
        {
            return new OuSpecification<T>(this, specification);
        }
    }
}