using Departamento.De.Policia.Dominio.DepartamentosDePolicias;

namespace Departamento.De.Policia.Infra.Mapeamento
{
    public class DepartamentoDePoliciaisMap : MapBase<DepartamentoDePoliciais>
    {
        public DepartamentoDePoliciaisMap()
        {
            Map(dp => dp.AnoDeCriacao).Nullable();
            Map(dp => dp.NumeroDeRegistro).Not.Nullable();
            HasMany(dp => dp.Policiais).Cascade.AllDeleteOrphan();
            HasMany(dp => dp.Viaturas).Cascade.AllDeleteOrphan();
        }
    }
}