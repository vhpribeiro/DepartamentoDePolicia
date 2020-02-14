using Departamento.De.Policia.Dominio._Comum;

namespace Departamento.De.Policia.Dominio.Viaturas
{
    public class Viatura : Entidade<Viatura>
    {
        public int Ano { get; protected set; }
        public int QuantidadeMaximaDoTanqueEmLitros { get; protected set; }
        public int QuantidadeDeGasolinaEmLitros { get; protected set; }
        public bool SireneEstaAtiva { get; protected set; }

        public Viatura(int ano, int quantidadeMaximaDoTanqueEmLitros, int quantidadeDeGasolinaEmLitros)
        {
            Ano = ano;
            QuantidadeMaximaDoTanqueEmLitros = quantidadeMaximaDoTanqueEmLitros;
            QuantidadeDeGasolinaEmLitros = quantidadeDeGasolinaEmLitros;
            SireneEstaAtiva = false;
        }

        public void EncherOTanque()
        {
            QuantidadeDeGasolinaEmLitros = QuantidadeMaximaDoTanqueEmLitros;
        }
    }
}