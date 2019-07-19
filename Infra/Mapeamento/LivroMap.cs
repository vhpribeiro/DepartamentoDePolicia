using Biblioteca.Dominio.Livros;

namespace Biblioteca.Infra.Mapeamento
{
    public class LivroMap : MapBase<Livro>
    {
        public LivroMap()
        {
            Map(l => l.Titulo).Not.Nullable();
            Map(l => l.AnoDeLancamento).Not.Nullable();
            Map(l => l.Categoria).Not.Nullable();
            Map(l => l.QuantidadeDisponivel).Not.Nullable();
            References(l => l.Autor).Not.Nullable().Cascade.None();
        }
    }
}