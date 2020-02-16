using Departamento.De.Policia.Dominio._Comum;

namespace Departamento.De.Policia.Dominio.Viaturas
{
    public class Viatura : Entidade<Viatura>
    {
        public virtual int Ano { get; protected set; }
        public virtual int QuantidadeMaximaDoTanqueEmLitros { get; protected set; }
        public virtual int QuantidadeDeGasolinaEmLitros { get; protected set; }
        public virtual bool SireneEstaAtiva { get; protected set; }

        protected Viatura() { }

        public Viatura(int ano, int quantidadeMaximaDoTanqueEmLitros, int quantidadeDeGasolinaEmLitros)
        {
            Ano = ano;
            QuantidadeMaximaDoTanqueEmLitros = quantidadeMaximaDoTanqueEmLitros;
            QuantidadeDeGasolinaEmLitros = quantidadeDeGasolinaEmLitros;
            SireneEstaAtiva = false;
        }

        public virtual void EncherOTanque()
        {
            QuantidadeDeGasolinaEmLitros = QuantidadeMaximaDoTanqueEmLitros;
        }
    }
}