using Departamento.De.Policia.Dominio.Policiais;

namespace Departamento.De.Policia.Infra.Mapeamento
{
    public class PolicialMap : MapBase<Policial>
    {
        public PolicialMap()
        {
            Map(p => p.NumeroDoDistintivo).Not.Nullable();
            Map(p => p.AnosNaAcademia).Nullable();
            Map(p => p.Idade).Nullable();
            Map(p => p.Experiencia).Nullable();
            Map(p => p.Nivel).Nullable();
            Map(p => p.Nome).Not.Nullable();
            References(p => p.Arma).Cascade.SaveUpdate();
            References(p => p.Viatura).Cascade.SaveUpdate();
        }
    }
}