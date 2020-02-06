using DepartamentoDePolicia.Dominio.Armas;

namespace DepartamentoDePolicia.Testes._Helper.Builders
{
    public class ArmaBuilder
    {
        private static string _nome;
        private TiposDeArmas _tipo;
        private int _quantidadeDeBalasNoPente;
        private int _quantidadeDeBalasRestantesNoPente;

        public ArmaBuilder()
        {
            _nome = "P90";
            _tipo = TiposDeArmas.SMG;
            _quantidadeDeBalasNoPente = 100;
            _quantidadeDeBalasRestantesNoPente = 0;
        }

        public static ArmaBuilder UmNovaArma()
        {
            return new ArmaBuilder();
        }

        public ArmaBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public ArmaBuilder ComTipo(TiposDeArmas tipo)
        {
            _tipo = tipo;
            return this;
        }

        public ArmaBuilder ComQuantidadeDeBalasNoPente(int quantidadeDeBalasNoPonte)
        {
            _quantidadeDeBalasNoPente = quantidadeDeBalasNoPonte;
            return this;
        }

        public ArmaBuilder ComQuantidadeDeBalasRestantesNoPente(int quantidadeDeBalasRestantesNoPente)
        {
            _quantidadeDeBalasRestantesNoPente = quantidadeDeBalasRestantesNoPente;
            return this;
        }

        public Arma Criar()
        {
            var arma = new Arma(_nome, _tipo, _quantidadeDeBalasNoPente);

            if (_quantidadeDeBalasRestantesNoPente > 0)
                arma.RecarregarPente(_quantidadeDeBalasRestantesNoPente);

            return arma;
        }
    }
}