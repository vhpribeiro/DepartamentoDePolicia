using Departamento.De.Policia.Dominio.Armas;
using NHibernate;

namespace Departamento.De.Policia.Infra.AcessoADados.Repositorio
{
    public class ArmaRepositorio : RepositorioBase<Arma>, IArmaRepositorio
    {
        public ArmaRepositorio(ISession sessao) : base(sessao)
        {
        }
    }
}