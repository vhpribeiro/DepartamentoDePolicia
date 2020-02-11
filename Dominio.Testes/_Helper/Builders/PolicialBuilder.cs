using DepartamentoDePolicia.Dominio.Armas;
using DepartamentoDePolicia.Dominio.Policiais;

namespace DepartamentoDePolicia.Testes._Helper.Builders
{
    public class PolicialBuilder
    {
        private string _nome;
        private string _numeroDoDistintivo;
        private int _idade;
        private Arma _arma;
        private int _anosDeAcademia;

        public PolicialBuilder()
        {
            _nome = "Vitor H. P. Ribeiro";
            _numeroDoDistintivo = "10005469";
            _idade = 23;
            _arma = ArmaBuilder.UmNovaArma().Criar();
            _anosDeAcademia = 2;
        }

        public static PolicialBuilder UmNovoPolicial()
        {
            return new PolicialBuilder();;
        }

        public PolicialBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public PolicialBuilder ComNumeroDoDistintivo(string numeroDoDistintivo)
        {
            _numeroDoDistintivo = numeroDoDistintivo;
            return this;
        }

        public PolicialBuilder ComIdade(int idade)
        {
            _idade = idade;
            return this;
        }

        public PolicialBuilder ComAnosDeAcademia(int anosDeAcademia)
        {
            _anosDeAcademia = anosDeAcademia;
            return this;
        }

        public PolicialBuilder ComArma(Arma arma)
        {
            _arma = arma;
            return this;
        }

        public Policial Criar()
        {
            return new Policial(_nome, _numeroDoDistintivo, _idade, _anosDeAcademia, _arma);
        }
    }
}