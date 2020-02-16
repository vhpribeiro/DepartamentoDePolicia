using Departamento.De.Policia.Dominio.Viaturas;

namespace Departamento.De.Policia.Infra.Mapeamento
{
    public class ViaturaMap : MapBase<Viatura>
    {
        public ViaturaMap()
        {
            Map(v => v.SireneEstaAtiva).Nullable();
            Map(v => v.Ano).Nullable();
            Map(v => v.QuantidadeDeGasolinaEmLitros).Nullable();
            Map(v => v.QuantidadeMaximaDoTanqueEmLitros).Nullable();
        }
    }
}