using Biblioteca.Dominio.Autores;

namespace Biblioteca.Infra.Mapeamento
{
    public class AutorMap : MapBase<Autor>
    {
        public AutorMap()
        {
            Map(a => a.Nome).Not.Nullable();
            Map(a => a.QuantidadeDeLivrosVendidos).Not.Nullable();
        }
    }
}