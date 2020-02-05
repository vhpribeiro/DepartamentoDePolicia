using System.Linq.Expressions;

namespace DepartamentoDePolicia.Dominio._Comum
{
    public class ViolacaoDeRegra
    {
        public LambdaExpression Propriedade { get; internal set; }
        public string Mensagem { get; internal set; }
    }
}