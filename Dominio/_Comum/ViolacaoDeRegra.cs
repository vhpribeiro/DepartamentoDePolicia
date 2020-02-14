using System.Linq.Expressions;

namespace Departamento.De.Policia.Dominio._Comum
{
    public class ViolacaoDeRegra
    {
        public LambdaExpression Propriedade { get; internal set; }
        public string Mensagem { get; internal set; }
    }
}