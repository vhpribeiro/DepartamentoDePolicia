using System;
using System.Linq.Expressions;

namespace Biblioteca.Dominio._Comum
{
    public interface ISpecification<TEntity> where TEntity : class
    {
        Expression<Func<TEntity, bool>> EhAtendidaPor();
    }
}