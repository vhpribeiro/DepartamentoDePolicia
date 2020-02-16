using Departamento.De.Policia.Dominio.Armas;

namespace Departamento.De.Policia.Infra.Mapeamento
{
    public class ArmaMap : MapBase<Arma>
    {
        public ArmaMap()
        {
            Map(a => a.Nome).Not.Nullable();
            Map(a => a.Tipo).Not.Nullable();
            Map(a => a.QuantidadeDeBalasNoPente).Nullable();
            Map(a => a.QuantidadeDeBalasRestantesNoPente).Nullable();
        }
    }
}