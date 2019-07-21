using Biblioteca.Aplicacao.Autores;
using Biblioteca.Dominio.Autores;
using NHibernate;

namespace Biblioteca.Infra.AcessoADados.Repositorio
{
    public class AutorRepositorio : RepositorioBase<Autor>, IAutorRepositorio
    {
        public AutorRepositorio(ISession sessao) : base(sessao) { }
    }
}