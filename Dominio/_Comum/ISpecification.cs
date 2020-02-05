using System;
using System.Linq.Expressions;

namespace DepartamentoDePolicia.Dominio._Comum
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> EhAtendidaPor();
    }
}