using System;
using System.Linq;
using System.Linq.Expressions;
using DepartamentoDePolicia.Dominio._Comum;

namespace Departamento.De.Policia.Dominio._Comum
{
    public class ESpecification<T> : Specification<T> where T : class
    {
        private readonly Specification<T> _direita;
        private readonly Specification<T> _esquerda;

        public ESpecification(Specification<T> esquerda, Specification<T> direita)
        {
            _direita = direita;
            _esquerda = esquerda;
        }

        public override Expression<Func<T, bool>> EhAtendidaPor()
        {
            Expression<Func<T, bool>> expressaoEsquerda = _esquerda.EhAtendidaPor();
            Expression<Func<T, bool>> expressaoDireita = _direita.EhAtendidaPor();

            BinaryExpression expressaoE = Expression.AndAlso(
                expressaoEsquerda.Body, expressaoDireita.Body);

            return Expression.Lambda<Func<T, bool>>(
                expressaoE, expressaoEsquerda.Parameters.Single());
        }
    }
}