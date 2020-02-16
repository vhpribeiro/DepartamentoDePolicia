using Departamento.De.Policia.Dominio.Policiais;
using NHibernate;

namespace Departamento.De.Policia.Infra.AcessoADados.Repositorio
{
    public class PolicialRepositorio : RepositorioBase<Policial>, IPolicialRepositorio
    {
        public PolicialRepositorio(ISession sessao) : base(sessao)
        {
        }
    }
}